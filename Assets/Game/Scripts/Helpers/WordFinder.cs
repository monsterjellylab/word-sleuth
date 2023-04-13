using System.Linq;
using Game.Scripts.Interfaces.ITheme;
using Game.Scripts.Interfaces.IWord;

namespace Game.Scripts.Helpers
{
    public class WordFinder : IWordFinder<string>
    {
        private readonly IThemeLoader themeLoader;

        public WordFinder(IThemeLoader themeLoader)
        {
            this.themeLoader = themeLoader;
        }

        public string[] FindWordsByTheme(string themeName)
        {
            return (from theme in themeLoader.LoadThemes() where theme.Name == themeName select theme.Words)
                .FirstOrDefault();
        }
    }
}