using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDead : MonoBehaviour
{
    private Animator anim;
    [SerializeField] GameObject player;
    [SerializeField] AudioSource pickupsound;
    private void Start()
    {
        anim = GetComponent<Animator>();
        pickupsound = GetComponent<AudioSource>();
    }
    
   
    private void OnTriggerEnter2D(Collider2D collision)
    {

            pickupsound.Play();
            anim.Play("Ghostie_death");
            Destroy(gameObject,0.5f);        
        
    }


}
