/*Using Audio Class*/
using UnityEngine;
using UnityEngine.Audio;

public class audiomanager : MonoBehaviour
{   //variables 
    public AudioMixer Gameaudio;
    [SerializeField]
    private AudioSource FirstTrack;

    [SerializeField]
    private AudioSource SecondTrack;
    public AudioClip Click;

    public static audiomanager audiomanagerinstance;

    //awake method
    private void Awake()
    {

        if (audiomanagerinstance != null && audiomanagerinstance != this)
        {

            Destroy(gameObject);
            return;
        }
        audiomanagerinstance = this;
        DontDestroyOnLoad(this);
    }

    //start method
    private void Start()
    {
        if (FirstTrack == null)
        {
            Debug.Log("First Track has not been set");
            enabled = false;
        }
        if (SecondTrack == null)
        {
            Debug.Log("Second track has not been set");
            enabled = false;
        }

        FirstTrack.Play();
        SecondTrack.Play();


    }
    //setaudio method
    public void SetAudio(float Volume)
    {
        Gameaudio.SetFloat("Audio", Volume);

    }
}
