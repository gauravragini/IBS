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
        private IIntererstCalculationDL interestCalculationDataLayer;
        public InterestCalculationBL(IIntererstCalculationDL interestCalculationDataLayer)
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
                    throw new InterestException("\n\t\t\tYou can Calculate the Interest after 30 days only \n\t\t\tLast Calculated interest on :" + last + "By Admin Id :" + adminID + "\n Days left : " + numberofdays);
                }
                else
                {
                   return interestCalculationDataLayer.CalculateInterest(adminID);
                }
            }
        }

    }
}
