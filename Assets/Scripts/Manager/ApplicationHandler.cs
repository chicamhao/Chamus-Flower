namespace Assets.Scripts.Manager
{
    public class ApplicationHandler
    {
        private static ApplicationHandler instance;

        public static ApplicationHandler Instance
        {
            get
            {
                if (instance == null)
                    instance = new ApplicationHandler();
                return instance;
            }
        }

        public void ExitApplication()
            => UnityEngine.Application.Quit();
    }
}
