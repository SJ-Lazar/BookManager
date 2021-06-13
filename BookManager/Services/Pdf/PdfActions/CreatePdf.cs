using BookManager.Services.Pdf.Utility;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.Services.Pdf.PdfActions
{
    public class CreatePdf : ICreatePdf
    {
        private IConverter _converter;

        public CreatePdf(IConverter converter)
        {
            _converter = converter;
        }

        public string CreatePdfInvoice()
        {
            //Overall Configuration propertise.
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF INVOICE",
                Out = @"C:\PDFCreator\Invoice.pdf"
            };

            //content of pdf propertises.
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = TemplateGenerator.GetHTMLString(),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "style.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

           _converter.Convert(pdf);

            var response = ("Successfully created PDF document.");

            return response;
        }
    }
}
