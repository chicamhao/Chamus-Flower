using UnityEngine;
using Utility;

public class Player : MonoBehaviour
{
    [SerializeField] Animator _animator;

    public Inventory playerInventory;

    private void Update()
    {
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        var direction = Vector3.zero;
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        //moving character
        if(direction != Vector3.zero)
        {
            direction.Normalize();
            transform.Translate(Common.Constants.PlayerSpeed * Time.deltaTime * direction);

            _animator.SetFloat("moveX", direction.x);
            _animator.SetFloat("moveY", direction.y);
            _animator.SetBool("moving", true);
        }
        else
        {
            _animator.SetBool("moving",false);
        }
    }  
}