using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HelpPage : MonoBehaviour
{
    // Start is called before the first frame update
    public int debug;
    //public Button StarGameButton;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnClick(){
        GameObject.Find("PageControl").GetComponent<PageControl>().HelpPage.SetActive(false);
        GameObject.Find("OverAll").GetComponent<Overall>().ifstart=true;
        GameObject.Find("PageControl").GetComponent<PageControl>().ValueDisplay.SetActive(true);
        //GameObject.Find("PageControl").GetComponent<PageControl>().Page6.SetActive(true);
    }
}
