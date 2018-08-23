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
    public partial class LogsPanel : UserControl
    {
        public LogsPanel()
        {
            InitializeComponent();
        }
        private static bool Flag { get; set; } = false;
        private LogBooks logBook;
        public LogsPanel(LogBooks logBook)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            this.BringToFront();
            this.BackColor = Flag ? Color.DarkGray : Color.Black;
            Flag = !Flag;
            labelNameUser.Text = logBook.Users.Name;
            labelNameBook.Text = logBook.Books.Name;
            this.logBook = logBook;
            checkBoxDebstor.Checked = !logBook.IsDebtor;
            
            ToolTip t = new ToolTip();
            t.SetToolTip(buttonDelete, "Удалить запись");
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Вы дейсвительно хотите удалить запись", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            using(var db=new LibraryContainer())
            {
                db.LogBooksSet.Remove(db.LogBooksSet.ToList().Find(p => p.Id == logBook.Id));
                db.SaveChanges();
            }
            this.Parent.Controls.Remove(this);
        }

        private void checkBoxDebstor_CheckedChanged(object sender, EventArgs e)
        {
            using(var db=new LibraryContainer())
            {
                db.LogBooksSet.ToList().Find(p => p.Id==logBook.Id).IsDebtor = !checkBoxDebstor.Checked;
                db.SaveChanges();
            }
        }
    }
}
