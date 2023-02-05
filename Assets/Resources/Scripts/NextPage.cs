using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NextPage : MonoBehaviour
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
        GameObject.Find("PageControl").GetComponent<PageControl>().HomePage.SetActive(false);
        GameObject.Find("PageControl").GetComponent<PageControl>().Page1.SetActive(true);
    }
}
