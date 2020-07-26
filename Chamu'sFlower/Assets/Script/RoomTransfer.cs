using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Transfer
public class RoomTransfer : MonoBehaviour
{
    public Vector3 playerChange;
    public Vector3 cameraChange;
    private CameraMovement cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
            if(other.CompareTag("Player")){
            other.transform.position += playerChange;
            cam.offset += cameraChange;
        }
    }
}
