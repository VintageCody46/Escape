using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertController : MonoBehaviour
{
    public static AlertController Instance;

    public event Action<Vector3, MonsterType, Vector3> PlayerSeenEvent;

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

    public void AlertPlayerPos(Vector3 playerPos, MonsterType type, Vector3 monsterPos)
    {
        PlayerSeenEvent?.Invoke(playerPos, type, monsterPos);

    }
}
