using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class LevelMove : MonoBehaviour
{
    //Forms a UnityEvent
    public UnityEvent doEvent = new UnityEvent();

    public void OnTriggerEnter(Collider other)
    {
        //If the colliding gameObject is tagged with player
        if(other.gameObject.tag == "Player")
        {
            //invoke the event
            doEvent.Invoke();
        }
    }
}
