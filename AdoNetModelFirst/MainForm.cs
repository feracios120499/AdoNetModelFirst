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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonMinim_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void ShowAll()
        {
            ShowBooks();
            ShowAuthors();
            ShowUsers();
            ShowLogs();
        }
        private void ShowBooks()
        {
            panelListBooks.Controls.Clear();
            using (var db = new LibraryContainer())
            {
                foreach (var item in db.BooksSet)
                {
                    var panel = new BooksPanel(item);
                    panelListBooks.Controls.Add(panel);
                }
            }
        }

        private void ShowAuthors()
        {
            panelListAuthors.Controls.Clear();
            using (var db = new LibraryContainer())
            {
                foreach (var item in db.AuthorsSet)
                {
                    var panel = new AuthorsPanel(item);
                    panelListAuthors.Controls.Add(panel);
                }
            }
        }

        private void ShowUsers()
        {
            panelListUsers.Controls.Clear();
            using (var db = new LibraryContainer())
            {
                foreach (var item in db.UsersSet)
                {
                    var panel = new UsersPanel(item);
                    panelListUsers.Controls.Add(panel);
                }
            }
        }

        private void ShowLogs()
        {
            panelListLogs.Controls.Clear();
            using (var db = new LibraryContainer())
            {
                foreach (var item in db.LogBooksSet)
                {
                    var panel = new LogsPanel(item);
                    panelListLogs.Controls.Add(panel);
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowAll();
        }

        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            new FormAddBook().ShowDialog();
            ShowAll();
        }

        private void buttonBooks_Click(object sender, EventArgs e)
        {
            panelBooks.BringToFront();
        }

        private void buttonAuthors_Click(object sender, EventArgs e)
        {
            panelAuthors.BringToFront();
        }

        private void buttonUsers_Click(object sender, EventArgs e)
        {
            panelUsers.BringToFront();
        }

        private void buttonLog_Click(object sender, EventArgs e)
        {
            panelLog.BringToFront();
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            panelQuery.BringToFront();
        }

        private void buttonAddAuthor_Click(object sender, EventArgs e)
        {
            new FormAddAuthor().ShowDialog();
            ShowAll();
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            new FormAddUser().ShowDialog();
            ShowAll();
        }

        private void buttonAddLog_Click(object sender, EventArgs e)
        {
            new FormAddLog().ShowDialog();
            ShowAll();
        }

        private void buttonQuery1_Click(object sender, EventArgs e)
        {
            listBoxQuery1.Items.Clear();
            using (var db = new LibraryContainer())
            {
                foreach (var item in db.UsersSet)
                {
                    if (item.LogBooks.ToList().Exists(ex => ex.IsDebtor))
                    {
                        listBoxQuery1.Items.Add(item);
                    }
                }
                //listBoxQuery1.Items.AddRange(db.UsersSet.Where(p => p.LogBooks.ToList().Exists(ex => ex.IsDebtor)).ToArray());
                //не работает, хз почему, кидает не понятный Exception 
            }
        }

        private void buttonQuery2_Click(object sender, EventArgs e)
        {
            listBoxQuery2.Items.Clear();
            using (var db = new LibraryContainer())
            {
                listBoxQuery2.Items.AddRange(db.BooksSet.ToList().Skip(2).FirstOrDefault().Authors.ToArray());
            }
        }

        private void buttonQuery3_Click(object sender, EventArgs e)
        {
            listBoxQuery3.Items.Clear();
            using (var db = new LibraryContainer())
            {
                var listBook = db.BooksSet.ToList();
                foreach (var item in db.LogBooksSet.Where(p => p.IsDebtor))
                {
                    listBook.Remove(listBook.Find(p => p.Id == item.Books.Id));
                }
                listBoxQuery3.Items.AddRange(listBook.ToArray());
            }
        }

        private void buttonQuery4_Click(object sender, EventArgs e)
        {
            listBoxQuery4.Items.Clear();
            using(var db=new LibraryContainer())
            {
                listBoxQuery4.Items.AddRange(db.UsersSet.ToList().Skip(1).FirstOrDefault().LogBooks.Where(p=>p.IsDebtor).Select(p => p.Books).ToArray());
            }
        }

        private void buttonQuery5_Click(object sender, EventArgs e)
        {
            using(var db=new LibraryContainer())
            {
                db.LogBooksSet.ToList().ForEach(p => p.IsDebtor = false);
                db.SaveChanges();
                ShowAll();
            }
        }
    }
}
