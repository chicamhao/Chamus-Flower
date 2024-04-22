using System;
using Manager;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected bool _isEntered;
    protected Action<Collider2D> _onEnter;
    protected Action _onExit;
    protected Action _onInteract;

    [SerializeField] private ObjectType _type;
    [SerializeField] protected GameObject _object;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isEntered)
        {
            Interact();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isEntered = true;
            _onEnter?.Invoke(other);
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isEntered = false;
            if (_object != null)
            {
                _object.SetActive(false);
            }
            _onExit?.Invoke();
        }
    }

    private void Interact()
    {
        if (_object == null)
        {
            Director.Instance.GetInteractObject(_type);
        }

        if (_object != null)
        {
            _object.SetActive(!_object.activeInHierarchy);
            _onInteract?.Invoke();

        }
    }

    public enum ObjectType
    {
        Empty,
        Newspaper,
        CatPicture,
        Bush
    }
}
