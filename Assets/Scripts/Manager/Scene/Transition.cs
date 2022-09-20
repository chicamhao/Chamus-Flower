using UnityEngine.SceneManagement;

namespace Assets.Scripts.Manager.Scene
{
    public sealed class Transition
    {
        private static Transition instance;

        public static Transition Instance
        {
            get
            {
                if (instance == null)
                    instance = new Transition();
                return instance;
            }
        }

        public void LoadScene(Scene scene)
            => SceneManager.LoadScene(scene.ToString());
    }

    //Ensure enum has the same name as scene
    public enum Scene
    {
        Title,
        Livingroom,
        Bedroom,
        Bathroom
    }
}
