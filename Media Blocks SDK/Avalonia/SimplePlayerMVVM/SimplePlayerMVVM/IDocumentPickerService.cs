using System.Threading.Tasks;

namespace SimplePlayerMVVMMB;

public interface IDocumentPickerService
{
    Task<object?> PickVideoAsync();
}