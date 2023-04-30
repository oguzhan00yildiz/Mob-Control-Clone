using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour
{
    [SerializeField] private GameObject bluePrefab;
    [SerializeField] private int multiplyNumber;
    [SerializeField] private TextMesh gateText;
    private Vector3 playerPosition;
    private GameObject cloneBlue;


    void Start()
    {
        gateText.text=multiplyNumber.ToString()+"x";
    }

       void Update()
    {
        
    }

    private void Multiply(int multiplynumber)
    {
        int multiplier=1;
        multiplier=multiplynumber;
        
        //multiplier = Random.Range(2,6);

        for (int i = 0; i < multiplier; i++)
        {
            var rnd=Random.Range(-1f,1f);
            Vector3 newPosition = playerPosition + new Vector3(rnd, 0, rnd); //rastgele pozisyon oluştur
            cloneBlue = Instantiate(bluePrefab, newPosition, Quaternion.identity);
            cloneBlue.tag="null";
            StartCoroutine(TagTimer(cloneBlue));
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("blue"))
        {
           playerPosition=other.transform.position;
           Destroy(other.gameObject);
           Multiply(multiplyNumber); 
        }
        
    }

    private IEnumerator TagTimer(GameObject obj)
{
    yield return new WaitForSeconds(.5f);
    obj.tag = "blue";
}
}
