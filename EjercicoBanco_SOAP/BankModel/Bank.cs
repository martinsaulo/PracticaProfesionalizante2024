using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankModel
{
    public class Bank
    {
        public static List<Client> Clients { get; protected set; } = new List<Client>();
        public static int ClientCount { get; set; } = 0;
        public static List<BankAccount> BankAccounts { get; protected set; } = new List<BankAccount>();
        public static int AccountCount { get; set; } = 0;
        public static void AddNewClient(string name, string dni)
        {
            int id = ClientCount + 1;

            Client newClient = new Client()
            {
                ClientID = id,
                Name = name,
                DNI = dni,
            };

            Clients.Add(newClient);

            ClientCount++;
        }
        public static void AddNewAccount(int clientID)
        {
            var client = Clients.Find(x => x.ClientID == clientID);

            if (client == null)
            {
                throw new Exception("Client not found.");
            }

            int id = AccountCount + 1;

            BankAccount newAccount = new BankAccount()
            {
                AccountID = id,
                AccountOwner = client,
            };

            BankAccounts.Add(newAccount);

            AccountCount++;
        }
    }
}
