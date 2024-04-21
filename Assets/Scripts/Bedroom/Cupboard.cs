/*
    This object needs the key to open
    Show Shikagami technique
*/

using UnityEngine;
using UnityEngine.UI;
using Utility;

public class Cupboard : Interactable
{
    public GameObject diary;
    public GameObject dialogBox;
    public Inventory PlayerInventory;
    public Item Key;
    public Text dialogText;
    SpriteRenderer spriteRenderer;
    public Sprite cupborOpen;
    bool isOpened;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && activeArea){
            if(PlayerInventory.checkContains(Key) && !isOpened){
                spriteRenderer.sprite = cupborOpen;
                Audio.Instance.Play(Sound.Key);
                isOpened = true;
                return;
            }
            if (isOpened){
                if(!diary.activeInHierarchy){
                    diary.SetActive(true);
                }else
                    diary.SetActive(false);
            }
            else{
                if(!dialogBox.activeInHierarchy){
                    dialogBox.SetActive(true);
                    dialogText.text = "Nothing but a locked drawer.";
                }
                else{
                    dialogBox.SetActive(false);
                }
            }
        }
    }
    public override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger){
            activeArea = false;
            dialogBox.SetActive(false);
            diary.SetActive(false);
        }
    }

}
