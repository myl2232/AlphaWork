using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameFramework.Event;

namespace AlphaWork
{
    class LeftClickEventArgs : GameEventArgs
    {
        public override int Id
        {
            get
            {
                return (int)EventId.LeftClickEvent;
            }
        }
    }
}
