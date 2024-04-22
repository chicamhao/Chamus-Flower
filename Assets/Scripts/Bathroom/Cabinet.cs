using UnityEngine;
using UnityEngine.UI;
using Utility;

// resolve the puzzle to receive the 'Key' to unlook the cupboard 
// discovery Chamu's diary 
public sealed class Cabinet : Interactable
{
    [SerializeField] GameObject _resultObject;
    [SerializeField] GameObject _diaryObject;

    public Inventory PlayerIventory;
    public Item Content;
    public Sprite openSprite;
    SpriteRenderer spriteRenderer;
    public GameObject itemDesDialog;
    public Text itemText;
    bool _isOpened;
    bool _puzzleResolved;
    private BookShelfPuzzle _puzzleObject;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void OnPuzzleResolved()
    {
        _puzzleResolved = true;
        _puzzleObject.gameObject.SetActive(false);
        _object = _resultObject;
    }

    public void OnInteract()
    {
        if (!_puzzleResolved)
        {
            DialogLauncher.Instance.LaunchBookPuzzle(OnPuzzleResolved);
        }

        if (!_isOpened)
        {
            // take the items
            PlayerIventory.AddItem(Content);
            itemText.text = Content.itemDescription;
            // switching sprites (instead of animation)
            spriteRenderer.sprite = openSprite;
            Audio.Instance.Play(Sound.Cupboard);
            _isOpened = true;
            _object = _diaryObject;
        }
    }

    public void OnExit()
    {
        if (!_puzzleResolved)
        {
            _puzzleObject.Reload();
        }
    }
}