using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace UnityHooks.PluginPage.Renderer
{
    public class SceneRenderer
    {
        public void Render(IEnumerable<string> sceneNames)
        {
            RenderAsync(sceneNames).Forget();
        }

        public async UniTask RenderAsync(IEnumerable<string> sceneNames)
        {
            var requestSceneMap = CreateRequestSceneMap(sceneNames);
            var currentSceneMap = CreateCurrentSceneMap();
            var loadScenes = requestSceneMap.Keys
                .Where(scene => !currentSceneMap.ContainsKey(scene) || !currentSceneMap[scene])
                .Distinct().ToList();
            var unloadScenes = currentSceneMap.Keys
                .Where(scene => !requestSceneMap.ContainsKey(scene) || !requestSceneMap[scene])
                .Distinct().ToList();

            {
                var list = new List<UniTask>();
                foreach (var scene in loadScenes)
                {
                    list.Add(SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive).ToUniTask());
                }

                await UniTask.WhenAll(list);
            }

            {
                var list = new List<UniTask>();
                foreach (var scene in unloadScenes)
                {
                    list.Add(SceneManager.UnloadSceneAsync(scene).ToUniTask());
                }

                await UniTask.WhenAll(list);
            }
        }

        private IDictionary<string, bool> CreateRequestSceneMap(IEnumerable<string> sceneNames)
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