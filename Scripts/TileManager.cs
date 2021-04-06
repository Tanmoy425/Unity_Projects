using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tileprefab;
    Transform playerTransform;
    float spawnZ = -0.0f;
    float spawnX = 0.0f;
    float tileLength = 10.0f;
    int Number_of_Tiles_on_Screen = 5;
    List<GameObject> activeTiles;
    float safezone = 15.0f;
    int lastPrefabIndex = 0;
    public Player_Controller pc;

    // Start is called before the first frame update
    void Start()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        if (pc.ifAlive)
        {
            for (int i = 0; i < Number_of_Tiles_on_Screen; i++)
            {
                if (i < 2)
                {
                    SpawnTile(0);
                }
                else
                    SpawnTile();

            }
        }
           
    }

    // Update is called once per frame
    void Update()
    {
        if(pc.ifAlive)
        {
            if (playerTransform.position.z - safezone > (spawnZ - Number_of_Tiles_on_Screen * tileLength))
            {
                SpawnTile();
                DeleteTile();
            }
        }

        
    }

    void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
        {
            go = Instantiate(tileprefab[RandomPrefabIndex()]) as GameObject;
        }
        else
        {
            go = Instantiate(tileprefab[prefabIndex]) as GameObject;
        }
            go.transform.SetParent(transform);
            go.transform.position = Vector3.forward * spawnZ;
            spawnZ += tileLength;
            activeTiles.Add(go);
        
    }

    void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    int RandomPrefabIndex()
    {
        if(tileprefab.Length <=1)
        {
            return 0;
        }

        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tileprefab.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
