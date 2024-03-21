using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]

public class JohnLemon_Controller : MonoBehaviour
{

    Vector3 movement;
    Animator animator;
    Rigidbody rb;

    public TextMeshProUGUI keyText;

    public float turnSpeed = 10f;

    private int _numKeys = 0;

    private AudioSource[] audioData;
    private bool _isAlert;

    // Start is called before the first frame update
    void Start()
    {
      animator = GetComponent<Animator>();
      rb = GetComponent<Rigidbody>();
      _isAlert = false;
      audioData = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMovement(InputAction.CallbackContext context) {

      Vector2 inputVector = context.ReadValue<Vector2>();
      inputVector.Normalize();

      movement.Set(inputVector.x, 0, inputVector.y);

      bool isWalking = (movement.magnitude > 0.1f);
      animator.SetBool("isWalking", isWalking);
    }


    public void OnAnimatorMove() {

      rb.MovePosition(rb.position + movement * animator.deltaPosition.magnitude);

      Vector3 desiredRotation = Vector3.RotateTowards(transform.forward, movement, turnSpeed * Time.deltaTime, 0f);
      Quaternion rotation = Quaternion.LookRotation(desiredRotation);
      rb.MoveRotation(rotation);
    }


    public void IncrementKeys() {
      _numKeys++;
      keyText.text = "X " + _numKeys.ToString();
    }

    public void DecrementKeys() {
      _numKeys--;
      keyText.text = "X " + _numKeys.ToString();
    }

    public int GetKeys() {
      return _numKeys;
    }


    void OnAlert() {

      if (!_isAlert) {
        _isAlert = true;
        audioData[0].Stop();
        audioData[1].Play(0);
      }

      StartCoroutine("AlertTimer");
    }


    IEnumerator AlertTimer() {

      yield return new WaitForSeconds(20);

      _isAlert = false;
      audioData[1].Stop();
      audioData[0].Play(0);
    }


    void OnDestroy() {

    }
}
