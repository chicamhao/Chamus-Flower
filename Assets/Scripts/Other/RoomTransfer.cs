using UnityEngine;

public sealed class RoomTransfer : Interactable
{
    public Vector3 playerChange;
    public Vector3 cameraChange;
    private Camera _camera;

    void Awake()
    {
        _camera = Camera.main;
        _onEnter += OnEnter;
    }

    private void OnEnter(Collider2D other)
    {
        other.transform.position += playerChange;
        _camera.transform.position += cameraChange;
    }
}
