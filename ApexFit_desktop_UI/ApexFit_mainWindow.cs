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
        }

        private void ResetForm()
        {
            MenuButtonsDefaultColor();
            HideAllPanels();
            pnlHomePage.Visible = true;
            btnHome.BackColor = Color.FromArgb(205, 234, 231);
            UserDataLoad();
            ComboboxReset();
        }

        private void ResetControls()
        {

        }
        private void TextboxReset()
        {
           /* txtLoginUsername.Text = "Kasutajanimi";
            txtLoginUsername.ForeColor = Color.DarkGray;*/
            txtCurrentUserPassword.Text = "Praegune salasõna";
            txtCurrentUserPassword.UseSystemPasswordChar = false;
            txtCurrentUserPassword.ForeColor = Color.DarkGray;
            txtNewUserPassword.Text = "Uus salasõna";
            txtNewUserPassword.UseSystemPasswordChar = false;
            txtNewUserPassword.ForeColor = Color.DarkGray;
            txtNewUserPassword2.Text = "Korda uut salasõna";
            txtNewUserPassword2.UseSystemPasswordChar = false;
            txtNewUserPassword2.ForeColor = Color.DarkGray;
            txtCurrentEmail.Text = "Praegune meiliaadress";
            txtCurrentEmail.ForeColor = Color.DarkGray;
            txtNewEmail.Text = "Uus meiliaadress";
            txtNewEmail.ForeColor = Color.DarkGray;
            txtConfirmEmailChangePassword.Text = "Salasõna";
            txtConfirmEmailChangePassword.UseSystemPasswordChar = false;
            txtConfirmEmailChangePassword.ForeColor = Color.DarkGray;


           /* txtCreateAccount2SecurityQuestionAnswer.Text = "Turvaküsimuse vastus";
            txtCreateAccount2SecurityQuestionAnswer.ForeColor = Color.DarkGray;
            txtForgotPasswordUserEmail.Text = "Meiliaadress";
            txtForgotPasswordUserEmail.ForeColor = Color.DarkGray;
            txtForgotPasswordSecurityAnswer.Text = "Turvaküsimuse vastus";
            txtForgotPasswordSecurityAnswer.ForeColor = Color.DarkGray;

            txtForgotPassword2Password2.Text = "Korda salasõna";
            txtForgotPassword2Password2.UseSystemPasswordChar = false;
            txtForgotPassword2Password2.ForeColor = Color.DarkGray;
            lblCreateAccountSecurityQuestion.Visible = false;
            lblForgotPassword2Username.Visible = false;*/
        }

        private void UserDataLoad()
        {
            Security = new SecurityLayer.CSecurity();
            UserProfile = new UserProfileComponent.CUserProfile();

            lblProfileWeightGoal.Visible = false;
            lblFirstname.Text = Security.DecryptString(UserProfile.GetStringFromUserData(userId, "firstname_enc"));
            lblHomeTitleName.Text = "Tere, " + lblFirstname.Text + "!";
            lblUserProfileFirstname.Text = lblFirstname.Text;
            lblUserProfileUsername.Text = Security.DecryptString(UserProfile.GetStringFromUserData(userId, "username_enc"));
            lblProfileUserAge.Text = "-  " + UserProfile.GetIntegerFromUserData(userId, "age") + "-aastane";
            lblProfileUserHeight.Text = "-  " + UserProfile.GetIntegerFromUserData(userId, "height") + "cm";
            lblProfileUserWeight.Text = "-  " + UserProfile.GetIntegerFromUserData(userId, "weight") + "kg";
            lblProfileCalorieLimit.Text = "-  " + "Kalorilimiit: " + UserProfile.GetIntegerFromUserData(userId, "calorie_limit") + "kcal";
            if (UserProfile.GetIntegerFromUserData(userId, "premium_unlocked") == 1)
            {
                lblProfileWeightGoal.Text = "-  " + "Sihtkaal: " + UserProfile.GetIntegerFromUserData(userId, "weight_goal") + "kg";
                lblProfileWeightGoal.Visible = true;
            }
        }
        private void ComboboxReset()
        {
            UserProfile = new UserProfileComponent.CUserProfile();

            for (int index = 12; index < 100; index++)
            {
                cmbUserAgeSelection.Items.Add(index);
            }
            cmbUserAgeSelection.SelectedItem = UserProfile.GetIntegerFromUserData(userId, "age");

            for (int index = 140; index < 210; index++)
            {
                cmbUserHeightSelection.Items.Add(index);
            }
            cmbUserHeightSelection.SelectedItem = UserProfile.GetIntegerFromUserData(userId, "height");
        }
        private void MenuButtonsDefaultColor()
        {
            btnFood.BackColor = Color.FromArgb(188, 227, 224);
            btnTraining.BackColor = Color.FromArgb(188, 227, 224);
            btnAnalysis.BackColor = Color.FromArgb(188, 227, 224);
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

        private void HideAllPanels()
        {
            pnlAnalysis.Visible = false;
            pnlFoods.Visible = false;
            pnlGoals.Visible = false;
            pnlProfileSettings.Visible = false;
            pnlTrainings.Visible = false;
            pnlSleep.Visible = false;
            pnlHomePage.Visible = false;
        }

        private void btnCloseApplication_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFood_Click(object sender, EventArgs e)
        {
            MenuButtonsDefaultColor();
            HideAllPanels();
            pnlFoods.Visible = true;
            btnFood.BackColor = Color.FromArgb(205, 234, 231);
        }

        private void btnTraining_Click(object sender, EventArgs e)
        {
            MenuButtonsDefaultColor();
            HideAllPanels();
            pnlTrainings.Visible = true;
            btnTraining.BackColor = Color.FromArgb(205, 234, 231);
        }

        private void btnGoals_Click(object sender, EventArgs e)
        {
            UserProfile = new UserProfileComponent.CUserProfile();

            if (UserProfile.GetIntegerFromUserData(userId, "premium_unlocked") == 0)
            {
                MessageBox.Show("See funktsioon on saadaval ainult rakenduse PRO-versioonil. PRO-versiooni ostmiseks klõpsake 'Profiili seaded'. ", "PRO-versioon", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MenuButtonsDefaultColor();
                HideAllPanels();
                pnlHomePage.Visible = true;
                btnHome.BackColor = Color.FromArgb(205, 234, 231);
            }
            else
            {
                MenuButtonsDefaultColor();
                HideAllPanels();
                pnlGoals.Visible = true;
                btnGoals.BackColor = Color.FromArgb(205, 234, 231);
            }
            
        }

        private void btnSleep_Click(object sender, EventArgs e)
        {
            if (UserProfile.GetIntegerFromUserData(userId, "premium_unlocked") == 0)
            {
                MessageBox.Show("See funktsioon on saadaval ainult rakenduse PRO-versioonil. PRO-versiooni ostmiseks klõpsake 'Profiili seaded'. ", "PRO-versioon", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MenuButtonsDefaultColor();
                HideAllPanels();
                pnlHomePage.Visible = true;
                btnHome.BackColor = Color.FromArgb(205, 234, 231);
            }
            else
            {
                MenuButtonsDefaultColor();
                HideAllPanels();
                pnlSleep.Visible = true;
                btnSleep.BackColor = Color.FromArgb(205, 234, 231);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            MenuButtonsDefaultColor();
            HideAllPanels();
            pnlHomePage.Visible = true;
            btnHome.BackColor = Color.FromArgb(205, 234, 231);
        }

        private void btnProfileSettings_Click(object sender, EventArgs e)
        {
            MenuButtonsDefaultColor();
            HideAllPanels();
            pnlProfileSettings.Visible = true;
            btnProfileSettings.BackColor = Color.FromArgb(205, 234, 231);
        }

        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            MenuButtonsDefaultColor();
            HideAllPanels();
            pnlAnalysis.Visible = true;
            btnAnalysis.BackColor = Color.FromArgb(205, 234, 231);
        }

        private void btnChangeUserHeight_Click(object sender, EventArgs e)
        {

        }

        private void btnChangeUserAge_Click(object sender, EventArgs e)
        {

        }
    }
}
