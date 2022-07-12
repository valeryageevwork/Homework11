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
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using static Homework11.Generator;

namespace Homework11
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Consultant> DataBaseConsultants;
        private ObservableCollection<Manager> DataBaseManagers;

        private List<List<bool>> flags = new List<List<bool>>()
        {
            new List<bool>() { false, false },
            new List<bool>() { false, false , false, false }
        };
        public MainWindow()
        {
            InitializeComponent();

            DataBaseConsultants = new ObservableCollection<Consultant>();
            DataBaseManagers = new ObservableCollection<Manager>();

            for (int i = 0; i < 10; i++)
            {
                Client client = ClientGenerate();

                DataBaseConsultants.Add(new Consultant(client.Name, client.Surname,
                                                       client.PhoneNumber, client.PassportSeries,
                                                       client.PassportNumber,
                                                       "All", "Beginning", "None"));

                DataBaseManagers.Add(new Manager(client.Name, client.Surname,
                                                 client.PhoneNumber, client.PassportSeries,
                                                 client.PassportNumber,
                                                 "All", "Beginning", "None"));
            }

            ConsultantListBox.ItemsSource = DataBaseConsultants;
            ManagerListBox.ItemsSource = DataBaseManagers;
        }

        private void PhoneNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            flags[0][0] = false;

            if (ButtonChangePhoneNumberClient != null)
                ButtonChangePhoneNumberClient.IsEnabled = false;

            if (PhoneNumberTextBox.Text != "") 
            {
                if (PhoneNumberTextBox.Text.First() == '+')
                {
                    if (PhoneNumberTextBox.Text.Length > 1)
                    {
                        if (PhoneNumberTextBox.Text.Length < 14)
                        {
                            if (!long.TryParse(PhoneNumberTextBox.Text.Remove(0, 1), out long num))
                                PhoneNumberTextBox.Clear();

                            if(PhoneNumberTextBox.Text.Length == 3)
                            {
                                if(!((PhoneNumberTextBox.Text[1] == '4') && (PhoneNumberTextBox.Text[2] == '4')))
                                    PhoneNumberTextBox.Clear();
                            }

                            if (PhoneNumberTextBox.Text.Length == 13)
                            {
                                flags[0][0] = true;
                                ButtonChangePhoneNumberClient.IsEnabled = flags[0][0] && flags[0][1];
                            }
                        }
                        else
                            PhoneNumberTextBox.Clear();
                    }
                }
                else
                    PhoneNumberTextBox.Clear();
            }
        }

        private void ChangePhoneNumberClientButton_Click(object sender, RoutedEventArgs e)
        {
            int index = ConsultantListBox.SelectedIndex;
            Consultant consultant = (Consultant) ConsultantListBox.SelectedItem;

            if (consultant != null)
            {
                Consultant new_consultant = new Consultant(consultant.Name, consultant.Surname,
                                                           PhoneNumberTextBox.Text, consultant.PassportSeries,
                                                           consultant.PassportNumber,
                                                           "PhoneNumber", "Changing", "Consultant");
                DataBaseConsultants[index] = new_consultant;

                Manager manager = new Manager(consultant.Name, consultant.Surname,
                                              PhoneNumberTextBox.Text, consultant.PassportSeries,
                                              consultant.PassportNumber,
                                              "PhoneNumber", "Changing", "Consultant");
                DataBaseManagers[index] = manager;

                ConsultantListBox.ItemsSource = null;
                ConsultantListBox.ItemsSource = DataBaseConsultants;

                ManagerListBox.ItemsSource = null;
                ManagerListBox.ItemsSource = DataBaseManagers;
            }
        }

        private void ConsultantListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            flags[0][1] = true;
            ButtonChangePhoneNumberClient.IsEnabled = flags[0][0] && flags[0][1];

            if (PhoneNumberTextBox.Text == "")
                ButtonChangePhoneNumberClient.IsEnabled = true;
        }

        private void ChangeDataButton_Click(object sender, RoutedEventArgs e)
        {
            int index = ManagerListBox.SelectedIndex;
            Manager manager = ManagerListBox.SelectedItem as Manager;

            if (manager != null)
            {
                Manager new_manager = new Manager(NameTextBox.Text, SurnameTextBox.Text, M_PhoneNumberTextBox.Text,
                                                  PassportNumberTextBox.Text, PassportSeriesTextBox.Text,
                                                  "All", "Changing", "Manager");
                DataBaseManagers[index] = new_manager;

                Consultant consultant = new Consultant(NameTextBox.Text, SurnameTextBox.Text, M_PhoneNumberTextBox.Text,
                                                       PassportNumberTextBox.Text, PassportSeriesTextBox.Text,
                                                       "All", "Changing", "Manager");
                DataBaseConsultants[index] = consultant;

                ManagerListBox.ItemsSource = null;
                ManagerListBox.ItemsSource = DataBaseManagers;

                ConsultantListBox.ItemsSource = null;
                ConsultantListBox.ItemsSource = DataBaseConsultants;
            }
        }

        private void MPhoneNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            flags[1][1] = false;

            if(ButtonChangeData != null)
                ButtonChangeData.IsEnabled = false;

            if (M_PhoneNumberTextBox.Text.Length == 13)
            {
                Regex regex = new Regex(@"^(\+44\d{10,10})$");
                if (regex.IsMatch(M_PhoneNumberTextBox.Text))
                {
                    flags[1][1] = true;
                }
                else
                    M_PhoneNumberTextBox.Clear();
            }
        }

        private void PassportNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            flags[1][2] = false;

            if (ButtonChangeData != null)
                ButtonChangeData.IsEnabled = false;

            if (PassportNumberTextBox.Text.Length == 4)
            {
                Regex regex = new Regex(@"^(\d{4,4})$");
                if (regex.IsMatch(PassportNumberTextBox.Text))
                {
                    flags[1][2] = true;
                }
                else
                    PassportNumberTextBox.Clear();
            }
        }

        private void PassportSeriesTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            flags[1][3] = false;

            if (ButtonChangeData != null)
                ButtonChangeData.IsEnabled = false;

            if (PassportSeriesTextBox.Text.Length == 6)
            {
                Regex regex = new Regex(@"^(\d{6,6})$");
                if (regex.IsMatch(PassportSeriesTextBox.Text))
                {
                    flags[1][3] = true;
                }
                else
                    PassportSeriesTextBox.Clear();
            }
        }

        private void ManagerListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            flags[1][0] = true;
            ButtonChangeData.IsEnabled = flags[1][0] && flags[1][1] && flags[1][2] && flags[1][3];

            if (M_PhoneNumberTextBox.Text == "" && PassportNumberTextBox.Text == "" && PassportSeriesTextBox.Text == "")
                ButtonChangeData.IsEnabled = true;
        }
    }
}
