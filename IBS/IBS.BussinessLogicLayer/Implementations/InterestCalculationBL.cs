using IBS.BussinessLogicLayer.Interfaces;
using IBS.DataAccessLayer.Interfaces;
using IBS.EntitiesLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static IBS.Exceptions.Exceptions;

namespace IBS.BussinessLogicLayer.Implementations
{
    public class InterestCalculationBL : IInterestCalculationBL
    {
        private IInterestCalculationDL interestCalculationDataLayer;
        public InterestCalculationBL(IInterestCalculationDL interestCalculationDataLayer)
        {
            this.interestCalculationDataLayer = interestCalculationDataLayer;
        }
        public Adminwork CalculateInterest(string adminID)
        {
            DateTime datecheck = new DateTime(1000, 01, 01, 12, 00, 00);

            DateTime last = interestCalculationDataLayer.lastInterestCalculation();

            if (last == datecheck)
            {
               return interestCalculationDataLayer.CalculateInterest(adminID);
            }
            else
            {
                int numberofdays = (last - DateTime.Now).Days;

                if (numberofdays < 30)
                {
                    throw new InterestException("\n\t\t\tYou can Calculate the Interest after 30 days only ......... Last Calculated interest on : " + last + ".......By Admin Id : " + adminID + "..... Days left : " + numberofdays);
                }
                else
                {
                   return interestCalculationDataLayer.CalculateInterest(adminID);
                }
            }
        }

        public Transaction AddInterest(string accountNumber)
        {
            return interestCalculationDataLayer.AddInterest(accountNumber);
        }

        public Transaction WithdrawInterest(string accountNumber)
        {
            return interestCalculationDataLayer.WithdrawInterest(accountNumber);
        }

    }
}
