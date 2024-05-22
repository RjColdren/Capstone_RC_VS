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
        public GameObject healthFull;
        //Audio for the health script
        public AudioSource source;
        public AudioClip hurtSound;
        public int playerMoney;
        public Currency currency;

        private void Start()
        {
            currency = FindAnyObjectByType<Currency>();
        }

        private void Update()
        {
            //ensures you cannot go above 100 health
            if (currentHealth > 100)
            {
                currentHealth = 100;
                ValueDisplay.OnValueChanged.Invoke(gameObject.name + "Health", currentHealth);
            }
            //makes it so when you hit 100 health, it tells you you are full
            if (currentHealth == 100)
            {
                healthFull.SetActive(true);
            }
            //turns off health full to ensure the player doesn't get a mistaken full health value.
            else 
            {
                healthFull.SetActive(false);
            }
        }





        public void TakeDamage(int damageAmount)
        {
            //Makes the current health equal to it minus the amount of damage taken
            currentHealth -= damageAmount;
            ValueDisplay.OnValueChanged.Invoke(gameObject.name + "Health", currentHealth);

            source.PlayOneShot(hurtSound);


            //IF current health is less than or equal to zero
            if (currentHealth <= 0)
            {
                //destroys the gameObject that the script is attached to
                Destroy(gameObject);
                //Destroys the parent prefab
                Destroy(parentPrefab);

                currency.AddCurrency(playerMoney);
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