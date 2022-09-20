/*
    A little horror when a black long hair spills up from the toilet
*/
using UnityEngine;

public class Toilet : MonoBehaviour
{
    private Animator animToilet;
    public GameObject Teddy;
    private bool isSpilled;

    void Start()
    {
        animToilet = GetComponent<Animator>();
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
