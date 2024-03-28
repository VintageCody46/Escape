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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform GetPlayer()
    {
        return player.transform;
    }
}
