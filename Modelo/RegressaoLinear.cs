using System;
using System.Collections.Generic;

namespace LinearRegression.Modelo
{
    public class RegressaoLinear
    {
        //constante
        private double _theta0;
        //coeficiente
        private double _theta1;
        private double _alpha;


        public RegressaoLinear(double thetaZero = 0, double thetaUm = 0, double alpha = 0.005)
        {
            _theta0 = thetaZero;
            _theta1 = thetaUm;
            _alpha = alpha;
        }


        public void fit(double [,] realValues, long interactions = 200)
        {
            // double cost = Int32.MaxValue;
            for (int i = 0; i < interactions; i++)
            {
                newThetaValue(realValues);
            }
        }
        private double[,] predictValues(double[] values)
        {
            double[,] prediction = new double[values.Length,2];
            for (int i = 0; i < values.Length; i++)
            {
                prediction[i, 0] = values[i];
                prediction[i, 1] = _theta0 + _theta1 * prediction[i, 0];
            }

            return prediction;
        }

        public double predictSingleValue(double x){
            double h = _theta0 + _theta1 * x;
            return h;
        }

        private void newThetaValue (double[,] realValues){
            // 1 / m
            double proportion = 1.0 / realValues.GetLength(0);
            double sumZero = 0;
            double sumOne = 0;
            // somatorio das diferenças
            for (int i = 0; i < realValues.GetLength(0); i++)
            {
                double h_x = _theta0 + _theta1 * realValues[i, 0];

                sumZero += (h_x - realValues[i, 1]);

                sumOne +=  (h_x - realValues[i, 1]) * realValues[i,0];
            }

            _theta0 = _theta0 - _alpha *  proportion * sumZero;
            _theta1 = _theta1 - _alpha * proportion * sumOne;   
        }

        public (double, double) getThetaValues(){
            return (_theta0, _theta1);
        }
    }
}