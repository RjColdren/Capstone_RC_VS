using UnityEngine;
using CapstoneFps_RC;

public class Currency : MonoBehaviour
{
    public int currentCurrency;
    public GameObject noCurrency;
    public GameObject fullCurrency;
    private void Update()
    {
        if (currentCurrency > 999)
        {
            currentCurrency = 999;
            ValueDisplay.OnValueChanged.Invoke("PlayerCurrency", "$" + currentCurrency);
        }

        if (currentCurrency == 999)
        {
            fullCurrency.SetActive(true);
        }
        else
        {
            fullCurrency.SetActive(false);
        }


    }

    public void AddCurrency(int addAmount)
    {
      
        if (currentCurrency >= 999)
        {
            print("Your wallet is full");
        }
        else
        {
            currentCurrency += addAmount;
            ValueDisplay.OnValueChanged.Invoke("PlayerCurrency", "$" + currentCurrency);
        }
    }

    public void RemoveCurrency(int removeAmount) 
    { 
        if (currentCurrency < removeAmount)
        {
            noCurrency.SetActive(true);
            Invoke("DisableUI", 1);

        }
        if (currentCurrency >= removeAmount)
        {
            currentCurrency -= removeAmount;
            ValueDisplay.OnValueChanged.Invoke("PlayerCurrency", "$" + currentCurrency);
        }
        
    }

    public void DisableUI()
    {
        noCurrency.SetActive(false);
    }
}
