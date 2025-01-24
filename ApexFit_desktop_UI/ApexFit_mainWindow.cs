using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using Domain;
using DataAccess;

namespace ApexFit_desktop_UI
{
    public partial class ApexFit_mainWindow : Form
    {
        private AppDbContext _dbContext;
        private UserMainEntity userMainData = new UserMainEntity();
        public ApexFit_mainWindow(UserMainEntity user, AppDbContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;
            userMainData = user;
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
            txtLoginUsername.Text = "Kasutajanimi";
            txtLoginUsername.ForeColor = Color.DarkGray;
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
            txtDeleteUserAccountPassword.Text = "Salasõna";
            txtDeleteUserAccountPassword.UseSystemPasswordChar = false;
            txtDeleteUserAccountPassword.ForeColor = Color.DarkGray;
            txtChangeCalorieLimitCalories.Text = "kcal";
            txtChangeCalorieLimitCalories.ForeColor = Color.DarkGray;*/


            txtCreateAccount2SecurityQuestionAnswer.Text = "Turvaküsimuse vastus";
            txtCreateAccount2SecurityQuestionAnswer.ForeColor = Color.DarkGray;
            txtForgotPasswordUserEmail.Text = "Meiliaadress";
            txtForgotPasswordUserEmail.ForeColor = Color.DarkGray;
            txtForgotPasswordSecurityAnswer.Text = "Turvaküsimuse vastus";
            txtForgotPasswordSecurityAnswer.ForeColor = Color.DarkGray;

            txtForgotPassword2Password2.Text = "Korda salasõna";
            txtForgotPassword2Password2.UseSystemPasswordChar = false;
            txtForgotPassword2Password2.ForeColor = Color.DarkGray;
            lblCreateAccountSecurityQuestion.Visible = false;
            lblForgotPassword2Username.Visible = false;
        }

