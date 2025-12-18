using UnityEngine;

namespace UnityUtils.ScriptUtils
{
    public static class CoroutineStarter
    {
        public class CoroutineStarterObject : MonoBehaviour { }

        private static CoroutineStarterObject starter;

        /// Starter for normal coroutines.
        public static CoroutineStarterObject Starter { 
            get 
            { 
                if (starter == null)
                {
                    GameObject obj = new GameObject("Coroutine Starter [UnityUtils]");
                    starter = obj.AddComponent<CoroutineStarterObject>();
                }

                return starter;
            } 
        }

        private static CoroutineStarterObject persistantStarter;

        /// Starter for coroutines that don't stop on loading a new scene.
        public static CoroutineStarterObject PersistantStarter
        {
            get
            {
                if (persistantStarter == null)
                {
                    GameObject obj = new GameObject("Persistant Coroutine Starter [UnityUtils]");
                    persistantStarter = obj.AddComponent<CoroutineStarterObject>();
                    Object.DontDestroyOnLoad(obj);
                }

                return persistantStarter;
            }
        }
    }
}