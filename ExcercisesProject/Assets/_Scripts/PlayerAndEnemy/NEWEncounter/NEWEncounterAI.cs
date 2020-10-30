using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NEWEncounterAI : MonoBehaviour
{
    public GameObject EncounterController;
    public GameObject MyHealthBar;
    private Image Fill;
    private float health = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        Fill = MyHealthBar.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Fill.fillAmount < health)
        {
            Fill.fillAmount += 0.01f;
        }
        if(Fill.fillAmount > health)
        {
            Fill.fillAmount -= 0.01f;
        }

    }

    void EndAnimation()
    {
        EncounterController.SendMessage("EndEnemyAnimation");
    }

    void TakeDamage(float dmg)
    {
        if (dmg < 0) return;
        health -= dmg;
    }

    void Heal(float dmg)
    {
        health += dmg;
    }
}
