using System;
using System.Collections.Generic;
using System.Linq;

namespace UnityHooks.PluginPage
{
    [Serializable]
    public class Page
    {
        public string name;
        public List<string> scenes;

        public Page(string name, params string[] scenes)
        {
            this.name = name;
            this.scenes = scenes.ToList();
        }
    }
}