        private void UserDataLoad()
        {
            Security = new SecurityLayer.CSecurity();
            UserProfile = new UserProfileComponent.CUserProfile();

            lblProfileWeightGoal.Visible = false;
            lblFirstname.Text = Security.DecryptString((string)UserProfile.GetDataFromUserData(userId, "firstname_enc"));
            lblHomeTitleName.Text = "Tere, " + lblFirstname.Text + "!";
            lblUserProfileFirstname.Text = lblFirstname.Text;
            lblUserProfileUsername.Text = Security.DecryptString((string)UserProfile.GetDataFromUserData(userId, "username_enc"));
            lblProfileUserAge.Text = "-  " + (int)UserProfile.GetDataFromUserData(userId, "age") + "-aastane";
            lblProfileUserHeight.Text = "-  " + (int)UserProfile.GetDataFromUserData(userId, "height") + "cm";
            lblProfileUserWeight.Text = "-  " + (int)UserProfile.GetDataFromUserData(userId, "weight") + "kg";
            lblProfileCalorieLimit.Text = "-  " + "Kalorilimiit: " + (int)UserProfile.GetDataFromUserData(userId, "calorie_limit") + "kcal";
            if ((int)UserProfile.GetDataFromUserData(userId, "premium_unlocked") == 1)
            {
                lblProfileWeightGoal.Text = "-  " + "Sihtkaal: " + (int)UserProfile.GetDataFromUserData(userId, "weight_goal") + "kg";
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
            cmbUserAgeSelection.SelectedItem = (int)UserProfile.GetDataFromUserData(userId, "age");

            for (int index = 140; index < 210; index++)
            {
                cmbUserHeightSelection.Items.Add(index);
            }
            cmbUserHeightSelection.SelectedItem = (int)UserProfile.GetDataFromUserData(userId, "height");

            cmbAnalysisOverallWeightPeriod.Items.Add("Viimased 7 päeva");
            cmbAnalysisOverallWeightPeriod.Items.Add("Viimane 1 kuu");
            cmbAnalysisOverallWeightPeriod.Items.Add("Viimased 3 kuud");
            cmbAnalysisOverallWeightPeriod.Items.Add("Viimased 6 kuud");
            cmbAnalysisOverallWeightPeriod.Items.Add("Viimane aasta");
            cmbAnalysisOverallWeightPeriod.Items.Add("Kogu ajalugu");
            cmbAnalysisOverallWeightPeriod.SelectedIndex = 0;
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
            login.Show();
        }

        private void HideAnalysisSubPanels()
        {
            subpnlAnalysisOverall.Visible = false;
            subpnlAnalysisFoods.Visible = false;
            subpnlAnalysisTrainings.Visible = false;
            subpnlAnalysisSleep.Visible = false;
        }

        private void AnalysisSubPanelButtonsDefaultColor()
        {
            btnAnalysisOverall.BackColor = Color.FromArgb(221, 241, 239);
            btnAnalysisFoods.BackColor = Color.FromArgb(221, 241, 239);
            btnAnalysisTrainings.BackColor = Color.FromArgb(221, 241, 239);
            btnAnalysisSleep.BackColor = Color.FromArgb(221, 241, 239);
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
            pnlApplicationInfo.Visible = false;
        }
        private void successPbTimer_Tick(object sender, EventArgs e)
        {
            successPbTimer.Stop();
            //pbCalorieLimitSetSuccessful.Visible = false;
            pbChangeEmailSuccessfull.Visible = false;
            pbChangeUserHeightSuccessful.Visible = false;
            pbUserAgeChangeSuccessful.Visible = false;
            pbUserPasswordChangeSuccessful.Visible = false;
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

            if ((int)UserProfile.GetDataFromUserData(userId, "premium_unlocked") == 0)
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
            if ((int)UserProfile.GetDataFromUserData(userId, "premium_unlocked") == 0)
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
            subpnlAnalysisOverall.Visible = true;
            btnAnalysis.BackColor = Color.FromArgb(205, 234, 231);
            btnAnalysisOverall.BackColor = Color.FromArgb(235, 247, 246);
        }

        private void btnChangeUserHeight_Click(object sender, EventArgs e)
        {
            UserProfile = new UserProfileComponent.CUserProfile();

            UserProfile.UpdateUserData(userId, cmbUserHeightSelection.SelectedItem, "height");
            UserDataLoad();
            pbChangeUserHeightSuccessful.Visible = true;
            successPbTimer.Start();
        }

        private void btnChangeUserAge_Click(object sender, EventArgs e)
        {
            UserProfile = new UserProfileComponent.CUserProfile();

            UserProfile.UpdateUserData(userId, cmbUserAgeSelection.SelectedItem, "age");
            UserDataLoad();
            pbUserAgeChangeSuccessful.Visible = true;
            successPbTimer.Start();
        }

        private void txtChangeCalorieLimitCalories_Enter(object sender, EventArgs e)
        {
           if (txtChangeCalorieLimitCalories.Text == "kcal")
            {
                txtChangeCalorieLimitCalories.Text = "";
                txtChangeCalorieLimitCalories.ForeColor = Color.Black;
            }
        }

     private void txtCurrentEmail_Enter(object sender, EventArgs e)
        {
            if (txtCurrentEmail.Text == "Praegune meiliaadress")
            {
                txtCurrentEmail.Text = "";
                txtCurrentEmail.ForeColor = Color.Black;
            }
        }

        private void txtNewEmail_Enter(object sender, EventArgs e)
        {
            if (txtNewEmail.Text == "Uus meiliaadress")
            {
                txtNewEmail.Text = "";
                txtNewEmail.ForeColor = Color.Black;
            }
        }

        private void txtConfirmEmailChangePassword_Enter(object sender, EventArgs e)
        {
            if (txtConfirmEmailChangePassword.Text == "Salasõna")
            {
                txtConfirmEmailChangePassword.Text = "";
                txtConfirmEmailChangePassword.UseSystemPasswordChar = true;
                txtConfirmEmailChangePassword.ForeColor = Color.Black;
            }
        }

        private void txtDeleteUserAccountPassword_Enter(object sender, EventArgs e)
        {
            if (txtDeleteUserAccountPassword.Text == "Salasõna")
            {
                txtDeleteUserAccountPassword.Text = "";
                txtDeleteUserAccountPassword.UseSystemPasswordChar = true;
                txtDeleteUserAccountPassword.ForeColor = Color.Black;
            }
        }

        private void txtCurrentUserPassword_Enter(object sender, EventArgs e)
        {
            if (txtCurrentUserPassword.Text == "Praegune salasõna")
            {
                txtCurrentUserPassword.Text = "";
                txtCurrentUserPassword.UseSystemPasswordChar = true;
                txtCurrentUserPassword.ForeColor = Color.Black;
            }
        }

        private void txtNewUserPassword_Enter(object sender, EventArgs e)
        {
            if (txtNewUserPassword.Text == "Uus salasõna")
            {
                txtNewUserPassword.Text = "";
                txtNewUserPassword.UseSystemPasswordChar = true;
                txtNewUserPassword.ForeColor = Color.Black;
            }
        }

        private void txtNewUserPassword2_Enter(object sender, EventArgs e)
        {
            if (txtNewUserPassword2.Text == "Korda uut salasõna")
            {
                txtNewUserPassword2.Text = "";
                txtNewUserPassword2.UseSystemPasswordChar = true;
                txtNewUserPassword2.ForeColor = Color.Black;
            }
        }

        private void txtChangeCalorieLimitCalories_Leave(object sender, EventArgs e)
        {
            if (txtChangeCalorieLimitCalories.Text == "")
            {
                txtChangeCalorieLimitCalories.Text = "kcal";
                txtChangeCalorieLimitCalories.ForeColor = Color.DarkGray;
            }
        }

        private void txtCurrentEmail_Leave(object sender, EventArgs e)
        {
            if (txtCurrentEmail.Text == "")
            {
                txtCurrentEmail.Text = "Praegune meiliaadress";
                txtCurrentEmail.ForeColor = Color.DarkGray;
            }
        }

        private void txtNewEmail_Leave(object sender, EventArgs e)
        {
            if (txtNewEmail.Text == "")
            {
                txtNewEmail.Text = "Uus meiliaadress";
                txtNewEmail.ForeColor = Color.DarkGray;
            }
        }

        private void txtConfirmEmailChangePassword_Leave(object sender, EventArgs e)
        {
            if (txtConfirmEmailChangePassword.Text == "")
            {
                txtConfirmEmailChangePassword.Text = "Salasõna";
                txtConfirmEmailChangePassword.UseSystemPasswordChar = false;
                txtConfirmEmailChangePassword.ForeColor = Color.DarkGray;
            }
        }

        private void txtDeleteUserAccountPassword_Leave(object sender, EventArgs e)
        {
            if (txtDeleteUserAccountPassword.Text == "")
            {
                txtDeleteUserAccountPassword.Text = "Salasõna"; 
                txtDeleteUserAccountPassword.UseSystemPasswordChar = false;
                txtDeleteUserAccountPassword.ForeColor = Color.DarkGray;
            }
        }

        private void txtCurrentUserPassword_Leave(object sender, EventArgs e)
        {
            if (txtCurrentUserPassword.Text == "")
            {
                txtCurrentUserPassword.Text = "Praegune salasõna";
                txtCurrentUserPassword.UseSystemPasswordChar = false;
                txtCurrentUserPassword.ForeColor = Color.DarkGray;
            }
        }

        private void txtNewUserPassword_Leave(object sender, EventArgs e)
        {
            if (txtNewUserPassword.Text == "")
            {
                txtNewUserPassword.Text = "Uus salasõna";
                txtNewUserPassword.UseSystemPasswordChar = false;
                txtNewUserPassword.ForeColor = Color.DarkGray;
            }
        }

        private void txtNewUserPassword2_Leave(object sender, EventArgs e)
        {
            if (txtNewUserPassword2.Text == "")
            {
                txtNewUserPassword2.Text = "Korda uut salasõna";
                txtNewUserPassword2.UseSystemPasswordChar = false;
                txtNewUserPassword2.ForeColor = Color.DarkGray;
            }
        }

        private void btnSetCalorieLimit_Click(object sender, EventArgs e)
        {
            int temp;
            UserProfile = new UserProfileComponent.CUserProfile();

            if (int.TryParse(txtChangeCalorieLimitCalories.Text, out temp))
            {
                UserProfile.UpdateUserData(userId, txtChangeCalorieLimitCalories.Text, "calorie_limit");
                pbCalorieLimitSetSuccessful.Visible = true;
                UserDataLoad();
                TextboxReset();
                successPbTimer.Start();
            }
            else if (!(int.TryParse(txtChangeCalorieLimitCalories.Text, out temp)) && txtChangeCalorieLimitCalories.Text != "kcal")
            {
                MessageBox.Show("Viga kaloraaži sisestuses!", "Tõrge", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }
     private void btnChangeEmail_Click(object sender, EventArgs e)
        {
            Security = new SecurityLayer.CSecurity();
            Core = new CoreComponent.CCore();
            UserProfile = new UserProfileComponent.CUserProfile();

            if (txtCurrentEmail.Text != Security.DecryptString((string)UserProfile.GetDataFromUserData(userId, "user_email_enc")))
            {
                MessageBox.Show("Viga kehtivas meiliaadressis!", "Tõrge", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Core.CheckEmailRequirements(txtNewEmail.Text) == false)
            {
                MessageBox.Show("Viga uue meiliaadressi formaadis!", "Tõrge", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (UserProfile.UserProfileExists(txtNewEmail.Text) != 0)
            {
                MessageBox.Show("Uus meiliaadress on juba kasutusel!", "Tõrge", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Security.LoginAttempt(userId, txtConfirmEmailChangePassword.Text) == false)
            {
                MessageBox.Show("Viga salasõnas!", "Tõrge", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                UserProfile.UpdateUserData(userId, Security.EncryptString(txtNewEmail.Text), "user_email_enc");
                UserProfile.UpdateUserData(userId, Security.EncryptString(UserProfile.UserNameCreation(txtNewEmail.Text)), "username_enc");
                pbChangeEmailSuccessfull.Visible = true;
                UserDataLoad();
                TextboxReset();
                successPbTimer.Start();
            }
        }

        private void btnChangeUserPassword_Click(object sender, EventArgs e)
        {
            Security = new SecurityLayer.CSecurity();
            Core = new CoreComponent.CCore();
            UserProfile = new UserProfileComponent.CUserProfile();

            if (Security.LoginAttempt(userId, txtCurrentUserPassword.Text) == false)
            {
                MessageBox.Show("Viga praeguses salasõnas!", "Tõrge", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Core.CheckPasswordRequirements(txtNewUserPassword.Text, txtNewUserPassword2.Text) == false)
            {
                MessageBox.Show("Viga uues salasõnas!", "Tõrge", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Security.ChangeUserPassword(userId, txtNewUserPassword.Text);
                Security.RemoveToken(userId);
                pbUserPasswordChangeSuccessful.Visible = true;
                UserDataLoad();
                TextboxReset();
                successPbTimer.Start();
            }
        }

        private void btnDeleteUserAccount_Click(object sender, EventArgs e)
        {
            Security = new SecurityLayer.CSecurity();
            UserProfile = new UserProfileComponent.CUserProfile();
            if (Security.LoginAttempt(userId, txtDeleteUserAccountPassword.Text) == false)
            {
                MessageBox.Show("Viga salasõnas!", "Tõrge", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (UserProfile.DeleteUserAccount(userId) == true)
                {
                    MessageBox.Show("Konto kustutamine õnnestus!", "Konto kustutamine", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    ApexFit_login login = new ApexFit_login();
                    login.Show();
                }
                else
                {
                    MessageBox.Show("Konto kustutamine ebaõnnestus!", "Tõrge", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pnlAppLogo_Click(object sender, EventArgs e)
        {
            MenuButtonsDefaultColor();
            HideAllPanels();
            pnlApplicationInfo.Visible = true;
        }

        private void lnklblDevLinkedin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://ee.linkedin.com/in/alaasmagi");
        }

        private void lnklblDevGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/alaasmagi");
        }

        private void pbPauligLogo_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.pngegg.com/en/png-eovhe");
        }

        private void pbRedbullLogo_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.pngegg.com/en/png-dtrxy");
        }

        private void pbMonsterLogo_Click(object sender, EventArgs e)
        {
            Process.Start("https://i.pinimg.com/originals/54/e0/5d/54e05d64cfba06861544f94d5405802f.png");
        }

        private void pbApplicationInfoLogo_Click(object sender, EventArgs e)
        {

        }

        private void pbJanarLogo_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/alaasmagi/Toitumispaevik");
        }

        private void btnAnalysisOverall_Click(object sender, EventArgs e)
        {
            AnalysisSubPanelButtonsDefaultColor();
            HideAnalysisSubPanels();
            subpnlAnalysisOverall.Visible = true;
            btnAnalysisOverall.BackColor = Color.FromArgb(235, 247, 246);
        }

        private void btnAnalysisFoods_Click(object sender, EventArgs e)
        {
            AnalysisSubPanelButtonsDefaultColor();
            HideAnalysisSubPanels();
            subpnlAnalysisFoods.Visible = true;
            btnAnalysisFoods.BackColor = Color.FromArgb(235, 247, 246);
        }

        private void btnAnalysisTrainings_Click(object sender, EventArgs e)
        {
            AnalysisSubPanelButtonsDefaultColor();
            HideAnalysisSubPanels();
            subpnlAnalysisTrainings.Visible = true;
            btnAnalysisTrainings.BackColor = Color.FromArgb(235, 247, 246);
        }

        private void btnAnalysisSleep_Click(object sender, EventArgs e)
        {

            if ((int)UserProfile.GetDataFromUserData(userId, "premium_unlocked") == 0)
            {
                MessageBox.Show("See funktsioon on saadaval ainult rakenduse PRO-versioonil. PRO-versiooni ostmiseks klõpsake 'Profiili seaded'. ", "PRO-versioon", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AnalysisSubPanelButtonsDefaultColor();
                HideAnalysisSubPanels();
                subpnlAnalysisOverall.Visible = true;
                btnAnalysisOverall.BackColor = Color.FromArgb(235, 247, 246);
            }
            else
            {
                AnalysisSubPanelButtonsDefaultColor();
                HideAnalysisSubPanels();
                subpnlAnalysisSleep.Visible = true;
                btnAnalysisSleep.BackColor = Color.FromArgb(235, 247, 246);
            } 
        }

        private void pnlAnalysis_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlAnalysis.Visible == false)
            {
                AnalysisSubPanelButtonsDefaultColor();
                HideAnalysisSubPanels();
                subpnlAnalysisOverall.Visible = true;
                btnAnalysisOverall.BackColor = Color.FromArgb(235, 247, 246);
            }
        }

        private void pnlAnalysis_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTrainingsDateSelectionLabel_Click(object sender, EventArgs e)
        {
            mcPlanTrainings.Visible = true;
            lblTrainingsDateSelectionLabel.Visible = false;
            btnTrainingsCloseCalender.Visible = true;
            btnAddTrainingToPlan.Enabled = false;
        }

        private void btnTrainingsCloseCalender_Click(object sender, EventArgs e)
        {
            mcPlanTrainings.Visible = false;
            lblTrainingsDateSelectionLabel.Visible = true;
            btnTrainingsCloseCalender.Visible = false;
            btnAddTrainingToPlan.Enabled = true;
        }

    }
}