﻿/*
    This is the base class of interactable objects.
    The player interacts with object by press key space
*/

using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected bool activeArea;
    public GameObject Canvas;

    void Update(){
        interactObject(Canvas);
    }

    public void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            activeArea = true;
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            activeArea = false;
            Canvas.SetActive(false);
        }
    }

    protected void interactObject(GameObject interactiveObj){
        if(Input.GetKeyDown(KeyCode.Space) && activeArea){
            if(interactiveObj.activeInHierarchy){
                interactiveObj.SetActive(false);
            }else{
                interactiveObj.SetActive(true);
            }
        }
    }
}
