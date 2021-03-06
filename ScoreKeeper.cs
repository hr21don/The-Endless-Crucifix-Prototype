/* Using UI class  */
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    //public variables 
    public Text scoreText;
    public Text highScoreText;
    public float scorecounter;
    public float highscorecounter;
    public float pointspersecond;
    public bool scoreincrease;

    //start method
    private void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            ;
        }

        {
            highscorecounter = PlayerPrefs.GetFloat("HighScore");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (scoreincrease)
        {
            scorecounter += pointspersecond * Time.deltaTime;

        }
        if (scorecounter > highscorecounter)
        {

            highscorecounter = scorecounter;
            PlayerPrefs.SetFloat("HighScore", highscorecounter);
        }

        scoreText.text = "Score: " + Mathf.Round(scorecounter);
        highScoreText.text = "HighScore : " + Mathf.Round(highscorecounter);

    }
}
