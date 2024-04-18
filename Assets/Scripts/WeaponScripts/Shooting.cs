using UnityEngine;
using UnityEngine.UI;

namespace CapstoneFps_RC
{
    public class Shooting : MonoBehaviour
    {
        //Variables
        //creates a fire rate
        public float fireRate;
        
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

        // Update is called once per frame
        void Update()
        {
            //IF the magazine size is greater than 0, reloading is false
            // and fire rate is 0, do this
            if (magSize > 0 && reloading == false && fireRate == 0)
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

                    ValueDisplay.OnValueChanged.Invoke("MagAmmo", magSize + "/");
                }
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
                reloadUI.SetActive(true);

                //IF the R key is pressed
                if (Input.GetKeyDown(KeyCode.R))
                {
                    //calls reload
                    Reload();
                }
            }

            if (magSize <= 0 && stillAmmo == false)
            {
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
                stillAmmo = true;
            
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

            reloadUI.SetActive(false);
        }
    }
}

//update documentation