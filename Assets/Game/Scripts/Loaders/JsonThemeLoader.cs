using Game.Scripts.Interfaces.ITheme;
using Game.Scripts.IO;
using Game.Scripts.Models.Theme;

namespace Game.Scripts.Loaders
{
    public class JsonThemeLoader : IThemeLoader
    {
        private readonly string JSON_FILE = "themes";
        private bool loaded = false;
        private Theme[] loadedThemes;

        public Theme[] LoadThemes()
        {
            if (loaded)
                return loadedThemes;

            loadedThemes = JSONFileIO.ReadJSONFile<ThemesData>(JSON_FILE).Themes;

            return loadedThemes;
        }
    }
}