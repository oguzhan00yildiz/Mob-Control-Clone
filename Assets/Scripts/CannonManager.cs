using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonManager : MonoBehaviour
{
    [SerializeField] private GameObject bluePrefab;
    [SerializeField] private float fireRate = 0.5f; 
    [SerializeField] private float speed=5f; 
    
    private float nextFire = 0.0f; 

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFire) 
        {
            nextFire = Time.time + fireRate; 
            Shoot();
        }

        MoveHorizontal();
    }

    private void Shoot()
    {
        Instantiate(bluePrefab, transform.position, Quaternion.identity);
    }

    private void MoveHorizontal()
    {
        float mouseX = Input.mousePosition.x / Screen.width;
        float xPos = (mouseX - 0.5f) * speed * 2f; 
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }

}
