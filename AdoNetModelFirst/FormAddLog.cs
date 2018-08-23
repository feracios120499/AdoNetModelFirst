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
    public partial class FormAddLog : Form
    {
        public FormAddLog()
        {
            InitializeComponent();
            using(var db=new LibraryContainer())
            {
                var listBook = db.BooksSet.ToList();
                foreach(var item in db.LogBooksSet.Where(p => p.IsDebtor))
                {
                    listBook.Remove(listBook.Find(p => p.Id == item.Books.Id));
                }
                checkedListBox1.Items.AddRange(listBook.ToArray());
                comboBox1.Items.AddRange(db.UsersSet.ToArray());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Выберите пользователя");
                return;
            }
            if (checkedListBox1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите книги");
                return;
            }
            using(var db=new LibraryContainer())
            {
                var user = db.UsersSet.ToList().Find(p => p.Id == (comboBox1.SelectedItem as Users).Id);
                foreach(var item in checkedListBox1.SelectedItems)
                {
                    var book = db.BooksSet.ToList().Find(p => p.Id == (item as Books).Id);
                    db.LogBooksSet.Add(new LogBooks { Books = book, Users = user, IsDebtor = true });
                    

                }
                db.SaveChanges();
            }
            this.Close();
        }
    }
}
