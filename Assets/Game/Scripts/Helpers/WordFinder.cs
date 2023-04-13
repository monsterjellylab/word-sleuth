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

        public string[] FindWordsByTheme(string themeName, WordDifficulty difficulty)
        {
            var themes = themeLoader.LoadThemes();

            foreach (var theme in themes)
            {
                if (theme.Name != themeName) continue;
                    switch (difficulty)
                    {
                        case WordDifficulty.Easy:
                            return theme.Words.Easy;
                        case WordDifficulty.Medium:
                            return theme.Words.Medium;
                        case WordDifficulty.Hard:
                            return theme.Words.Hard;
                    }
            }

            return default;
        }
    }
}