using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            if (hand)
            {
                hand.SetActive(false);
            }
         if (slidetext)
         {
            slidetext.SetActive(false);  
         }
          
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
