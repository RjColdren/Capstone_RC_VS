using UnityEngine;
using Unity.UI;
using CapstoneFps_RC;

public class Currency : MonoBehaviour
{
    public int currentCurrency;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCurrency(int addAmount)
    {
        currentCurrency += addAmount;
        ValueDisplay.OnValueChanged.Invoke("PlayerCurrency", currentCurrency);
    }

    public void RemoveCurrency(int removeAmount) 
    { 
        currentCurrency -= removeAmount;
        ValueDisplay.OnValueChanged.Invoke("PlayerCurrency", "$" + currentCurrency);

    }
}
