using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //initializes 3 variables
    public bool spawn = true;
    public GameObject prefab;
    public float spawnRate = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //Starts the Coroutine
        StartCoroutine(Spawn());

    }

    //Coroutine that will spawn the prefabs
    IEnumerator Spawn()
    {
        //while spawn is true
        while (spawn)
        {
            //instantiates a the prefab
            Instantiate(prefab, transform.position, transform.rotation);
            //waits for however long "spawnRate" is.
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
