using System.Threading.Tasks;

namespace SimplePlayerMVVM;

/// <summary>
/// Document picker service.
/// </summary>
public interface IDocumentPickerService
{
    /// <summary>
    /// Pick video async.
    /// </summary>
    Task<object?> PickVideoAsync();
}