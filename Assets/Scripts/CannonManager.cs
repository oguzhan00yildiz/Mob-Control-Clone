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
    [SerializeField] private GameObject muzzle;
    [SerializeField] private Animator animator;
    private int chargeCount=0;
    public float shotSpeed=10f; 
    private float nextFire = 0.0f; 

    void Update()
    {
        if (Input.GetMouseButton(0) &&  Time.time > nextFire) 
        {
            nextFire = Time.time + fireRate; 
            Shoot();
        }
        else if(Input.GetMouseButtonUp(0) && chargeCount == 25) ShootBig();
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
        animator.SetTrigger("CannonShoot");
        GameObject cloneBlue= Instantiate(bluePrefab, muzzle.transform.position, Quaternion.identity);
        rb=cloneBlue.GetComponent<Rigidbody>();
        StartCoroutine(ApplyForce());
        if(chargeCount <25) chargeCount++; 
    }

    private void ShootBig()
    {
        GameObject BigPlayer= Instantiate(BigPlayerPrefab, muzzle.transform.position, Quaternion.identity); 
        rb=BigPlayer.GetComponent<Rigidbody>();
        StartCoroutine(ApplyForce());  
        chargeCount=0;
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
        rb.AddForce(muzzle.transform.forward * shotSpeed, ForceMode.Impulse);
        yield return new WaitForSeconds(.4f);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

}
