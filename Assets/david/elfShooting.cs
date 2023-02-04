using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elfShooting : MonoBehaviour
{
    // Start is called before the first frame update

    // shooting related
    public float range = 10;
    bool detectEnemy = false;
    Vector2 shootingDirection;
    public GameObject bullet;
    public float fireRate = 0.5f;
    float nextToSHoot = 0;


    public Enemy targetEnemy;
    void Start()
    {
        targetEnemy = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetEnemy)
        {
            Debug.Log("shoot");
            if (nextToSHoot <= 0)
            {
                nextToSHoot = fireRate;
                GameObject bulletIns = Instantiate(bullet, transform.position, Quaternion.identity);
                Vector3 direction = (targetEnemy.transform.position - transform.position);
                bullet bulletComp = bulletIns.GetComponent<bullet>();
                bulletComp.targetPos = transform.position + direction.normalized * 1000.0f;
                bulletComp.speed = 1;
            }
            else
            {
                nextToSHoot -= Time.deltaTime;
            }
        }
    }
    public void OnCollisionEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            if (targetEnemy == null)
            {
                targetEnemy = enemy;
                return;
            }
        }
    }
}
