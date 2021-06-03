using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Examples.SceneChange.Scripts
{
    public class SceneRenderer : MonoBehaviour
    {
        public void Render(string[] sceneNames)
        {
            var requestSceneMap = CreateRequestSceneMap(sceneNames);
            var currentSceneMap = CreateCurrentSceneMap();
            var loadScenes = requestSceneMap.Keys
                .Where(scene => !currentSceneMap.ContainsKey(scene) || !currentSceneMap[scene])
                .Distinct().ToList();
            var unloadScenes = currentSceneMap.Keys
                .Where(scene => !requestSceneMap.ContainsKey(scene) || !requestSceneMap[scene])
                .Distinct().ToList();

            foreach (var scene in loadScenes)
            {
                SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
            }

            foreach (var scene in unloadScenes)
            {
                SceneManager.UnloadSceneAsync(scene);
            }
        }

        private IDictionary<string, bool> CreateRequestSceneMap(string[] sceneNames)
        {
            var sceneMap = new Dictionary<string, bool>();
            foreach (var sceneName in sceneNames)
            {
                sceneMap[sceneName] = true;
            }

            return sceneMap;
        }

        private IDictionary<string, bool> CreateCurrentSceneMap()
        {
            var sceneMap = new Dictionary<string, bool>();

            for (var i = 0; i < SceneManager.sceneCount; i++)
            {
                var scene = SceneManager.GetSceneAt(i);
                sceneMap[scene.name] = true;
            }

            return sceneMap;
        }
    }
}