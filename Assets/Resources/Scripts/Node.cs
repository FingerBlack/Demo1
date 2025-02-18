using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{   
    public GameObject children;
    public List<GameObject> Neighbors;
    public float total;
    public int resourceslimit;
    public int currentNodeamount = 0;
    // int[] nums = new int[] 
    public List<int> roots = new List<int>{ -60, 0, 60,120,-120,180};
    public List<int> Level = new List<int>{ 0, 3, 9,27,81,243,729,2187,6561,19683};
    public int timeCount=0;
    public int NodePrize=20;
    //public Dictionary<GameObject, float> posibility = new Dictionary<GameObject, float>();
    // Start is called before the first frame update
    void Start()
    {
        
        children = Resources.Load("Prefabs/children") as GameObject;
        if(Neighbors.Count==0){
            roots =new List<int>{ -30, 30, 90,150,-90,-150};
        }else{
            roots =new List<int>{ 0, 60, 120,-60,-120};
        }
        //Debug.Log(transform.parent);
        total=0f;
        timeCount=0;
        if(gameObject==GameObject.Find("Roots/Root")){
            Growth();
            Growth();
            Growth();
            Growth();
            Growth();
            Growth();
        }
    }

    // Update is called once per frame
    void Update()
    {   
        // resourceslimit=GameObject.Find("Roots").GetComponent<RootGrowup>().resourceslimit;
        // timeCount+=1;
        // int limit=GameObject.Find("Roots").GetComponent<RootGrowup>().Total;
        // if(limit>=resourceslimit)
        //     limit-=resourceslimit;
        
        // if(timeCount>limit*limit*6){
        //     Growth();
        //     timeCount=0;
        // }
        currentNodeamount = GameObject.Find("Roots").GetComponent<RootGrowup>().Total;
        NodePrize = Mathf.Max((int)(0.005 * currentNodeamount* currentNodeamount), 20);
        //NodePrize=GameObject.Find("Roots").GetComponent<RootGrowup>().Total;
        total=0;
        if(Neighbors.Count==0){
            return;
        }
        foreach (GameObject edge in Neighbors)
        {
            total+=edge.GetComponent<Edge>().possibility+Level[(int)edge.GetComponent<Edge>().guidline];
        }
    }
    public void Growth(){
            Quaternion b = new Quaternion(0, 0, 210, 210 );//rotation设置 
            
            Vector2 position = new Vector2( transform.position.x+1.5f, transform.position.y -1.0f);

            
            int element = Random.Range(0,roots.Count-1); 
            RootGrowup resources=GameObject.Find("Roots").GetComponent<RootGrowup>();
            if(roots.Count>0){
                if(gameObject!=GameObject.Find("Roots/Root")){

                    if(resources.resourcesCount>NodePrize){
                        resources.resourcesCount-=NodePrize;
                    }else{
                        return;
                    }
                    
                }
                GameObject child = GameObject.Instantiate(children, transform.position+new Vector3(0,0,-1),Quaternion.Euler(0, 0, roots[element]+transform.eulerAngles.z+Random.Range(-10f,10f)),transform) as GameObject;//transform.localPosition父亲坐标系
                RootGrowup rootGrowup =GameObject.Find("Roots").GetComponent<RootGrowup>();
                rootGrowup.Total+=1;
                UnityEngine.Rendering.Universal.Light2D light2d=GameObject.Find("Roots/Light 2D").GetComponent<UnityEngine.Rendering.Universal.Light2D>();
                float dis=Vector3.Distance(child.transform.position,GameObject.Find("Roots").transform.position);
                
                Neighbors.Add(child);
                child.GetComponent<Edge>().start=gameObject;
                child.GetComponent<Edge>().end=child.transform.GetChild(0).gameObject;
                child.GetComponent<Edge>().end.GetComponent<Node>().Neighbors.Add(child);
               // Debug.Log(transform.parent.gameObject.transform.eulerAngles.z);
                            // 数组转换为集合
                roots.RemoveAt(element);
            }
            


    }
}
