namespace Game.Scripts.Interfaces.IWord
{
    public interface IWordFinder<T>
    {
        T[] FindWords(string themeName, WordDifficulty difficulty);
    }
}