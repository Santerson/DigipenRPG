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
    [SerializeField] GameObject wallPrefab;
    [SerializeField] TextMeshProUGUI PlayerHealthDisplay;
    [SerializeField] TextMeshProUGUI EnemyHealthDisplay;
    [SerializeField] TextMeshProUGUI PLayerLog;
    [SerializeField] TextMeshProUGUI EnemyLog;
    [SerializeField] int PlayerMissChance = 10;
    [SerializeField] int PlayerDamageMin = 1;
    [SerializeField] int PlayerDamageMax = 2;
    [SerializeField] int SpecialMoveMulti = 2;
    [SerializeField] int RecoilDamage = 2;
    int EnemyHealth = 3;
    public int EnemiesFought = 0;
    private int SoulsReaped = 0;
    private int PlayerAction;
    private int EnemyAction;
    GameObject enemy = null;
    
    

    // Start is called before the first frame update
    
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// The main attack loop
    /// </summary>
    public void Attack()
    {
        float random = Random.Range(1, 100);
        if (random <= PlayerMissChance)
        {
            //MISS
            PlayerAction = 0;
        }
        else if (random >= 90)
        {
            //CRITICAL
            PlayerAction = 2;
        }
        else
        {
            //NORMAL HIT
            PlayerAction = 1;
        }
        EnemyTurn(); 
    }

    public void Block()
    {
        //BLOCK
        PlayerAction = 3;
        EnemyTurn();
    }

    public void Special()
    {
        int SpecialMoveRoll = (Random.Range(PlayerDamageMin, PlayerDamageMax)) * 2;
        EnemyHealth = EnemyHealth - SpecialMoveRoll;
        Debug.Log("You used speical attack for" + SpecialMoveRoll + " damage and took " + RecoilDamage);
        PLayerLog.SetText("You used speical attack for" + SpecialMoveRoll + " damage and took " + RecoilDamage);
        EnemyTurn();
    }

    void EnemyTurn()
    {
        float random = Random.Range(1, 100);
        if (random <= 10)
        {
           //MISS
           EnemyAction = 0;
        }
        else if (random <= 70)
        {
            //NORMAL ATTACK
            EnemyAction = 1;
            
            
        }
        else if (random > 80)
        {
            //BLOCK
            EnemyAction = 3;
        }
        else
        {
            //CRIT
            EnemyAction = 2;
        }
        CalculateAction();
    }

    private void CalculateAction()
    {
        if (PlayerAction == 0)
        {
            Debug.Log("You Missed!");
            PLayerLog.SetText("You Missed!");
        }
        else if (PlayerAction == 1)
        {
            if (EnemyAction != 3)
            {
                int DamageRoll = Random.Range(PlayerDamageMin, PlayerDamageMax);
                Debug.Log("You attacked enemy for " + DamageRoll + " damage");
                PLayerLog.SetText("You hit for " + DamageRoll + " damage");
                EnemyHealth = EnemyHealth - DamageRoll;
                UpdateHealth();
            }
            else
            {
                PLayerLog.SetText("Enemy Blocked!");
            }
        }
        else if (PlayerAction == 2)
        {
            if (EnemyAction != 3)
            {
                int DamageRoll = Random.Range(PlayerDamageMin, PlayerDamageMax) * 2;
                Debug.Log("You attacked enemy for " + DamageRoll + " damage");
                PLayerLog.SetText("CRITICAL! You hit for " + DamageRoll + " damage");
                EnemyHealth = EnemyHealth - DamageRoll;
                UpdateHealth();
            }
            else
            {
                PLayerLog.SetText("Enemy Blocked!");
            }
        }
        else if (PlayerAction == 3)
        {
            PLayerLog.SetText("You Blocked!");
            Debug.Log("You Blocked");
        }

        if (EnemyAction == 0)
        {
            EnemyLog.SetText("Enemy Missed!");
        }
        else if (EnemyAction == 1)
        {
            if (PlayerAction != 3)
            {
                PlayerHealth--;
                UpdateHealth();
                Debug.Log("Enemy attacked you for 1 damage");
                EnemyLog.SetText("Enemy hit for 1 damage");
            }
            else
            {
                Debug.Log("Enemy attack was blocked!");
                EnemyLog.SetText("Enemy attack was blocked!");
            }
        }
        else if (EnemyAction == 2)
        {
            if (PlayerAction != 3)
            {
                PlayerHealth--;
                PlayerHealth--;
                UpdateHealth();
                Debug.Log("CRITICAL! Enemy attacked you for 2 damage");
                EnemyLog.SetText("CRITICAL! Enemy attacked you for 2 damage");
            }
            else
            {
                Debug.Log("CRITCAL BLOCKED! Enemy attack was blocked!");
                EnemyLog.SetText("CRITCAL BLOCKED! Enemy attack was blocked!");
            }
        }
        else if (EnemyAction == 3) 
        {
            Debug.Log("Enemy Blocked");
            EnemyLog.SetText("Enemy Blocked!");
        }

        if (EnemyHealth <= 0)
        {

            EndBattle();
        }

        if (PlayerHealth <= 0)
        {
            SceneManager.LoadScene("You Suck");
            FindObjectOfType<CanvasChecker>().hide();
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
        if (EnemiesFought == 2)
        {
            EnemyHealth = 5;
        }
        else
        {
            EnemyHealth = 3;
        }

        UpdateHealth();
        FindObjectOfType<CanvasChecker>().show();
        Debug.Log("Battle Start");
    }

    public void EndBattle()
    {
        FindObjectOfType<CanvasChecker>().hide();
        EnemiesFought++;
        if (EnemiesFought == 3)
        {
            //WIN THE GAME
            Debug.Log("All enemies have been slain");
            SceneManager.LoadScene("EndScreen");
        }
        else
        {
            ++SoulsReaped;
            SceneManager.LoadScene("TheMaze");
        }
    }

    public void resetHP()
    {
        if (SoulsReaped > 1)
        {
            PlayerHealth = 10;
        }
    }
}

