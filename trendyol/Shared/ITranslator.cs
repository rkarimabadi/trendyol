namespace trendyol.Shared
{
    public interface ITranslator
    {

        Task<string> Translate(string input, string fromLanguage="fa", string toLanguage = "tr");
    } 
}