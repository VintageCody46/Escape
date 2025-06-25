using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BansheeRanPointGen : MonoBehaviour
{
    private GameObject floorReference;

    public Vector3? GetRandomPoint()
    {
        floorReference = GameObject.FindGameObjectWithTag("Floor");

        if (floorReference != null)
        {
            Bounds bounds = floorReference.GetComponent<BoxCollider>().bounds;

            float minX = bounds.min.x;
            float maxX = bounds.max.x;
            float minZ = bounds.min.z;
            float maxZ = bounds.max.z;

            float randX = Random.Range(minX, maxX);
            float randZ = Random.Range(minZ, maxZ);

            Vector3 ranPoint = new Vector3(randX, transform.position.y, randZ);
        
            return ranPoint;
        }

        return null;
    }
}
