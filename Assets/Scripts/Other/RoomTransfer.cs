using UnityEngine;

public class RoomTransfer : MonoBehaviour
{
    public Vector3 playerChange;
    public Vector3 cameraChange;
    private CameraController cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraController>();
    }

    private void OnTriggerEnter2D(Collider2D other){
            if(other.CompareTag("Player")){
            other.transform.position += playerChange;
            cam.offset += cameraChange;
        }
    }
}
