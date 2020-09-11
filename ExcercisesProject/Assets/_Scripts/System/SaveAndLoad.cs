using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
  void LoadData()
    {
        this.transform.position = new Vector3
            (PlayerPrefs.GetFloat("posX"), 
            PlayerPrefs.GetFloat("posY"), 
            0);
    }

  void SaveData()
    {
        PlayerPrefs.SetFloat("posX", this.transform.position.x);
        PlayerPrefs.SetFloat("posY", this.transform.position.y);
    }
}
