using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollionController : MonoBehaviour
{

  AudioSource audioData;

  void Start() {
      audioData = GetComponent<AudioSource>();
  }

  void OnTriggerEnter(Collider col) {

    if (col.gameObject.tag == "Player") {

      audioData.Play(0);
      col.gameObject.GetComponent<JohnLemon_Controller>().IncrementKeys();
      Destroy(gameObject, 0.5f);
    }
  }
}
