using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scream : MonoBehaviour
{

  private AudioSource audioData;

  void Start() {
      audioData = GetComponent<AudioSource>();
  }


  void OnTriggerEnter(Collider col) {

    if (col.gameObject.tag == "Player") {

      audioData.Play(0);
    }
  }

}
