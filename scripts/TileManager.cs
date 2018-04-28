using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TileManager : MonoBehaviour
{


    public GameObject[] tilesPrefab = new GameObject[10];
    private Transform PlayerTransform;
    private float spawnZ = 11.7f;
    private float tileLength = 90.0f;
    private int amountOfTilesOnScreen = 10;
    private List<GameObject> activeTiles;
    private float safeZone = 10.0f;
    private int lastPrefabIndex = 0;
    void Start()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        activeTiles = new List<GameObject>();

        for (int i = 0; i < amountOfTilesOnScreen; i++)
        {
            SpawningTile();
        }
    }

    void SpawningTile(int tileIndex = -1)
    {
        GameObject tile;
        if (tileIndex == -1)
        {
            tile = tilesPrefab[0];
            // tile.transform.position = Vector3.forward * (spawnZ + tileLength);
            tile = Instantiate(tilesPrefab[RandomPrefabIndex()]) as GameObject;
            tile.transform.SetParent(transform);
            tile.transform.position = Vector3.forward * (spawnZ + tileLength);
            spawnZ += tileLength;
            activeTiles.Add(tile);
        }
        else
        {
            tile = Instantiate(tilesPrefab[tileIndex]) as GameObject;
        }
    }

    private void DeleteTile()
    {

        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);

    }

    private int RandomPrefabIndex()
    {
        if (tilesPrefab.Length <= 0)
        {
            return 0;
        }
        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilesPrefab.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }

    void Update()
    {

        if (PlayerTransform.position.z - safeZone <  amountOfTilesOnScreen * tileLength-spawnZ )
        {
            SpawningTile();
            DeleteTile();
        }

    }


}
