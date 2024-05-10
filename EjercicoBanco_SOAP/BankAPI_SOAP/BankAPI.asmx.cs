using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BankModel;

namespace BankAPI_SOAP
{
    /// <summary>
    /// Descripción breve de BankAPI
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class BankAPI : System.Web.Services.WebService
    {

        [WebMethod]
        public ApiResponse AddNewClient(string Name, string DNI)
        {
            Bank.AddNewClient(Name, DNI);
            return ApiResponse.Success("Client Successfully Added.");
        }

        [WebMethod]
        public List<BankAccount> GetDebtors()
        {
            return Bank.BankAccounts.FindAll(x => x.isDebtor());
        }

        [WebMethod]
        public ApiResponse AddNewAccount(int ClientID)
        {
            try
            {
                Bank.AddNewAccount(ClientID);
                return ApiResponse.Success("Account Successfully Added.");
            }
            catch (Exception ex)
            {
                return ApiResponse.Failure(ex.Message);
            }
        }
        
        [WebMethod]
        public List<Client> GetClients()
        {
            return Bank.Clients;
        }
        [WebMethod]
        public List<BankAccount> GetAccounts()
        {
            return Bank.BankAccounts;
        }

        [WebMethod]
        public BankAccount GetAccount(int AccountID)
        {
            BankAccount accountFound = Bank.BankAccounts.Find(x => x.AccountID == AccountID);

            return accountFound;
        }

        [WebMethod]
        public ApiResponse MakeTransaction(BankAccount sourceAccount, int targetAccountID, double amount, string description)
        {
            try
            {
                sourceAccount.MakeNewTransaction(amount, description, targetAccountID);
                return ApiResponse.Success("Transaction Successfully Made.");
            }
            catch (Exception ex)
            {
                return ApiResponse.Failure(ex.Message);
            }
        }
        
    }
}
