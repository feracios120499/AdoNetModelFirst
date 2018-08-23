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
    public partial class FormAddAuthor : Form
    {
        public FormAddAuthor()
        {
            InitializeComponent();
            using (var db = new LibraryContainer())
            {
                checkedListBox1.Items.AddRange(db.BooksSet.ToArray());
            }
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
                var newAuthor = new Authors();
                newAuthor.Name = textBox1.Text;

                foreach (var item in checkedListBox1.SelectedItems)
                {
                    var book = db.BooksSet.ToList().Find(p => p.Id == (item as Books).Id);
                    newAuthor.Books.Add(book);
                }
                db.AuthorsSet.Add(newAuthor);
                db.SaveChanges();
            }
            this.Close();
        }
    }
}
