using AspNetCore.Reporting;
using BlazorReportViewer.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace BlazorReportViewer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        EmployeeService employeeService = new EmployeeService();
        public EmployeeController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        [HttpGet]
        [Route("EmployeeReport")]
        public IActionResult EmployeeReport()
        {
            var dt = new DataTable();
            dt = employeeService.GetEmployeeInfo();

            string mimetype = "";
            int extension = 1;
            var path = $"{webHostEnvironment.WebRootPath}\\Reports\\EmployeeReport.rdlc";

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("param", "Blazor Sever Report Viewer");

            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("DsEmployeeInfo", dt);
            var report = localReport.Execute(RenderType.Pdf, extension, parameters, mimetype);

            return File(report.MainStream,"Application/pdf");
        }
    }
}
