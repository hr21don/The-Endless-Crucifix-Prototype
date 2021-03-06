using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class TXTLoader : MonoBehaviour
{

    private TextAsset txtFile;
    private readonly char lineSeperator = '\n';
    private readonly char surround = '"';
    private readonly string[] fieldseperator = { "\" , \"" };
    public void LoadTXT()
    {
        txtFile = Resources.Load<TextAsset>("Localisation");

    }

    public Dictionary<string, string> GetDictionaryValues(string attributeID)
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        string[] lines = txtFile.text.Split(lineSeperator);
        int attributeIndex = -1;
        string[] headers = lines[0].Split(fieldseperator, System.StringSplitOptions.None);

        for (int i = 0; i < headers.Length; i++)
        {
            if (headers[i].Contains(attributeID))
            {
                attributeIndex = i;
                break;
            }

        }
        Regex txtparser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] fields = txtparser.Split(line);
            for (int f = 0; f < fields.Length; f++)
            {
                fields[f] = fields[f].TrimStart(' ', surround);
                fields[f] = fields[f].TrimStart(surround);

            }
            if (fields.Length > attributeIndex)
            {
                string key = fields[0];
                if (dictionary.ContainsKey(key)) { continue; }

                string value = fields[attributeIndex];
                dictionary.Add(key, value);

            }

        }
        return dictionary;
    }

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }
}
