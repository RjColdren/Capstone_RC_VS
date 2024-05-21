using UnityEngine;
using CapstoneFps_RC;

public class Currency : MonoBehaviour
{
    //Variables
    public int currentCurrency;
    public GameObject noCurrency;
    public GameObject fullCurrency;
    private void Update()
    {
        //if currency is greater than 99999
        if (currentCurrency > 99999)
        {
            //set currency to 99999
            currentCurrency = 99999;
            //change on valueDisplay
            ValueDisplay.OnValueChanged.Invoke("PlayerCurrency", "$" + currentCurrency);
        }

        //if currentCurrency is 99999
        if (currentCurrency == 99999)
        {
            //fullcurrency is active
            fullCurrency.SetActive(true);
        }
        else
        {
            //full currency is inactive
            fullCurrency.SetActive(false);
        }


    }
    //adds currency 
    public void AddCurrency(int addAmount)
    {
      
        //if the current currency is greaterThan or equal to 99999
        if (currentCurrency >= 99999)
        {
            //your wallet is full
            print("Your wallet is full");
        }
        else
        {
            //add the amount to current currency
            currentCurrency += addAmount;
            //change the value display
            ValueDisplay.OnValueChanged.Invoke("PlayerCurrency", "$" + currentCurrency);
        }
    }

    //remove currency
    public void RemoveCurrency(int removeAmount) 
    { 
        //if current currency is less than remove amount
        if (currentCurrency < removeAmount)
        {
            //not enough currency
            noCurrency.SetActive(true);
            Invoke("DisableUI", 1);

        }
        //if current currency is greater than or equal to the remove amount
        if (currentCurrency >= removeAmount)
        {
            //subtract the remove amount
            currentCurrency -= removeAmount;
            ValueDisplay.OnValueChanged.Invoke("PlayerCurrency", "$" + currentCurrency);
        }
        
    }
    //disables the UI
    public void DisableUI()
    {
        noCurrency.SetActive(false);
    }
}
