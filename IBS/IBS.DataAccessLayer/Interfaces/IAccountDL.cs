using IBS.EntitiesLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBS.DataAccessLayer.Interfaces
{
    public interface IAccountDL
    {
        string AcceptCustomer(string id);
        string RejectCustomer(string id);
    }
}
