using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CastleManager : MonoBehaviour
{
    [SerializeField] TMP_Text castleHealthText;
    [SerializeField] private ParticleSystem castleParticles;
    private Animator animator;
    private int castleHealth = 50;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
            OnDamage();
            Destroy(other.gameObject, 0.5f);
        }
    }

    private void OnDamage()
    {
        animator.SetTrigger("Damage");
        castleParticles.Play();
        
    }

}
