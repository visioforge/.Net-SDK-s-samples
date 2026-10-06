using System;
using System.Web;
using VisioForge.Core.UI.WebForms;

namespace HLS_Media_Web_Forms
{
    public class Global : HttpApplication
    {
        protected void Application_End(object sender, EventArgs e)
        {
            HlsStreamManager.StopAll();
        }
    }
}
