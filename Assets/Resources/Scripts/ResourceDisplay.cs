using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ResourceDisplay : MonoBehaviour
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
        string txt="Resource: "+GameObject.Find("Roots").GetComponent<RootGrowup>().resourcesCount.ToString();
        m_TextComponent.text=txt;
        
    }
}
