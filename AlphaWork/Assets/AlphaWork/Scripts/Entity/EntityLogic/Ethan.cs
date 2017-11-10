using GameFramework.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace AlphaWork
{
    public class Ethan : EntityObject
	{
        private float m_lastShrinkTime;
        private Transform m_localTransform;
        private Vector3 m_rootPos;
        private Vector3 m_variantPos;
        private bool m_bShrink = false;

        // Use this for initialization
        void Start()
		{
            GameEntry.Event.Subscribe(UIOccupyEventArgs.EventId, OnShrink);          
        }

		// Update is called once per frame
		void Update()
		{         
             Detect();
        }

        private void FixedUpdate()
        {
          
        }

        void Detect()
        {
            float curTime = Time.realtimeSinceStartup;
            if(curTime - m_lastShrinkTime > 0.1)         
            {
                m_lastShrinkTime = curTime;
                GameObject gb = GameEntry.Entity.GetEntity(Id).Handle as GameObject;
                Animator animator = gb.GetComponent<Animator>();
                animator.rootPosition = m_rootPos;
                m_bShrink = false;
            }
        }
        
        void OnShrink(object sender, GameEventArgs arg)
        {
            m_lastShrinkTime = Time.realtimeSinceStartup;
            
            GameObject gb = GameEntry.Entity.GetEntity(Id).Handle as GameObject;
            m_localTransform = gb.transform;
            CapsuleCollider collider = gb.GetComponent<CapsuleCollider>();
            Debug.LogWarning("<<MainTransformPos>>:" + gb.transform.position.x + "," + gb.transform.position.y
                + "," + gb.transform.position.z);
            Debug.LogWarning("<<~~collider~~>>:"+ collider.transform.position.x + "," + collider.transform.position.y
                + "," + collider.transform.position.z);

            Animator animator = gb.GetComponent<Animator>();
            m_rootPos = animator.rootPosition;
//             Debug.LogWarning("<<MainRootPos>>:" + animator.rootPosition.x + "," + animator.rootPosition.y 
//                 + "," + gb.transform.position.z);
            m_variantPos = animator.rootPosition + new Vector3(Random.Range(-0.5f, 0.5f), 0, Random.Range(-0.5f, 0.5f));
            m_bShrink = true;
        }

        private void OnAnimatorIK(int layerIndex)
        {
            if(m_bShrink)
            {
                GameObject gb = GameEntry.Entity.GetEntity(Id).Handle as GameObject;
                Animator animator = gb.GetComponent<Animator>();
                animator.rootPosition = m_variantPos;
                Debug.LogWarning("<<----------Pos---------->>:" + gb.transform.position.x + "," + gb.transform.position.y
    + "," + gb.transform.position.z);
            }

        }
    }
}

