using Interface_Osennikov.Classes;
using Microsoft.Win32;
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

namespace Interface_Osennikov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public UsersContext usersContext = new UsersContext();
        public MessagesContext messagesContext = new MessagesContext();
        public int idSelectUser = -1;
        public static MainWindow mainWindow;
        public static Elements.Messages EditMsg = null;
        public string ImageSource = null;

        public MainWindow()
        {
            InitializeComponent();

            mainWindow = this;
            LoadUser();
        }

        public void LoadUser()
        {
            foreach (var user in usersContext.AllUsers)
            {
                ParentUser.Children.Add(new Elements.Users(user));
            }
        }

        private void SendMessages(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (idSelectUser == -1) return;

                if (EditMsg == null)
                {
                    MessagesContext newMessages;
                    if (ImageSource != null)
                    {
                        newMessages = new MessagesContext(Message.Text, DateTime.Now, idSelectUser, ImageSource);
                        newMessages.Save();
                        Message.Text = "";
                        SelectUser(null);
                        CancelImage();
                        return;
                    }
                    newMessages = new MessagesContext(Message.Text, DateTime.Now, idSelectUser);
                    newMessages.Save();
                    Message.Text = "";
                    SelectUser(null);
                    return;
                }

                if (EditMsg != null)
                {
                    EditMsg.ThisMessage.MessageText = Message.Text;
                    Message.Text = "";
                    SelectUser(null);
                    EditMsg = null;
                }
            }
        }

        public void SelectUser(Models.Users user)
        {
            if (user != null)
            {
                idSelectUser = usersContext.AllUsers.FindIndex(u => u == user);
            }

            parentMessage.Children.Clear();

            foreach (MessagesContext Messages in MessagesContext.AllMessages.FindAll(x => x.UserId == idSelectUser))
            {
                parentMessage.Children.Add(new Elements.Messages(Messages));
            }

            BlockMessage.IsEnabled = true;
        }

        private void Attachments_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = @"Изображения JPEG (*.jpg)|*.jpg|Изображения PNG (*.png)|*.png|Все файлы (*.*)|*.*";
            openFileDialog.ShowDialog();
            ImageSource = openFileDialog.FileName;
        }

        private void CancelImage()
        {
            ImageSource = null;
        }
    }
}
