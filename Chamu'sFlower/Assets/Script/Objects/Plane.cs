/*
    This object hold a clue about Television Puzzle
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Plane : Interactable
{
    public GameObject dialogBox;
    public Text dialogText;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && activeArea){
            dialogText.text = "Look like a weird line on it: on-off x 3";
            interactObject(dialogBox);
        }
    }

    public override void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            activeArea = false;
            dialogBox.SetActive(false);
        }
    }
}
