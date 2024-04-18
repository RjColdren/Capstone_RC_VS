using UnityEngine;
using UnityEngine.SceneManagement;


    public class GameManager : MonoBehaviour
    {
        //References the GameManager.
        public static GameManager instance;

        private void Awake()
        {
            //if instance is true 
            if (instance)
            {
                //destroys this
                Destroy(this);
            }

            //ELSE
            else
            {
                //sets instance to this
                instance = this;
                //makes sure that it doesn't destroy this when loaded
                DontDestroyOnLoad(this);
            }
        }

        //Loads a scene with 1 parameter, the name of the scene
        public static void LoadScene(string sceneName)
        {
            //Loads whatever scene sceneName is.
            SceneManager.LoadScene(sceneName);
        }

        //Quits out of the application when called
        public static void Quit()
        {
            //Quits out of the application
            Application.Quit();
        }
    }