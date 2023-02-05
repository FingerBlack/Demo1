using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elves : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public GameObject enemyTarget;
    public Node node;
    public float speed;
    public List<int> Level = new List<int>{ 0, 3, 9,27,81,243,729,2187,6561,19683};
    //bool detectEnemy = false;
    Vector2 shootingDirection;
    public GameObject bullet;
    public float fireRate = 2f;
    float nextToSHoot = 0;
    public bool flag;
    public ContactFilter2D filter;
    public List<Collider2D> results;
    void Start()
    {
        flag=false;
        speed=1f;
        target=GameObject.Find("Roots/Root");
        node=target.GetComponent<Node>();
        filter = new ContactFilter2D().NoFilter();
        //filter.layerMask=LayerMask.GetMask("Edges","Elves","Resources","Bullets");
        //results = new List<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {   
        node=target.GetComponent<Node>();
        float dis=Vector3.Distance(transform.position,target.transform.position);

        if(dis>0.1f){
            transform.position=Vector3.MoveTowards(transform.position,target.transform.position,speed*Time.deltaTime);
        }else{

            
            int times=0;
            while(true){
                times++;
                if(times>100){
                    break;
                    
                }
                if(node.Neighbors.Count==0){
                    return;
                }
                int element = Random.Range(0,node.Neighbors.Count); 
                
                GameObject edge=node.Neighbors[element];
                float Dice =Random.Range(0f,1f);
                Edge e=edge.GetComponent<Edge>();
                //Debug.Log(element+" "+e.possibility/node.total);
                if(Dice <(e.possibility+Level[e.guidline])/node.total){
                    //Debug.Log(target+" "+e.start);
                    if(target!=e.start){
                        target=e.start;

                    }else{
                        target=e.end;
                    }
                    break;
                }
            }
        }
        // if(!enemyTarget){

        // }
        if(enemyTarget==null){
            flag=false;
        }
        if (flag)
        {
            //Debug.Log("shoot");
            if (nextToSHoot <= 0)
            {
                nextToSHoot = fireRate;
                GameObject bulletIns = Instantiate(bullet, transform.position, Quaternion.identity,GameObject.Find("Bullets").transform);
                Vector3 direction = (enemyTarget.transform.position - transform.position);
                bullet bulletComp = bulletIns.GetComponent<bullet>();
                bulletComp.target = enemyTarget;
                //bulletComp.speed = 1;
            }
            else
            {
                nextToSHoot -= Time.deltaTime;
            }
        }else{
            
            Physics2D.OverlapCircle(transform.position,2f,filter,results);
            foreach( Collider2D result in results)
            {
                //Debug.Log(result.gameObject);
                if(result.gameObject.TryGetComponent<Enemy>(out Enemy enemy)){
                    // float dis=Vector3.Distance((edge.start.transform.position+edge.end.transform.position)/2.0f,Camera.main.ScreenToWorldPoint(Input.mousePosition));
                    // dis-=30f;
                    enemyTarget=result.gameObject;
                    flag=true;
                }
            }
        }
        // shooing
        // Vector2 targetPos = targetEnemy.position;
        // shootingDirection = targetPos - (Vector2)transform.position;
        // RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, shootingDirection, range);

        // if(rayInfo.collider.gameObject.tag == "Enemy")
        // {
        //     Debug.Log("detected");
        //     detectEnemy = true;
        // }
        // else
        // {
        //     detectEnemy = false;
        // }
    }
}
