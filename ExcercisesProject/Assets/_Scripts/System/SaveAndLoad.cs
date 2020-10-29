using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    //This is how we know which abilities should be in each slot
    //It is related to the Master List array of ability objects. 
    //For example, if Abilities_1 = 0 then the first ability the player
    //has is BasicAttack. 
    private int Ability_1, Ability_2, Ability_3, Ability_4;
    private float _EXP; // our current exp 0-1;
    private int _Level; // Current level of the character
    private float _Health; //Current HP 0-1; 
    private float _Defense; //Way to modify incoming dmg to simulate hp increase each lvl. 


  void LoadData()
    {
        transform.position = new Vector3 (PlayerPrefs.GetFloat("posX"), PlayerPrefs.GetFloat("posY"), 0);
        Ability_1 = PlayerPrefs.GetInt("Ability_1");
        Ability_2 = PlayerPrefs.GetInt("Ability_2");
        Ability_3 = PlayerPrefs.GetInt("Ability_3");
        Ability_4 = PlayerPrefs.GetInt("Ability_4");
        _EXP = PlayerPrefs.GetFloat("_EXP");
        _Health = PlayerPrefs.GetFloat("_Health");
        _Level = PlayerPrefs.GetInt("_Level");
        _Defense = PlayerPrefs.GetFloat("_Defense");
    }

  void SaveData()
    {       
        
    }

  void SavePosition()
    {
        PlayerPrefs.SetFloat("posX", this.transform.position.x);
        PlayerPrefs.SetFloat("posY", this.transform.position.y);
    }
  void SaveAbilities()
    {
        PlayerPrefs.SetInt("Ability_1", Ability_1);
        PlayerPrefs.SetInt("Ability_2", Ability_2);
        PlayerPrefs.SetInt("Ability_3", Ability_3);
        PlayerPrefs.SetInt("Ability_4", Ability_4);
    }
  
  void SavePlayerStats()
    {
        PlayerPrefs.SetFloat("_EXP", _EXP);
        PlayerPrefs.SetFloat("_Health", _Health);
        PlayerPrefs.SetInt("_Level", _Level);
        PlayerPrefs.SetFloat("_Defense", _Defense);
    }
}
