using UnityEngine;

public class Ambience : MonoBehaviour
{
    public static Ambience instance;
    public AudioSource source;
    //public AudioClip clip;




    // Start is called before the first frame update
    void Start()
    {
        if (instance)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this);

        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying) 
        { 
         source.Play();
        
        }
    }
}
