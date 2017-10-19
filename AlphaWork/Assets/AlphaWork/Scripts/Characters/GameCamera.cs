using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using HomeSystemSpace;

namespace AlphaWork
{
    public class GameCamera : MonoBehaviour
    {
        /// <summary>
        /// player的Transform
        /// </summary>
        public Transform player;


        private bool canRotate = false;
        private Vector3 lookOffset;
        private float nextDragTime = 0;
        private float cameraScaleSpeed = 10.0f;
        void Awake()
        {
            /*lookOffset = transform.position - player.position;*/
        }
        void Start()
        {
            InstallGestureRecognizers();
        }
        void InstallGestureRecognizers()
        {
            List<GestureRecognizer> recogniers = new List<GestureRecognizer>(GetComponents<GestureRecognizer>());
            DragRecognizer drag = recogniers.Find(r => r.EventMessageName == "OnDrag") as DragRecognizer;
            //DragRecognizer twoFingerDrag = recogniers.Find(r => r.EventMessageName == "OnTwoFingerDrag") as DragRecognizer;
            PinchRecognizer pinch = recogniers.Find(r => r.EventMessageName == "OnPinch") as PinchRecognizer;

            if (!drag)
            {
                drag = gameObject.AddComponent<DragRecognizer>();
                drag.RequiredFingerCount = 1;
                drag.IsExclusive = true;
                drag.MaxSimultaneousGestures = 1;
                drag.SendMessageToSelection = GestureRecognizer.SelectionType.None;
            }

            if (!pinch)
                pinch = gameObject.AddComponent<PinchRecognizer>();

            //if (!twoFingerDrag)
            //{
            //    twoFingerDrag = gameObject.AddComponent<DragRecognizer>();
            //    twoFingerDrag.RequiredFingerCount = 2;
            //    twoFingerDrag.IsExclusive = true;
            //    twoFingerDrag.MaxSimultaneousGestures = 1;
            //    twoFingerDrag.ApplySameDirectionConstraint = true;
            //    twoFingerDrag.EventMessageName = "OnTwoFingerDrag";
            //}


        }

        void GetLookOffset()
        {
            GameObject mainPlayer = ObjectUtility.GetMainPlayer() as GameObject;
            if (mainPlayer)
            {
                player = mainPlayer.transform;
                lookOffset = transform.position - player.position;
            }
        }

        void OnDrag(DragGesture gesture)
        {
            if (!HomeSystem.Instance.AllowFingerInput())
                return;
            if (PlayerController.Instance != null && PlayerController.Instance.IsControl)
                return;

            if (Time.time < nextDragTime)
                return;
            Vector3 lookAtPos = player.transform.position;

            GetLookOffset();

            if (gesture.Phase == ContinuousGesturePhase.Started)
            {
                lookOffset = transform.position - lookAtPos;
                canRotate = true;
            }
            else if (gesture.Phase == ContinuousGesturePhase.Updated)
            {
                if (!canRotate)
                    return;
                lookOffset = Quaternion.AngleAxis(10f * Time.deltaTime * gesture.DeltaMove.x, Vector3.up) * lookOffset;
                lookOffset = Quaternion.AngleAxis(-5.0f * Time.deltaTime * gesture.DeltaMove.y, transform.right) * lookOffset;
                transform.position = lookAtPos + lookOffset;
                transform.LookAt(lookAtPos);
                lookOffset = transform.position - lookAtPos;

            }
            else if (gesture.Phase == ContinuousGesturePhase.Ended)
            {
                canRotate = false;
            }

        }
        void OnPinch(PinchGesture gesture)
        {
            if (!HomeSystem.Instance.AllowFingerInput())
                return;
            if (PlayerController.Instance != null && PlayerController.Instance.IsControl)
                return;
            GetLookOffset();
            nextDragTime = Time.time + 0.25f;
            Vector3 lookAtPos = player.transform.position;
            Vector3 tmp = transform.position + transform.forward * gesture.Delta * cameraScaleSpeed * Time.deltaTime;
            transform.position = tmp;
            lookOffset = transform.position - lookAtPos;
        }

        void Update()
        {
            GameObject mainPlayer = ObjectUtility.GetMainPlayer() as GameObject;
            if (mainPlayer)
            {
                player = mainPlayer.transform;
                transform.position = player.position + lookOffset;
            }
                
        }
    }
}
