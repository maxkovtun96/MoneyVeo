using MoneyVeo.Web.Services.Mdl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyVeo.Web.Services.Services.Int
{
    public interface IMatrixService
    {
        MatrixModel GetRandomMatrix(int length);
        MatrixModel Degree90Matrix(int[,] arry);
    }
}
