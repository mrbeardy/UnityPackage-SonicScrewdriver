using Beardy.SonicScrewdriver.Editor.MonoBehaviours;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Beardy.SonicScrewdriver.Editor.Features
{
    [InitializeOnLoad]
    public class Watch
    {
        static Watch()
        {
            SceneManager.sceneLoaded += SceneManager_SceneLoaded;
        }

        private static void SceneManager_SceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            InstantiateWatchManager();
        }

        private static void InstantiateWatchManager()
        {
            Debug.Log("Initializing Watch Manager");

            Helpers.InstantiatePrefab("WatchManager");
        }
    }
}