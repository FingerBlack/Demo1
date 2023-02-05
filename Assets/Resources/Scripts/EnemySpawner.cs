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
    public List<int> nodeLevels=new List<int>{5,10,15,20,25,30,40,50};
    public List<int> HPLevels=new List<int>{ 10, 10, 10,10,10,10,10,10,10};
    public List<int> NumberLevels=new List<int>{ 2, 4, 8,15,25,30,36,40,50};
    public List<float> DamageLevels=new List<float>{ 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f , 0.5f , 0.5f };
    // Start is called before the first frame update
    void Start()
    {
        spawnGap = 2f;
        highBound = 4*spawnGap;
        resourceBlockLength = resourcePrefab.transform.localScale.x;
        level=0;
    }

    // Update is called once per frame
    void Update()
    {
        
        int count=0;
        
        foreach(int i in nodeLevels){
            
            if(GameObject.Find("Roots").GetComponent<RootGrowup>().Total>i){
                level=count;
            }
            count+=1;
        }
        lowBound=GameObject.Find("Roots/Light 2D").GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius+2f;
        while (GameObject.Find("Enemies").transform.childCount<3&&level<=5)
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

                x=lowBound*Mathf.Sin(Random.Range(0f,360f));
                y=lowBound*Mathf.Cos(Random.Range(0f,360f));
                

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