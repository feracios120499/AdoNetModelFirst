using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNetModelFirst
{
    public partial class FormAddUser : Form
    {
        public FormAddUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Введите ФИО!");
                return;
            }
            using (var db = new LibraryContainer())
            {
                db.UsersSet.Add(new Users { Name = textBox1.Text });
                db.SaveChanges();

            }
            this.Close();
        }
    }
}
