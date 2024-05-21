using TowerDefense;
using Unity.VisualScripting;
using UnityEngine;

//Scrapped, may be useful later.
namespace CapstoneFps_RC
{
    public class Bullet : MonoBehaviour
    {

        //Variables, Scripts and GameObjects.
        public Rigidbody rigidbody;
        public Health health;
        public int damage = 5;
        public GameObject bullet;
        public GameObject gun;
        public GameObject bulletHole;
        public int bulletVelocity = 15;
        public float timeDestroy;
        public string tag;
        RaycastHit hit;
        public int range = 500;
 
        void Start()
        {
            //Finds the Rigidbody component in the GameObject
            rigidbody = GetComponent<Rigidbody>();

            //Creates a Vector3 in a forward direction
            Vector3 forceDirection = transform.forward;

            //adds force in a forward direction when GameObject is created
            rigidbody.AddForce(forceDirection * bulletVelocity, ForceMode.VelocityChange);

            //destroys the bullet if it doesn't hit anything in 4 seconds
            Invoke("BulletDestroy", 4f);

        }

        //When this gameObject collides with something
        private void OnCollisionEnter(Collision other)
        {
           // if (Physics.Raycast(bullet.transform.position, bullet.transform.forward, out hit, range))
          //  {
                //IF the other GameObjects tag is equal to tag
                if (other.gameObject.tag == tag)
                {
                    //Gets the health script from the other object and tries to damage it
                    Health.TryDamage(other.gameObject, damage);

                    //destroys the gameObject
                    Destroy(bullet);
                }

                // *IMPLEMENT LATER*
                //IF it hits a building, spawn a bullet hole at the location that it hit.
                /* if (other.gameObject.tag == "Building")
                 {
                     Instantiate(bulletHole, gameObject.position, Quaternion.identity);
                 }
                */


           // }
        }
        private void BulletDestroy()
        {
            Destroy(bullet);
        }
    }
}
        