
namespace com.application.utility
{
    /// <summary>
    /// Generic class for making singletons.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> where T : class
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = (T)System.Activator.CreateInstance(typeof(T));
                }
                return instance;
            }
        }
    }
}

