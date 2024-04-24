using CapstoneFps_RC;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace TowerDefense
{
    public class Health : MonoBehaviour
    {
        //Sets the health amount
        [SerializeField] public int currentHealth = 10;
        //Initializes a new UnityEvents
        public UnityEvent OnZeroHealth = new UnityEvent();
        //Initilizes 2 variables
        public GameObject parentPrefab;
        //Makes the object with this script "Take damage", Has 1 parameter
        public void TakeDamage(int damageAmount)
        {
            //Makes the current health equal to it minus the amount of damage taken
            currentHealth -= damageAmount;
            ValueDisplay.OnValueChanged.Invoke(gameObject.name + "Health", currentHealth);


            //IF current health is less than or equal to zero
            if (currentHealth <= 0)
            {
                //destroys the gameObject that the script is attached to
                Destroy(gameObject);
                //Destroys the parent prefab
                Destroy(parentPrefab);

             
                //Invokes the UnityEvent
                OnZeroHealth.Invoke();
            }
        }

        //Trys to damage the object, has 2 parameters
        public static void TryDamage(GameObject target, int damageAmount)
        {
            //checks if the script has the health component
            Health health = target.GetComponent<Health>();

            //IF it does
            if (health)
            {

                //Takes a random amount of damage between 5 and 10
                health.TakeDamage(damageAmount); 
            }
        }

      
    }
}