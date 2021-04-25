using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Task3
{
    public static class Utils
    {
        public static Guid[] toGuid(this string[] inputData)
        {
            Guid[] outputData = new Guid[inputData.Length];
            for (int i = 0; i < inputData.Length; i++)
            {
                outputData[i] = new Guid(inputData[i]);
            }
            return outputData;
        }
        public static double[] toDouble(this string[] inputData)
        {
            double[] outputData = new double[inputData.Length];
            for (int i = 0; i < inputData.Length; i++)
            {
                outputData[i] = double.Parse(inputData[i], CultureInfo.InvariantCulture);
            }
            return outputData;
        }
    }
}
