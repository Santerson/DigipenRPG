using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hide()
    {
        Debug.Log("hiding ui");
        GameObject.Find("AttackButton").GetComponent<Image>().color = new Color(128, 0, 64, 0);
        GameObject.Find("BlockButton").GetComponent<Image>().color = new Color(85, 205, 173, 0);
        GameObject.Find("AttackText").GetComponent<TextMeshProUGUI>().text = "";
        GameObject.Find("BlockText").GetComponent<TextMeshProUGUI>().text = "";
        GameObject.Find("PlayerHealth Text").GetComponent<TextMeshProUGUI>().text = "";
        GameObject.Find("EnemyHealth Text").GetComponent<TextMeshProUGUI>().text = "";
        GameObject.Find("PlayerLog").GetComponent<TextMeshProUGUI>().text = "";
        GameObject.Find("EnemyLog").GetComponent<TextMeshProUGUI>().text = "";
    }

    public void show()
    {
        Debug.Log("showing ui");
        GameObject.Find("AttackButton").GetComponent<Image>().color = new Color(64, 64, 64, 0.3f);
        GameObject.Find("BlockButton").GetComponent<Image>().color = new Color(85, 205, 173, 0.6f);
        GameObject.Find("AttackText").GetComponent<TextMeshProUGUI>().text = "Attack";
        GameObject.Find("BlockText").GetComponent<TextMeshProUGUI>().text = "Block";
        FindObjectOfType<TurnBasedCombat>().UpdateHealth();
    }
}
