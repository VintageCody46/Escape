using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BansheeController : MonoBehaviour
{
    private bool bansheeMoveTo;
    private Vector3 destination;
    
    public float destinationRadius;
    public float speed = 1f;
    public float radius = 8;
    
    // Start is called before the first frame update
    void Start()
    {
        SetRandomDestination();

        bansheeMoveTo = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (bansheeMoveTo == true)
        {
            if ((transform.position - destination).magnitude < destinationRadius)
            {
                StartCoroutine(DestinationWaitTimer(0.2f));
            }
        }

        if (bansheeMoveTo == true)
        {
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, , Time.deltaTime);
            transform.LookAt(destination);
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        }

        
    }

    private void SetRandomDestination()
    {
        BansheeRanPointGen ranPoint = GetComponent<BansheeRanPointGen>();

        destination = ranPoint.GetRandomPoint();
    }

    private IEnumerator DestinationWaitTimer(float time)
    {
        bansheeMoveTo = false;
        yield return new WaitForSeconds(time);
        SetRandomDestination();
        bansheeMoveTo = true;
    }
}
