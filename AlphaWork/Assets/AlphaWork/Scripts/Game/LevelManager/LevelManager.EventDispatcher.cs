using GameFramework.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace AlphaWork
{
    public partial class LevelManager
    {
        public void OnGameToLogin(object sender, GameEventArgs e)
        {
            ClearStructures();
        }

        public void OnGameStart(object sender, GameEventArgs e)
        {
            GetDefaultTerrain();
            LoadGameObjects();
            //BuildBlocks();
                        
        }

        public void OnUIOccupy(object sender, GameEventArgs e)
        {
            Vector3 mainPos = new Vector3();
            GameBase.GetMainPos(out mainPos);

            int h = (int)mainPos.x / m_blockSize;
            int w = (int)mainPos.z / m_blockSize;

            int Id = m_blocks[w][h];
            
            BlockInfo info = new BlockInfo();
            info.EntityId = Id;
            m_blocks[w][h] = Id;

            UnityGameFramework.Runtime.Entity block = GameEntry.Entity.GetEntity(Id);
            if (!block)
                return;

            Structure structEnt = block.Logic as Structure;
            structEnt.Occupyed = !structEnt.Occupyed;
            GameObject gb = block.Handle as GameObject;
            if (gb)
            {
                //string texStr = structEnt.GetReplaceTex();
                GameEntry.Resource.LoadAsset(structEnt.GetReplaceTex(),
                    m_loadForOccupyCallbacks, block);
            }
        }

        public void OnAIGo(object sender, GameEventArgs e)
        {
            
        }

        public void OnUpClick(object sender, GameEventArgs e)
        {
            CrossPlatformInputManager.SetAxis("Vertical", 0.1f);
        }
        public void OnDownClick(object sender, GameEventArgs e)
        {
            CrossPlatformInputManager.SetAxis("Vertical", -0.1f);
        }
        public void OnLeftClick(object sender, GameEventArgs e)
        {
            CrossPlatformInputManager.SetAxis("Horizontal", -0.1f);
        }
        public void OnRightClick(object sender, GameEventArgs e)
        {
            CrossPlatformInputManager.SetAxis("Horizontal", 0.1f);
        }
    }
}
