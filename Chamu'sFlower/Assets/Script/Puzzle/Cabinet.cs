
/*
    This object hold a word puzzle (Cabinet Puzzle)
    Receive a item 'Key' to unlook the cupboard 
    and Chamu's diary  when the player solved the puzzle
*/

using UnityEngine;
using UnityEngine.UI;
public class Cabinet : Interactable
{   
    public GameObject PuzzleWord;
    public GameObject dialogBox;

    public Inventory PlayerIventory;
    public Item Content;
    public Sprite openSprite;
    SpriteRenderer spriteRenderer;
    public GameObject itemDesDialog;
    public Text itemText;
    bool isOpened, Success;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Success = PuzzleWord.GetComponent<CabinetPuzzle>().Success;
        if (!Success)
            interactObject(PuzzleWord);
        else{
            if(!isOpened)
                OpenCabinet();
            else
                CabinetAlreadyOpened();
        }
    }

    public override void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            activeArea = false;
            PuzzleWord.SetActive(false);
            dialogBox.SetActive(false);
            itemDesDialog.SetActive(false);
            PuzzleWord.GetComponent<CabinetPuzzle>().Reload();
        }
    }

    public void OpenCabinet(){
        PuzzleWord.SetActive(false);
        //item taken
        PlayerIventory.AddItem(Content);
        itemDesDialog.SetActive(true);
        itemText.text = Content.itemDescription;
        //puzzle off
        spriteRenderer.sprite = openSprite;
        //sound
        FindObjectOfType<AudioManager>().Play("cupboard");

        isOpened = true;
    }

    public void CabinetAlreadyOpened(){
        if(Input.GetKeyDown(KeyCode.Space) && activeArea && itemDesDialog.activeInHierarchy)
            itemDesDialog.SetActive(false);
        else
            interactObject(dialogBox);
    }
}