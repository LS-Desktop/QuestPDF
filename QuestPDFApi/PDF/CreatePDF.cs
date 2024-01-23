using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using QuestPDF.Previewer;
using Svg.Skia;
using QuestPDFApi.PDF.ExtensionToSVG;

namespace QuestPDFApi.PDF
{
    public class CreatePDF
    {
        public static void GeneratePdf()
        {
            //Logo ls svg 
            using var svg = new SKSvg();
            svg.Load("Images/LSlogo.svg");

            //License
            QuestPDF.Settings.License = LicenseType.Community;
            // code in your main method
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(20));

                    page.Header()
                        .Text("Crea el PDF!")
                        .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);

                    page.Content()
                .PaddingVertical(1, Unit.Centimetre)
                .Column(x =>
                {
                    x.Spacing(20);

                    x.Item().Text("Esto es una prueba de que funciona");
                    x.Item().Text("Desde la api");

                    x.Item().Svg(svg);
                });
                    
                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.DefaultTextStyle(x => x.FontSize(10));
                            x.Span("Page ");
                            x.CurrentPageNumber();
                        });
                });
            });
            // instead of the standard way of generating a PDF file
            document.GeneratePdf("hello.pdf");

            // use the following invocation
            document.ShowInPreviewer();

        }
    }
}
