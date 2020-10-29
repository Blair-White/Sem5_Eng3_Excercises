using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Ability", menuName = "ScriptableObjects/Ability", order = 1)]
public class ScriptableAbility : ScriptableObject
{   
    [SerializeField]
    public string CombatText;
    [SerializeField]
    public float Damage;
    [SerializeField]
    public float Healing;
    [SerializeField]
    public string DebuffMessage;
    [SerializeField]
    public AnimatorController Animator;
    [SerializeField]
    public string ButtonText;
    [SerializeField]
    public Color ButtonTextColor;
    [SerializeField]
    public bool Learnable;
    [SerializeField]
    public bool IsIsolatedText;
}
