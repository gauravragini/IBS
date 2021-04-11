using IBS.EntitiesLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBS.BussinessLogicLayer.Interfaces
{
    public interface IInterestCalculationBL
    {
        Adminwork CalculateInterest(string adminID);
        Transaction AddInterest(string accountNumber);
        Transaction WithdrawInterest(string accountNumber);
    }
}
