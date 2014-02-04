using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Controller;
using Interfaces;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for AddCustomerWindow.xaml
    /// </summary>
    public partial class AddCustomerWindow : Window
    {
        //private List<IContactPerson> cpList = SubController.getCpList(); 
        
        public AddCustomerWindow()
        {
            InitializeComponent();
            //listviewCP.ItemsSource = cpList;
        }

        private void onClickAddContact(object sender, RoutedEventArgs e)
        {
            //string name = txtboxName.Text;
            //string phone = txtboxPhone.Text;
            //string emails = txtboxEmail.Text;
            //string available = txtboxAvailable.Text;

            //IContactPerson cp = SubController.CreateContact(name, phone, emails, available);
            ////add to subcontroller list
            //SubController.AddCPToList(cp);
            //cpList.Add(cp);

            //UpdateList();
        }

        private void UpdateList()
        {
            //cpList = SubController.getCpList();
            //listviewCP.Items.Refresh();
        }

        private void onClickApply(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void onClickCancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DeleteContact(object sender, RoutedEventArgs e)
        {
            //IContactPerson iCP = listviewCP.SelectedItem as IContactPerson;
            //SubController.DeleteCPFromList(iCP);
            //UpdateList();
        }
    }
}
