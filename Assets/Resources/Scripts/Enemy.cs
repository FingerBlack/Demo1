using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject root;
    public float speed;
    public float originalspeed;
    public float HP;
    public float damage;
    public ContactFilter2D filter;
    public List<Collider2D> results;
    void Start()
    {
        originalspeed=0.4f;
        speed=originalspeed;
        HP=10f;
        filter = new ContactFilter2D().NoFilter();
        root=GameObject.Find("Roots/Root");
        //results = new List<Collider2D>();
        //filter.SetLayerMask(LayerMask.GetMask("Bullets","Edges"));
        // setLayerMask();
    }
    // static void setLayerMask()
    // {   
    //     ContactFilter2D.useLayerMask=true;
    //     // Write static logic for setTextboxText.  
    //     // This may require a static singleton instance of Form1.
    // }
    // Update is called once per frame
    void Update()
    {
        transform.position=Vector3.MoveTowards(transform.position,root.transform.position,speed*Time.deltaTime);

        Physics2D.OverlapCircle(transform.position, 0.01f,filter,results);
        //Debug.Log(Input.mousePosition);
        //bool flag=false;

        foreach( Collider2D result in results)
        {
            
            if(result.gameObject.TryGetComponent<Edge>(out Edge Edge)){
                // float dis=Vector3.Distance((edge.start.transform.position+edge.end.transform.position)/2.0f,Camera.main.ScreenToWorldPoint(Input.mousePosition));
                // dis-=30f;
               Debug.Log(result.gameObject);
               if(result.GetComponent<Edge>().HP>damage){
                    result.GetComponent<Edge>().HP-=damage;
                    speed=0f;
                }
                else{
                    speed=originalspeed;        
                }
            }else
            if(result.gameObject.TryGetComponent<bullet>(out bullet bul)){
                //Debug.Log(result.gameObject);
                Destroy(result.gameObject);
                HP-=3f;
                if(HP<0f){
                    Destroy(gameObject);
                }
            }
        }
        // if(){

        // }
    }
}
