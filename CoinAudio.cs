using UnityEngine;

public class CoinAudio : MonoBehaviour
{
    public static AudioClip coincollectorsound;
    public AudioSource audioSource;
    //  public Sound[] sounds; foreach (Sound s in sounds)


    public void pickupcoin()
    {
        audioSource.Play();
    }

}
