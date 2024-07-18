using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TurnBasedCombat : MonoBehaviour
{
    [SerializeField] int PlayerHealth = 10;
    
    [SerializeField] TextMeshProUGUI PlayerHealthDisplay;
    [SerializeField] TextMeshProUGUI EnemyHealthDisplay;
    [SerializeField] int PlayerMissChance = 10;
    [SerializeField] int PlayerDamageMin = 1;
    [SerializeField] int PlayerDamageMax = 2;
    [SerializeField] int SpecialMoveMulti = 2;
    [SerializeField] int RecoilDamage = 2;
    int EnemyHealth = 3;
    int EnemiesFought = 0;
    GameObject enemy = null;
    
    

    // Start is called before the first frame update
    
    
    void Start()
    {
        StartBattle();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Attack()
    {
        if (Random.Range(1, 100) <= PlayerMissChance)
        {
            Debug.Log("You Missed!");
            
        }
        else
        {
            int DamageRoll = Random.Range (PlayerDamageMin, PlayerDamageMax);
            Debug.Log("You attacked enemy for " + DamageRoll + " damage");
            EnemyHealth = EnemyHealth - DamageRoll;
            UpdateHealth();
        }


        if (EnemyHealth <= 0)
        {
            EndBattle();
        }
        else { EnemyTurn(0); }
        
        
    }

    public void Block()
    {
        Debug.Log("You Blocked");
        EnemyTurn(1);
    }

    public void Special()
    {
        int SpecialMoveRoll = (Random.Range(PlayerDamageMin, PlayerDamageMax)) * 2;
        EnemyHealth = EnemyHealth - SpecialMoveRoll;
        Debug.Log("You used speical attack for" + SpecialMoveRoll + " damage and took " + RecoilDamage);
        EnemyTurn(0);
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
    public void UpdateHealth()
    {
        
        EnemyHealthDisplay.text = ("Enemy Health:" + EnemyHealth);
        PlayerHealthDisplay.text = ("Player Health: " + PlayerHealth);
    }
    private void Awake()
    {
        TurnBasedCombat[] objs = FindObjectsOfType<TurnBasedCombat>();

        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    public void SetEnemyHealth(int health)
    {
        int EnemyHealth = (int)health;
        return;
    }

    public void StartBattle()
    {
        UpdateHealth();
        FindObjectOfType<CanvasChecker>().show();
        Debug.Log("Battle Start");
        if (EnemiesFought == 2)
        {
            EnemyHealth = 5;
        }
        else
        {
            EnemyHealth = 3;
        }
    }

    public void EndBattle()
    {
        FindObjectOfType<CanvasChecker>().hide();
        SceneManager.LoadScene("TheMaze");
    }
}

