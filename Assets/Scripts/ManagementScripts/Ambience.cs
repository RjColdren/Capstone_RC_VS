using UnityEngine;

public class Ambience : MonoBehaviour
{
    //creates an instance and an audio source
    public static Ambience instance;
    public AudioSource source;
    //public AudioClip clip;




    // Start is called before the first frame update
    void Start()
    {
        //Ensures there is only one instance of this 
        if (instance)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this);
        //Plays the sound
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //if the source is not playing
        if (!source.isPlaying) 
        { 
            //play the source again
         source.Play();
        
        }
    }
}
