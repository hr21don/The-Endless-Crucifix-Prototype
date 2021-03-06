using UnityEngine;

using UnityEngine.UI;


namespace GameData.ScoreBoards
{

    public class LeaderBoardUI : MonoBehaviour
    {
        [SerializeField] private Text entryPositionText = null;
        [SerializeField] private Text entryNameText = null;
        [SerializeField] private Text entryScoreText = null;

        public void Initialised(HighScoreBoard highScoreBoard)
        {
            entryNameText.text = highScoreBoard.entryPosition.ToString();
            entryNameText.text = highScoreBoard.entryScore.ToString();
            entryNameText.text = highScoreBoard.entryName;
        }


    }
}