using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum MonsterType
{
    Banshee,
    Gargoyle,
    Ghost
}

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager Instance;
    public GameObject player;
    public GameObject floor;

    //public Canvas canv;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public Transform GetPlayer()
    {
        return player.transform;
    }
}
