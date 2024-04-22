using UnityEngine;
using UnityEngine.Assertions;
using Utility;
using static Interactable;

namespace Manager
{
    public sealed class Director
    {
        public static Director Instance => DIContainer.Get<Director>();
        private readonly DialogData _dialogData;

        public Director(DialogData dialogData)
        {
            Assert.IsNotNull(dialogData);
            _dialogData = dialogData;

            Audio.Instance.Play(Sound.Background);
            DialogLauncher.Instance.LaunchCommon(Common.Constants.Introduction_1);
            Camera.main.transform.position = Common.Appearance.LivingRoom.Camera;
        }

        public GameObject GetInteractObject(ObjectType type)
        {
            switch (type)
            {
                case ObjectType.Empty: break;

                case ObjectType.Newspaper:
                    DialogLauncher.Instance.LaunchCommon(Common.Constants.Newspaper_1);
                    return null;

                case ObjectType.CatPicture:
                    return Instance._dialogData.CatPicture;

                case ObjectType.Bush:
                    return Instance._dialogData.Bush;
            }
            return null;
        }
    }
}


