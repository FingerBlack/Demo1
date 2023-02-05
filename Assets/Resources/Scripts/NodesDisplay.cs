using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NodesDisplay : MonoBehaviour
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
         string txt="Node: "+GameObject.Find("Roots").GetComponent<RootGrowup>().Total.ToString()+"/200";
         m_TextComponent.text=txt;
        
    }
}
