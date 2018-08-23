using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace AdoNetModelFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitDB();
            Show();
        }
        private void InitDB()
        {
            using (var db = new LibraryContainer())
            {
                try
                {
                    foreach (var item in db.BooksSet)
                    {
                        item.Authors.Clear();
                    }
                    db.BooksSet?.RemoveRange(db.BooksSet);
                    db.AuthorsSet?.RemoveRange(db.AuthorsSet);

                    db.LogBooksSet?.RemoveRange(db.LogBooksSet);
                    db.UsersSet?.RemoveRange(db.UsersSet);
                    db.SaveChanges();

                    db.UsersSet.Add(new Users { Name = "Max" });
                    db.UsersSet.Add(new Users { Name = "Ira" });
                    db.SaveChanges();

                    db.BooksSet.Add(new Books { Name = "Calina" });
                    db.BooksSet.Add(new Books { Name = "Stalingrad" });
                    db.SaveChanges();

                    db.AuthorsSet.Add(new Authors { Name = "Pushkin" });
                    db.AuthorsSet.Add(new Authors { Name = "Lenin" });
                    db.SaveChanges();

                    db.AuthorsSet.ToList()[0].Books.Add(db.BooksSet.ToList()[0]);
                    db.AuthorsSet.ToList()[0].Books.Add(db.BooksSet.ToList()[1]);
                    db.AuthorsSet.ToList()[1].Books.Add(db.BooksSet.ToList()[1]);

                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException.InnerException.Message);
                }
            }
        }
        private void Show()
        {
            using (var db = new LibraryContainer())
            {
                foreach (var item in db.AuthorsSet)
                {
                    listBox1.Items.Add(item);
                }
            }
        }
    }
}
