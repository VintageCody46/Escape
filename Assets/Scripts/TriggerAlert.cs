using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAlert : MonoBehaviour
{

    void OnTriggerStay(Collider col) {

    if (col.gameObject.tag == "Player") {

      GameController.Instance.AlertTriggered();
    }
  }
}
