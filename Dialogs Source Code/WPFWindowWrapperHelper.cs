// <copyright file="WPFWindowWrapperHelper.cs" company="VisioForge">
// Copyright (c) VisioForge. All rights reserved.
// </copyright>

using System.Windows.Forms;

namespace VisioForge.Controls.UI.Dialogs
{
    /// <summary>
    /// Helper to show WinForms dialog in WPF app.
    /// </summary>
    public static class WPFWindowWrapperHelper
    {
        /// <summary>
        /// Show dialog.
        /// </summary>
        /// <param name="form">
        /// WinForms form.
        /// </param>
        /// <param name="parent">
        /// WPF window.
        /// </param>
        /// <returns>
        /// Dialog result.
        /// </returns>
        public static DialogResult ShowDialog(this Form form, System.Windows.Window parent)
        {
            return form.ShowDialog(new WPFWindowWrapper(parent));
        }
    }
}
