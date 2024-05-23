using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BansheeController : MonoBehaviour
{
    [Header("Banshee Movement")]
    public float destinationRadius;
    public float speed = 1f;
    public float radius = 8;
    private bool bansheeMoveTo;
    private Vector3 destination;

    [Header("Banshee Scream")]
    private bool bansheeScream;

    [Header("Banshee LoS")]
    public float viewDistance;
    public float viewAngle;

    [Header("Monster Type")]
    private MonsterType type = MonsterType.Banshee;
    
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

        CheckView();
    }

    private void SetRandomDestination()
    {
        BansheeRanPointGen ranPoint = GetComponent<BansheeRanPointGen>();

        destination = ranPoint.GetRandomPoint();
    }

    void CheckView()
    {
        Vector3 origin = transform.position;
        Vector3 direction = (ObjectManager.Instance.GetPlayer().position - origin).normalized;


        if (Physics.Raycast(origin, direction, out RaycastHit hit, viewDistance))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                if (Vector3.Angle(transform.forward, direction) < viewAngle)
                {
                    var playerPos = hit.collider.transform.position;
                    playerPos.y = transform.position.y;
                    transform.LookAt(playerPos);
                    bansheeMoveTo = false;
                    BansheeScreamStart(hit.point);
                    
                }
                else
                {
                    BansheeScreamStop();
                } 
            }
            else
            {
                BansheeScreamStop();
            }

            Debug.DrawLine(origin, hit.point, Color.green);
        }
        else
        {
            BansheeScreamStop();
        }
    }

    private void BansheeScreamStart(Vector3 hit)
    {
        bansheeScream = true;
        AlertController.Instance.AlertPlayerPos(hit, type, transform.position);
        Debug.Log("Screm and alert ghosts");
    }

    private void BansheeScreamStop()
    {
        if (bansheeScream == true)
        {
            bansheeScream = false;
            StartCoroutine(DestinationWaitTimer(0.5f));
            Debug.Log("No screm");
        }
    }
    
    private IEnumerator DestinationWaitTimer(float time)
    {
        bansheeMoveTo = false;
        yield return new WaitForSeconds(time);
        SetRandomDestination();
        bansheeMoveTo = true;
    }
}
