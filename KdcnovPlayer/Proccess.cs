﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audio;
using System.Windows.Forms;
using DataProvider;
using System.IO;
using Video;
using System.Threading;
using PlaylistLib;

namespace kdcnovAutoWinForms
{

    /// <summary>
    /// Основной процесс
    /// </summary>
    public static class Proccess
    {
        #region CONSTANTS
        public const int STOP = 0;
        public const int PLAY_MAIN_TRACK = 1;
        public const int PLAY_BG_TRACK = 2;
        public const int TRACK_STOPPED = 255;
        #endregion

        public static IPlayer player { get; set; }
        private static IPlayer tempPlayer { get; set; }

        /// <summary>
        /// Свойство "текущий трек"
        /// </summary>
        internal static Track currentTrack { get; set; }

        /// <summary>
        /// Свойство "текущий ключ трека в плейлисте"
        /// </summary>
        internal static int currentKey { get; set; }
        internal static string ip;
        internal static int port;
        internal static Track bgMain { get; set; }
        internal static Playlist mainPlayList;
        internal static BgPlaylist bgPlaylist { get; set; }
        internal static int playerBgVolume { get; set; }


        static Random rnd = new Random();

        public static event statusHandler status;

        static Proccess()
        {
            // UNDONE: При переключении плеера во время воспроизведения - косяк

            bgMain = new Track(true);
            Init();
        }

        /// <summary>
        /// Инициализация устройств
        /// </summary>
        internal static void Init()
        {
            /// MIDI Выход
            int midiDevice = 0;
            midiDevice = SettingsReader<int>.Read("midiDeviceNo");
            try
            {
                NAudioMidi.Init(midiDevice);
            }
            catch
            {
                MessageBox.Show("MIDI устройство сохранённое в настройках не найдено");
                NAudioMidi.Init(0);
            }

            playerBgVolume = SettingsReader<int>.Read("bgVolume");


            /// Инициализация OSC протокола
            ip = SettingsReader<string>.Read("oscIP");
            port = SettingsReader<int>.Read("oscPORT");
            ip = ip ?? "127.0.0.1";
            port = (port != 0) ? port : 7000;

            OSC.init(ip, port);

            /// Инициализация плеера
            string setPlayer = SettingsReader<string>.Read("defaultPlayer");
            if (player == null || player.name != setPlayer)
            {
                if (setPlayer != null)
                {
                    switch (SettingsReader<string>.Read("defaultPlayer"))
                    {
                        case "naudio":
                            player = new NAudioPlayer();
                            break;
                        case "aimp":
                            player = new AIMPPlayer();
                            break;
                    }
                }
                else
                {
                    player = new AIMPPlayer();
                }
            }

            // TODO Временное решение!!!!!!
            string value = SettingsReader<string>.Read("bgPlaylistFolder");
            if (value != null)
                bgPlaylist = new BgPlaylist(value);


        }

        /// <summary>
        /// Играем фоновый трек
        /// Выбирает случайную команду OSC и MIDI ноту из списка.
        /// </summary>
        internal static void BgPlay()
        {
            if (bgPlaylist.tracks == null || bgPlaylist.tracks.Count < 1)
            {
                MessageBox.Show("Для воспроизведения случайного фонового трека, выберите папку с аудиофайлами в настройках, вкладка \"ФОНОВЫЙ ПЛЕЙЛИСТ\"", "НЕ НАЙДЕН ФОНОВЫЙ ПЛЕЙЛИСТ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Random rnd = new Random();
            int r = rnd.Next(bgPlaylist.tracks.Count);
            // TODO random
            int rndMidi = (bgPlaylist.midiNotes.Count > 0) ? rnd.Next(bgPlaylist.midiNotes.Count - 1) : 0;
            int rndOsc = (bgPlaylist.oscTracks.Count > 0) ? rnd.Next(bgPlaylist.oscTracks.Count) : 0;

            Thread.Sleep(50);
            Play(new Track()
            {
                audioFilePath = (string)bgPlaylist.tracks[r],
                bg = true,
                isMidiNote = true,
                midiNote = (rndMidi == 0) ? 0 : bgPlaylist.midiNotes[rndMidi],
                oscCommand = (rndOsc == 0) ? 0 : bgPlaylist.oscTracks[rndOsc],
                next = nextTrack.bgRandom
            }, currentKey);
        }

        /// <summary>
        /// Основной метод play
        /// </summary>
        /// <param name="track"></param>
        /// <param name="key"></param>
        internal static void Play(Track track, int key)
        {
            if (tempPlayer != null)
                tempPlayer = null;

            // Инициализация плеера. 
            player.Init(() => getNext());

            // "Защита от дурака". Не даёт случайно выключить основной трек.
            if (player.GetState() == 1 && currentTrack.bg == false)
            {
                MessageBox.Show("Сейчас играет трек " + currentTrack.name + ". Чтобы его остановить нажмите \"СТОП\" ", "ВНИМАНИЕ!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                currentTrack = track;
                currentKey = key;


                midiSend();
                player.Play(track.audioFilePath);

              //  Diagnostic.start();
                if (currentTrack.bg)
                {
                    status(PLAY_BG_TRACK, currentTrack.audioFilePath);
                    player.volume = playerBgVolume;
                }
                else
                {
                    status(PLAY_MAIN_TRACK, currentTrack.name);
                    player.volume = 100;
                }
               // Diagnostic.stop();
            }

            oscSend();
        }

        internal static void Stop()
        {
            if (tempPlayer != null)
            {
                tempPlayer.Stop();
                tempPlayer = null;
            }

            player.Stop();
            NAudioMidi.Stop();
            status(STOP);
        }

        internal static void Pause()
        {

        }
       

        /// <summary>
        /// Передаём OSC комманду.
        /// </summary>
        private static void oscSend()
        {
           OSC.onTrack(currentTrack.oscCommand);
        }

        private static void midiSend()
        {
            if (currentTrack.isMidiNote == false && currentTrack.midiFile != null)
            {
                NAudioMidi.PlayFile(currentTrack.midiFile);
                return;
            }

            NAudioMidi.Send(currentTrack.midiNote);
            //NAudioMidi.playFile(@"D:\00000\ttt.midi");            
        }

        private static void getNext()
        {
            NAudioMidi.Stop();

            if (currentTrack.isPlaylistTrack)
            {
                currentKey++;
                status(TRACK_STOPPED);
            }
            switch (currentTrack.next)
            {
                case nextTrack.bgRandom:
                    BgPlay();
                    break;
                case nextTrack.next:
                    if (currentKey >= mainPlayList.tracks.Count)
                    {
                        MessageBox.Show("Данный трек последний в плейлисте, поэтому воспроизвести следующий трек невозможно.", "ПОСЛЕДНИЙ ТРЕК В ПЛЕЙЛИСТЕ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Stop();
                        break;
                    }
                    else
                        Play(mainPlayList.tracks[currentKey], currentKey);                    
                    break;
                case nextTrack.bgConcrete:
                    if (bgMain != null)
                        Play(bgMain, currentKey);
                    else
                        BgPlay();
                    break;
                case nextTrack.cycle:
                    Play(currentTrack, currentKey);
                    break;
                case nextTrack.pause:
                    Stop();
                    break;                              
                default:
                    Stop();
                    break;
            }            
        }

    }
}
