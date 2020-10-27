using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class EncounterController : MonoBehaviour
{
    private bool StateInitiated, StateCompleted;
     
    [SerializeField]
    float StruggleSuccessRate;

    [SerializeField]
    private GameObject DialogueText, AbilityButtons;

    private GameObject PlayerCharacter, EnemyAi, FadePanel, SceneController;


    [SerializeField]
    private int DelayBetweenActions = 0; 
    [SerializeField]
    private int Delay; 

    public enum States
    {
        Intro, 
        PlayerTurn, AiTurn,
        PlayerDied, Victory, Escaped
    }
    public States State;

    void Start()
    {
        EnemyAi = GameObject.Find("EnemyA");
        PlayerCharacter = GameObject.Find("PlayerChar");
        FadePanel = GameObject.Find("Fading Panel");
        SceneController = GameObject.Find("SceneController");
        State = States.Intro;
    }
    
    //Incoming Messages
    void StateFinished()  {StateCompleted = true; }
    void EnemyKilled() 
    {
        State = States.Victory;
        PlayerCharacter.GetComponent<EncounterPlayer>().State = EncounterPlayer.States.Inactive;
        AbilityButtons.SetActive(false);
        StateInitiated = false;
        StateCompleted = false;
    }
    void PlayerDied() { State = States.PlayerDied; }
    
    //Outgoing Messages
    void StartEnemyTurn() 
    {
        EnemyAi.SendMessage("StartTurn");
        AbilityButtons.SetActive(false);
    }
    void StartPlayerTurn() 
    {
        PlayerCharacter.SendMessage("StartTurn");
        AbilityButtons.SetActive(true);
    }

    void Update()
    {

        switch (State)
        {
            case States.Intro:
                if (!StateInitiated)
                {
                    Delay++;
                    if(Delay > DelayBetweenActions)
                    {
                        Delay = 0;
                        StateInitiated = true;
                    }
                    
                }
                else
                if (!StateCompleted)
                {
                    StateCompleted = true;
                }
                else
                { 
                    State = States.PlayerTurn;
                    StateCompleted = false;
                    StateInitiated = false;
                }
                
                break;

            case States.PlayerTurn:
                if(!StateInitiated)
                {
                    Delay++;
                    if(Delay > DelayBetweenActions)
                    {
                        Delay = 0;
                        StartPlayerTurn();
                        StateInitiated = true;
                        StateCompleted = false;
                    }
                }
                else
                {
                    if (StateCompleted)
                    {
                        State = States.AiTurn;
                        StateCompleted = false;
                        StateInitiated = false;
                    }
                }
                break;

            case States.AiTurn:
                if (!StateInitiated)
                {
                    Delay++;
                    if (Delay > DelayBetweenActions)
                    {
                        Delay = 0;
                        StateInitiated = true;
                        StartEnemyTurn();
                    }
                }
                else
                {
                    if (StateCompleted)
                    {
                        State = States.PlayerTurn;
                        StateInitiated = false;
                        StateCompleted = false;
                    }
                }
                break;

            case States.PlayerDied:
                if (!StateInitiated)
                {
                    Delay++;
                    if (Delay > DelayBetweenActions)
                    {
                        Delay = 0;
                        StateInitiated = true;
                        StateCompleted = false;
                    }
                }
                else
                {
                    if (StateCompleted)
                    {

                    }
                }
                break;

            case States.Victory:
                if (!StateInitiated)
                {
                    Delay++;
                    if (Delay > 1500)
                    {
                        Delay = 0;
                        StateInitiated = true;
                        StateCompleted = true;
                        Debug.Log("Ending Battle");
                        FadePanel.SendMessage("FadeOutNow");
                        SceneController.SendMessage("MoveToOverworld");
                    }
                }
                else
                {
                    if (StateCompleted)
                    {
                       
                    }
                }
                break;

            case States.Escaped:
                if (!StateInitiated)
                {
                    Delay++;
                    if (Delay > DelayBetweenActions)
                    {
                        Delay = 0;
                        StateInitiated = true;
                        StateCompleted = false;
                    }
                }
                else
                {
                    if (StateCompleted)
                    {

                    }
                }
                break;

            default:
                break;
        }
    }
}
