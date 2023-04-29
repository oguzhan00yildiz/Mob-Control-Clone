using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonManager : MonoBehaviour
{
    [SerializeField] private GameObject bluePrefab;
    [SerializeField] private float fireRate = 0.5f; 
    private float nextFire = 0.0f; 

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFire) 
        {
            nextFire = Time.time + fireRate; 
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(bluePrefab, transform.position, Quaternion.identity);
    }
}
