using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class GhostController : MonoBehaviour
{

    NavMeshAgent navMeshAgent;

    public float radius = 10;
    public float viewDistance;
    public float viewAngle;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        AlertController.Instance.PlayerSeenEvent += OnAlert;
    }

    // Update is called once per frame
    void Update()
    {
        CheckView();
        
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
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


    void OnAlert(Vector3 playerPos, MonsterType type, Vector3 monsterPos)
    {
        switch(type)
        {
            case MonsterType.Gargoyle:
                navMeshAgent.SetDestination(playerPos);
                break;

            case MonsterType.Banshee:
                if ((transform.position - monsterPos).magnitude <= 10)
                {
                    navMeshAgent.SetDestination(playerPos);
                }
                break;
        }
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

    void OnDestroy()
    {
        AlertController.Instance.PlayerSeenEvent -= OnAlert;
    }
}
