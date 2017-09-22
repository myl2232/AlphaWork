using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameFramework.Event;

namespace AlphaWork
{
    class UpClickEventArgs : GameEventArgs
    {
        public override int Id
        {
            get
            {
                return (int)EventId.UpClickEvent;
            }
        }
    }
}
