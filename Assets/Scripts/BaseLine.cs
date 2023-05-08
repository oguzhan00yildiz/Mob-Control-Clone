using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BaseLine : MonoBehaviour
{
    [SerializeField] private GameObject defeatImg;  
    private bool gameEnded = false; 
    private bool slowTimeCalled = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemysmall"))
        {
            if (!gameEnded)
            {
                gameEnded = true;
                defeatImg.SetActive(true);
                
                if (!slowTimeCalled)
                {
                    StartCoroutine(SlowTime()); 
                    slowTimeCalled = true;
                }
            }
        }
    }

    private IEnumerator SlowTime()
    {
        Time.timeScale = 0.2f;
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
        SceneManager.LoadScene(3);
    }
}
