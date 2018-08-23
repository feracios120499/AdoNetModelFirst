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
    public partial class FormAddBook : Form
    {
        public FormAddBook()
        {
            InitializeComponent();
            using (var db = new LibraryContainer())
            {
                checkedListBox1.Items.AddRange(db.AuthorsSet.ToArray());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Введите название книги!");
                return;
            }
            using (var db = new LibraryContainer())
            {
                var newBook = new Books();
                newBook.Name = textBox1.Text;
                
                foreach (var item in checkedListBox1.SelectedItems)
                {
                    var author = db.AuthorsSet.ToList().Find(p => p.Id == (item as Authors).Id);
                    newBook.Authors.Add(author);
                }
                db.BooksSet.Add(newBook);
                db.SaveChanges();
            }
            this.Close();
        }
    }
}
