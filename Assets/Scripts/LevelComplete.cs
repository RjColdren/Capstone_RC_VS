using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CapstoneFps_RC
{
    public class LevelComplete : MonoBehaviour
    {
        public bool level1Complete = false;
        public bool level2Complete = false;

        public void level1Completed ()
        {
            level1Complete = true;
        }

        public void level2Completed()
        {
            level2Complete = true;
        }
    }
}