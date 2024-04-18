using System.Collections;
using System.Collections.Generic;
using TowerDefense;
using UnityEngine.UI;
using UnityEngine;
using CapstoneFps_RC;

public class PlayerObjectInteraction : MonoBehaviour
{
    //instance of this script
  public static PlayerObjectInteraction instance;

    //Instance of the health script
    Health health;
    Shooting shooting;

    private void Awake()
    {
        //makes the instance equal to this
        instance = this;

    }

    private void Start()
    {
        //finds the health component in the gameObject
        health = GetComponent<Health>();
        shooting = GetComponentInChildren<Shooting>();
    }

    //Increases the health when called
    public void IncreaseHealth(int value)
    {
        //Adds whatever value is to the current health.
        health.currentHealth += value;
        ValueDisplay.OnValueChanged.Invoke(gameObject.name + "Health", health.currentHealth);
    }

    public void AddAmmo(int value)
    {
        shooting.fullAmmo += value;
        ValueDisplay.OnValueChanged.Invoke("fullAmmo", shooting.fullAmmo);
    }
}
