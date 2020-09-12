using System.Collections;
using System.Collections.Generic;
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

    private int delay;
    private bool Healing, Damaging;
    private int HealCharges;//0 Attack, 1 heal, 2 Escape;
    private float RNG, HP, TargetHP;
    
    //Incoming Messages
    void StartTurn()
    {
        Highlighter.SetActive(true);
        Dialogue.SetActive(false);
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
                TargetHP += 0.1f;
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
                TargetHP -= .01f;
            }
            if (TargetHP == HP)
            {
                Damaging = false;
            }
        }

        if(HP <= 0)
        {
            GameController.SendMessage("EnemyKilled");
        }

        switch (State)
        {
            case States.Inactive:
                break;

            case States.Idle:
                delay++;
                if (delay > 180)
                {
                    if(HP < .5f)
                    {
                        if(HealCharges > 0)
                        {
                            Heal();
                            State = States.Acting;
                        }
                        else
                        {
                            Escape();
                            State = States.Acting;
                        }
                    }
                    else
                    {
                        Attack();
                        State = States.Acting;
                    }
                    delay = 0;
                }
                break;

            case States.Acting:
                delay++;
                if (delay > 280)
                {
                    State = States.Finished;
                }
                break;

            case States.Finished:
                Highlighter.SetActive(false);
                ClearDialogue();
                State = States.Inactive;
                break;

            default:
                break;
        }
    }

    void IncomingDamage()
    {
        //temp set damage amount
        Damaging = true;
        HP -=.35f;
    }
    void Attack() 
    {
        State = States.Acting;
        mAnimator.SetBool("StartAttack", true); 
    }
    void EndAttack() 
    {
        State = States.Finished;
        mAnimator.SetBool("StartAttack", false); 
    }
    void Heal()
    {
        mAnimator.SetBool("StartHeal", true); 
    
    }
    void EndHeal()
    {
        mAnimator.SetBool("StartHeal", false); 
    
    }
    void Escape() 
    {
        mAnimator.SetBool("StartEscape", true); 
    
    }
    void EndEscape()
    {
        mAnimator.SetBool("StartEscape", false); 
    
    }

    void ClearDialogue()
    {
        Dialogue.GetComponent<Text>().text = "";
    }

}
