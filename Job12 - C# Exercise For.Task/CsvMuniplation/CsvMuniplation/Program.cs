// See https://aka.ms/new-console-template for more information
using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using CsvMuniplation;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Xml.Linq;
using System;


Console.WriteLine("Hello, World!");
List<Model> models = new List<Model>();
List<OutputModel> outModels = new List<OutputModel>();
using (var reader = new StreamReader("D:\\Tariq-private\\work\\Job12\\CsvMuniplation\\CsvMuniplation\\csvFile\\Test.csv"))
using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
{
    models = csv.GetRecords<Model>().ToList();

    foreach (var record in models)
    {
        var newColumn = "";
        if(record.OC.ToString().Length < 4)
        {
            newColumn = record.OC.ToString();
            var zeroCount = 4 - record.OC.ToString().Length ;
            for (int i = 0; i < zeroCount; i++)
            {
                newColumn = "0" + newColumn;
            }
        }
        outModels.Add(new OutputModel
        {
            Fname = record.Fname,
            Lname = record.Lname,
            Phone = record.Phone,
            email = record.email,
            managerEmail = record.managerEmail,
            New_Column = record.CCID + "-" + newColumn,
            Country = record.Country,
            Active = record.Active,
            UG = record.UG,
        });

        var filePath = "D:\\Tariq-private\\work\\Job12\\CsvMuniplation\\CsvMuniplation\\Output\\Test_Modified.csv";

        // Write data to the CSV file
        using (var writer = new StreamWriter(filePath))
        using (var csvOutput = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            csvOutput.WriteRecords(outModels);
        }
    }
}
