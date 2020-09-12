using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterAi : MonoBehaviour
{
    [SerializeField]
    private GameObject Highlighter, Dialogue;

    //Incoming Messages
    void StartTurn()
    {
        Highlighter.SetActive(true);
        Dialogue.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
