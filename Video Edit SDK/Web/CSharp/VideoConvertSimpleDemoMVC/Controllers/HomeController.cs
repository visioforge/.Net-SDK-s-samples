using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideoEditMVC.Controllers
{
    using System.Diagnostics;
    using System.IO;
    using System.Web.Caching;

    using VisioForge.Controls.VideoEdit;
    using VisioForge.Types;
    using VisioForge.Types.OutputFormat;

    public class HomeController : Controller
    {
        private VideoEditCore _core;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Convert(string filename)
        {
            ViewBag.Message = "Convert file: " + filename;

            return View();
        }

        private void _core_OnError(object sender, VisioForge.Types.ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        public ActionResult Download(string filename)
        {
            ViewBag.Message = "Download output file: " + filename;

            return View();
        }

        public ActionResult StartConvertClick()
        {
            var sourceFile = Session["UploadedFile"].ToString();
            var sourceFileFull = Path.Combine(Server.MapPath("~/Data/"), sourceFile);

            ViewBag.Message = $"Converting... ({sourceFile})";

            _core = new VideoEditCore();
            _core.OnError += _core_OnError;
            _core.OnProgress += _core_OnProgress;
            _core.Input_AddVideoFile(sourceFileFull);
            _core.Input_AddAudioFile(sourceFileFull, sourceFileFull);
            _core.Mode = VFVideoEditMode.Convert;
            _core.Output_Format = new VFMP4v8v10Output();
            _core.Output_Filename = Server.MapPath("~/Data/output.mp4");
            
            _core.ConsoleUsage = true;

            _core.Start();

            _core.Dispose();

            return RedirectToAction("Download", new { filename = "output.mp4" });
        }

        private void _core_OnProgress(object sender, ProgressEventArgs e)
        {
            Debug.WriteLine(e.Progress);

            //ViewBag.Progress = "Progress: " + e.Progress.ToString();
        }

        public ActionResult SaveDocumentClick()
        {
            string filePath = Server.MapPath("~/Data/output.mp4");
            string contentType = "video/mp4";

            return File(filePath, contentType, "output.mp4");
        }

        [HttpPost]
        public ActionResult Upload()
        {
            string uploadedFile = null;
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    uploadedFile = Path.GetFileName(file.FileName);
                    var uploadedFileFull = Path.Combine(Server.MapPath("~/Data/"), uploadedFile);
                    file.SaveAs(uploadedFileFull);

                    Session["UploadedFile"] = uploadedFile;
                }
            }

            return RedirectToAction("Convert", new { filename = uploadedFile });
        }
    }
}