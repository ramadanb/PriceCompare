using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PriceCompare.Entities;
using PriceCompare.Logic;

namespace PriceCompare.View
{
    public partial class SignUp : Form
    {
        private readonly IManager _manager;

        private bool _flagValidation = true;

        public SignUp(IManager manager)
        {
            _manager = manager;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
           RegularExpressionAttribute userNameValidation= new RegularExpressionAttribute("^[a-zA-Z0-9]+$");

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

        private void SignUp_Load(object sender, EventArgs e)
        {
            lblUserNameError.Hide();
            lblConfirmPasswordError.Hide();
            lblPasswordError.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            InputValidation();

            if (!_flagValidation)
            {
                _flagValidation = true;
              
                return;
            }

            BeginInvoke((Action) (async () =>
            {
                User result = null;
                User user = new User(txtUserName.Text, txtPassword.Text);
                btnRegister.Enabled = false;
                await Task.Run(() =>
                {
                    result = _manager.RegisterUser(user);
                });
              

                if (result.ResultCode == User.UserResultCode.Success)
                {
                    MessageBox.Show("Signup completed Successfully!");
                }
                else
                {
                    MessageBox.Show("User Name Exist!");
                }
                btnRegister.Enabled = true;
            }));
        }

        private void InputValidation()
        {
            bool flagPassword = true;
            bool flagConfrim = true;
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
            if (txtConfirmPassword.Text.Length < 5)
            {
                lblConfirmPasswordError.Text = "Please use 5-10 characters";
                lblConfirmPasswordError.Show();
                flagConfrim = false;
            }
            if (!txtConfirmPassword.Text.Equals(txtPassword.Text))
            {
                lblConfirmPasswordError.Text = "passwords don't match";
                lblConfirmPasswordError.Show();
                flagConfrim = false;
            }

            if (flagUser)
            {
                lblUserNameError.Hide();
            }

            if (flagPassword)
            {

                lblPasswordError.Hide();
            }
            if (flagConfrim)
            {

                lblConfirmPasswordError.Hide();

            }

            _flagValidation = flagUser & flagPassword & flagConfrim;
        }
    }
}
