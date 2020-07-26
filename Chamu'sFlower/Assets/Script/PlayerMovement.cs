using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState{
    walk,
    interact,
};
public class PlayerMovement : MonoBehaviour
{
    PlayerState currentState;
    public float Speed;
    private Rigidbody2D myRigidbody;
    private Vector3 movement;
    private Animator animator;
    public Inventory playerInventory;
    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentState == PlayerState.interact){
            return;
        }else
        if(currentState == PlayerState.walk){
            UpdateMovement();
        }
    }
    public void RaiseItem(){
        currentState = PlayerState.interact;
    }

    private void UpdateMovement(){
        //set up when character stand still.
        movement = Vector3.zero;

        //get input keyboard to change vector3D movement.
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        //moving character
        if(movement != Vector3.zero){
            movement.Normalize();
            myRigidbody.MovePosition(transform.position + movement * Speed * Time.deltaTime);
            //moving animation
            animator.SetFloat("moveX",movement.x);
            animator.SetFloat("moveY",movement.y);
            animator.SetBool("moving",true);
        }else{
            animator.SetBool("moving",false);
        }
    }  
}

