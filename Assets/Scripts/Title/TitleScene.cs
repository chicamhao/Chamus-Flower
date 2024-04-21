using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Manager.Scene;

namespace Scripts.Title
{
    public sealed class TitleScene : MonoBehaviour
    {
        [SerializeField] Button _startButton;
        [SerializeField] Button _exitButton;

        private void Start()
        {
            _startButton.onClick.AddListener(() =>
            {
                Transition.Load(Scene.Playground);
            });

            _exitButton.onClick.AddListener(() =>
            {
                Transition.Exit();
            });
        }
    }
}
