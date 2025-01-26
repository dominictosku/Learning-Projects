using ClosedXML.Excel;
using MAUIExamples.Core.Entities;

namespace MAUIExamples.Core.Services
{
    public class ExcelService
    {
        public MemoryStream GenerateExcel(List<Car> cars, List<Producer> producers)
        {
            // Create a new workbook
            using (var workbook = new XLWorkbook())
            {
                // Add a worksheet for cars
                var carsWorksheet = workbook.AddWorksheet("Cars");

                // Add headers for cars
                carsWorksheet.Cell(1, 1).Value = "ID";
                carsWorksheet.Cell(1, 2).Value = "Name";
                carsWorksheet.Cell(1, 3).Value = "Release Date";
                carsWorksheet.Cell(1, 4).Value = "Producer ID";

                // Add car data to worksheet
                for (int i = 0; i < cars.Count; i++)
                {
                    carsWorksheet.Cell(i + 2, 1).Value = cars[i].Id;
                    carsWorksheet.Cell(i + 2, 2).Value = cars[i].Name;
                    carsWorksheet.Cell(i + 2, 3).Value = cars[i].ReleaseDate.ToShortDateString();
                    carsWorksheet.Cell(i + 2, 4).Value = cars[i].ProducerId;
                }

                // Add a worksheet for producers
                var producersWorksheet = workbook.AddWorksheet("Producers");

                // Add headers for producers
                producersWorksheet.Cell(1, 1).Value = "ID";
                producersWorksheet.Cell(1, 2).Value = "Name";

                // Add producer data to worksheet
                for (int i = 0; i < producers.Count; i++)
                {
                    producersWorksheet.Cell(i + 2, 1).Value = producers[i].Id;
                    producersWorksheet.Cell(i + 2, 2).Value = producers[i].Name;
                }

                // Save the workbook
                var memoryStream = new MemoryStream();
                workbook.SaveAs(memoryStream);

                memoryStream.Position = 0;
                return memoryStream;
            }
        }

    }
}
