using UnityEngine;

namespace CapstoneFps_RC
{
    public class DoorTrigger : MonoBehaviour
    {
        //variables
        public GameObject spawner;


        private void OnTriggerEnter(Collider other)
        {
            //if the colliding gameobject is tagged with player
            if (other.gameObject.tag == "Player")
            {
                //set it to active
                spawner.SetActive(true);
            }

        }
    }
}

