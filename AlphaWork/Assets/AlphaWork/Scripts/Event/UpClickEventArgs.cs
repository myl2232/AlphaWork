using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameFramework.Event;

namespace AlphaWork
{
    class UpClickEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(UpClickEventArgs).GetHashCode();
        public override int Id
        {
            get
            {
                return EventId;
            }
        }
    }
}
