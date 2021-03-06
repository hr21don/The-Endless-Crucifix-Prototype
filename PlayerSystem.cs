/* using TMPro */
using TMPro;
using UnityEngine;
public class PlayerSystem : MonoBehaviour
{
    //public vairablescon
    public TextMeshProUGUI playerLevel;
    public TextMeshProUGUI playerXP;
    public TextMeshProUGUI notificationMessage;
    public GameObject notification;
    private LevelController lc;

    // Start is called before the first frame update
    private void Start()
    {

        lc = new LevelController();
        lc.onlevelup += onlevelup;
        lc.OnEXPchange += onAddXP;
        UpdateTest();
    }
    //level up method 
    public void LevelUp()
    {
        lc.LevelUp();
    }
    //add exp method 
    public void AddXP()
    {
        lc.AddExperincePoints(100);
    }
    //onlevelup method 
    private void onlevelup(int oldlevel, int newlevel)
    {
        Debug.Log($"Player level up! newlevel:  {newlevel} , oldlevel: {oldlevel} , EXP: {lc.currentEXPpoints}|{lc.GoalExp}");
        UpdateTest();
        notificationMessage.text = $"Congrats on Leveling up Level {newlevel} ";
        //+ notification.ToString();
        notification.SetActive(true);
    }
    //aonaddxp method
    private void onAddXP()
    {
        Debug.Log($"Add XP! Current EXP: {lc.currentEXPpoints} | {lc.GoalExp}");
        UpdateTest();

    }
    //update method
    private void UpdateTest()
    {
        playerLevel.text = $"{lc.CurrentLevel}";
        playerXP.text = $"{lc.currentEXPpoints} | {lc.GoalExp}";

    }

}
