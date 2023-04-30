using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonManager : MonoBehaviour
{
    [SerializeField] private GameObject bluePrefab;
    [SerializeField] private float fireRate = 0.5f; 
    [SerializeField] private float speed=5f; 
    [SerializeField]private Rigidbody rb;
    public float shotSpeed=10f; 
    
    private float nextFire = 0.0f; 

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFire) 
        {
            nextFire = Time.time + fireRate; 
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        MoveHorizontal();
    }

    private void Start() 
    {

       
    }

    private void Shoot()
    {
        GameObject cloneBlue= Instantiate(bluePrefab, transform.position, Quaternion.identity);
        rb=cloneBlue.GetComponent<Rigidbody>();
        StartCoroutine(ApplyForce());  
    }

    private void MoveHorizontal()
    {
        float mouseX = Input.mousePosition.x / Screen.width;
        float xPos = (mouseX - 0.5f) * speed * 2f; 
        xPos = Mathf.Clamp(xPos, -20f, 20f);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }

    IEnumerator ApplyForce()
    {
        
        rb.AddForce(transform.forward * shotSpeed, ForceMode.Impulse);
        yield return new WaitForSeconds(.4f);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

}
