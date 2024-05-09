using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Button : MonoBehaviour
{
    public bool level1Complete = false;
    public bool level2Complete = false;
    public GameObject completeLevels;

    public void LoadLevel3Scene()
    {
       if (level1Complete == true && level2Complete == true) 
        {
            GameManager.LoadScene("Level3");
        
        }

       if (level1Complete == false || level2Complete == false) 
        { 
         completeLevels.SetActive(true);
        
        }


    }

}
