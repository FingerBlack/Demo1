using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public GameObject root;
    public float speed;
    public bool flag;
    void Start()
    {
        flag=false;
        speed=1f;
        root=GameObject.Find("/Roots/Root");
    }

    // Update is called once per frame
    void Update()
    {
        if(flag){
            
            float dis=Vector3.Distance(transform.position,target.transform.position);
            transform.position=Vector3.MoveTowards(transform.position,target.transform.position,speed*Time.deltaTime);
            if(dis<0.01f&&target!=root){
                target=target.transform.parent.gameObject.GetComponent<Edge>().start;

            }else
            if(dis<0.01f&&target==root){
                root.transform.parent.gameObject.GetComponent<RootGrowup>().resourcesCount+=1;
                Destroy(gameObject);
            }
        }else{
            ContactFilter2D filter = new ContactFilter2D().NoFilter();
            List<Collider2D> results = new List<Collider2D>();
            Physics2D.OverlapCircle(transform.position, 0.01f,filter,results);
            //Debug.Log(Input.mousePosition);
            //bool flag=false;

            foreach( Collider2D result in results)
            {
                //Debug.Log(result.gameObject);
                if(result.gameObject.TryGetComponent<Edge>(out Edge Edge)){
                    // float dis=Vector3.Distance((edge.start.transform.position+edge.end.transform.position)/2.0f,Camera.main.ScreenToWorldPoint(Input.mousePosition));
                    // dis-=30f;
                    target=Edge.start; 
                    flag=true;
                  
                }
            }
        }
        
            
    }
}
