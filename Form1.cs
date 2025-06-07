using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApkScriptPad
{
    public partial class Form1 : Form
    {
        
        private string registeredUsername;
        private string registeredPassword;

        public Form1()
        {
            InitializeComponent();

            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsernameReg.Text;
            string password = txtPasswordReg.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username dan Password tidak boleh kosong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Password dan Konfirmasi Password tidak cocok.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            registeredUsername = username;
            registeredPassword = password;

            MessageBox.Show($"Registrasi berhasil untuk user: {username}", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
            txtUsernameReg.Clear();
            txtPasswordReg.Clear();
            txtConfirmPassword.Clear();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsernameLogin.Text;
            string password = txtPasswordLogin.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username dan Password harus diisi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

          
            if (!string.IsNullOrEmpty(registeredUsername) && !string.IsNullOrEmpty(registeredPassword))
            {
                if (username == registeredUsername && password == registeredPassword)
                {
                    MessageBox.Show("Login berhasil!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    txtUsernameLogin.Clear();
                    txtPasswordLogin.Clear();
                }
                else
                {
                    MessageBox.Show("Username atau Password salah.", "Gagal Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Belum ada akun yang terdaftar. Silakan registrasi terlebih dahulu.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}