using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Data playerSpawnData;
    [SerializeField] private TextMeshProUGUI keyTextUI;


    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        OnSpawnPlayer();
    }

    public void OnSpawnPlayer()
    {
        Vector3 spawnLoc;

        switch (GameController.Instance.currentLevel)
        {
            case "Level1":
                spawnLoc = playerSpawnData.level1Placements[0];
                break;

            case "Level2":
                spawnLoc = playerSpawnData.level2Placements[0];
                break;

            default:
                spawnLoc = Vector3.zero;
                break;
        }

        
        GameObject spawnedPlayer;
        spawnedPlayer = Instantiate(player, spawnLoc, Quaternion.identity);
        PlayerInventory playerInv = spawnedPlayer.GetComponent<PlayerInventory>();
        playerInv.keyText = keyTextUI;

        ObjectManager.Instance.player = spawnedPlayer;
    }
}
