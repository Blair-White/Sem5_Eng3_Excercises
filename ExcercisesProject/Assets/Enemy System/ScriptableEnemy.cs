using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy", order = 3)]
public class ScriptableEnemy : ScriptableObject
{
    [SerializeField]
    public AnimationClip IdleAnimation;
    [SerializeField]
    public string Name;
    [SerializeField]
    public Color NameColor;
    [SerializeField]
    public ScriptableAbility BasicAttack;
    [SerializeField]
    public AnimationClip BasicAttackAnim;
    [SerializeField]
    public ScriptableAbility HealingAbility;
    [SerializeField]
    public AnimationClip HealingAnim;
    [SerializeField]
    public ScriptableAbility UtilityAbility;
    [SerializeField]
    public AnimationClip UtilityAnim;
    [SerializeField]
    public ScriptableAbility SignatureAbility;
    [SerializeField]
    public AnimationClip SignatureAnim;

}
