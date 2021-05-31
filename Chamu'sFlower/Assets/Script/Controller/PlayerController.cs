using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    Vector3 movement;
    Animator animator;

    public float Speed;
    public Inventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerInventory.InitInventory() ;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
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

