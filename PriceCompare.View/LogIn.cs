using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PriceCompare.Entities;
using PriceCompare.Logic;

namespace PriceCompare.View
{
    public partial class LogIn : Form
    {
        private readonly IManager _manager = new Manager();
        private bool _flagValidation = true;

      

        public LogIn()
        {
           
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUp sinUpForm = new SignUp(_manager);
            sinUpForm.ShowDialog();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            bool flagLogin = false;
            User loginUser = new User("", "");
            string errorMessage = "";


            InputValidation();
            if (!_flagValidation)
            {
                _flagValidation = true;

                return;
            }

            BeginInvoke((Action)(async () =>
            {
                User user = new User(txtUserName.Text, txtPassword.Text);
                await Task.Run(() =>
                {

                    loginUser = _manager.LoginUser(user);
                });

                switch (loginUser.ResultCode)
                    {
                        case User.UserResultCode.UserLoggedIn:
                            errorMessage = "User Name already loggedin!";
                            break;

                        case User.UserResultCode.ErrorPassword:
                            errorMessage = "Incorrect password!";
                            break;

                        case User.UserResultCode.UserNotExist:
                            errorMessage = "User Name doesn't exist!";
                            break;
                        case User.UserResultCode.Success:
                            flagLogin = true;
                            break;
                    }

                    if (!flagLogin)
                    {
                        MessageBox.Show(errorMessage);
                        return;
                    }

                Main mainForm = new Main(_manager,loginUser);
                this.Hide();
                mainForm.ShowDialog();
                this.Show();
            }));



            
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
             lblUserNameError.Hide();
            lblPasswordError.Hide();
            
            BeginInvoke((Action)(async () =>
            {
                await Task.Run(() => _manager.InitializeData());
                btnSignIn.Enabled = true;
                btnSignUp.Enabled = true;
            }));
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            RegularExpressionAttribute userNameValidation = new RegularExpressionAttribute("^[a-zA-Z0-9]+$");

            bool result = userNameValidation.IsValid(txtUserName.Text);

            if (!result)
            {
                lblUserNameError.Text = "Enter numbers and letters only!";
                lblUserNameError.Show();
                _flagValidation = false;
            }
            else
            {
                lblUserNameError.Hide();
                _flagValidation = true;

            }
        }

        private void InputValidation()
        {
            bool flagPassword = true;
            bool flagUser = true;

            if (txtUserName.Text.Length < 5)
            {
                lblUserNameError.Text = "Please use 5-10 characters";
                lblUserNameError.Show();
                flagUser = false;
            }
            if (txtPassword.Text.Length < 5)
            {
                lblPasswordError.Text = "Please use 5-10 characters";
                lblPasswordError.Show();
                flagPassword = false;
            }

            if (flagUser)
            {
                lblUserNameError.Hide();
            }

            if (flagPassword)
            {

                lblPasswordError.Hide();
            }
            

            _flagValidation = flagUser & flagPassword ;
        }
    }
}
