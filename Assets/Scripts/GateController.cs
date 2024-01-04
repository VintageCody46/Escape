using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{

    public float speed;
    public bool _open;

    private AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {
      _open = false;
      audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

      if (!_open) {

        if (transform.position.y > -0.6f && transform.position.y <= 1.6f) {
          transform.position += Vector3.up * speed * Time.deltaTime;
        }

      } else {

        if (transform.position.y < 1.7f && transform.position.y >= -0.5) {
          transform.position -= Vector3.up * speed * Time.deltaTime;
        }
      }
    }


    void OnTriggerEnter(Collider col) {

      if (col.gameObject.tag == "Player") {

        if (col.gameObject.GetComponent<JohnLemon_Controller>().GetKeys() > 0 && !_open) {

          col.gameObject.GetComponent<JohnLemon_Controller>().DecrrementKeys();
          audioData.Play(0);
          _open = true;
        }
      }
    }
}
