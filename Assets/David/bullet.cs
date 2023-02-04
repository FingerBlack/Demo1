using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Vector3 targetPos;
    public float speed = 20f;
    public float timeBeforeDisappear = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        speed = 8f;
        timeBeforeDisappear = 1f;
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
