using UnityEngine;
using Utility;

public class CameraController : MonoBehaviour
{
    public Vector3 offset;
    public GameObject dialogBox;

    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(true);
        Audio.Instance.Play(Sound.Background);
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            dialogBox.SetActive(false);
        }
        transform.position = offset;
    }
}
