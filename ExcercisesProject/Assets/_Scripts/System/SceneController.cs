using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private enum States { ChangingScene, Transitioning, Idle, SceneLoaded};
    private States State = States.Idle;
    
    public bool ChangeReady;
    private int SceneDestination;
    private GameObject FadePanel;
    // Start is called before the first frame update
    private void Awake()
    {
     //   DontDestroyOnLoad(this);
    }
    void Start()
    {
        SceneDestination = 0;
        FadePanel = GameObject.FindGameObjectWithTag("FadePanel");
    }

    // Update is called once per frame
    void Update()
    {
        switch(State)
        {
            case States.ChangingScene:
                SceneManager.LoadScene(SceneDestination);
                State = States.Idle;
                ChangeReady = false;
                break;
            case States.Transitioning:
                if (ChangeReady)
                {
                    State = States.ChangingScene;
                }
                break;
            case States.SceneLoaded:
                
                break;
            case States.Idle:

                break;

            default:
                break;
                
        }


    }

    void MoveToOverworld()
    {
        SceneDestination = 1;
        State = States.Transitioning;
    }

    void MoveToMainMenu()
    {
        SceneDestination = 0;
        State = States.Transitioning;
    }

    void MoveToEncounter()
    {
        SceneDestination = 2;
        State = States.Transitioning;
    }
}
