using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    private TMP_Text m_TextComponent;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_TextComponent = GetComponent<TMP_Text>();
        double mainGameTimerd = 1200-(double)GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().TimeCount;
        TimeSpan time = TimeSpan.FromSeconds(mainGameTimerd);
        string displayTime = time.ToString(@"mm\:ss");
        string txt="Timer: "+(displayTime);
        m_TextComponent.text=txt;
        
    }
}
