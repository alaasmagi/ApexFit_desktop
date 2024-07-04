using SecurityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserProfileComponent;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ApexFit_desktop_UI
{
    public partial class ApexFit_login : Form
    {
        private static CSecurity SecurityLayer = new CSecurity();
        private static CUserProfile UserProfileComponent = new CUserProfile();
        //private string dbConnection = Program.GetConnectionString();
        public ApexFit_login()
        {
            InitializeComponent();
            ResetForm();
            pnlCreateAccount2.Visible = true;
            pnlCreateAccount1.Visible = false;
            pnlForgotPassword2.Visible = false;
            pnlForgotPassword1.Visible = false;
            pnlLogin.Visible = false;
        }
        private void ResetForm()
        {
            ClearControls(this);
            ComboboxReset();
            TextboxReset();
        }
        private void ComboboxReset()

        {
            for (int index = 12; index < 100; index++)
            {
                cmbCreateAccountUserAge.Items.Add(index);
            }
            cmbCreateAccountUserAge.SelectedItem = 20;

            for (int index = 140; index < 210; index++)
            {
                cmbCreateAccountUserHeight.Items.Add(index);
            }
            cmbCreateAccountUserHeight.SelectedItem = 176;

            for (int index = 25; index < 200; index++)
            {
                cmbCreateAccountUserWeight.Items.Add(index);
            }
            cmbCreateAccountUserWeight.SelectedItem = 75;

            List<string> securityQuestions = SecurityLayer.GetSecurityQuestions();
            foreach (string question in securityQuestions)
            {
                cmbCreateAccountSecurityQuestion.Items.Add(question);
            }
            cmbCreateAccountSecurityQuestion.SelectedIndex = 0;
        }

        public void ClearControls(Control parentControl)
        {
            foreach (Control ctrl in parentControl.Controls)
            {
                if (ctrl is System.Windows.Forms.TextBox)
                {
                    ((System.Windows.Forms.TextBox)ctrl).Text = "";
                }
                else if (ctrl is System.Windows.Forms.ComboBox)
                {
                    ((System.Windows.Forms.ComboBox)ctrl).SelectedIndex = -1;
                }
                else if (ctrl is CheckBox)
                {
                    ((CheckBox)ctrl).Checked = false;
                }
                else if (ctrl is RadioButton)
                {
                    ((RadioButton)ctrl).Checked = false;
                }
                else if (ctrl is ListBox)
                {
                    ((ListBox)ctrl).Items.Clear();
                }
                else if (ctrl is Panel)
                {
                    ClearControls(ctrl);
                }
            }
        }

        private void TextboxReset()
        {
            txtLoginUsername.Text = "Kasutajanimi";
            txtLoginPassword.Text = "Salasõna";
            txtCreateAccountFirstname.Text = "Eesnimi";
            txtCreateAccountEmail.Text = "Meiliaadress";
            txtCreateAccountPassword1.Text = "Salasõna";
            txtCreateAccountPassword2.Text = "Korda salasõna";
            txtCreateAccount2SecurityQuestionAnswer.Text = "Turvaküsimuse vastus";
            txtForgotPasswordUserEmail.Text = "Meiliaadress";
            txtForgotPasswordSecurityAnswer.Text = "Turvaküsimuse vastus;";
            txtForgotPassword2Password.Text = "Salasõna";
            txtForgotPassword2Password2.Text = "Korda salasõna";
        }


        private void txtLoginUsername_Enter(object sender, EventArgs e)
        {
            if (txtLoginUsername.Text == "Kasutajanimi")
            {
                txtLoginUsername.Text = "";
                txtLoginUsername.ForeColor = Color.Black;
            }
        }

        private void txtLoginPassword_Enter(object sender, EventArgs e)
        {
            if (txtLoginPassword.Text == "Salasõna")
            {
                txtLoginPassword.Text = "";
                txtLoginPassword.UseSystemPasswordChar = true;
                txtLoginPassword.ForeColor = Color.Black;
            }
        }

        private void txtLoginUsername_Leave(object sender, EventArgs e)
        {
            if (txtLoginUsername.Text == "")
            {
                txtLoginUsername.Text = "Kasutajanimi";
                txtLoginUsername.ForeColor = Color.DarkGray;
            }
        }

        private void txtLoginPassword_Leave(object sender, EventArgs e)
        {
            if (txtLoginPassword.Text == "")
            {
                txtLoginPassword.Text = "Salasõna";
                txtLoginPassword.UseSystemPasswordChar = false;
                txtLoginPassword.ForeColor = Color.DarkGray;
            }
        }

        private void btnLogiSisse_Click(object sender, EventArgs e)
        {
            string username = txtLoginUsername.Text;
            string password = txtLoginPassword.Text;

            if (SecurityLayer.LoginAttempt(username, password) == true)
            {
                pnlLogin.Visible = false;
                pnlForgotPassword2.Visible = true;
            }
            else
            {
                pnlLogin.Visible = true;
                MessageBox.Show("Kasutajanime ja/või parooli viga", "Tõrge", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCreateAccountFirstname_Enter(object sender, EventArgs e)
        {
            if (txtCreateAccountFirstname.Text == "Eesnimi")
            {
                txtCreateAccountFirstname.Text = "";
                txtCreateAccountFirstname.ForeColor = Color.Black;
            }
        }

        private void txtCreateAccountEmail_Enter(object sender, EventArgs e)
        {
            if (txtCreateAccountEmail.Text == "Meiliaadress")
            {
                txtCreateAccountEmail.Text = "";
                txtCreateAccountEmail.ForeColor = Color.Black;
            }
        }

        private void txtCreateAccountPassword1_Enter(object sender, EventArgs e)
        {
            if (txtCreateAccountPassword1.Text == "Salasõna")
            {
                txtCreateAccountPassword1.Text = "";
                txtCreateAccountPassword1.UseSystemPasswordChar = true;
                txtCreateAccountPassword1.ForeColor = Color.Black;
            }
        }

        private void txtCreateAccountPassword2_Enter(object sender, EventArgs e)
        {
            if (txtCreateAccountPassword2.Text == "Korda salasõna")
            {
                txtCreateAccountPassword2.Text = "";
                txtCreateAccountPassword2.UseSystemPasswordChar = true;
                txtCreateAccountPassword2.ForeColor = Color.Black;
            }
        }

        private void txtCreateAccountFirstname_Leave(object sender, EventArgs e)
        {
            if (txtCreateAccountFirstname.Text == "")
            {
                txtCreateAccountFirstname.Text = "Eesnimi";
                txtCreateAccountFirstname.ForeColor = Color.DarkGray;
            }

        }

        private void txtCreateAccountEmail_Leave(object sender, EventArgs e)
        {
            if (txtCreateAccountEmail.Text == "")
            {
                txtCreateAccountEmail.Text = "Meiliaadress";
                txtCreateAccountEmail.ForeColor = Color.DarkGray;
            }
        }

        private void txtCreateAccountPassword1_Leave(object sender, EventArgs e)
        {
            if (txtCreateAccountPassword1.Text == "")
            {
                txtCreateAccountPassword1.Text = "Salasõna";
                txtCreateAccountPassword1.UseSystemPasswordChar = false;
                txtCreateAccountPassword1.ForeColor = Color.DarkGray;
            }
        }

        private void txtCreateAccountPassword2_Leave(object sender, EventArgs e)
        {
            if (txtCreateAccountPassword2.Text == "")
            {
                txtCreateAccountPassword2.Text = "Korda salasõna";
                txtCreateAccountPassword2.UseSystemPasswordChar = false;
                txtCreateAccountPassword2.ForeColor = Color.DarkGray;
            }
        }

        private void lblNoAccount_Click(object sender, EventArgs e)
        {
            pnlLogin.Visible = false;
            pnlCreateAccount1.Visible = true;
        }

        private void lblCreateAccountBack_Click(object sender, EventArgs e)
        {
            pnlCreateAccount1.Visible = false;
            pnlLogin.Visible = true;
        }

        private void lblCreateAccount2Back_Click(object sender, EventArgs e)
        {
            pnlCreateAccount2.Visible = false;
            pnlCreateAccount1.Visible = true;
        }

        private void txtCreateAccount2SecurityQuestionAnswer_Enter(object sender, EventArgs e)
        {
            if (txtCreateAccount2SecurityQuestionAnswer.Text == "Turvaküsimuse vastus")
            {
                txtCreateAccount2SecurityQuestionAnswer.Text = "";
                txtCreateAccount2SecurityQuestionAnswer.ForeColor = Color.Black;
            }
        }

        private void txtCreateAccount2SecurityQuestionAnswer_Leave(object sender, EventArgs e)
        {
            if (txtCreateAccount2SecurityQuestionAnswer.Text == "")
            {
                txtCreateAccount2SecurityQuestionAnswer.Text = "Turvaküsimuse vastus";
                txtCreateAccount2SecurityQuestionAnswer.ForeColor = Color.DarkGray;
            }
        }

        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            pnlLogin.Visible = false;
            pnlForgotPassword1.Visible = true;
        }

        private void btnForgotPasswordShowQuestion_Click(object sender, EventArgs e)
        {

        }

        private void lblForgotPassword1GoBack_Click(object sender, EventArgs e)
        {
            pnlForgotPassword1.Visible = false;
            pnlLogin.Visible = true;
        }

        private void btnForgotPasswordChechSecurityAnswer_Click(object sender, EventArgs e)
        {
            pnlForgotPassword1.Visible = false;
            pnlForgotPassword2.Visible = true;
        }

        private void lblForgotPassword2GoBack_Click(object sender, EventArgs e)
        {
            pnlForgotPassword2.Visible = false;
            pnlLogin.Visible = true;
        }

        private void txtForgotPasswordUserEmail_Enter(object sender, EventArgs e)
        {
            if (txtForgotPasswordUserEmail.Text == "Meiliaadress")
            {
                txtForgotPasswordUserEmail.Text = "";
                txtForgotPasswordUserEmail.ForeColor = Color.Black;
            }
        }

        private void txtForgotPasswordUserEmail_Leave(object sender, EventArgs e)
        {
            if (txtForgotPasswordUserEmail.Text == "")
            {
                txtForgotPasswordUserEmail.Text = "Meiliaadress";
                txtForgotPasswordUserEmail.ForeColor = Color.DarkGray;
            }
        }

        private void txtForgotPasswordSecurityAnswer_Enter(object sender, EventArgs e)
        {
            if (txtForgotPasswordSecurityAnswer.Text == "Turvaküsimuse vastus")
            {
                txtForgotPasswordSecurityAnswer.Text = "";
                txtForgotPasswordSecurityAnswer.ForeColor = Color.Black;
            }
        }

        private void txtForgotPasswordSecurityAnswer_Leave(object sender, EventArgs e)
        {
            if (txtForgotPasswordSecurityAnswer.Text == "")
            {
                txtForgotPasswordSecurityAnswer.Text = "Turvaküsimuse vastus";
                txtForgotPasswordSecurityAnswer.ForeColor = Color.DarkGray;
            }
        }

        private void txtForgotPassword2Password_Enter(object sender, EventArgs e)
        {
            if (txtForgotPassword2Password.Text == "Salasõna")
            {
                txtForgotPassword2Password.Text = "";
                txtForgotPassword2Password.UseSystemPasswordChar = true;
                txtForgotPassword2Password.ForeColor = Color.Black;
            }
        }

        private void txtForgotPassword2Password_Leave(object sender, EventArgs e)
        {
            if (txtForgotPassword2Password.Text == "")
            {
                txtForgotPassword2Password.Text = "Salasõna";
                txtForgotPassword2Password.UseSystemPasswordChar = false;
                txtForgotPassword2Password.ForeColor = Color.DarkGray;
            }
        }

        private void txtForgotPassword2Password2_Enter(object sender, EventArgs e)
        {
            if (txtForgotPassword2Password2.Text == "Korda salasõna")
            {
                txtForgotPassword2Password2.Text = "";
                txtForgotPassword2Password2.UseSystemPasswordChar = true;
                txtForgotPassword2Password2.ForeColor = Color.Black;
            }
        }

        private void txtForgotPassword2Password2_Leave(object sender, EventArgs e)
        {
            if (txtForgotPassword2Password2.Text == "")
            {
                txtForgotPassword2Password2.Text = "Korda salasõna";
                txtForgotPassword2Password2.UseSystemPasswordChar = false;
                txtForgotPassword2Password2.ForeColor = Color.DarkGray;
            }
        }

        private void btnCreateAccount2_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCreateAccount1_Click_1(object sender, EventArgs e)
        {
            if (txtCreateAccountFirstname.Text == "Eesnimi")
            {
                MessageBox.Show("Viga eesnimes", "Tõrge", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!UserProfileComponent.IsValidEmailAddress(txtCreateAccountEmail.Text))
            {
                MessageBox.Show("Viga meiliaadressis", "Tõrge", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtCreateAccountPassword1.Text.Length < 8 || txtCreateAccountPassword1.Text == "Salasõna")
            {
                MessageBox.Show("Viga salasõna(des)", "Tõrge", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtCreateAccountPassword1.Text != txtCreateAccountPassword2.Text || txtCreateAccountPassword2.Text == "Korda salasõna")
            {
                MessageBox.Show("Salasõnad ei klapi", "Tõrge", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                pnlCreateAccount1.Visible = false;
                pnlCreateAccount2.Visible = true;
            }
        }
    }
}
