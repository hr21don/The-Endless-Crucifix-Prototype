using System.IO;
using UnityEngine;

namespace GameData.ScoreBoards
{

    public class leaderboards : MonoBehaviour
    {
        [SerializeField] private int maxscoreboardentries = 5;
        [SerializeField] private Transform HighScoreTemplateTransform;
        [SerializeField] private Transform scoreboardEntryObject;

        [Header("TEST")]
        [SerializeField] private HighScoreBoard testhighScoreBoard = new HighScoreBoard();

        private string SavePath => $"{Application.persistentDataPath}/highscore.json";


        [ContextMenu("Add test entry")]
        public void AddTestEntry()
        {
            AddEntry(testhighScoreBoard);
        }
        private void Start()
        {
            savedata savedScores = GetsavedScore();
            UpdateUI(savedScores);

            SaveScores(savedScores);
        }

        public void AddEntry(HighScoreBoard highScoreBoard)
        {
            savedata savedscores = GetsavedScore();
            bool scoreisadded = false;
            for (int i = 0; i < savedscores.highscore.Count; i++)
            {
                if (highScoreBoard.entryScore > savedscores.highscore[i].entryScore)
                {
                    savedscores.highscore.Insert(i, highScoreBoard);
                    scoreisadded = true;
                    break;
                }

            }
            if (!scoreisadded && savedscores.highscore.Count < maxscoreboardentries)
            {
                savedscores.highscore.Add(highScoreBoard);
            }
            if (savedscores.highscore.Count > maxscoreboardentries)
            {
                savedscores.highscore.RemoveRange(maxscoreboardentries, savedscores.highscore.Count - maxscoreboardentries);
            }
            UpdateUI(savedscores);
            SaveScores(savedscores);
        }

        private void UpdateUI(savedata savedScores)
        {
            foreach (Transform child in HighScoreTemplateTransform)
            {
                Destroy(child.gameObject);
            }
            foreach (HighScoreBoard highScore in savedScores.highscore)
            {
                Instantiate(scoreboardEntryObject, HighScoreTemplateTransform).GetComponent<LeaderBoardUI>().Initialised(highScore);
            }

        }
        private savedata GetsavedScore()
        {
            if (!File.Exists(SavePath))
            {
                File.Create(SavePath).Dispose();
                return new savedata();
            }
            using (StreamReader stream = new StreamReader(SavePath))
            {

                string json = stream.ReadToEnd();

                return JsonUtility.FromJson<savedata>(json);
            }

        }
        private void SaveScores(savedata savedata)
        {
            using (StreamWriter stream = new StreamWriter(SavePath))
            {

                string json = JsonUtility.ToJson(savedata, true);
                stream.Write(json);
            }
        }

    }
}