using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightColorChanger : MonoBehaviour
{

    Color defaultColor;
    Light light;
    bool _isAlert;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponentInChildren<Light>();
        defaultColor = light.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isAlert) {
            light.color = Color.red;
        } else {
            light.color = defaultColor;
        }
    }


    void OnAlert() {

      _isAlert = true;
      StartCoroutine("AlertTimer");
    }


    IEnumerator AlertTimer() {

      yield return new WaitForSeconds(20);

      _isAlert = false;
    }


    void OnDestroy() {
      
    }
}
