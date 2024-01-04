using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCapture : MonoBehaviour
{
      void OnTriggerEnter(Collider col) {

      if (col.gameObject.tag == "Player") {

        GameController.Instance.LoseGame();
      }
    }
}
