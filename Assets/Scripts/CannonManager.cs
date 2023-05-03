using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonManager : MonoBehaviour
{
    [SerializeField] private GameObject bluePrefab;
    [SerializeField] private GameObject BigPlayerPrefab;
    [SerializeField] private float fireRate = 0.5f; 
    [SerializeField] private float speed=5f; 
    [SerializeField]private Rigidbody rb;
    [SerializeField] private Slider bigPlayerSlider;
    private int chargeCount=0;
    public float shotSpeed=10f; 
    
    private float nextFire = 0.0f; 

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFire) 
        {
            nextFire = Time.time + fireRate; 
            Shoot();
        }
        bigPlayerSlider.value = chargeCount;
    }

    private void FixedUpdate()
    {
        MoveHorizontal();
    }

    private void Start() 
    {
        bigPlayerSlider.value = chargeCount;
    }

    private void Shoot()
    {
        if (chargeCount==25)
        {
            GameObject BigPlayer= Instantiate(BigPlayerPrefab, transform.position, Quaternion.identity); 
            rb=BigPlayer.GetComponent<Rigidbody>();
            StartCoroutine(ApplyForce());  
            chargeCount=0;
        }
        else
        {
            GameObject cloneBlue= Instantiate(bluePrefab, transform.position, Quaternion.identity);
            rb=cloneBlue.GetComponent<Rigidbody>();
            StartCoroutine(ApplyForce());  
            chargeCount++;
        }
        
        
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
