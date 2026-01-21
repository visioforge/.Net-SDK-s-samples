using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Simple_Player_MVVM.ViewModels;
using System;

namespace Simple_Player_MVVM
{
    /// <summary>
    /// View locator.
    /// </summary>
    public class ViewLocator : IDataTemplate
    {
        /// <summary>
        /// Build control.
        /// </summary>
        public Control? Build(object? data)
        {
            if (data is null)
                return null;

            var name = data.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
            var type = Type.GetType(name);

            if (type != null)
            {
                return (Control)Activator.CreateInstance(type)!;
            }

            return new TextBlock { Text = "Not Found: " + name };
        }

        /// <summary>
        /// Match.
        /// </summary>
        public bool Match(object? data)
        {
            return data is ViewModelBase;
        }
    }
}