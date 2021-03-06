using UnityEngine;
[System.Serializable]
public class Sound : MonoBehaviour
{
    public string name;
    public AudioClip clip;
    public float volume;
    public bool loop;
    public AudioSource source;

}
