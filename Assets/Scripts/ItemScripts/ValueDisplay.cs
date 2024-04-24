using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CapstoneFps_RC
{
    // Require text component!
    [RequireComponent(typeof(Text))]
    public class ValueDisplay : MonoBehaviour
    {
        //Forms a UnityEvent
        public static UnityEvent<string, object> OnValueChanged = new UnityEvent<string, object>();
        [SerializeField] private string valueName = ""; // Name of value for this script
        public Text displayText; // UI component to display value

        void Awake()
        {
            //Gets the component for the text
            displayText = GetComponent<Text>();
            //Adds a listener for when it is called
            OnValueChanged.AddListener(ValueChanged);
        }

        //Changes the value on the UI
        void ValueChanged(string valueName, object value)
        {
            //if the valueName is equal to this value name
            if (valueName == this.valueName)
            {
                //Change the display text to the new display text.
                displayText.text = value.ToString();
            }
        }
    }
}
