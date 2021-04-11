using IBS.EntitiesLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBS.DataAccessLayer.Interfaces
{
    public interface IInterestCalculationDL
    {
        Adminwork CalculateInterest(string adminID);
        DateTime lastInterestCalculation();
        Transaction AddInterest(string accountNumber);
        Transaction WithdrawInterest(string accountNumber);
    }
}
