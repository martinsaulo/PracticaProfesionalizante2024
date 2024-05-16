using System.Text;

namespace ApiClient
{
    public partial class Form1 : Form
    {
        BankWS.BankAPISoapClient bankWS =
                new BankWS.BankAPISoapClient(BankWS.BankAPISoapClient.EndpointConfiguration.BankAPISoap);
        public Form1()
        {
            InitializeComponent();
        }


        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            if (txtDNI.Text == "" || txtNombre.Text == "")
            {
                MessageBox.Show("Complete todos los campos.");
            }
            else
            {
                bankWS.AddNewClient(txtNombre.Text, txtDNI.Text);
                ActualizarClientes();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            bankWS.AddNewClient("jose paz", "123");
            bankWS.AddNewAccount(1);
            ActualizarClientes();
            ActualizarCuentas();
            ActualizarDeudores();
        }
        private void ActualizarClientes()
        {
            var clients = bankWS.GetClients();
            listBoxClientes.DataSource = null;
            listBoxClientes.DataSource = clients;
            listBoxClientes.DisplayMember = "Name";

            comboBox3.DataSource = null;
            comboBox3.DataSource = clients;
            comboBox3.DisplayMember = "Name";
        }
        private void ActualizarCuentas()
        {
            var accounts = bankWS.GetAccounts();
            listBoxCuentas.DataSource = null;
            listBoxCuentas.DataSource = accounts;
            listBoxCuentas.DisplayMember = "AccountID";

        }
        private void ActualizarDeudores()
        {
            listBoxDeudores.DataSource = null;
            listBoxDeudores.DataSource = bankWS.GetDebtors();
            listBoxDeudores.DisplayMember = "AccountID";
        }

        private void btnAgregarCuenta_Click(object sender, EventArgs e)
        {
            var response = bankWS.AddNewAccount(((BankWS.Client)comboBox3.SelectedItem).ClientID);

            if (response.ResponseCode == "500")
            {
                MessageBox.Show(response.Message);
            }
            else
            {
                ActualizarCuentas();
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            if (listBoxCuentas.SelectedItem != null)
            {
                BankWS.BankAccount cuenta = (BankWS.BankAccount)listBoxCuentas.SelectedItem;
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Dueño: {cuenta.AccountOwner.Name}");
                sb.AppendLine($"Balance: {cuenta.Balance}");

                MessageBox.Show(sb.ToString());
            }
        }

        private void btnTransferir_Click(object sender, EventArgs e)
        {
            if(txtMonto.Text == "" && txtDescrip.Text == "")
            {
                MessageBox.Show("Complete todos los campos");
            }
            else
            {
                int sourceAccount = int.Parse(txtIdOrigen.Text);
                int idTargetAccount = int.Parse(txtIdDestino.Text);
                double monto = double.Parse(txtMonto.Text);
                var response = bankWS.MakeTransaction(sourceAccount,idTargetAccount, monto, txtDescrip.Text);

                if(response.ResponseCode == "500")
                {
                    MessageBox.Show(response.Message);
                }
                else
                {
                    ActualizarCuentas();
                    ActualizarDeudores();
                }
            }
        }
    }
}
