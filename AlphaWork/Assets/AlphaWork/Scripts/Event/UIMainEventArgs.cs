﻿using GameFramework.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlphaWork
{
    class UIMainEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(UIMainEventArgs).GetHashCode();
        public override int Id
        {
            get
            {
                return EventId;
            }
        }
    }

}
