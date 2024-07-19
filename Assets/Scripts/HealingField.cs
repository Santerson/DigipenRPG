using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingField : MonoBehaviour
{
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
        FindObjectOfType<TurnBasedCombat>().resetHP();
        Debug.Log("Reset HP");
    }
}
