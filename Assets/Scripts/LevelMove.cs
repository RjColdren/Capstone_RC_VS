using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class LevelMove : MonoBehaviour
{
    public UnityEvent doEvent = new UnityEvent();

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            doEvent.Invoke();
        }
    }
}
