using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GargoyleController : MonoBehaviour
{
    public float viewDistance;
    public float viewAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckView();

        //(x,y,z) + (0,21,0)
    }

    void CheckView()
    {
        Renderer rend = gameObject.GetComponentInChildren<Renderer>();
        
        
        Vector3 origin = rend.bounds.center;
        Vector3 direction = (ObjectManager.Instance.GetPlayer().position - origin).normalized;

        //Debug.DrawLine(origin, origin + direction * 50, Color.cyan);


        if (Physics.Raycast(origin, direction, out RaycastHit hit, viewDistance))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                if (Vector3.Angle(transform.forward, direction) < viewAngle)
                {
                    Debug.Log("Spotted by Gargoyle at: " + Vector3.Angle(transform.forward, direction));
                    AlertController.Instance.AlertPlayerPos(hit.point);
                }
            }

            Debug.DrawLine(origin, hit.point, Color.cyan);
        }
    }
}
