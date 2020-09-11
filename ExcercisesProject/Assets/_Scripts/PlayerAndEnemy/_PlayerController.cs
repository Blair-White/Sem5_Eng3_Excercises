﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _PlayerController : MonoBehaviour
{
    public bool inEncounterTiles, lockPlayer;
    private Rigidbody2D mRig;
    public float mSpeed;
    public float EncounterRate;
    private float EncounterRng;
    private int EncounterThrottle;
    private GameObject FadePanel;
    // Start is called before the first frame update
    void Start()
    {
        this.SendMessage("LoadData");
        EncounterRate = 0.998f;
        mRig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
  
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hAxis, vAxis, 0) * mSpeed * Time.deltaTime;
        if(!lockPlayer)
        mRig.MovePosition(transform.position + movement);

        if (hAxis > 0 || vAxis > 0)
        {
            EncounterThrottle++;
            if(inEncounterTiles&&EncounterThrottle>7)
            {
                EncounterRng = Random.value;
                EncounterThrottle = 0;
                if (EncounterRng > EncounterRate)
                {
                    EncounterRng = 0;
                    FadePanel = GameObject.FindGameObjectWithTag("FadePanel");
                    FadePanel.SendMessage("FadeOutNow");
                    lockPlayer = true;
                    this.SendMessage("SaveData");
                    GameObject sManager = GameObject.Find("SceneController");
                    sManager.SendMessage("MoveToEncounter");
                }
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EncounterTile")
        {
            inEncounterTiles = false;
        }   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EncounterTile")
        {
            inEncounterTiles = true;
        }
    }
}
