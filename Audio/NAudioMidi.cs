using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Midi;
using NAudio.CoreAudioApi;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;


namespace Audio
{
    public static class NAudioMidi
    {
        static MidiOut midiOut;

        static Dictionary<long, List<int>> notes = new Dictionary<long, List<int>>();

        static Timer mmTimer;

        public static void Init(int device)
        {

            if (midiOut != null)
                midiOut.Dispose();
            midiOut = new MidiOut(device);
        }
        

        public static void Send(int note)
        {
            try
            {
                midiOut.Send(MidiMessage.StartNote(note, 127, 1).RawData);
                midiOut.Reset();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "NAudio MIDI");
            }
            finally
            {
               // midiOut.Close();
            }
        }

        public static Dictionary<int, string> GetDevices()
        {
            Dictionary<int, string> devices = new Dictionary<int, string>();
            for (int device = 0; device < MidiOut.NumberOfDevices; device++)
            {
                devices.Add(device, MidiOut.DeviceInfo(device).ProductName);
            }
            return devices;
        }

        public static void PlayFile(string filename)
        {
            readMidiFile(new MidiFile(filename));

            System.ComponentModel.IContainer components = new System.ComponentModel.Container();
            mmTimer = new Timer(components);

            long msec = 0;

            mmTimer.Mode = TimerMode.Periodic;
            mmTimer.Period = 1;
            mmTimer.Resolution = 1;
            //    mmTimer.SynchronizingObject = this;

            if (notes.ContainsKey(0))
            {
                foreach (int note in notes[0])
                    Send(note);
            }

            mmTimer.Start();

            mmTimer.Tick += new System.EventHandler((e, s) =>
            {
                msec++;
                if (notes.ContainsKey(msec))
                {
                    foreach (int note in notes[msec])
                        Send(note);
                }
            });
        }

        public static void Stop()
        {
            if (mmTimer != null)
                mmTimer.Stop();
        }

        private static void readMidiFile(MidiFile file)
        {

            List<TempoEvent> tempo = new List<TempoEvent>();
            notes.Clear();
            long d = 0;
            List<int> notesList = new List<int>();
            for (int i = 0; i < file.Events.Count(); i++)
            {

                foreach (MidiEvent note in file.Events[i])
                {
                    TempoEvent tempoE;

                    try { tempoE = (TempoEvent)note; tempo.Add(tempoE); }
                    catch { }


                    if (note.CommandCode == MidiCommandCode.NoteOn)
                    {
                       
                        var t_note = (NoteOnEvent)note;            

                        var noteOffEvent = t_note.OffEvent;

                        long thisTimeNote = (t_note.AbsoluteTime / file.DeltaTicksPerQuarterNote) * tempo[tempo.Count() - 1].MicrosecondsPerQuarterNote / 1000;
                       //long thisTimeNoteOff = (noteOffEvent.AbsoluteTime / file.DeltaTicksPerQuarterNote) * tempo[tempo.Count() - 1].MicrosecondsPerQuarterNote / 1000;

                        if (thisTimeNote == d)
                        {
                            notesList.Add(t_note.NoteNumber);
                            d = thisTimeNote;
                            notes[d] = notesList;
                           // notes[thisTimeNoteOff + 1] = new List<int> { noteOffEvent.NoteNumber };
                        }
                        else
                        {
                            d = thisTimeNote;
                            notesList = new List<int>
                            {
                                t_note.NoteNumber
                            };
                            notes.Add(d, notesList);
                        }                
                    }
                }
            }
        }
    }
}
