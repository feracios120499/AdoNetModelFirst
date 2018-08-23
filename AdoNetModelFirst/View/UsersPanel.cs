using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNetModelFirst
{
    public partial class UsersPanel : UserControl
    {
        public UsersPanel()
        {
            InitializeComponent();
        }
        private static bool Flag { get; set; } = false;
        private Users users;
        public UsersPanel(Users users)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            this.BringToFront();
            this.BackColor = Flag ? Color.DarkGray : Color.Black;
            Flag = !Flag;
            labelName.Text = users.Name;
            this.users = users;
            ToolTip t = new ToolTip();
            t.SetToolTip(buttonDelete, "Удалить пользователя");
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Вы дейсвительно хотите удалить пользователя {users.Name}", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            using(var db=new LibraryContainer())
            {
                var usersFind = db.UsersSet.ToList().Find(p => p.Id == users.Id);
                if (usersFind != null)
                {
                    usersFind.LogBooks.Clear();
                    db.UsersSet.Remove(usersFind);
                    db.SaveChanges();
                }
            }
            this.Parent.Controls.Remove(this);
        }
    }
}
