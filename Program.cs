using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using LinearRegression.CSVModels;
using LinearRegression.Modelo;
using LinearRegression.Utils;

namespace LinearRegression
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<LinearValuesModel> records;
            List<LinearValuesModel> recordsList;
            using (var reader = new StreamReader("C:\\yara_logs\\Clevinho.csv"))
            using(var csv = new CsvReader(reader))
            {
                records = csv.GetRecords<LinearValuesModel>();
                recordsList = records.ToList();
            }
            double [,] recordsArray = recordsList.ToTwoDimensionalArray();

            RegressaoLinear modelo = new RegressaoLinear(alpha: 0.00005);

            int interacoes = 200000;

            modelo.fit(recordsArray, interactions: interacoes);

            var (theta0, theta1) = modelo.getThetaValues();
            Console.WriteLine($"interação {interacoes -1}: thetaZERO: {theta0} ; thetaUM: {theta1}");
        }
    }
}
