/*Using scenemanagement class*/

using UnityEngine;
using UnityEngine.SceneManagement;

//public class restartrigger 
public class RestartTrigger : MonoBehaviour
{
    //private scorekeeper 
    private ScoreKeeper scoreKeeper;
    private Scene scene;

    // Start is called before the first frame update
    private void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        scene = SceneManager.GetActiveScene();
    }

    //collision methods
    private void OnTriggerEnter(Collider other)
    {

        print("Entering the" + other.gameObject.name);

        if (other.CompareTag("Player"))
        {
            ;
        }

        {
            string activeScene = SceneManager.GetActiveScene().name;
            PlayerPrefs.SetString("Levelsaved", activeScene);
            gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //  SceneManager.LoadScene("GameOver");
        print("In this" + other.gameObject.name);

    }
    private void OnTriggerExit(Collider other)
    {


        scoreKeeper.scoreincrease = false;
        scoreKeeper.scorecounter = 0;
        scoreKeeper.scoreincrease = true;
        print("Exiting the" + other.gameObject.name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
