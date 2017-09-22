using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AlphaWork
{
    public class MoveTarget : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetTarget(Vector3 goal)
        {
            NavMeshAgent ag = GetComponent<NavMeshAgent>();
            ag.destination = goal;
        }
    }
}

