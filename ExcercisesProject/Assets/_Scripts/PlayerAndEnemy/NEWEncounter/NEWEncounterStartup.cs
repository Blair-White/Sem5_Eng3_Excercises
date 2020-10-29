using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;

public class NEWEncounterStartup : MonoBehaviour
{
    [SerializeField]
    private GameObject _Player, _Enemy, _Ability1, _Ability2, _Ability3, _Ability4, EnemyTitle;
    
    [SerializeField]
    private MasterEnemyTable EnemyList;

    [SerializeField]
    private ScriptableEnemy StartingEnemy;

    [SerializeField]
    private AbilityMasterList AbilityList;
    
    private int[] Abilities = { 0, 1, 2, 3 };
    
    [SerializeField]
    private ScriptableAbility[] PlayerAbilities;

    [SerializeField]
    private ScriptableAbility[] EnemyAbilities;

    [SerializeField]
    private AnimatorController DefaultPlayerAnimation, DefaultEnemyAnimation;
    // Start is called before the first frame update
    void Start()
    {
        Abilities[0] = PlayerPrefs.GetInt("Ability_1");
        Abilities[1] = PlayerPrefs.GetInt("Ability_2");
        Abilities[2] = PlayerPrefs.GetInt("Ability_3");
        Abilities[3] = PlayerPrefs.GetInt("Ability_4");

        if (Abilities[1] == 0) { Abilities[1] = 6; }
        if (Abilities[2] == 0) { Abilities[2] = 2; }
        if (Abilities[3] == 0) { Abilities[3] = 3; }


        PlayerAbilities[0] = AbilityList.Abilities[Abilities[0]];
        PlayerAbilities[1] = AbilityList.Abilities[Abilities[1]];
        PlayerAbilities[2] = AbilityList.Abilities[Abilities[2]];
        PlayerAbilities[3] = AbilityList.Abilities[Abilities[3]];

        _Ability1.GetComponentInChildren<TextMeshProUGUI>().text = PlayerAbilities[0].ButtonText;
        _Ability1.GetComponentInChildren<TextMeshProUGUI>().color = PlayerAbilities[0].ButtonTextColor;
        _Ability2.GetComponentInChildren<TextMeshProUGUI>().text = PlayerAbilities[1].ButtonText;
        _Ability2.GetComponentInChildren<TextMeshProUGUI>().color = PlayerAbilities[1].ButtonTextColor;
        _Ability3.GetComponentInChildren<TextMeshProUGUI>().text = PlayerAbilities[2].ButtonText;
        _Ability3.GetComponentInChildren<TextMeshProUGUI>().color = PlayerAbilities[2].ButtonTextColor;
        _Ability4.GetComponentInChildren<TextMeshProUGUI>().text = PlayerAbilities[3].ButtonText;
        _Ability4.GetComponentInChildren<TextMeshProUGUI>().color = PlayerAbilities[3].ButtonTextColor;

        int i = Random.Range(0, EnemyList.EnemyList.Length);
        StartingEnemy = EnemyList.EnemyList[i];
        _Enemy.GetComponent<Animator>().runtimeAnimatorController = StartingEnemy.DefaultAnimation;
        DefaultEnemyAnimation = StartingEnemy.DefaultAnimation;
        EnemyAbilities[0] = StartingEnemy.BasicAttack;
        EnemyAbilities[1] = StartingEnemy.DefenseAbility;
        EnemyAbilities[2] = StartingEnemy.UtilityAbility;
        EnemyAbilities[3] = StartingEnemy.SignatureAbility;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateAbility(int A)
    {
        Debug.Log("Activated Ability: " + PlayerAbilities[A].name);
        _Player.GetComponent<Animator>().runtimeAnimatorController = PlayerAbilities[A].Animator; 
        
    }

    void EndPlayerAnimation()
    {
        _Player.GetComponent<Animator>().runtimeAnimatorController = DefaultPlayerAnimation; 
    }
    void EndEnemyAnimation()
    {
        _Enemy.GetComponent<Animator>().runtimeAnimatorController = DefaultEnemyAnimation;
    }
}
