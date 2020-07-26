/*
    This object hold a word puzzle (BookShelf Puzzle)
    Receive a clue about whole story of "Beauty under the moon" when the player solve the puzzle
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookShelf : Interactable
{   
    public GameObject PuzzleWord;
    private bool Success;
    public GameObject dialogBox;

    // Update is called once per frame
    void Update()
    {
        Success = PuzzleWord.GetComponent<BookShelfPuzzle>().Success;
        if (!Success)
            interactObject(PuzzleWord);
        else{
            PuzzleWord.SetActive(false);
            interactObject(dialogBox);
        }
    }
  
    public override void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            activeArea = false;
            PuzzleWord.SetActive(false);
            dialogBox.SetActive(false);
            PuzzleWord.GetComponent<BookShelfPuzzle>().Reload();
        }
    }
}
