using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy", order = 3)]
public class ScriptableEnemy : ScriptableObject
{
    [SerializeField]
    public string Name;
    [SerializeField]
    public Color NameColor;
    [SerializeField]
    public ScriptableAbility BasicAttack;
    [SerializeField]
    public ScriptableAbility DefenseAbility;
    [SerializeField]
    public ScriptableAbility UtilityAbility;
    [SerializeField]
    public ScriptableAbility SignatureAbility;
    [SerializeField]
    public AnimatorController DefaultAnimation;
    [SerializeField]
    public float Defense;
    [SerializeField]
    public Sprite DefaultSprite;

}
