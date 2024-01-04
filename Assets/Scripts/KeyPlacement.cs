using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPlacement : MonoBehaviour
{

    public GameObject keyPrefab;
    public List<GameObject> KeyPlacementPoints = new List<GameObject>();

    private int numKeys;

    // Start is called before the first frame update
    void Start()
    {
        numKeys = 3;

        if (KeyPlacementPoints.Count > 3) {

          for (int i=0; i<numKeys; i++) {

            int num = Random.Range(0, KeyPlacementPoints.Count);

            Instantiate(keyPrefab, KeyPlacementPoints[num].transform);

            KeyPlacementPoints.Remove(KeyPlacementPoints[num]);
          }
        }
    }
}
