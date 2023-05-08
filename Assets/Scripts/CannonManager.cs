using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
    [SerializeField] private Sprite sliderFullImage;
    [SerializeField] private Sprite sliderLoadImage;
    [SerializeField] private GameObject Level1;
    [SerializeField] private GameObject releaseTxt;
    private int chargeCount=0;
    public float shotSpeed=10f; 
    private float nextFire = 0.0f; 
    private bool isclicked=false;

    void Update()
    {
        if (Input.GetMouseButton(0) &&  Time.time > nextFire) 
        {
            nextFire = Time.time + fireRate; 
            Shoot();
        }
        else if(Input.GetMouseButtonUp(0) && chargeCount == 25) ShootBig();
        bigPlayerSlider.value = chargeCount;
        releaseTxt.SetActive(false);
        if(bigPlayerSlider.value == 25)
        {
            releaseTxt.SetActive(true);
            bigPlayerSlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().sprite = sliderFullImage;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            isclicked=true;
        }

    }

    private void FixedUpdate()
    {       if (isclicked)
        {
        MoveHorizontal();
        }
        
    }

    private void Start()
    {
        bigPlayerSlider.value = chargeCount;
    }

    private void Shoot()
    {
        animator.SetTrigger("CannonShoot");
        GameObject cloneBlue= Instantiate(bluePrefab, muzzle.transform.position, muzzle.transform.rotation);
        rb=cloneBlue.GetComponent<Rigidbody>();
        StartCoroutine(ApplyForce(rb));
        if(chargeCount <25) chargeCount++; 
        if (cloneBlue)
        {
            cloneBlue.transform.SetParent(Level1.transform);
        }
        
    }

    private void ShootBig()
    {
        animator.SetTrigger("CannonShoot");
        GameObject BigPlayer= Instantiate(BigPlayerPrefab, muzzle.transform.position, muzzle.transform.rotation); 
        rb=BigPlayer.GetComponent<Rigidbody>();
        StartCoroutine(ApplyForce(rb));
        bigPlayerSlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().sprite = sliderLoadImage;  
        chargeCount=0;
        if (BigPlayer)
        {
            BigPlayer.transform.SetParent(Level1.transform);
        }
        
    }

    private void MoveHorizontal()
{
    float mouseX = Input.mousePosition.x / Screen.width;
    float xPos = (mouseX - 0.5f) * speed * 2f; 
    xPos = Mathf.Clamp(xPos, -15f, 15f);

    // Convert the input position from world space to local space
    Vector3 localPos = transform.TransformDirection(new Vector3(xPos, 0f, 0f));

    // Set the local position of the cannon
    transform.localPosition = new Vector3(localPos.x, transform.localPosition.y, transform.localPosition.z);
}
    /* private void MoveHorizontal()
    {
        float mouseX = Input.mousePosition.x / Screen.width;
        float xPos = (mouseX - 0.5f) * speed * 2f; 
        xPos = Mathf.Clamp(xPos, -20f, 20f);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    } */

    IEnumerator ApplyForce(Rigidbody rb)
    {
        if (rb)
        {
            Vector3 muzzleWorldPos = muzzle.transform.position + muzzle.transform.TransformDirection(Vector3.forward * 7);
            rb.DOMove(muzzleWorldPos, .3f);
            yield return new WaitForSeconds(0.4f);
            if (rb)
            {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;  
            }
            
        }
    }

}
