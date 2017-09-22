﻿using GameFramework.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlphaWork
{
    class UIHomeEventArgs : GameEventArgs
    {
        public override int Id
        {
            get
            {
                return (int)EventId.HomeStateEvent;
            }
        }
    }
}
