using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour
{
    [SerializeField] private GameObject smallPrefab;
    [SerializeField] private GameObject bigPrefab;
    [SerializeField] private int multiplyNumber;
    [SerializeField] private TextMesh gateText;
    private Vector3 playerPosition;
    private GameObject cloneSmall;
    private GameObject cloneBig;
    [SerializeField] private GameObject level1;
    public float speed = 2.0f;
    public float distance = 2.0f; 
    private float originalPos;
    [SerializeField] private bool gateCanMove;



    void Start()
    {
        gateText.text=multiplyNumber.ToString()+"x";
        originalPos = transform.parent.transform.position.x;
    }

       void Update()
    {
        if (gateCanMove)
        {
            GateMove();
        }
        
    }

    private void Multiply(int multiplynumber,GameObject charactertype)
    {
        int multiplier=1;
        multiplier=multiplynumber;
        
        for (int i = 0; i < multiplier; i++)
        {
            var rnd=Random.Range(-1f,1f);
            Vector3 newPosition = playerPosition + new Vector3(rnd, 0, 0);
            if (charactertype.CompareTag("small"))
            {
                cloneSmall = Instantiate(smallPrefab, newPosition,transform.rotation);
                StartCoroutine(TagTimer(cloneSmall));
                if (!PathFollow.instance.isLevelDestroyed)
                {
                cloneSmall.transform.SetParent(level1.transform);
                }
            }
            
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("small"))
        {
           playerPosition=other.transform.position;
           Destroy(other.gameObject);
           Multiply(multiplyNumber,other.gameObject); 
        }
        else if(other.CompareTag("big"))
        {
            
        }
    }

    private IEnumerator TagTimer(GameObject obj)
    {
        var temptag=obj.tag;
        obj.tag="null";
        yield return new WaitForSeconds(.5f);
    
        if (obj)
        {
           obj.tag = temptag;
        } 
    }

    private void GateMove()
    {
        float newPos = originalPos + Mathf.PingPong(Time.time * speed, distance);
        transform.parent.transform.position = new Vector3(newPos, transform.parent.transform.position.y, transform.parent.transform.position.z);
    }
}
