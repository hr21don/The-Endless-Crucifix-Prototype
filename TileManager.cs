using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tileprefabs;
    public float isspawnedz = 0;
    public float tilelength = 30;
    public int numberoftiles = 5;
    public Transform playerTransform;
    private readonly List<GameObject> ActiveTiles = new List<GameObject>();

    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < numberoftiles; i++)
        {
            if (i == 0)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile(Random.Range(0, tileprefabs.Length));
            }
        }

    }

    // Update is called once per frame
    private void Update()
    {
        if (playerTransform.position.z - 35 > isspawnedz - (numberoftiles * tilelength))
        {
            SpawnTile(Random.Range(0, tileprefabs.Length));
            DeleteTiles();
        }

    }
    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(tileprefabs[tileIndex], transform.forward * isspawnedz, transform.rotation);
        ActiveTiles.Add(go);
        isspawnedz += tilelength;

    }
    private void DeleteTiles()
    {
        Destroy(ActiveTiles[0]);
        ActiveTiles.RemoveAt(0);

    }
}
