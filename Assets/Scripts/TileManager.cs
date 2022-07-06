using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn = 14.5f;
    public float tileLength = 6;
    public int numberOfTiles = 12;
    private List<GameObject> activeTiles = new List<GameObject>(); 
    public Transform playerTransform;
    private int oldTileIndex = 0;
    private int newTileIndex;

    void Start()
    {
        SpawnTile(0);
        SpawnTile(1);

        for(int i = 0; i < numberOfTiles; i++)
        {
            SpawnTile(RandomTileIndex());
        }
    }

    void Update()
    {
        if (playerTransform.position.z - 7 > zSpawn - ((numberOfTiles) * tileLength))
        {
            SpawnTile(RandomTileIndex());
            DeleteTile();
        }
    }

    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
    }

    public void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    int RandomTileIndex()
    {
        newTileIndex = Random.Range(0, tilePrefabs.Length);

        if(newTileIndex == oldTileIndex)
        {
            RandomTileIndex();
        }
       oldTileIndex = newTileIndex;
       return newTileIndex;
    }
}
