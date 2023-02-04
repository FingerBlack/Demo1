using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Vector3 targetPos;
    public float speed = 1.0f;
    public float timeBeforeDisappear = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeBeforeDisappear -= Time.deltaTime;
        if (timeBeforeDisappear <= 0)
        {
            Destroy(gameObject);
        }
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPos, speed * Time.deltaTime);
    }
}
