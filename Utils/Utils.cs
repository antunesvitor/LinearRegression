using System.Collections.Generic;
using LinearRegression.CSVModels;

namespace LinearRegression.Utils
{
    public static class Utils{
        public static double[,] ToTwoDimensionalArray (this List<LinearValuesModel> list){
            double [,] tuples = new double[list.Count,2];
            for (int i = 0; i < list.Count; i++)
            {
                tuples[i, 0] = list[i].x;
                tuples[i, 1] = list[i].y;
            }

            return tuples;
        }
    }
}