using Game.Scripts.Helpers;
using Game.Scripts.Interfaces.ITheme;
using Game.Scripts.Loaders;

namespace Game.Scripts.Selector
{
    public static class WordSelector
    {
        public static string SelectedWord;

        public delegate void WordSelectedEventHandler(string word);

        public static event WordSelectedEventHandler WordSelected;

        public static void SelectWord(string themeName = null, WordDifficulty difficulty = WordDifficulty.All,
            IThemeLoader themeLoader = null)
        {
            themeLoader ??= new JsonThemeLoader();
            var wordFinder = new WordFinder(themeLoader);

            var words = wordFinder.FindWords(themeName, difficulty);

            SelectedWord = words.GetRandomElementFromArray();
            WordSelected?.Invoke(SelectedWord);
        }
    }
}