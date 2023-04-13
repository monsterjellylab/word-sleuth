using Game.Scripts.Helpers;
using Game.Scripts.Loaders;

namespace Game.Scripts
{
    public static class WordSelector
    {
        public static string SelectWord(string themeName, WordDifficulty difficulty)
        {
            WordFinder wordFinder = new WordFinder(new JsonThemeLoader());

            var words = wordFinder.FindWordsByTheme(themeName, difficulty);

            return words.GetRandomElementFromArray();
        }
    }
}