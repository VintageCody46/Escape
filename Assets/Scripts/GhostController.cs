using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class GhostController : MonoBehaviour
{

    NavMeshAgent navMeshAgent;

    private bool _isAlert;
    public float alertLength;
    public float radius = 10;
    public float viewDistance;
    public float viewAngle;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckView();
        
        if (!_isAlert && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            Vector3 point;

            if(SetRandomDestination(out point))
            {
                navMeshAgent.SetDestination(point);
            }
        }
    }


    private bool SetRandomDestination(out Vector3 result)
    {
        Vector3 ranPoint = transform.position + Random.insideUnitSphere * radius;
        NavMeshHit hit;

        if (NavMesh.SamplePosition(ranPoint, out hit, 1f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }


    void OnAlert()
    {
        _isAlert = true;
        navMeshAgent.SetDestination(ObjectManager.Instance.GetPlayer().position);
    }


    void OnDestroy()
    {
        
    }

    void CheckView()
    {
        Vector3 origin = transform.position;
        Vector3 direction = (ObjectManager.Instance.GetPlayer().position - origin).normalized;
        
        
        if (Physics.Raycast(origin, direction, out RaycastHit hit, viewDistance)) 
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                if(Vector3.Angle(transform.forward, direction) < viewAngle)
                {
                    navMeshAgent.SetDestination(ObjectManager.Instance.GetPlayer().position);
                }
            }

            Debug.DrawLine(origin, hit.point, Color.cyan);
        }
    }
}
