using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextLocaliser : MonoBehaviour
{
    private TextMeshProUGUI textfield;
    public string key;

    // Start is called before the first frame update
    private void Start()
    {
        textfield = GetComponent<TextMeshProUGUI>();
        string value = LocalisationSystem.GetLocalisedValues(key);
        textfield.text = value;
    }


}
