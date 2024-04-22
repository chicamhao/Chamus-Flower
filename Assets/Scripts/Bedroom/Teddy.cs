
using UnityEngine;
using UnityEngine.UI;
using Utility;


// This object hold a item to solve televison puzzle
// Player does a option choice and must choose tearing the teddy bear to take the item "Remote"
public sealed class Teddy : Interactable
{
    public Inventory Inventory;
    public Item contents;
    public bool isOpened, isTakenRemote;
    public GameObject dialogBox;
    public Text dialogText;
    public GameObject Option; 
    private Animator anim;

    void Start()
    {
        _object = Option;
        _onInteract += OnInteract;
        anim = GetComponent<Animator>();
    }

    private void OnInteract()
    {
        if (isOpened && !isTakenRemote)
        {
            DialogLauncher.Instance.LaunchCommon(contents.itemDescription);
            Inventory.AddItem(contents);
            isTakenRemote = true;
        }
        else if (isOpened && isTakenRemote)
        {
            DialogLauncher.Instance.Deactivate();
        }
    }

    public void OpenTeddyOption()
    {
        Audio.Instance.Play(Sound.Teddy);
        anim.SetBool("teared", true);

        Option.SetActive(false);
        isOpened = true;
    }
    
    public void doNothingOption()
    {
        Option.SetActive(false);
    }
}

