/*
    If player's inventory have the remote, player can control the object turn on or off
    If player turns on and off the tele 3 times on a row (countControled = 6), show a clue about "Beauty under the moon"
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

enum StatusOfTV {
    On, Off
};

public class Television : Interactable
{
    StatusOfTV currentStatus;
    private int countControled;

    public Inventory PlayerInventory;
    public Item ItemContents;
    //option choice turn the tv
    public GameObject option;
    public Text textChoise;
    //zoom the object when ever interacting, tvZoom_on when the tv turns on and opposite
    public GameObject tvZoom_on ,tvZoom_off;
    //text on the tv before and after solve the puzzle
    public GameObject textNor, textSucc; 
    //black when the tv turns off
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start(){
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        countControled = -1;
        spriteRenderer.color = new Color(0,0,0);
        currentStatus = StatusOfTV.Off;
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Space) && activeArea){
            //have the remote in inventory
            if(PlayerInventory.checkContains(ItemContents)){
                startChoice();
            }
        }

        if(currentStatus == StatusOfTV.On)
            spriteRenderer.color = new Color(255,255,255);
        else
            spriteRenderer.color = new Color(0,0,0);

        //the puzzle is solved
        if(countControled >= 6){
            //show the answer on the tivi
            textNor.SetActive(false);
            textSucc.SetActive(true);
        }
    }
 
   public override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger){
            activeArea = false;
            tvZoom_on.SetActive(false);
            tvZoom_off.SetActive(false);
            option.SetActive(false);
            countControled = -1;
        }
    }

    public void startChoice(){
        option.SetActive(true);

        if (currentStatus == StatusOfTV.On){
            textChoise.text = "Turn off";
            tvZoom_on.SetActive(true);
        }else{
            textChoise.text = "Turn on";
            tvZoom_off.SetActive(true);
        }
    }
    public void optTurnTV(){
        countControled++;

        if (currentStatus == StatusOfTV.Off){
            currentStatus = StatusOfTV.On;
            FindObjectOfType<AudioManager>().Play("tv");
            tvZoom_off.SetActive(false);
        }
        else {
            currentStatus = StatusOfTV.Off;
            FindObjectOfType<AudioManager>().Pause("tv");
            tvZoom_on.SetActive(false);
        }
        option.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }
}

