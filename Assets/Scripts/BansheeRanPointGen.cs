using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BansheeRanPointGen : MonoBehaviour
{

    public Vector3 GetRandomPoint()
    {
        Transform floor = ObjectManager.Instance.GetFloor();

        Bounds bounds = floor.GetComponent<BoxCollider>().bounds;

        float minX = bounds.min.x;
        float maxX = bounds.max.x;
        float minZ = bounds.min.z;
        float maxZ = bounds.max.z;

        float randX = Random.Range(minX, maxX);
        float randZ = Random.Range(minZ, maxZ);

        Vector3 ranPoint = new Vector3(randX, 0, randZ);
        
        return ranPoint;
    }
}
