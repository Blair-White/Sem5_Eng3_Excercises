using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class NEWEncounterStartup : MonoBehaviour
{
    [SerializeField]
    private GameObject _Player, _Enemy, _EnemyParent, _Ability1, _Ability2, _Ability3, _Ability4, EnemyTitle,
                       EnemyHealthBar, PlayerHealthBar, CombatDialogue;
    
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

    private enum States { Idle, PlayerTurn, EnemyTurn, EndingCombat};
    private States State;
    private bool PlayerTurn;
    private int IdleCount;
    private int EnemySignatureCharges;
    private int EnemyDecidedAttack;
    private Image EnemyBarFill;

    // Start is called before the first frame update
    void Start()
    {
        EnemyBarFill = EnemyHealthBar.GetComponent<Image>();
        EnemySignatureCharges = Random.Range(1, 2);
        State = States.Idle;
        PlayerTurn = true;

        Abilities[0] = PlayerPrefs.GetInt("Ability_1");
        Abilities[1] = PlayerPrefs.GetInt("Ability_2");
        Abilities[2] = PlayerPrefs.GetInt("Ability_3");
        Abilities[3] = PlayerPrefs.GetInt("Ability_4");

        if (Abilities[1] == 0) { Abilities[1] = 1; }
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
        EnemyTitle.GetComponent<TextMeshProUGUI>().text = StartingEnemy.Name;
        EnemyTitle.GetComponent<TextMeshProUGUI>().color = StartingEnemy.NameColor;
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
        
        if(_Enemy.GetComponent<SpriteRenderer>().sprite == null)
        {
            _Enemy.GetComponent<SpriteRenderer>().sprite = StartingEnemy.DefaultSprite;
        }

        switch (State)
        {
            case States.Idle:
                IdleCount++;
                if(IdleCount > 1022)
                {
                    if (PlayerTurn)
                    {
                        State = States.PlayerTurn;
                        _Ability1.SetActive(true);
                        _Ability2.SetActive(true);
                        _Ability3.SetActive(true);
                        _Ability4.SetActive(true);
                        CombatDialogue.GetComponent<TextMeshProUGUI>().text = " ";
                        IdleCount = 0;
                    }
                    if(PlayerTurn == false)
                    {
                        State = States.EnemyTurn;
                        IdleCount = 0;
                    }
                    
                }
                 
                break;
            case States.PlayerTurn:
                break;

            case States.EnemyTurn:
                DecideEnemyAction();
                break;

            case States.EndingCombat:
                break;
            default:
                break;
        }

    }
    

    public void ActivateAbility(int A)
    {
        Debug.Log("Activated Ability: " + PlayerAbilities[A].name);
        _Player.GetComponent<Animator>().runtimeAnimatorController = PlayerAbilities[A].Animator;
        _Ability1.SetActive(false);
        _Ability2.SetActive(false);
        _Ability3.SetActive(false);
        _Ability4.SetActive(false);

        _Enemy.SendMessage("TakeDamage", PlayerAbilities[A].Damage);

        if(PlayerAbilities[A].IsIsolatedText == false)
            CombatDialogue.GetComponent<TextMeshProUGUI>().text ="Crono " + PlayerAbilities[A].CombatText + " " + StartingEnemy.Name;
        if (PlayerAbilities[A].IsIsolatedText == true)
            CombatDialogue.GetComponent<TextMeshProUGUI>().text ="Crono " + PlayerAbilities[A].CombatText;
       
        State = States.Idle;
        PlayerTurn = false;

       
    }

    void DecideEnemyAction()
    {
        if(EnemyHealthBar.GetComponent<Image>().fillAmount > .5)
        {
            if (Random.Range(0, 100) > 75)
            {
                EnemyDecidedAttack = 1;
                _EnemyParent.GetComponent<Animator>().runtimeAnimatorController = StartingEnemy.DefenseAbility.Animator;
                CombatDialogue.GetComponent<TextMeshProUGUI>().text = StartingEnemy.DefenseAbility.CombatText;
                PlayerTurn = true;
                State = States.Idle;
                return;
            }
            else
            {
                EnemyDecidedAttack = 0;
                _EnemyParent.GetComponent<Animator>().runtimeAnimatorController = StartingEnemy.BasicAttack.Animator;
                CombatDialogue.GetComponent<TextMeshProUGUI>().text = StartingEnemy.BasicAttack.CombatText;
                State = States.Idle;
                PlayerTurn = true;
                return;
            }
                
        }

        if (EnemyHealthBar.GetComponent<Image>().fillAmount < .5)
        {
            if(EnemySignatureCharges > 0)
            {
                EnemyDecidedAttack = 3;
                EnemySignatureCharges--;
                _EnemyParent.GetComponent<Animator>().runtimeAnimatorController = StartingEnemy.SignatureAbility.Animator;
                CombatDialogue.GetComponent<TextMeshProUGUI>().text = StartingEnemy.SignatureAbility.CombatText;
                PlayerTurn = true;
                State = States.Idle;
                return;
            }
            if(EnemySignatureCharges <= 0)
            {
                if(Random.Range(0,100) > 75)
                {
                    EnemyDecidedAttack = 2;
                    _EnemyParent.GetComponent<Animator>().runtimeAnimatorController = StartingEnemy.UtilityAbility.Animator;
                    CombatDialogue.GetComponent<TextMeshProUGUI>().text = StartingEnemy.UtilityAbility.CombatText;
                    PlayerTurn = true;
                    State = States.Idle;
                    return;
                }
                else
                {
                    EnemyDecidedAttack = 0;
                    _EnemyParent.GetComponent<Animator>().runtimeAnimatorController = StartingEnemy.BasicAttack.Animator;
                    CombatDialogue.GetComponent<TextMeshProUGUI>().text = StartingEnemy.BasicAttack.CombatText;
                    State = States.Idle;
                    PlayerTurn = true;
                    return;
                }
            }
        }

    }
    void ActivateEnemyAbility(int A)
    {

    }

    void EndPlayerAnimation()
    {
        _Player.GetComponent<Animator>().runtimeAnimatorController = DefaultPlayerAnimation; 
    }
    void EndEnemyAnimation()
    {
        _EnemyParent.GetComponent<Animator>().runtimeAnimatorController = null;
    }
}
