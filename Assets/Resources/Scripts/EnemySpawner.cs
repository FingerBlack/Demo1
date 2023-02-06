using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public List<GameObject> resourcePrefab;
    public GameObject root;
    public float spawnRange = 10f;
    public float spawnGap;
    public int numPerSpawn = 10;
    public int minBlockPerSide = 10;
    public int blockSizeIncreaseRate = 2;


    private float lowBound ;
    private float highBound ;
    //private float resourceBlockLength = 0;
    //public float originalHP;
    public int level;
    public List<float> nodeLevels;
    public List<int> HPLevels;
    public List<int> NumberLevels;
    public List<float> DamageLevels;
    public Vector2 Debug;
    public int count;
    public float angle;
    public float x;
    public float y;
    public float TimeCount=0f;
    // Start is called before the first frame update
    void Start()
    {
        spawnGap = 2f;
        //resourceBlockLength = 0.1f;
        level=0;
        nodeLevels=new List<float>{5f,10f,15f,20f,25f,30f,40f,50f,60f,70f,80f,90f,100f};
        HPLevels=new List<int>{ 100, 100, 125,150,170,170,170,170,170,170,200,200,250,300};
        NumberLevels=new List<int>{ 4, 8, 16,25,32,38,42,48,55,63,72,84,96,100};
        DamageLevels=new List<float>{ 0.3f, 0.3f, 0.3f, 0.3f, 0.3f, 0.3f, 0.3f , 0.3f , 0.3f, 0.3f, 0.3f, 0.3f, 0.3f, 0.3f };
    }

    // Update is called once per frame
    void Update()
    {
        

        if(!GameObject.Find("OverAll").GetComponent<Overall>().ifstart){
            return;
        }
        count=0;
        TimeCount+=Time.deltaTime;
        for (int count =0; count<nodeLevels.Count;count++){
            
            if(TimeCount>nodeLevels[count]*10f){
                //Debug=new Vector2(GameObject.Find("Roots").GetComponent<RootGrowup>().Total,count);
                level=count;
            }
            
        }
       
        lowBound=GameObject.Find("Roots/Light 2D").GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius+2f;
        if (GameObject.Find("Enemies").transform.childCount<NumberLevels[level]/3)
        {
            // spawn n obj per hollow
            numPerSpawn=NumberLevels[level];
            int n = numPerSpawn;
            float directionRange=Random.Range(0f,5f);
            while (n > 0)
            {
                x = 0;
                y = 0;
                //float dist = 0;

                // check if in hollow

                // x=lowBound*Mathf.Sin(Random.Range(0f,360f));
                // y=lowBound*Mathf.Cos(Random.Range(0f,360f));
                
                angle=Random.Range(directionRange* 1/3f*Mathf.PI,directionRange*1/3f*Mathf.PI+1/3f*Mathf.PI);
                //angle=0;
                x=Random.Range(lowBound,lowBound+2f)*Mathf.Sin(angle);
                y=Random.Range(lowBound,lowBound+2f)*Mathf.Cos(angle);
                //spawn resourse
                //GameObject Resource = GameObject.Find("/++)
                // {
                //     for (int j = 0; j < minBlockPerResource");
                // for(int i = 0; i < minBlockPerSide; iSide; j++)
                //     {
                int element=Random.Range(0,3);
                GameObject obj = Instantiate(resourcePrefab[element], root.transform.position + new Vector3(x, y, 0), Quaternion.identity,GameObject.Find("/Enemies").transform) as GameObject;
                obj.GetComponent<Enemy>().HP=HPLevels[level];
                obj.GetComponent<Enemy>().damage=DamageLevels[level];
                    //}
                //}
                //GameObject obj = Instantiate(resorsePrefeb, roots.transform.position + new Vector3(x, y, 0), Quaternion.identity) as GameObject;


                //Debug.Log("spawned at: " + x + " " + y);
                n--;
            }
            // level+=1;
        }
    }
}