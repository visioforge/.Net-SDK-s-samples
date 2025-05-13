using System.Threading.Tasks;

namespace SimplePlayerMVVM;

public interface IDocumentPickerService
{
    Task<object?> PickVideoAsync();
}