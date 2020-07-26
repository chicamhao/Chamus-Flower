using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Vector3 offset;
    public GameObject dialogBox;

    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(true);
        FindObjectOfType<AudioManager>().Play("backround"); 
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            dialogBox.SetActive(false);
        }
        transform.position = offset;
    }
}
