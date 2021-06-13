using BookManager.Services.Pdf.PdfActions;
using BookManager.Services.Pdf.Utility;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.Controllers.PdfGeneratorControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfCreatorController : ControllerBase
    {
        private ICreatePdf _createPdf;

        public PdfCreatorController(ICreatePdf createPdf)
        {
            _createPdf = createPdf;
        }

        [HttpGet]
        public IActionResult CreatePDF()
        {
            var response = _createPdf.CreatePdfInvoice();
            return Ok(response);
        }

    }
}
