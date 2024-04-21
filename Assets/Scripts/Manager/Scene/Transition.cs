using UnityEngine.SceneManagement;

namespace Manager.Scene
{
    public sealed class Transition
    {
        public static void Load(Scene scene)
        {
            SceneManager.LoadScene(scene switch
            {
                Scene.Title => SceneName.Title,
                Scene.Playground => SceneName.Playground,
                _ => throw new System.NotImplementedException($"{scene}")
            });
        }

        public static void Exit()
        {
            UnityEngine.Application.Quit();
        }
    }

    public enum Scene
    {
        Title,
        Playground
    }

    public sealed class SceneName
    {
        public static string Title = "title";
        public static string Playground = "playground";        
    }
}
