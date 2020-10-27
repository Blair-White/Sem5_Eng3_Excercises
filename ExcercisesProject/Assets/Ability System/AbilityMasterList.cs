using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilityMasterTable", menuName = "ScriptableObjects/AbilityMasterTable", order = 2)]
public class AbilityMasterList : ScriptableObject
{
    [SerializeField]
    public ScriptableAbility[] Abilities;
}
