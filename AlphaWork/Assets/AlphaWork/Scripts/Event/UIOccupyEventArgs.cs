using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameFramework.Event;

namespace AlphaWork
{
    class UIOccupyEventArgs : GameEventArgs
    {
        //private int m_entityId;
        public override int Id
        {
            get
            {
                return (int)EventId.UIOccupyEvent;
            }
        }
        //public int EntityId
        //{
        //    get
        //    { return m_entityId; }
        //    set
        //    { m_entityId = value; }
        //}
    }
}
