using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Assets.Scripts.Manager.Scene;
using Assets.Scripts.Manager;

namespace Scripts.Title
{
    public sealed class TitleSceneRoot : MonoBehaviour
    {
        [SerializeField] Button startButton;
        [SerializeField] Button exitButton;
        //TODO:
        [SerializeField] Button saveButton;

        private void Start()
        {
            startButton.OnClickAsObservable()
                .Subscribe(_ => Transition.Instance.LoadScene(Scene.Livingroom))
                .AddTo(this);

            exitButton.OnClickAsObservable()
                .Subscribe(_ => ApplicationHandler.Instance.ExitApplication())
                .AddTo(this);
        }
    }
}
