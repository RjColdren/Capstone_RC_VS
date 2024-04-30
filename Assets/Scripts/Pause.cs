using UnityEngine;
using UnityEngine.UI;

namespace CapstoneFps_RC
{
    public class Pause : MonoBehaviour
    {
        public GameObject pauseMenuUI;
        public Shooting shooting;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                pauseMenuUI.SetActive(true);
                shooting.enabled = false;
                Cursor.lockState = CursorLockMode.None;
            }



        }


        public void Unpause()
        {
            Time.timeScale = 1f;
            pauseMenuUI.SetActive(false);
            shooting.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}