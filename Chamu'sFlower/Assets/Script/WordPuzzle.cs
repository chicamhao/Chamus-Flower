using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordPuzzle : MonoBehaviour {
    public GameObject[] Lettres;
    public GameObject[] Boxes;

    private Vector3[] lettresInitPos, lettresInitScal;
    private bool[] droppedLettre, droppedBox;

    private string inputString = "";
    public string resultString;

    public bool Success;

    void Start(){
        lettresInitPos = new Vector3[Lettres.Length];
        lettresInitScal = new Vector3[Lettres.Length];
        droppedLettre = new bool[Lettres.Length];
        droppedBox = new bool[Boxes.Length];
        for(int i = 0; i < Lettres.Length; i++){
            lettresInitPos[i] = Lettres[i].transform.position;
            lettresInitScal[i] = Lettres[i].transform.localScale;
        }
    }

    //dragging lettre
    protected void DragLettreBase(int indexLettre){
        if (!droppedLettre[indexLettre])
            Lettres[indexLettre].transform.position = Input.mousePosition;
    }
    //dropping lettre
    protected void DropLettreBase(int indexLettre){
        //distance from lettre to boxes
        float[] Distances = new float[Boxes.Length];
        for (int i = 0; i < Boxes.Length; i++){
            Distances[i] = Vector3.Distance(Lettres[indexLettre].transform.position, Boxes[i].transform.position);
        }

        //drop letrre
        for (int i = 0; i < Boxes.Length && !droppedLettre[indexLettre]; i++){
            if (Distances[i] < 50 && !droppedBox[i]){
                    Lettres[indexLettre].transform.localScale = Boxes[i].transform.localScale;
                    Lettres[indexLettre].transform.position = Boxes[i].transform.position;
                    droppedLettre[indexLettre] = true;
                    droppedBox[i] = true;
                    Boxes[i].name = Lettres[indexLettre].name;
                    break;
            }
            else{
                Lettres[indexLettre].transform.position = lettresInitPos[indexLettre];
            }
        }
    }
    

        //---------------------------Option Function-----------------------------
    public void Check()
    { 
        foreach(GameObject s in Boxes){
            inputString += s.name;
        }

        if(inputString==resultString)
        {
            Success = true;
        }
        else
        {
            Reload();
            gameObject.SetActive(false); 
            Success = false;   
        }
    }

    public void Reload()
    {
        inputString = "";
        droppedLettre = new bool[Lettres.Length];
        droppedBox = new bool[Boxes.Length];

        for (int i = 0; i < Boxes.Length; i++){
            Boxes[i].name = i.ToString();
        }
        for(int i = 0; i < Lettres.Length; i++){
            Lettres[i].transform.position = lettresInitPos[i];
            Lettres[i].transform.localScale = lettresInitScal[i];
        }
       
    }
    
}