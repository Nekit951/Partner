using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Documents;

namespace Demo
{
    public class MaterialCalculationService
    {
        public int CalcMaterial(int productTypeId, int materialTypeId, int quantity, double param1, double param2)
        {
            if (productTypeId <= 0 || materialTypeId <= 0 || quantity <= 0 || param1 <= 0 || param2 <= 0)
            {
                return -1;
            }

            double productTypeCoefficient = 0;
            switch (productTypeId)
            {
                case 1: productTypeCoefficient = 1.1; break;
                case 2: productTypeCoefficient = 2.5; break;
                case 3: productTypeCoefficient = 8.43; break;
                default: return -1;
            }

            double defectRate = 0;
            switch (materialTypeId)
            {
                case 1: defectRate = 0.003; break;
                case 2: defectRate = 0.012; break;
                case 3: defectRate = 0.005; break;
                default: return -1;
            }

            try
            {
                double materialPerUnit = param1 * param2 * productTypeCoefficient;
                double totalBaseMaterial = materialPerUnit * quantity;
                double totalMaterialWithDefect = totalBaseMaterial / (1 - defectRate);
                int finalAmount = (int)Math.Ceiling(totalMaterialWithDefect);
                return finalAmount;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}