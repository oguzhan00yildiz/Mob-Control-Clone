using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    [SerializeField]private GameObject hand;
    [SerializeField]private GameObject slidetext;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
         hand.SetActive(false);
         slidetext.SetActive(false);   
        }
    }
}
