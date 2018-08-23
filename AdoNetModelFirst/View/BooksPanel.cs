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
    public partial class BooksPanel : UserControl
    {
        public BooksPanel()
        {
            InitializeComponent();
        }
        private static bool Flag { get; set; } = false;
        private Books books;
        public BooksPanel(Books books)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            this.BringToFront();
            this.BackColor = Flag ? Color.DarkGray : Color.Black;
            Flag = !Flag;
            labelName.Text = books.Name;
            foreach(var item in books.Authors)
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
            this.books = books;
            ToolTip t = new ToolTip();
            t.SetToolTip(buttonDelete, "Удалить книгу");
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Вы дейсвительно хотите удалить книгу {books.Name}", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            using(var db=new LibraryContainer())
            {
                var bookFind = db.BooksSet.ToList().Find(p => p.Id == books.Id);
                if (bookFind != null)
                {
                    bookFind.Authors.Clear();
                    db.BooksSet.Remove(bookFind);
                    db.SaveChanges();
                }
            }
            this.Parent.Controls.Remove(this);
        }
    }
}
