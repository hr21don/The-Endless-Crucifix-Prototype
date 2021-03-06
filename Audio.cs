using UnityEngine;

public class Audio : MonoBehaviour
{


    public static Audio audio;
    private void Awake()
    {

        if (audio != null && audio != this)
        {

            Destroy(gameObject);
            return;
        }
        audio = this;
        DontDestroyOnLoad(this);
    }
}
