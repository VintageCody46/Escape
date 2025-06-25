using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public int requiredKeys;
    void OnTriggerEnter(Collider col) {

        if (col.gameObject.tag == "Player") {

            if (col.gameObject.GetComponent<PlayerInventory>().GetKeys() >= requiredKeys)
            {
                //audioData.Play(0);

                Debug.Log("you win!");

                GameController.Instance.LevelTransition("Level2");
            }
        }
    }
}
