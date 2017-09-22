using GameFramework.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
//using HomeSystemSpace;

namespace AlphaWork
{
    public partial class LevelManager
    {
        public LevelManager()
        {
            RegisterCustomEvents();
            InitCallbacks();
            
        }

        protected void RegisterCustomEvents()
        {
            GameEntry.Event.Subscribe(EventId.GameToLoginEvent, OnGameToLogin);
            GameEntry.Event.Subscribe(EventId.GameEventStart, OnGameStart);
            GameEntry.Event.Subscribe(EventId.UIOccupyEvent, OnUIOccupy);
            GameEntry.Event.Subscribe(EventId.AIGoEvent,OnAIGo);

            GameEntry.Event.Subscribe(EventId.UpClickEvent, OnUpClick);
            GameEntry.Event.Subscribe(EventId.DownClickEvent, OnDownClick);
            GameEntry.Event.Subscribe(EventId.LeftClickEvent, OnLeftClick);
            GameEntry.Event.Subscribe(EventId.RightClickEvent, OnRightClick);
        }
        protected void InitCallbacks()
        {
            m_loadForOccupyCallbacks = new GameFramework.Resource.LoadAssetCallbacks(
                LoadResourceForOccupySuccessCallback);
            m_StructureCallbacks = new StructureBehaviourCallback(OnOccupy, OnUnOccupy);
        }
 
    }
}
