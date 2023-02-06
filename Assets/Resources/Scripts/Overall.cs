using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Overall : MonoBehaviour
{
    // Start is called before the first frame update
    public bool ifstart=false;

    void Start()
    {
        ifstart=false;
        Screen.SetResolution(1920,1080,false);

    }

    // Update is called once per frame
    void Update()
    {   

        if(ifstart){
            if(GameObject.Find("Roots").GetComponent<RootGrowup>().Total>=100){
                ifstart=false;
                GameObject.Find("PageControl").GetComponent<PageControl>().ValueDisplay.SetActive(false);
                GameObject.Find("PageControl").GetComponent<PageControl>().Page6.SetActive(true);
        //GameObject.Find("PageControl").GetComponent<PageControl>().Page7.SetActive(true);
            }
            if(GameObject.Find("Roots").GetComponent<RootGrowup>().HP<0){
                ifstart=false;
                GameObject.Find("PageControl").GetComponent<PageControl>().ValueDisplay.SetActive(false);
                GameObject.Find("PageControl").GetComponent<PageControl>().Page7.SetActive(true);
        //GameObject.Find("PageControl").GetComponent<PageControl>().Page7.SetActive(true);
            }
            
        }
    }
}
