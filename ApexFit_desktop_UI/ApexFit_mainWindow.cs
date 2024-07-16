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
            ResetForm();
            lblFirstname.Text = Security.DecryptString(UserProfile.GetStringFromUserData(userId, "firstname_enc"));     
        }

        private void ResetForm()
        {
            MenuButtonsDefaultColor();
            btnHome.BackColor = Color.FromArgb(205, 234, 231);
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
            btnFood.BackColor = Color.FromArgb(188, 227, 224);
            btnTraining.BackColor = Color.FromArgb(188, 227, 224);
            btnHistory.BackColor = Color.FromArgb(188, 227, 224);
            btnHome.BackColor = Color.FromArgb(188, 227, 224);
            btnProfileSettings.BackColor = Color.FromArgb(188, 227, 224);
            btnGoals.BackColor = Color.FromArgb(188, 227, 224);
            btnSleep.BackColor = Color.FromArgb(188, 227, 224);
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

        private void btnFood_Click(object sender, EventArgs e)
        {
            MenuButtonsDefaultColor();
            btnFood.BackColor = Color.FromArgb(205, 234, 231);
        }

        private void btnTraining_Click(object sender, EventArgs e)
        {
            MenuButtonsDefaultColor();
            btnTraining.BackColor = Color.FromArgb(205, 234, 231);
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            MenuButtonsDefaultColor();
            btnHistory.BackColor = Color.FromArgb(205, 234, 231);
        }

        private void btnGoals_Click(object sender, EventArgs e)
        {
            MenuButtonsDefaultColor();
            btnGoals.BackColor = Color.FromArgb(205, 234, 231);
        }

        private void btnSleep_Click(object sender, EventArgs e)
        {
            MenuButtonsDefaultColor();
            btnSleep.BackColor = Color.FromArgb(205, 234, 231);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            MenuButtonsDefaultColor();
            btnHome.BackColor = Color.FromArgb(205, 234, 231);
        }

        private void btnProfileSettings_Click(object sender, EventArgs e)
        {
            MenuButtonsDefaultColor();
            btnProfileSettings.BackColor = Color.FromArgb(205, 234, 231);
        }
    }
}
