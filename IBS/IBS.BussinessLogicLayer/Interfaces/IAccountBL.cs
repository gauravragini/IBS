using IBS.EntitiesLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBS.BussinessLogicLayer.Interfaces
{
    public interface IAccountBL
    {
         string AcceptCustomer(string id);
         string RejectCustomer(string id);
    }
}
