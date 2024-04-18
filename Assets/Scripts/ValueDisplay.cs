using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CapstoneFps_RC
{
    // Require text component!
    [RequireComponent(typeof(Text))]
    public class ValueDisplay : MonoBehaviour
    {
        public static UnityEvent<string, object> OnValueChanged = new UnityEvent<string, object>();
        [SerializeField] private string valueName = ""; // Name of value for this script
        public Text displayText; // UI component to display value

        void Awake()
        {
            displayText = GetComponent<Text>();
            OnValueChanged.AddListener(ValueChanged);
        }

        void ValueChanged(string valueName, object value)
        {
            if (valueName == this.valueName)
            {
                displayText.text = value.ToString();
            }
        }
    }
}
