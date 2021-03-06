/*using scenemanagement class */

using UnityEngine;
using UnityEngine.SceneManagement;
public class characterselection : MonoBehaviour
{
    //public variables
    public GameObject[] characters;
    public int selectedcharacter = 0;

    //nextselection method
    public void NextSelection()
    {
        characters[selectedcharacter].SetActive(false);
        selectedcharacter = (selectedcharacter + 1) % characters.Length;
        characters[selectedcharacter].SetActive(true);
    }
    //previous selection method
    public void PreviousSelection()
    {
        characters[selectedcharacter].SetActive(false);
        selectedcharacter--;
        if (selectedcharacter < 0)
        {
            selectedcharacter += characters.Length;
        }
        characters[selectedcharacter].SetActive(true);
    }

    //start game method
    public void StartGame()
    {
        PlayerPrefs.SetInt("SelectedCharacter", selectedcharacter);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
