using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EncounterPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject Highlighter, Dialogue, EncounterEnemy, Buttons;

    private GameObject GameController;

    [SerializeField]
    private Animator mAnimator;

    [SerializeField]
    private AbilityMasterList AbilityList;

    public enum States { Inactive, Idle, Acting, Finished }
    public States State;

    private int delay;
    private float RNG;

    //Incoming Messages
    void StartTurn() 
    {
        Highlighter.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.Find("EncounterController");
        EncounterEnemy = GameObject.FindGameObjectWithTag("EncounterEnemy");
    }

    // Update is called once per frame
    void Update()
    {
        switch (State)
        {
            case States.Inactive:
                break;

            case States.Idle:
                break;

            case States.Acting:
                delay++;
                if (delay > 980)
                {
                    delay = 0;
                    State = States.Finished;
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

    void Attack() 
    {
        Buttons.SetActive(false);
        State = States.Acting;
        mAnimator.SetBool("StartAttack", true);
        Dialogue.GetComponent<TextMeshProUGUI>().text = "You Attack The Slime!!";
    }
    void EndAttack() 
    {
        mAnimator.SetBool("StartAttack", false);
        EncounterEnemy.SendMessage("IncomingDamage");
    }
    void Defend() 
    {
        Buttons.SetActive(false);
        State = States.Acting;
        mAnimator.SetBool("StartDefend", true);
        Dialogue.GetComponent<TextMeshProUGUI>().text = "You Brace For An Attack.";
    }
    void EndDefend() 
    {
        mAnimator.SetBool("StartDefend", false);
    }
    void Struggle()
    {
        Buttons.SetActive(false);
        State = States.Acting;
        mAnimator.SetBool("StartStruggle", true);
        Dialogue.GetComponent<TextMeshProUGUI>().text = "You Attempt A Rear Naked Choke";
    }
    void EndStruggle() 
    {
        mAnimator.SetBool("StartStruggle", false);
    }
    void Escape() 
    {
        Buttons.SetActive(false);
        State = States.Acting;
        mAnimator.SetBool("StartEscape", true);
        Dialogue.GetComponent<TextMeshProUGUI>().text = "You Try To Run Away.";
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
