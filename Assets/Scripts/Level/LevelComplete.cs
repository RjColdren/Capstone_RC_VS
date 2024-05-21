using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CapstoneFps_RC
{
    public class LevelComplete : MonoBehaviour
    {
        //bools
        public bool level1Complete = false;
        public bool level2Complete = false;

        //sets level1 to completed
        public void level1Completed ()
        {
            level1Complete = true;
        }
        //sets level 2 to completed.
        public void level2Completed()
        {
            level2Complete = true;
        }
    }
}