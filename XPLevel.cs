using TMPro;
using UnityEngine;
public class XPLevel : MonoBehaviour
{
    // public variables 
    public TextMeshProUGUI XpText;
    public TextMeshProUGUI LevelText;
    public float xp { get; private set; }
    public float level { get; private set; }

    //private variables 
    private float Levelup;
    public float LevelAdjust;

    //start function
    private void Start()
    {
        Levelup = level * LevelAdjust;
        UpdateUI();

    }
    //update function
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            float amountt = Random.Range(1f, 40f);
            Debug.Log("Added" + amountt.ToString() + "Xp");
            AddXP(amountt);

        }
    }
    // AddXP function
    public void AddXP(float amount)
    {

        xp += amount;
        if (xp >= Levelup)
        {
            xp = xp - Levelup;
            level += 1;
            Levelup += level * LevelAdjust;
        }
        UpdateUI();

    }
    // UpdateUI function
    private void UpdateUI()
    {
        LevelText.text = "Level | " + level.ToString();
        XpText.text = "XP | " + xp.ToString();

    }
}
