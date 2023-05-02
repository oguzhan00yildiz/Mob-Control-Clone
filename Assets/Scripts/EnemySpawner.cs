using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemySmallPrefab;
    [SerializeField] private float shootSpeed;
    [SerializeField] private float nextFire;
    [SerializeField] private float fireRate;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    private void Timer()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate; 
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        GameObject enemySmall= Instantiate(enemySmallPrefab, transform.position, Quaternion.Euler(0,180,0)); 
        rb=enemySmall.GetComponent<Rigidbody>();
        StartCoroutine(ApplyForce());  

    }

    IEnumerator ApplyForce()
    {
        
        rb.AddForce(-transform.forward * shootSpeed, ForceMode.Impulse);
        yield return new WaitForSeconds(.4f);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
