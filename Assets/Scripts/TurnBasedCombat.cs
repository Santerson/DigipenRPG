using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnBasedCombat : MonoBehaviour
{
    [SerializeField] int PlayerHealth = 10;
    [SerializeField] int EnemyHealth = 5;
    [SerializeField] TextMeshProUGUI PlayerHealthDisplay;
    [SerializeField] TextMeshProUGUI EnemyHealthDisplay;
    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        Debug.Log("You attacked enemy for 1 damage");
        EnemyHealth--;
        
        if (EnemyHealth == 0)
        {
            //End Combat
        }
        else { EnemyTurn(0); }
        
        
    }

    public void Block()
    {
        Debug.Log("You Blocked");
        EnemyTurn(1);
    }

    void EnemyTurn(int action)
    {
        if (action == 0)
        {
            PlayerHealth--;
            UpdateHealth();
            Debug.Log("Enemy attacked you for 1 damage");
        }
        else if (action == 1)
        {
            Debug.Log("Enemy attack was blocked");
        }

    }
    void UpdateHealth()
    {
        EnemyHealthDisplay.text = ("Enemy Health:" + EnemyHealth);
        PlayerHealthDisplay.text = ("Player Health: " + PlayerHealth);
    }

}
