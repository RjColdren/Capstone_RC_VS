using TowerDefense;
using UnityEngine;
using CapstoneFps_RC;

public class PlayerObjectInteraction : MonoBehaviour
{
    //instance of this script
  public static PlayerObjectInteraction instance;

    //Instance of the health script
    Health health;
    //instance of the shooting script
    Shooting shooting;
    //instance of the currency script
    Currency currency;

    private void Awake()
    {
        //makes the instance equal to this
        instance = this;

    }

    private void Start()
    {
        //finds the health component in the gameObject
        health = GetComponent<Health>();
        //finds the shooting component in the gameobjects child
        shooting = GetComponentInChildren<Shooting>();
        //finds the Currency script in the scene
        currency = FindAnyObjectByType<Currency>();
    }

    //Increases the health when called
    public void IncreaseHealth(int value)
    {
        //Adds whatever value is to the current health.
        health.currentHealth += value;
        //Changes the display on the UI
        ValueDisplay.OnValueChanged.Invoke(gameObject.name + "Health", health.currentHealth);
    }
    //adds ammo hwen called
    public void AddAmmo(int value)
    {
        //adds the full ammo and the new value/increased value
        shooting.fullAmmo += value;
        //changes the display on the UI
        ValueDisplay.OnValueChanged.Invoke("fullAmmo", shooting.fullAmmo);
    }
    //increases the players cash when called
    public void IncreaseCash(int value)
    {
        //adds the currency
        currency.currentCurrency += value;
        ValueDisplay.OnValueChanged.Invoke("PlayerCurrency", "$" + currency.currentCurrency);
    }
}
