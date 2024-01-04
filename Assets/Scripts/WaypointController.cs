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
    Transform[] waypoints;

    private int _curIndex;
    private bool _isAlert;
    public float alertLength;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (waypoints.Length > 0) {
          navMeshAgent.SetDestination(waypoints[0].position);
        }

        GameController.Instance.onAlertTriggered += OnAlert;
    }

    // Update is called once per frame
    void Update()
    {
        if (waypoints.Length > 0 && !_isAlert && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance) {
          _curIndex++;
          _curIndex %= waypoints.Length;

          navMeshAgent.SetDestination(waypoints[_curIndex].position);

        } else if (_isAlert) {

          if (navMeshAgent.remainingDistance < 1) {

            Vector3 destination = navMeshAgent.destination;
            Vector3 newPos = new Vector3( destination.x + Random.Range(-5, 5), destination.y + Random.Range(-5, 5), destination.z);

            while (!SetDestination(newPos)) {

              newPos = new Vector3( destination.x + Random.Range(-5, 5), destination.y + Random.Range(-5, 5), destination.z);
            }
          }
        }
    }


    private bool SetDestination(Vector3 newPos) {

      NavMeshHit hit;

      if (NavMesh.SamplePosition(newPos, out hit, 1f, NavMesh.AllAreas)) {

        navMeshAgent.SetDestination(hit.position);
        return true;
      }

      return false;
    }


    void OnAlert() {

      _isAlert = true;
      navMeshAgent.SetDestination(player.transform.position);
      StartCoroutine("AlertTimer");
    }


    void OnDestroy() {
      GameController.Instance.onAlertTriggered -= OnAlert;
    }


    IEnumerator AlertTimer() {

      yield return new WaitForSeconds(alertLength);

      _isAlert = false;
    }

}
