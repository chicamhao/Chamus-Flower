/*
    A little horror when a black long hair spills up from the toilet
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletSpill : MonoBehaviour
{
    private Animator animToilet;
    public GameObject Toilet;
    public GameObject Teddy;
    private bool isSpilled;
    // Start is called before the first frame update
    void Start()
    {
        animToilet = Toilet.GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D other){
            if(other.CompareTag("Player") && !isSpilled){
                animToilet.SetBool("spilled", true);
                FindObjectOfType<AudioManager>().Play("toilet");
                Teddy.SetActive(true);
                isSpilled = true;         
        }
    }
}
