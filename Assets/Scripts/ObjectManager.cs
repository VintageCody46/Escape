using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public Transform GetFloor()
    {
        return floor.transform;
    }
}
