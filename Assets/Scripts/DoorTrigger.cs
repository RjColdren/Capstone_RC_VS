using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace CapstoneFps_RC
{
    public class DoorTrigger : MonoBehaviour
    {
        public GameObject spawner;


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                spawner.SetActive(true);
            }

        }
    }
}

