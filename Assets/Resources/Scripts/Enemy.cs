using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject root;
    public float speed;
    void Start()
    {
        speed=1f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=Vector3.MoveTowards(transform.position,root.transform.position,speed*Time.deltaTime);
        ContactFilter2D filter = new ContactFilter2D().NoFilter();
        List<Collider2D> results = new List<Collider2D>();
        Physics2D.OverlapCircle(transform.position, 0.01f,filter,results);
        //Debug.Log(Input.mousePosition);
        //bool flag=false;

        foreach( Collider2D result in results)
        {
            Debug.Log(result.gameObject);
            if(result.gameObject.TryGetComponent<Edge>(out Edge Edge)){
                // float dis=Vector3.Distance((edge.start.transform.position+edge.end.transform.position)/2.0f,Camera.main.ScreenToWorldPoint(Input.mousePosition));
                // dis-=30f;
               
               if(result.GetComponent<Edge>().HP>0.5f){
                    result.GetComponent<Edge>().HP-=0.5f;
                    speed=0f;
                }
                else{
                    speed=1f;        
                }
            }
        }
        // if(){

        // }
    }
}
