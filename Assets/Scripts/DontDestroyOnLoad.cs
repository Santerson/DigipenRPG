using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        DontDestroyOnLoad[] objs = FindObjectsOfType<DontDestroyOnLoad>();

        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void StartBattle()
    {
        Debug.Log("Started Battle");
        FindObjectOfType<TurnBasedCombat>().StartBattle();
    }
}