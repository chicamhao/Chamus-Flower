using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset;
    public GameObject dialogBox;

    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(true);
        FindObjectOfType<AudioManager>().Play("backround"); 
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            dialogBox.SetActive(false);
        }
        transform.position = offset;
    }
}
