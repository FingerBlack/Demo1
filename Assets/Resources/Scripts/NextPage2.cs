using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NextPage2 : MonoBehaviour
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
        GameObject.Find("PageControl").GetComponent<PageControl>().Page2.SetActive(false);
        GameObject.Find("PageControl").GetComponent<PageControl>().Page3.SetActive(true);
        
    }
}
