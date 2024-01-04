using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public float timeWaitMin, timeWaitMax;
    public float flashIncrementMin, flashIncrementMax;
    public float flashLengthMin, flashLengthMax;
    private float _flashLength;
    private float _time;
    private Light _light;

    private enum State {Wait, FlashStart, Flash, FlashEnd};
    private State _state;

    private AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {
        _light = GetComponent<Light>();
        _time = Random.Range(timeWaitMin, timeWaitMax);
        _state = State.Wait;
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (_state == State.Wait) {

          _time -= Time.deltaTime;

          if (_time < 0) {

            _state = State.FlashStart;
            _flashLength = Random.Range(flashIncrementMin, flashIncrementMax);
          }
        }


        else if (_state == State.FlashStart) {

          if (_light.intensity < 1) {

            _light.intensity += 1 / _flashLength;

          } else {

            _state = State.Flash;
            audioData.Play(0);
            _time = Random.Range(flashLengthMin, flashLengthMax);
          }
        }


        else if (_state == State.Flash) {

          _time -= Time.deltaTime;

          if (_time < 0) {

            _state = State.FlashEnd;
            _flashLength = Random.Range(flashIncrementMin, flashIncrementMax);
          }
        }


        else if (_state == State.FlashEnd) {

          if (_light.intensity > 0) {

            _light.intensity -= 1 / _flashLength;

          } else {

            _light.intensity = 0;
            _state = State.Wait;
            _time = Random.Range(timeWaitMin, timeWaitMax);
          }
        }
    }
}
