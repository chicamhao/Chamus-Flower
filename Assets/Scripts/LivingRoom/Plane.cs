using UnityEngine.UI;

public sealed class Plane : Interactable
{
    public Text dialogText;

    private void Awake()
    {
        _onInteract += () =>
        {
            dialogText.text = "Look like a weird line on it: on-off x 3";
        };
    }
}
