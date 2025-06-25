using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO", menuName = "ScriptableObject/Data")]

public class Data : ScriptableObject
{
    public List<Vector3> level1Placements;

    public List<Vector3> level2Placements;
}
