using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADM_DTO;
using ADM_BLL;

namespace ADM_UI
{
    public partial class ADM_Login : Form
    {
        public ADM_Login()
        {
            InitializeComponent();
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            try
            {
                Login_DTO obj = new Login_DTO();
                obj.user = txtUser.Text;
                obj.senha = txtPassword.Text;
                string msg = Login_BLL.Login(obj);
                if (msg == "tanana")
                {
                    MessageBox.Show("Login successfully", "MSG", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Hide();
                    ADM_Home ah = new ADM_Home();
                    ah.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid user or password", "MSG", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Errrrrooooo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
