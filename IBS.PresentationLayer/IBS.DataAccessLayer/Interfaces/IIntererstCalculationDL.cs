using IBS.EntitiesLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBS.DataAccessLayer.Interfaces
{
    public interface IIntererstCalculationDL
    {
        Adminwork CalculateInterest(string adminID);
        DateTime lastInterestCalculation();
    }
}
