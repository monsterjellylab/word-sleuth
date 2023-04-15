using System.Collections.Generic;
using Game.Scripts.Interfaces.ITheme;
using Game.Scripts.Interfaces.IWord;
using Game.Scripts.Models.Theme;

namespace Game.Scripts.Helpers
{
    public class WordFinder : IWordFinder<string>
    {
        private readonly IThemeLoader themeLoader;

        public WordFinder(IThemeLoader themeLoader)
        {
            this.themeLoader = themeLoader;
        }

        public string[] FindWords(string themeName = null, WordDifficulty difficulty = WordDifficulty.All)
        {
            var themes = themeLoader.LoadThemes();

            var chosenTheme = getChosenTheme(themeName, themes);

            var allWords = new List<string>();

            switch (difficulty)
            {
                case WordDifficulty.Easy:
                    allWords.AddRange(chosenTheme.Words.Easy);
                    break;
                case WordDifficulty.Medium:
                    allWords.AddRange(chosenTheme.Words.Medium);
                    break;
                case WordDifficulty.Hard:
                    allWords.AddRange(chosenTheme.Words.Hard);
                    break;
                case WordDifficulty.All:
                    allWords.AddRange(chosenTheme.Words.Easy);
                    allWords.AddRange(chosenTheme.Words.Medium);
                    allWords.AddRange(chosenTheme.Words.Hard);
                    break;
            }

            return allWords.ToArray();
        }

        private Theme getChosenTheme(string themeName, Theme[] themes)
        {
            if (themeName == null)
            {
                return themes.GetRandomElementFromArray<Theme>();
            }

            foreach (var theme in themes)
            {
                if (theme.Name != themeName) continue;

                return theme;
                break;
            }

            return null;
        }
    }
}