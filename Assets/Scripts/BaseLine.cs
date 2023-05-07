using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseLine : MonoBehaviour
{
    [SerializeField] private GameObject defeatImg;   
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemysmall"))
        {
            //SceneManager.LoadScene(0);
            defeatImg.SetActive(true);
        }
    }
}
