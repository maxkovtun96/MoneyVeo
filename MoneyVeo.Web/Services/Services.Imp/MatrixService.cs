using MoneyVeo.Web.Services.Mdl;
using MoneyVeo.Web.Services.Services.Int;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyVeo.Web.Services.Imp
{
    public class MatrixService : IMatrixService
    {
        public MatrixModel GetRandomMatrix(int length)
        {
            if (length <= 0)
            {
                return new MatrixModel { Matrix = new int[0,0]};
            }
            Random random = new Random();
            int[,] array = new int[length, length];
            for (int i = 0; i < length; ++i)
                for (int j = 0; j < length; ++j)
                    array[i, j] = random.Next(10);
            return new MatrixModel { Matrix = array };
        }

        public MatrixModel Degree90Matrix(int[,] matrix)
        {
            int length = matrix.GetLength(0); 
            for (int i = 0; i < length / 2; i++)
            {
                for (int j = i; j < length - i - 1; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[length - 1 - j, i];
                    matrix[length - 1 - j, i] = matrix[length - 1 - i, length - 1 - j];
                    matrix[length - 1 - i, length - 1 - j] = matrix[j, length - 1 - i];
                    matrix[j, length - 1 - i] = temp;
                }
            }
            return new MatrixModel { Matrix = matrix };
        }
    }
}
