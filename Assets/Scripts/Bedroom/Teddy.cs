/*
  This object hold a item to solve televison puzzle
  Player does a option choice and must choose tearing the teddy bear to take the item "Remote"
*/

using UnityEngine;
using UnityEngine.UI;
using Utility;

public sealed class Teddy : Interactable
{
    public Inventory Inventory;
    public Item contents;
    public bool isOpened, isTakenRemote;
    public GameObject dialogBox;
    public Text dialogText;
    public GameObject Option; 
    private Animator anim;

    void Start(){
      //init the animator of the teddy.
      anim = GetComponent<Animator>();
    }

    void Update(){ 
      //show option choices
      if (Input.GetKeyDown(KeyCode.Space) && activeArea){
        if (!isOpened && !isTakenRemote)
        interactObject(Option);
        
        //take the remote.
        else if (isOpened && !isTakenRemote) {
          dialogBox.SetActive(true);
          dialogText.text = contents.itemDescription;
          Inventory.AddItem(contents);
          isTakenRemote = true;
        }
        //already taken the remote.
        else if (isOpened && isTakenRemote)
          dialogBox.SetActive(false);
      }
    }

    public void OpenTeddyOption()
    {
        Audio.Instance.Play(Sound.Teddy);
        anim.SetBool("teared", true);

        Option.SetActive(false);
        isOpened = true;
    }
    
    public void doNothingOption(){
      Option.SetActive(false);
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
      if (other.CompareTag("Player") && !other.isTrigger)
      {
        activeArea = false;
        dialogBox.SetActive(false);
        Option.SetActive(false);
      }
    }
}

