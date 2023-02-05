using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject target;
    public float speed = 20f;
    public float timeBeforeDisappear = 0.2f;
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        speed = 8f;
        timeBeforeDisappear = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        // if(!target){
        //     Destroy
        // }
        timeBeforeDisappear -= Time.deltaTime;
        if (timeBeforeDisappear <= 0)
        {
            Destroy(gameObject);
        }

        if(target)
            pos=target.transform.position;   
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, pos, speed * Time.deltaTime);

    }
}
