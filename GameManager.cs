using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    //public variables 
    public Text PointsText;

    //setup method
    public void setup(int score)
    {
        gameObject.SetActive(true);
        PointsText.text = score.ToString() + "Points";

    }
    //restart method
    public void RestartButton()
    {
        SceneManager.LoadScene("game");

    }

    //mainmenu method
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    //quitgame method
    public void QuitGame()
    {
        Debug.Log("QuitGame");
        Application.Quit();
    }
}
