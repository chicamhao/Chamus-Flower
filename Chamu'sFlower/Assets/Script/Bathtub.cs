/*
    Last puzzle of the game, when the flower "Beauty under the moon" blooms
    Shikagami coming for player, there are 2 option choice to hide: bathtub, bed
    Difference option to differende ending
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Bathtub : Interactable
{
    public GameObject option, Player,TriggerFlo, Light;
    public Text dialogText;
    public bool trigger;
    public bool isHided;

    // Update is c alled once per frame
    void Update() 
    {
        //Trigger "flower blooms" on
        trigger = TriggerFlo.GetComponent<TrigFlower>().Active;
        
        if (Input.GetKeyDown(KeyCode.Space) && activeArea && trigger && !isHided){
            startChoice();
        }
    }
    public override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger){
            activeArea = false;
            option.SetActive(false);
        }
    }

    public void Hide(){
        Player.SetActive(false);
        option.SetActive(false);
        isHided = true;
        FindObjectOfType<AudioManager>().Pause("door");
        FindObjectOfType<AudioManager>().Play("finding");
        EventSystem.current.SetSelectedGameObject(null);
        Light.SetActive(false);

    }
    public void startChoice(){
        option.SetActive(true);
        dialogText.text = "Hide in the bathtub.";
    }
}
