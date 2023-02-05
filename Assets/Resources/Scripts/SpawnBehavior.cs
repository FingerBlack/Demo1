using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehavior : MonoBehaviour
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
    public int level;
    public List<int> nodeLevels=new List<int>{20,30,50,100,200};
    public List<int> numberLevels=new List<int>{ 10, 15, 20,25,30,35};
    public List<int> sizeLevels=new List<int>{ 2, 4, 5,6,7,8};
    public List<int> rangeLevels=new List<int>{ 2, 4, 5,6,7,8};
    public List<int> rangeSizeLevels=new List<int>{ 2, 4, 5,6,7,8};
    public List<int> resourceLimit=new List<int>{ 1000, 5000, 8000,20000,30000,60000};
    public float TimePeirod;
    public float TimeCount;
    // Start is called before the first frame update
    void Start()
    {

        spawnGap = 2f;
        TimePeirod=10f;
        TimeCount=0f;
        resourceBlockLength = resourcePrefab.transform.localScale.x;
        level=0;
    }

    // Update is called once per frame
    void Update()
    {
        int count=0;
        TimeCount+=Time.deltaTime;
        foreach(int i in nodeLevels){
            count+=1;
            if(GameObject.Find("Roots").GetComponent<RootGrowup>().Total>i){
                level=count;
            }
        }
        
        
        lowBound=rangeLevels[level];
        highBound=lowBound+rangeSizeLevels[level];
        if (GameObject.Find("Resources").transform.childCount<resourceLimit[level]&&TimeCount>TimePeirod)
        {
            // spawn n obj per hollow
            TimeCount=0f;
            GameObject.Find("Roots").GetComponent<RootGrowup>().resourcesCount+=20;
            numPerSpawn=numberLevels[level];
            minBlockPerSide=sizeLevels[level];
            int n=numPerSpawn;
            while (n > 0)
            {
                float x = 0;
                float y = 0;
                //float dist = 0;

                // check if in hollow
                float angle=Random.Range(0f,360f);
                x=Random.Range(lowBound,highBound)*Mathf.Sin(angle);
                y=Random.Range(lowBound,highBound)*Mathf.Cos(angle);
                // while (dist <= lowBound || dist >= highBound)
                // {
                //     x = Random.Range((highBound + spawnGap) * -1, highBound + spawnGap);
                //     y = Random.Range((highBound + spawnGap) * -1, highBound + spawnGap);
                //     dist = Mathf.Sqrt(x * x + y * y);
                // }

                //spawn resourse
                //GameObject Resource = GameObject.Find("/Resource");
                for(int i = 0; i < minBlockPerSide; i++)
                {
                    for (int j = 0; j < minBlockPerSide; j++)
                    {
                        GameObject obj = Instantiate(resourcePrefab, root.transform.position + new Vector3(x+i* resourceBlockLength, y+j* resourceBlockLength, 0), Quaternion.identity,GameObject.Find("/Resources").transform) as GameObject;
                    
                    }
                }
                //GameObject obj = Instantiate(resorsePrefeb, roots.transform.position + new Vector3(x, y, 0), Quaternion.identity) as GameObject;


                //Debug.Log("spawned at: " + x + " " + y);
                n--;
            }

           
            // enlarge hollow
            
            //level+=1;
            minBlockPerSide=numberLevels[level];


        }
    }
}