using TowerDefense;
using UnityEngine;
using UnityEngine.AI;

namespace CapstoneFps_RC
{

    //Adds an AI Enemy that can move around and attack the player when the player is near the enemy: Created by Dave / GameDevelopment on Youtube - Link: https://www.youtube.com/watch?v=UjkSFoLxesw
    public class EnemyAI : MonoBehaviour
    {
        //Variables, NavMeshAgent, Transforms, GameObject, Vectors and Layermasks
        public bool attackedAlready;
        public bool inSight;
        public float fireRate;
        public float sightRange, attackRange;
        public bool playerInSightRange, playerInAttackRange;
        public NavMeshAgent agent;
        public Transform player;
        public GameObject bullet;
        public Transform barrel;
        public int bulletSpeed;
        public LayerMask whatIsGround, whatIsPlayer;
        public int bulletRange = 500;
        Health health;
        public int damage = 2;

        public Vector3 walkPoint;
        bool walkPointSet;
        public float walkPointRange;
        public GameObject fireParticle;
        public AudioSource source;
        public AudioClip fireSound;
        private void Awake()
        {
            //Finds the Players Transform
            player = GameObject.Find("Player").transform;
            //Finds the NavMeshAgent
            agent = GetComponent<NavMeshAgent>();

        }
    

        // Update is called once per frame
        void Update()
        {
            //Checks if the player is in sight range and/or attack range
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

            //IF player is not in either
            if (!playerInSightRange && !playerInAttackRange)
            {
                //calls Random Patrol
                RandomPatrol();
            }

            //IF Player is in Sight Range but is not in attack range
            if (playerInSightRange && !playerInAttackRange)
            {
                //Calls follow player
                followPlayer();
            }

            //IF player is in sight range and player is in attack range
            if (playerInSightRange && playerInAttackRange)
            {
                //calls attack
                Attack();
            }
        }

        //Randomly moves the enemy around in a "Patrol Route"
        private void RandomPatrol()
        {
            //IF there is no WalkPointSet, call search walk point
            if (!walkPointSet) SearchWalkPoint();

            //IF walk point is set
            if (walkPointSet)
            {
                //moves the agent to Walk Point
                agent.SetDestination(walkPoint);

            }

            //Forms a vector3 that finds the distance between the enemy and the walk point
            Vector3 distanceToWalkPoint = transform.position - walkPoint;

            //if the enemy reaches the walk point
            if (distanceToWalkPoint.magnitude < 1f)
            {
                //walk point is no longer set
                walkPointSet = false;
            }
        }

        //Searches for a new walk point
        private void SearchWalkPoint()
        {
            //creates a random point on the Z and X axis
            float randomZAxis = Random.Range(-walkPointRange, walkPointRange);
            float randomXAxis = Random.Range(-walkPointRange, walkPointRange);

            //sets the walk point to the randomized location + the current location
            walkPoint = new Vector3(transform.position.x + randomXAxis, transform.position.y, transform.position.z + randomZAxis);
            //IF it is on the ground
            if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)) 
            { 
              //Sets the walk point to true
            walkPointSet = true;
            }

        
        }

        //Follows the player
        private void followPlayer()
        {
            //Sets the destination of the Enemy to the location of the player.
            agent.SetDestination(player.position);
        }

        //Attacks the player
        private void Attack()
        {
            //stops the enemy
            agent.SetDestination(transform.position);

            //The enemy moves it's forward face towards the player
            transform.LookAt(player);

            //if it hasn't attacked already
            if (!attackedAlready)
            {
                source.PlayOneShot(fireSound);
                Instantiate(fireParticle, barrel.position, barrel.rotation);
                Destroy(fireParticle, 2);
                //instantiates a bullet in the gun
                // Instantiate(bullet, barrel.position, barrel.rotation);
                //sets attacked already to true

                //create a raycast hit
                RaycastHit hit;

                //if there is a raycast
                if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, bulletRange))
                {


                    //check the name of the object it hit
                    Debug.Log(hit.transform.name);
                    //if the collider that was hit is tagged with "Enemy"
                    if (hit.collider.tag == "Player")
                    {
                        //get that objects health script
                        health = hit.collider.GetComponent<Health>();
                        //cause the enemy to take damage
                        health.TakeDamage(damage);

                        attackedAlready = true;
                        //invokes Reset attack after the weapons fireRate
                        Invoke("ResetAttack", fireRate);
                    }
                    
                }
            }
        }

        //Resets the attack of the enemy
        private void ResetAttack()
        {
            //sets attacked already to false
            attackedAlready = false;
        }
    }
}