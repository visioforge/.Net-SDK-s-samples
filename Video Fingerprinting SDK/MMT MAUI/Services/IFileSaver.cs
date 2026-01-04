namespace MMT_MAUI.Services
{
    public interface IFileSaver
    {
        Task<string?> SaveFileAsync(string suggestedFileName, Dictionary<string, List<string>> fileTypes);
    }
}