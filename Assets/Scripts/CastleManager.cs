using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CastleManager : MonoBehaviour
{
    [SerializeField] TMP_Text castleHealthText;
    private int castleHealth = 50;
    // Start is called before the first frame update
    void Start()
    {
        castleHealthText.text = castleHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        castleHealthText.text = castleHealth.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("small") || other.CompareTag("big"))
        {
            castleHealth--;
            Destroy(other.gameObject, 0.5f);
        }
    }


}
