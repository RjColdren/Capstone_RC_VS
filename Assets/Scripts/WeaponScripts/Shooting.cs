using TowerDefense;
using UnityEngine;
using UnityEngine.UI;

namespace CapstoneFps_RC
{
    public class Shooting : MonoBehaviour
    {
      
        //Variables for aiming
        public float fireRate;
        public int damage;
        public float range;
        public bool aiming = false;
        public Camera fpsCam;
        Health health;
        public Animator animator;
        public GameObject crosshair;
        
        //Variables for hipfire
        public GameObject bullet;
        public Transform barrel;
        public bool stillAmmo;
        public bool reloading;
        public float timeToReload = 3f;
        public int magSize;
        public int fullAmmo;
        public int reloadSize;
        public GameObject reloadUI;
        public GameObject noAmmoUI;


        private void Awake()
        {
            //Gets the animator component from the game object
            animator = GetComponent<Animator>();
        }
        // Update is called once per frame
        void Update()
        {
            //IF the magazine size is greater than 0, reloading is false
            // and fire rate is 0, do this
            if (magSize > 0 && reloading == false && fireRate == 0)
            {
                //IF not aiming
                if (!aiming)
                {
                    //if right click is pressed down
                    if (Input.GetMouseButtonDown(0))
                    {
                        //calls fire
                        Fire();
                        //the mag size is decremented one
                        magSize--;
                        //the fire rate is set to half a second
                        fireRate = .5f;
                        //Changes the UI to display the current mag size
                        ValueDisplay.OnValueChanged.Invoke("MagAmmo", magSize + "/");
                    }
                }

                //IF aiming
                if (aiming)
                {
                    //IF the player presses left click
                    if (Input.GetMouseButtonDown(0))
                    {
                        //call the shoot function
                        Shoot();
                        //mag size is decremented
                        magSize--;
                        //fireRate is set to .7
                        fireRate = .7f;
                        //Changes the UI to display the current mag size
                        ValueDisplay.OnValueChanged.Invoke("MagAmmo", magSize + "/");
                    }
                }

            }
            
            //Sets "Aiming" in the animator to the value of aiming in the code
            animator.SetBool("Aiming", aiming);

            //IF rmb is held
            if (Input.GetMouseButton(1))
            {
                //set aiming to true 
                aiming = true;
                //set crosshair to inactive
                crosshair.SetActive(false);

            }

            //IF RMB is released
            if (Input.GetMouseButtonUp(1))
            {
                //set aiming to false
                aiming = false;
                //set the crosshair back to active
                crosshair.SetActive(true);
            }

            //IF the fireRate is above 0
            if(fireRate > 0)
            {
                //fire rate is subtracted by and becomes equal to it minus
                //real time
                fireRate -= Time.deltaTime;
            }

            //if fire rate is less than 0
            if (fireRate < 0)
            {
                //sets the fire rate to 0
                fireRate = 0;
            }

            //IF the magazine size is less than or equal to zero and there is
            //still ammo
            if (magSize <= 0 && stillAmmo == true)
            {
                //sets that you need to reload to true
                reloadUI.SetActive(true);
              
                //IF the R key is pressed
                if (Input.GetKeyDown(KeyCode.R))
                {
                    //calls reload
                    Reload();
                }
            }

            //if the mag size is less than or equal to zero AND still ammo is false:
            if (magSize <= 0 && stillAmmo == false)
            {
                //Set the UI that you have no ammo to true
                noAmmoUI.SetActive(true);
            }

            //IF full ammo is less than or equal to 0
            if (fullAmmo <= 0)
            {
                //sets that there is still ammo to false
                stillAmmo = false;
            }
            else 
            {
                //sets that there is still ammo to true
                stillAmmo = true;
            
            }
            //if still ammo is true
            if(stillAmmo == true)
            {
                //set that there is no ammo to false
                noAmmoUI.SetActive(false);
            }
            
        }

        //reloads the gun
         public void Reload()
        {
            //sets reloading to true
            reloading = true;
            //invokes that the reload is finished after the time to reload
            Invoke("ReloadFinished", timeToReload);

        }

        //actually fires the weapon
        public void Fire()
        {
            //instantiates the bullet at the position and rotation of the barrel
            Instantiate(bullet, barrel.position, barrel.rotation);
            
        }

        //When the timer for reload is finished, do this:
        private void ReloadFinished()
        {
            //Adds the reload size into the mag
                magSize += reloadSize;
            //subtracts the reload size from the full ammo
                fullAmmo -= reloadSize;
            ValueDisplay.OnValueChanged.Invoke("fullAmmo", fullAmmo);
            //sets reloading to false
            reloading = false;

            //Sets the reloadingUI to inactive
            reloadUI.SetActive(false);
            //changes the value of MagAmmo to magsize
            ValueDisplay.OnValueChanged.Invoke("MagAmmo", magSize + "/");
        }

        //When the player shoots while aiming
        public void Shoot()
        {
            //create a raycast hit
            RaycastHit hit;

            //if there is a raycast
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                //check the name of the object it hit
                Debug.Log(hit.transform.name);
                //if the collider that was hit is tagged with "Enemy"
                if (hit.collider.tag == "Enemy")
                {
                    //get that objects health script
                    health = hit.collider.GetComponent<Health>();
                    //cause the enemy to take damage
                    health.TakeDamage(damage);
                }
            }
        }
    }
}
