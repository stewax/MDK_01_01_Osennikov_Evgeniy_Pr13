using Interface_Osennikov.Classes;
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

namespace Interface_Osennikov.Elements
{
    /// <summary>
    /// Логика взаимодействия для Messages.xaml
    /// </summary>
    public partial class Messages : UserControl
    {
        public MessagesContext ThisMessage;

        public Messages(Classes.MessagesContext messages)
        {
            InitializeComponent();

            if (messages.ImageSource != null)
            {
                try
                {
                    image.Source = new BitmapImage(new Uri(messages.ImageSource));
                    image.Visibility = Visibility.Visible;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            ThisMessage = messages;
            Message.Text = messages.MessageText;
            Date.Text = messages.CreatedAt.ToString("dd.MM.yyyy");
        }

        private void DeleteMessage(object sender, MouseButtonEventArgs e)
        {
            ThisMessage.Delete();
            MainWindow.mainWindow.parentMessage.Children.Remove(this);
        }

        private void UserControl_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.Message.Text = ThisMessage.MessageText;
            MainWindow.EditMsg = this;
        }
    }
}
