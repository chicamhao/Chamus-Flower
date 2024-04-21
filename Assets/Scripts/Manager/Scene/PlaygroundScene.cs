using UniRx;
using UnityEngine;
using Utility;

namespace Manager.Scene
{
	public class PlaygroundScene : MonoBehaviour
	{
		[SerializeField] CommonSO _common;
        readonly CompositeDisposable _disposables = new();

		void Awake()
		{
			DIContainer.Inject(new Common(_common)).AddTo(_disposables);
		}

        private void OnDestroy()
        {
			_disposables.Dispose();
        }
    }
}