using System.Text;
using Game.Scripts.Helpers;

namespace Game.Scripts.UI.Game
{
    public class LetterMixer
    {
        public string Mix(string word)
        {
            string mixedWord = "";
            if (word.Contains(""))
            {
                StringBuilder combinedWords = new StringBuilder();

                var wordPieces = word.Split("");

                foreach (var wordPiece in wordPieces)
                {
                    combinedWords.Append(wordPiece);
                }

                mixedWord = combinedWords.ToString().ShuffleWord();
            }
            else
            {
                mixedWord = word.ShuffleWord();
            }

            return mixedWord;
        }
    }
}