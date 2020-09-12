using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject Highlighter, Dialogue;

    [SerializeField]
    private Animator mAnimator;
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

    void Attack() { mAnimator.SetBool("StartAttack", true); }
    void EndAttack() { mAnimator.SetBool("StartAttack", false); }
    void Defend() { mAnimator.SetBool("StartDefend", true); }
    void EndDefend() { mAnimator.SetBool("StartDefend", false); }
    void Struggle() { mAnimator.SetBool("StartStruggle", true); }
    void EndStruggle() { mAnimator.SetBool("StartStruggle", false); }
    void Escape() { mAnimator.SetBool("StartEscape", true); }
    void EndEscape() { mAnimator.SetBool("StartEscape", false); }

}
