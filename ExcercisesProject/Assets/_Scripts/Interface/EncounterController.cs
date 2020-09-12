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

    private GameObject PlayerCharacter, EnemyAi;


    [SerializeField]
    private int DelayBetweenActions; private int Delay; 

    private enum States
    {
        Intro, 
        PlayerTurn, AiTurn,
        PlayerDied, Victory, Escaped
    }
    private States State;

    void Start()
    {
        EnemyAi = GameObject.Find("EnemyA");
        PlayerCharacter = GameObject.Find("PlayerChar");
        State = States.Intro;
    }
    
    //Incoming Messages
    void StateFinished()  {StateCompleted = true; StateInitiated = false; }
    void EnemyKilled() { State = States.Victory; }
    void PlayerDied() { State = States.PlayerDied; }
    
    //Outgoing Messages
    void StartEnemyTurn() 
    {
        EnemyAi.SendMessage("StartTurn");
        
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
                        StartEnemyTurn();
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
