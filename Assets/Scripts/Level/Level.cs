using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level", order = 5)]
public class Level : ScriptableObject
{
    [Header("Level Settings")]
    public int levelEnemys = 10;
    public int maxEnemys = 30;
}
