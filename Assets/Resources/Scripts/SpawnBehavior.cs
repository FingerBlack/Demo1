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
    public List<int> nodeLevels=new List<int>{5,20,30,100,200};
    public List<int> numberLevels=new List<int>{ 10, 15, 20,25,30,35};
    public List<int> sizeLevels=new List<int>{ 2, 4, 5,6,7,8};
    public List<int> rangeLevels=new List<int>{ 2, 4, 5,6,7,8};
    public List<int> rangeSizeLevels=new List<int>{ 2, 4, 5,6,7,8};
    public List<int> resourceLimit=new List<int>{ 100, 200, 300,400,500,600};
    public float TimePeirod;

    // Start is called before the first frame update
    void Start()
    {

        spawnGap = 2f;
        TimePeirod=10f;
        resourceBlockLength = resourcePrefab.transform.localScale.x;
        level=0;
    }

    // Update is called once per frame
    void Update()
    {
        int count=0;
        
        foreach(int i in nodeLevels){
            count+=1;
            if(GameObject.Find("Roots").GetComponent<RootGrowup>().Total>i){
                level=count;
            }
        }
        
        
        lowBound=rangeLevels[level];
        highBound=lowBound+rangeSizeLevels[level];
        while (GameObject.Find("Resources").transform.childCount<resourceLimit[level]&&level<=5)
        {
            // spawn n obj per hollow
            numPerSpawn=numberLevels[level];
            minBlockPerSide=sizeLevels[level];
            int n=numPerSpawn;
            while (n > 0)
            {
                float x = 0;
                float y = 0;
                //float dist = 0;

                // check if in hollow
                x=Random.Range(lowBound,highBound)*Mathf.Sin(Random.Range(0f,360f));
                y=Random.Range(lowBound,highBound)*Mathf.Cos(Random.Range(0f,360f));
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