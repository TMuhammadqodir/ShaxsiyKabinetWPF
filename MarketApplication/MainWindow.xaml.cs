using MarketApplication.DbContexts;
using MarketApplication.Entities.Categories;
using Microsoft.EntityFrameworkCore;
using Shaxsiy_Kabinet.Components.Notes;
using Shaxsiy_Kabinet.Windows.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MarketApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private long _userId;
        public MainWindow(long userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        private void Border_mouse(object sender, MouseButtonEventArgs e)
        {
            NoteCreateWindow noteCreateWindow = new NoteCreateWindow(_userId);

            noteCreateWindow.Show();

            this.Close();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            wrpNotes.Children.Clear();

            AppDbContext appDbContext = new AppDbContext();

            var notes = appDbContext.notes.Where(x => (
            x.UserId == _userId)).ToList();

            var user = appDbContext.UserEntities.Where(x => (
            x.Id == _userId)).ToList();

            lbName.Content = user[0].LastName+" "+user[0].FirstName;

            foreach (var note in notes)
              {
                  NotesView notesView = new NotesView();

                  notesView.SetData(note);

                  wrpNotes.Children.Add(notesView);
              }
        }
    }
}
