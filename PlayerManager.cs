using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour

{
    //local variables 
    public Text Cointext;
    public static int numberofcoins;

    // Start is called before the first frame update
    private void Start()
    {
        numberofcoins = 0;

    }

    // Update is called once per frame
    private void Update()
    {
        Cointext.text = "Coins:" + numberofcoins;
    }
}
