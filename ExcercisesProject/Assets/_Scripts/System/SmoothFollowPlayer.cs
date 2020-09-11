using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollowPlayer : MonoBehaviour
{
    private float Speed;
    private GameObject mPlayer;
    // Start is called before the first frame update
    void Start()
    {
        mPlayer = GameObject.Find("PlayerCharacter");
        Speed = 0.002f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp
            (transform.position, mPlayer.transform.position, Speed);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
