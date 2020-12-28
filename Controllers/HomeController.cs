using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace crystalproject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Download_PDF();
            return View();
        }

        public ActionResult Download_PDF()
        {
          
            ReportDocument rprt = new ReportDocument();
            rprt.Load(Server.MapPath("~/CrystalReport1.rpt"));

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rprt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rprt.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rprt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;

            Stream stream = rprt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "CustomerList.pdf");
        }

    
    public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}