using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private int bigPlayerHealth;
    // Start is called before the first frame update
    void Start()
    {
        bigPlayerHealth = 5;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if(gameObject.tag == "small")
        {
            if (other.CompareTag("enemysmall"))
            {
                Destroy(other.gameObject,0.1f);
                Destroy(gameObject,0.1f);
            }
        }
        else if (gameObject.CompareTag("big"))
        {
            if(other.CompareTag("enemysmall"))
            {
                if (bigPlayerHealth > 1)
                {
                    Destroy(other.gameObject);
                    bigPlayerHealth--;
                    Debug.Log(bigPlayerHealth + " small enemy destroyed");
                }
                else
                {
                    Destroy(other.gameObject,0.1f);
                    Destroy(gameObject,0.1f);
                }
            }
        }
        
    }
}
