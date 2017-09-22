using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using GameFramework.Event;

namespace AlphaWork
{
    class GameToLoginEventArgs : GameEventArgs
    {
        public override int Id
        {
            get
            {
                return (int)EventId.GameToLoginEvent;
            }
        }

    }
}
