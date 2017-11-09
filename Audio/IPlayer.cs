using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audio
{
    public delegate void PlayerStateHandler();

    public interface IPlayer
    {
        bool run { get; set; }

        PlayerStateHandler handler { get; set; }

        string name { get; set; }

        bool beDestroyed { get; set; }

        int volume { get; set; }

        void Init(PlayerStateHandler handler);

        void Play(string filename);

        void Stop();

        void Pause();

        int GetState();
    }
}
