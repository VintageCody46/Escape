using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    AudioSource audioData;

    public string keyColor;
    public float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, transform.up, rotateSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {

            audioData.Play(0);
            col.gameObject.GetComponent<PlayerInventory>().IncrementKeys(this);
            Destroy(gameObject);
        }
    }
}
