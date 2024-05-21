using UnityEngine;
using UnityEngine.UI;

namespace CapstoneFps_RC
{
    public class Pause : MonoBehaviour
    {
        //variables and references
        public GameObject pauseMenuUI;
        public Shooting shooting;
    
        void Update()
        {
            //IF the player hits the escape key
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //Sets the timescale to 0 (frozen)
                Time.timeScale = 0;
                //Sets the pauseMenu UI to active
                pauseMenuUI.SetActive(true);
                //Does not allow you to shoot
                shooting.enabled = false;
                //Unlocks the cursor
                Cursor.lockState = CursorLockMode.None;
            }



        }

        //Unpauses the game
        public void Unpause()
        {
            //sets the time scale to 1 (normal)
            Time.timeScale = 1f;
            //Sets the PauseMenu UI to inactive
            pauseMenuUI.SetActive(false);
            //shooting is enabled again
            shooting.enabled = true;
            //cursor is locked
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}