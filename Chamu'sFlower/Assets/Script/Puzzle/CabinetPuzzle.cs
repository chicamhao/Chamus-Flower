/*
    Cabinet Puzzle: Player play a word puzzle game 
    with 8 random word littres and 4 answer boxes
    if 4 boxes = BUTM (clue from television puzzle), puzzle is solved
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetPuzzle : WordPuzzle {
    public void DragLettreOne()
    {
        DragLettreBase(0);
    }
    public void DragLettreTwo()
    {
       DragLettreBase(1);
    }
    public void DragLettreThree()
    {
       DragLettreBase(2);
    }
    public void DragLettreFor()
    {
        DragLettreBase(3);
    }
    public void DragLettreFive()
    {
        DragLettreBase(4);
    }
    public void DragLettreSix()
    {
        DragLettreBase(5);
    }
    public void DragLettrSeven()
    {
       DragLettreBase(6);
    }
    public void DragLettreEight()
    {
        DragLettreBase(7);
    }
    public void DragLettrNice()
    {
       DragLettreBase(8);
    }
    public void DragLettreTen()
    {
        DragLettreBase(9);
    }

    //---------------------------Dropping Function-----------------------------  
    public void DropLettreOne()
    {
       DropLettreBase(0);
    }
    public void DropLettreTwo()
    {
        DropLettreBase(1);
    }
    public void DropLettreThree()
    {
        DropLettreBase(2);
    }
    public void DropLettreFour()
    {
         DropLettreBase(3);
    }
    public void DropLettreFive()
    {
         DropLettreBase(4);
    }
    public void DropLettreSix()
    {
         DropLettreBase(5);
    }
    public void DropLettreSeven()
    {
         DropLettreBase(6);
    }
    public void DropLettreEight()
    {
         DropLettreBase(7);
    }
    public void DropLettreNice()
    {
         DropLettreBase(8);
    }
    public void DropLettreTen()
    {
         DropLettreBase(9);
    }

}