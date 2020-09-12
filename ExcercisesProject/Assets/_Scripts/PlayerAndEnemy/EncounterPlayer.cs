using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EncounterPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject Highlighter, Dialogue;

    [SerializeField]
    private Animator mAnimator;

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

    void Attack() 
    {
        State = States.Acting;
        mAnimator.SetBool("StartAttack", true);
        Dialogue.GetComponent<TextMeshProUGUI>().text = "You Attack The Slime!!";
    }
    void EndAttack() 
    {
        mAnimator.SetBool("StartAttack", false);
    }
    void Defend() 
    {
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
        State = States.Acting;
        mAnimator.SetBool("StartStruggle", true);
        Dialogue.GetComponent<TextMeshProUGUI>().text = "You Attempt A Rear Naked Choke.";
    }
    void EndStruggle() 
    {
        mAnimator.SetBool("StartStruggle", false);
    }
    void Escape() 
    {
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
