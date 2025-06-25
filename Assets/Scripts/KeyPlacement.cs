using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyPlacement : MonoBehaviour
{

    [SerializeField] private GameObject key;
    [SerializeField] private Data keySpawnData;


    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.buildIndex)
        {
            case 1:

                onSpawnKey(keySpawnData.level1Placements);
                break;


            case 2:

                onSpawnKey(keySpawnData.level2Placements);
                break;


        }
        
    }

    public void onSpawnKey(List<Vector3> spawnPlacements)
    {
        Vector3 spawnLoc = Vector3.zero;
        int randomNum = UnityEngine.Random.Range(1, spawnPlacements.Count);
        
        ExitDoor eWalk = GameObject.FindObjectOfType<ExitDoor>();

        eWalk.requiredKeys = randomNum;

        List<int> keyPos = new List<int>(); 

        for(int i = 0; i < randomNum; i++)
        {
            int randomKey = UnityEngine.Random.Range(0, spawnPlacements.Count);

            while(keyPos.Contains(randomKey))
            {
                randomKey = UnityEngine.Random.Range(0, spawnPlacements.Count);
            }

            keyPos.Add(randomKey);

            spawnLoc = spawnPlacements[randomKey];

            Instantiate(key, spawnLoc, Quaternion.identity);
        }

        /*switch (GameController.Instance.currentLevel)
        {
            case "Level1":

                break;

            case "Level2":
                
                for(int i = 0; i < randomNum; i++)
                {
                    int randomKey = UnityEngine.Random.Range(0, spawnPlacements.Count);

                    while (keyPos.Contains(randomKey))
                    {
                        randomKey = UnityEngine.Random.Range(0, spawnPlacements.Count);
                    }

                    keyPos.Add(randomKey);

                    spawnLoc = spawnPlacements[randomKey];

                    Instantiate(key, spawnLoc, Quaternion.identity);
                }
                break;

            default:
                spawnLoc = Vector3.zero;
                break;
        }*/    
    }
}
