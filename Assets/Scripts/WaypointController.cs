using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class WaypointController : MonoBehaviour
{

    NavMeshAgent navMeshAgent;

    [SerializeField]
    private GameObject player;

    [SerializeField]

    private bool _isAlert;
    public float alertLength;
    public float radius = 10;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        GameController.Instance.onAlertTriggered += OnAlert;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isAlert && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            Vector3 point;

            if(SetRandomDestination(out point))
            {
                navMeshAgent.SetDestination(point);
            }
        }
        //else if (_isAlert)
        //{
        //    if (navMeshAgent.remainingDistance < 1)
        //    {
        //        Vector3 point;
        //        Vector3 destination = navMeshAgent.destination;
        //        Vector3 newPos = new Vector3(destination.x + Random.Range(-5, 5), destination.y + Random.Range(-5, 5), destination.z);

        //        while (!SetDestination(point))
        //        {
        //            newPos = new Vector3(destination.x + Random.Range(-5, 5), destination.y + Random.Range(-5, 5), destination.z);
        //        }
        //    }
        //}
    }


    private bool SetRandomDestination(out Vector3 result)
    {
        
        Debug.Log("radius: " + radius);
        Vector3 ranPoint = transform.position + Random.insideUnitSphere * radius;
        NavMeshHit hit;

        if (NavMesh.SamplePosition(ranPoint, out hit, 1f, NavMesh.AllAreas))
        {
            result = hit.position;
            Debug.Log("Going to point");
            return true;
        }

        result = Vector3.zero;
        Debug.Log("I do nothing");
        return false;
    }


    void OnAlert()
    {

        _isAlert = true;
        navMeshAgent.SetDestination(player.transform.position);
        StartCoroutine("AlertTimer");
    }


    void OnDestroy()
    {
        GameController.Instance.onAlertTriggered -= OnAlert;
    }


    IEnumerator AlertTimer()
    {

        yield return new WaitForSeconds(alertLength);

        _isAlert = false;
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawSphere(transform.position, radius);
    //}
}
