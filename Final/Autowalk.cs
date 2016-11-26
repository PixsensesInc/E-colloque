
using System;
using UnityEngine;

namespace VRStandardAssets.Utils
{

    public class Autowalk : MonoBehaviour
    {

        public float speed = 6.0f;


        public bool teleport;

        private SF_Spaceship Cockpit Transform;
        private Transform MainCamera;

        [SerializeField]
        private VRInput m_InteractiveItem;


        private void Awake()
        {


            controller = GetComponent<CharacterController>();
            MainCamera = Camera.main.transform;


        }








        private void OnEnable()
        {

            m_InteractiveItem.OnCancel += moveUp;
          
        }

        private void OnDisable()
        {

            m_InteractiveItem.OnCancel -= moveUp;
           
        }
        void moveUp()
        {
            teleport = !teleport;
            //Vector3 up = MainCamera.TransformDirection (Vector3.up);
            //controller.SimpleMove (up * speed);



        }

  

        void Update()
        {
            if (teleport == true)
            {
                Vector3 forward = MainCamera.TransformDirection(Vector3.forward);
                controller.SimpleMove(forward * speed);

            }

        }


    }


}
