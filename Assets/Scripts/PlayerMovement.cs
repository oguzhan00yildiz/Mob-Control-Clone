using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;
    
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity=transform.forward*speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.CompareTag("small") || gameObject.CompareTag("big"))
        {
            if(other.CompareTag("CastleRotate"))
            {
                gameObject.transform.LookAt(other.gameObject.transform);
            }
        }

    }
    
}
