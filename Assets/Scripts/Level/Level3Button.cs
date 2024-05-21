using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Button : MonoBehaviour
{
    //variables
    public bool level1Complete = false;
    public bool level2Complete = false;
    public GameObject completeLevels;

    public void LoadLevel3Scene()
    {
        //IF level 1 and level 2 are complete
       if (level1Complete == true && level2Complete == true) 
        {
            //load the scene
            GameManager.LoadScene("Level3");
        
        }
        //if either are false
        else if (level1Complete == false || level2Complete == false) 
        { 
         //set the UI to true
         completeLevels.SetActive(true);
        
        }


    }

}
