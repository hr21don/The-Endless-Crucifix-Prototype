/*using collections class*/
using System.Collections;
using UnityEngine;

public class Popup : MonoBehaviour
{
    //onEnable Class
    private void onEnable()
    {
        StartCoroutine(Turnoff());
    }


    private IEnumerator Turnoff()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}
