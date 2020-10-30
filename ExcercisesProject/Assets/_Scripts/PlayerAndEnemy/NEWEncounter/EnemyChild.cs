using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChild : MonoBehaviour
{
    private Color parentcolor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          
    
    }
    
    void LateUpdate()
    {
        parentcolor = transform.parent.GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = parentcolor;
    }
       
}
