using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Utility
{
    public class Dialog : MonoBehaviour
    {
        [SerializeField] Text _descriptionText;
        [SerializeField] Button _closeButton;

        public Action PositiveCallback;

        private void Awake()
        {
            _closeButton.onClick.AddListener(Deactivate);
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && gameObject.activeInHierarchy)
            {
                Deactivate();
            }
        }

        public void Activate() => gameObject.SetActive(true);

        public void Deactivate() => gameObject.SetActive(false);
        
        public void Setup(string description)
        {
            _descriptionText.text = description;
        }
    }


    public sealed class DialogLauncher
    {
        public static DialogLauncher Instance => DIContainer.Get<DialogLauncher>();
        private readonly DialogData _data;

        private Dialog _displayed;
        private Action _callback;

        public DialogLauncher(DialogData data)
        {
            Assert.IsNotNull(data);
            _data = data;
        }

        public void LaunchCommon(string description)
        {
            _displayed = _data.Common;
            _displayed.Activate();
            _displayed.Setup(description);
        }

        public void LaunchBookPuzzle(Action callback)
        {
            _displayed = _data.BookSelfPuzzle;
            _callback = callback;
            _displayed.PositiveCallback += callback;
            _displayed.Activate();
        }

        public void Deactivate()
        {
            if (_displayed != null)
            {
                _displayed.Deactivate();
            }
            _displayed.PositiveCallback -= _callback;
            _callback = null;
            _displayed = null;
        }
    }

    [Serializable]
    public sealed class DialogData
    {
        public Dialog Common;

        public BookShelfPuzzle BookSelfPuzzle;
        public CabinetPuzzle CabinetPuzzle;

        public GameObject CatPicture;
        public GameObject Alphabet;
 
        public GameObject Shinigami;
        public GameObject ChamusDiary;
        public GameObject BeautyUnderTheMoon;

        public GameObject Newspaper;
        public GameObject Bush;
    }
}
