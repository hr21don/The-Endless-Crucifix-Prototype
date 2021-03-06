/*Using class UI to create text variables */
using UnityEngine;
using UnityEngine.UI;
public class PlayerName : MonoBehaviour
{
    //local variables
    public string nameofplayer;
    public string saveName;
    public Text text;
    public Text loadedName;

    // Update is called once per frame
    private void Update()
    {
        nameofplayer = PlayerPrefs.GetString("name", "none");
        loadedName.text = nameofplayer;

    }

    //set name method
    public void setName()
    {
        saveName = text.text;
        PlayerPrefs.SetString("name", saveName);

    }
}
