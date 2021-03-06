using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    //private variables 
    private Transform inputContainer;
    private Transform inputTemplate;
    private readonly List<HighScoreEntry> highScoreEntryList;
    private List<Transform> highscoreEntryTransformList;

    // creating awake function
    private void Awake()
    {
        inputContainer = transform.Find("Highscore_Container");
        inputTemplate = transform.Find("Highscore_Entry_Template");
        inputTemplate.gameObject.SetActive(false);



        string jsonString = PlayerPrefs.GetString("HighscoreTable");
        HighScores highscores = JsonUtility.FromJson<HighScores>(jsonString);
        if (highscores == null)
        {

            // There's no stored table, initialize
            Debug.Log("Initializing table with default values...");
            AddEntry(100, "Heli");
            AddEntry(200, "Cam");
            AddEntry(300, "Pete");
            AddEntry(400, "Patrick");
            AddEntry(500, "Patrick");
            AddEntry(600, "Patrick");

            // Reload
            jsonString = PlayerPrefs.GetString("HighscoreTable");
            highscores = JsonUtility.FromJson<HighScores>(jsonString);
        }
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int k = 0 + 1; k < highscores.highscoreEntryList.Count; k++)
            {
                if (highscores.highscoreEntryList[k].score > highscores.highscoreEntryList[i].score)
                {
                    HighScoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[k];
                    highscores.highscoreEntryList[k] = tmp;
                }
            }

        }
        highscoreEntryTransformList = new List<Transform>();
        foreach (HighScoreEntry highScoreEntry in highScoreEntryList)
        {

            HighScoreEntryTransform(highScoreEntry, inputContainer, highscoreEntryTransformList);
        }

    }
    private void HighScoreEntryTransform(HighScoreEntry highScoreEntry, Transform container, List<Transform> transformList)
    {
        float templateofHeight = 30f;
        Transform entryTransform = Instantiate(inputTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateofHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rankingsystem = transformList.Count + 1;
        string rankingstring;
        switch (rankingsystem)
        {
            default:
                rankingstring = rankingsystem + "TH"; break;
            case 1: rankingstring = "1st"; break;
            case 2: rankingstring = "2st"; break;
            case 3: rankingstring = "3st"; break;
        }
        entryTransform.Find("entry_Position").GetComponent<Text>().text = rankingstring;

        int scoresystem = highScoreEntry.score;
        entryTransform.Find("entry_Score").GetComponent<Text>().text = scoresystem.ToString();
        string name = highScoreEntry.name;
        entryTransform.Find("entry_Name").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);
    }

    private void AddEntry(int score, string name)
    {

        // Load saved Highscores
        HighScoreEntry highScoreEntry = new HighScoreEntry { score = score, name = name };
        string jsonString = PlayerPrefs.GetString("HighscoreTable");

        HighScores highscores = JsonUtility.FromJson<HighScores>(jsonString);

        if (highscores == null)
        {
            // There's no stored table, initialize
            highscores = new HighScores()
            {
                highscoreEntryList = new List<HighScoreEntry>()
            };
        }

        // Add new entry to Highscores
        highscores.highscoreEntryList.Add(highScoreEntry);

        // Save updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("HighscoreTable", json);
        PlayerPrefs.Save();
    }
    private class HighScores
    {
        public List<HighScoreEntry> highscoreEntryList;

    }
    [System.Serializable]
    private class HighScoreEntry
    {
        public int score;
        public string name;

    }
}
