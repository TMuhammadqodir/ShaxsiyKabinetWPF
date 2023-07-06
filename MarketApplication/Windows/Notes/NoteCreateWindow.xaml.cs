using MarketApplication;
using MarketApplication.DbContexts;
using MarketApplication.Entities.Categories;
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
using System.Windows.Shapes;

namespace Shaxsiy_Kabinet.Windows.Notes
{
    /// <summary>
    /// Interaction logic for NoteCreateWindow.xaml
    /// </summary>
    public partial class NoteCreateWindow : Window
    {
        private long _userId;
        public NoteCreateWindow(long userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        string StringFromRichTextBox(RichTextBox rtb)
        {
            TextRange textRange = new TextRange(
              rtb.Document.ContentStart,
             
              rtb.Document.ContentEnd
            );
            
            return textRange.Text;
        }


        private async void Create_Button(object sender, RoutedEventArgs e)
        {
            if(tbTitle.Text != "")
            {
                Note note = new Note();
                
                note.Title = tbTitle.Text;
                note.UserId = _userId;
                note.Notee = StringFromRichTextBox(rtnNote);

                AppDbContext appDbContext = new AppDbContext();

                appDbContext.notes.Add(note);
                await appDbContext.SaveChangesAsync();

                MessageBox.Show("saved");

                MainWindow mainWindow = new MainWindow(_userId);

                mainWindow.Show();  

                this.Close();
            }
        }
    }
}
