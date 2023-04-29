using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float shotSpeed=10f; 
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(ApplyForce());
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    IEnumerator ApplyForce()
    {
        
        rb.AddForce(transform.forward * shotSpeed, ForceMode.Impulse);
        yield return new WaitForSeconds(.4f);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
