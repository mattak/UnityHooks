using System;

namespace Examples.SceneChange.Scripts
{
    [Serializable]
    public class Page
    {
        public string Name { get; }
        public string[] SceneNames { get; }
        public object Data { get; set; }

        public Page(string name, string[] sceneNames)
        {
            Name = name;
            SceneNames = sceneNames;
            Data = null;
        }
    }
}