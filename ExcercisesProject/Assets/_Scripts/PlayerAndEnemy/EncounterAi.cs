using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EncounterAi : MonoBehaviour
{
    [SerializeField]
    private GameObject Highlighter, Dialogue, HealthBar, GameController;

    [SerializeField]
    private Animator mAnimator;

    public enum States { Inactive, Idle, Acting, Finished }
    public States State;

    public int delay;
    private bool Healing, Damaging;
    private int HealCharges;//0 Attack, 1 heal, 2 Escape;
    private float RNG, HP, TargetHP;
    
    //Incoming Messages
    void StartTurn()
    {
        Highlighter.SetActive(true);
        State = States.Idle;
    }

    // Start is called before the first frame update
    void Start()
    {
        HP = 1.0f;
        TargetHP = 1.0f;
        HealCharges = 1;
        GameController = GameObject.Find("EncounterController");
    }

    // Update is called once per frame
    void Update()
    {
        if (Healing)
        { 
            if(TargetHP < HP)
            {
                TargetHP += 0.001f;
            }
            if(TargetHP == HP)
            {
                Healing = false;
            }
        }

        if (Damaging)
        {
            if(TargetHP > HP)
            {
                TargetHP -= .001f;
            }
            if (TargetHP == HP)
            {
                Damaging = false;
            }
        }

        HealthBar.GetComponent<Slider>().value = TargetHP;
        
        if(HP <= 0)
        {
            GameController.SendMessage("EnemyKilled");
            Dialogue.GetComponent<TextMeshProUGUI>().text = "The Slime Has Been Defeated!!!";
        }

        switch (State)
        {
            case States.Inactive:
                break;

            case States.Idle:
                delay++;
                if (delay > 480)
                {
                    if(HP < .5f)
                    {
                        if(HealCharges > 0)
                        {
                            Heal();
                            State = States.Acting;
                            delay = 0;
                            break;
                        }
                        else
                        {
                            Escape();
                            State = States.Acting;
                            delay = 0;
                            break;
                        }
                    }
                    else
                    {
                        Attack();
                        State = States.Acting;
                        delay = 0;
                        break;
                    }
                    
                }
                break;

            case States.Acting:
                delay++;
                if (delay > 980)
                {
                    State = States.Finished;
                    delay = 0;
                }
                break;

            case States.Finished:
                Highlighter.SetActive(false);
                ClearDialogue();
                State = States.Inactive;
                GameController.SendMessage("StateFinished");
                break;

            default:
                break;
        }
    }

    void IncomingDamage()
    {
        //temp set damage amount
        Damaging = true;
        HP -=.25f;
    }
    void Attack() 
    {
        State = States.Acting;
        mAnimator.SetBool("StartAttack", true);
        Dialogue.GetComponent<TextMeshProUGUI>().text = "The Slime Spits Acid At You.";
    }
    void EndAttack() 
    {
        mAnimator.SetBool("StartAttack", false); 
    }
    void Heal()
    {
        mAnimator.SetBool("StartHeal", true);
        Dialogue.GetComponent<TextMeshProUGUI>().text = "The Slime Oozes A Healing Substance.";
        HealCharges--;
    }
    void EndHeal()
    {
        mAnimator.SetBool("StartHeal", false);
        HP += .15f;
        Healing = true;
    }
    void Escape() 
    {
        mAnimator.SetBool("StartEscape", true);
        Dialogue.GetComponent<TextMeshProUGUI>().text = "The Slime Tries To Run.";
    }
    void EndEscape()
    {
        mAnimator.SetBool("StartEscape", false); 
    
    }

    void ClearDialogue()
    {
        Dialogue.GetComponent<TextMeshProUGUI>().text = "";
    }

}
