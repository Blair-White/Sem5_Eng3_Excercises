using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyMasterTable", menuName = "ScriptableObjects/EnemyMasterTable", order = 4)]
public class MasterEnemyTable : ScriptableObject
{
    [SerializeField]
    public ScriptableEnemy[] EnemyList;

}
