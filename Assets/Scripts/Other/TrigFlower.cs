/*
    triggering the flower "Beauty under the moon" blooms when player hits note of shikagami.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utility;

public class TrigFlower : MonoBehaviour
{   
    public GameObject Flower, Clock;
    public GameObject shinigami, dialogBox;
    public Sprite booledFlower, midniClock;
    public Text dialogText;
    SpriteRenderer spriteRendererFlo;
    SpriteRenderer spriteRendererClo;

    bool trigger;
    public bool Active;
    bool alreadyShow;
    // Start is called before the first frame update
    void Start()
    {
        alreadyShow = false;
        spriteRendererFlo = Flower.GetComponent<SpriteRenderer>();
        spriteRendererClo = Clock.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shinigami.activeInHierarchy){
            trigger = true;
        }

        if (Input.GetKeyDown(KeyCode.Space)){
            dialogBox.SetActive(false);
        }

        if(Active && !alreadyShow){
            StartCoroutine(Coroutine());
        }
    }

    private void OnTriggerEnter2D(Collider2D other ){
            if(other.CompareTag("Player") && trigger){
            spriteRendererFlo.sprite = booledFlower;
            spriteRendererClo.sprite = midniClock;
            Active = true;
            Audio.Instance.Play(Sound.Background);

        }
    }

    IEnumerator Coroutine()
    {
        alreadyShow = true;
        Audio.Instance.Play(Sound.Door);
        yield return new WaitForSeconds(1.5f);

        //Show dialog box
        dialogBox.SetActive(true);
        dialogText.text = "Oh no, Beauty under the moon has already bloomed. Quickly, there are only 2 place can hide...";
    }
}
