using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyablewalls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<TurnBasedCombat>().EnemiesFought == 2)
        {
            Destroy(gameObject);
        }
    }
}
