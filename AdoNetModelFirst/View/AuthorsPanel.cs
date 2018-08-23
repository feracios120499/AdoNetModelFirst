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
    public partial class AuthorsPanel : UserControl
    {
        public AuthorsPanel()
        {
            InitializeComponent();
        }
        private static bool Flag { get; set; } = false;
        private Authors authors;
        public AuthorsPanel(Authors authors)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            this.BringToFront();
            this.BackColor = Flag ? Color.DarkGray : Color.Black;
            Flag = !Flag;
            labelName.Text = authors.Name;
            foreach(var item in authors.Books)
            {
                var label = new Label();
                label.Font = new Font("Century Gothic", 10f);
                label.Text = item.Name;
                label.AutoSize = true;
                label.ForeColor = Color.White;
                label.Dock = DockStyle.Top;
                panelAuthors.Controls.Add(label);
                label.BringToFront();
            }
            this.authors = authors;
            ToolTip t = new ToolTip();
            t.SetToolTip(buttonDelete, "Удалить книгу");
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Вы дейсвительно хотите удалить Автора {authors.Name}", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            using(var db=new LibraryContainer())
            {
                var authorFind = db.AuthorsSet.ToList().Find(p => p.Id == authors.Id);
                if (authorFind != null)
                {
                    authorFind.Books.Clear();
                    db.AuthorsSet.Remove(authorFind);
                    db.SaveChanges();
                }
            }
            this.Parent.Controls.Remove(this);
        }
    }
}
