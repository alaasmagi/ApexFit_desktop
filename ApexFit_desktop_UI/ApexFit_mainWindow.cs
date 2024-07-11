using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApexFit_desktop_UI
{
    public partial class ApexFit_mainWindow : Form
    {
        private SecurityLayer.ISecurity Security;
        private UserProfileComponent.IUserProfile UserProfile;

        private int userId;
        public ApexFit_mainWindow(int _userId)
        {
            InitializeComponent();
            UserProfile = new UserProfileComponent.CUserProfile();
            Security = new SecurityLayer.CSecurity();
            userId = _userId;

            lblFirstname.Text = Security.DecryptString(UserProfile.GetStringFromUserData(userId, "firstname_enc"));     
        }

        private void ResetForm()
        {

        }

        private void ResetControls()
        {

        }
        private void TextboxReset()
        {

        }
        private void ComboboxReset()
        {

        }
        private void MenuButtonsDefaultColor()
        {

        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Security = new SecurityLayer.CSecurity();

            Security.RemoveToken(userId);
            this.Hide();
            ApexFit_login login = new ApexFit_login();
           // ResetForm();
            login.Show();
        }

        private void btnCloseApplication_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
