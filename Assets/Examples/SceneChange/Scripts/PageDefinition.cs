using System;
using System.Collections.Generic;
using System.Linq;

namespace Examples.SceneChange.Scripts
{
    public static class PageDefinition
    {
        public static Page Of(string name)
        {
            var page = pages.FirstOrDefault(x => x.Name == name);
            if (page == null)
            {
                throw new ArgumentException($"Page: {name} is not defined");
            }

            return page;
        }

        private static readonly IList<Page> pages = new[]
        {
            new Page("Page1", new[] {"Base", "Multi1"}),
            new Page("Page2", new[] {"Base", "Multi2"}),
        };
    }
}