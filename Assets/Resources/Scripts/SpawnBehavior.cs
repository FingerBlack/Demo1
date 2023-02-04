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


    // Start is called before the first frame update
    void Start()
    {

        spawnGap = 2f;
        highBound = 4*spawnGap;
        lowBound=3*spawnGap;
        resourceBlockLength = resourcePrefab.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {


        while (highBound <= spawnRange)
        {
            // spawn n obj per hollow
            int n = numPerSpawn;
            while (n > 0)
            {
                float x = 0;
                float y = 0;
                float dist = 0;

                // check if in hollow
                while (dist <= lowBound || dist >= highBound)
                {
                    x = Random.Range((highBound + spawnGap) * -1, highBound + spawnGap);
                    y = Random.Range((highBound + spawnGap) * -1, highBound + spawnGap);
                    dist = Mathf.Sqrt(x * x + y * y);
                }

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
            highBound += spawnGap;
            lowBound += spawnGap;

            minBlockPerSide+=blockSizeIncreaseRate;


        }
    }
}