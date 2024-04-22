using UnityEngine;

// This object hold a word puzzle (BookShelf Puzzle)
// Receive a clue about whole story of "Beauty under the moon" when the player solve the puzzle
public sealed class BookShelf : Interactable
{   
    [SerializeField] BookShelfPuzzle _puzzleObject;
    [SerializeField] GameObject _resultObject;

    private void Awake()
    {
        _object = _puzzleObject.gameObject;
        _puzzleObject.OnResolved += OnPuzzleResolved;
        _onExit += OnExit;
    }

    public void OnPuzzleResolved()
    {
        _object = _resultObject;
    }

    public void OnExit()
    {
        _puzzleObject.Reload();
    }
}
