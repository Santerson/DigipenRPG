using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHitEnemy : MonoBehaviour
{
    [SerializeField] int EnemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Object TurnBasedCombat = FindObjectOfType<TurnBasedCombat>();
        SceneManager.LoadScene("Combat");
        FindObjectOfType<TurnBasedCombat>().SetEnemyHealth(EnemyHealth);
    }
}
