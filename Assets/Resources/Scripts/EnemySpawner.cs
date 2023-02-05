using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject resourcePrefab;
    public GameObject root;
    public float spawnRange = 10f;
    public float spawnGap;
    public int numPerSpawn = 10;
    public int minBlockPerSide = 10;
    public int blockSizeIncreaseRate = 2;


    private float lowBound ;
    private float highBound ;
    private float resourceBlockLength = 0;
    //public float originalHP;
    public int level;
    public List<int> nodeLevels;
    public List<int> HPLevels;
    public List<int> NumberLevels;
    public List<float> DamageLevels;
    public Vector2 Debug;
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        spawnGap = 2f;
        resourceBlockLength = resourcePrefab.transform.localScale.x;
        level=0;
        nodeLevels=new List<int>{5,10,15,20,25,30,40,50,60,70,80,90,100};
        HPLevels=new List<int>{ 20, 20, 20,20,20,20,20,20,20,20,20,20,20,20};
        NumberLevels=new List<int>{ 2, 4, 8,15,25,30,36,40,50,60,72,84,96,100};
        DamageLevels=new List<float>{ 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f , 0.5f , 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f };
    }

    // Update is called once per frame
    void Update()
    {
        
        count=0;
        
        for (int count =0; count<nodeLevels.Count;count++){
            
            if(GameObject.Find("Roots").GetComponent<RootGrowup>().Total>nodeLevels[count]){
                Debug=new Vector2(GameObject.Find("Roots").GetComponent<RootGrowup>().Total,count);
                level=count;
            }
            
        }
        lowBound=GameObject.Find("Roots/Light 2D").GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius+2f;
        while (GameObject.Find("Enemies").transform.childCount<3)
        {
            // spawn n obj per hollow
            numPerSpawn=NumberLevels[level];
            int n = numPerSpawn;
            while (n > 0)
            {
                float x = 0;
                float y = 0;
                //float dist = 0;

                // check if in hollow

                // x=lowBound*Mathf.Sin(Random.Range(0f,360f));
                // y=lowBound*Mathf.Cos(Random.Range(0f,360f));
                
                float angle=Random.Range(0f,360f);
                x=lowBound*Mathf.Sin(angle);
                y=lowBound*Mathf.Cos(angle);
                //spawn resourse
                //GameObject Resource = GameObject.Find("/Resource");
                // for(int i = 0; i < minBlockPerSide; i++)
                // {
                //     for (int j = 0; j < minBlockPerSide; j++)
                //     {
                GameObject obj = Instantiate(resourcePrefab, root.transform.position + new Vector3(x, y, 0), Quaternion.identity,GameObject.Find("/Enemies").transform) as GameObject;
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