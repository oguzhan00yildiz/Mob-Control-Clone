using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemySmallPrefab;
    [SerializeField] private float shootSpeed;
    [SerializeField] private float fireRate;
    [SerializeField] private float fireDuration;
    [SerializeField] private GameObject level1;
    [SerializeField] private GameObject level2;
    private float nextFire = 0f; 
    private Rigidbody rb;
    private bool isSpawnDone;
    private bool isclicked=false;


    void Update()
    {
        if (isclicked)
        {
             if (isSpawnDone==false)
        {
            if (Time.time > nextFire)
            {
                SpawnEnemy();
                nextFire = Time.time + fireRate; 
            }
        }

        }



        if (PathFollow.instance.isLevel2)
        {
            StartCoroutine(Timer());

             if (isSpawnDone==false)
        {
            if (Time.time > nextFire)
            {
                SpawnEnemy();
                nextFire = Time.time + fireRate; 
            }
        }

        }




       

        if (Input.GetMouseButtonDown(0))
        {
            isclicked=true;
            StartCoroutine(Timer());
        }
        
    }

    void Start()
    {
        
    }

    private void SpawnEnemy()
    {
        int rnd=Random.Range(-5,5);
        GameObject enemySmall = Instantiate(enemySmallPrefab, transform.position+new Vector3(rnd,0,0),Quaternion.Euler(0, 180, 0));
        rb = enemySmall.GetComponent<Rigidbody>();
        StartCoroutine(ApplyForce());
        if (level1)
        {
            enemySmall.transform.SetParent(level1.transform);
        }
        else if(level2)
        {
            enemySmall.transform.SetParent(level2.transform);
        }
        
    }

    IEnumerator ApplyForce()
    {
        rb.AddForce(-transform.forward * shootSpeed, ForceMode.Impulse);
        yield return new WaitForSeconds(.4f);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private IEnumerator Timer ()
    {
      yield return new WaitForSecondsRealtime(fireDuration);
      isSpawnDone=true;

    }

    
}
