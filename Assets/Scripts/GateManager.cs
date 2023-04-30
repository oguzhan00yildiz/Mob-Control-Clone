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



    void Start()
    {
        gateText.text=multiplyNumber.ToString()+"x";
    }

       void Update()
    {
        
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
                cloneSmall = Instantiate(smallPrefab, newPosition, Quaternion.identity);
                StartCoroutine(TagTimer(cloneSmall));
            }
            else if(charactertype.CompareTag("big"))
            {
                cloneBig = Instantiate(bigPrefab, newPosition, Quaternion.identity);
                StartCoroutine(TagTimer(cloneBig));
            }
            
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("small")||other.CompareTag("big"))
        {
           playerPosition=other.transform.position;
           Destroy(other.gameObject);
           Multiply(multiplyNumber,other.gameObject); 
        } 
    }

    private IEnumerator TagTimer(GameObject obj)
{
    var temptag=obj.tag;
    obj.tag="null";
    yield return new WaitForSeconds(.5f);
    
    obj.tag = temptag;
}
}
