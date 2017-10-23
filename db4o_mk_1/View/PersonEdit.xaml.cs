using db4o_mk_1.Model;
using db4o_mk_1.Controller;
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

namespace db4o_mk_1.View
{
    /// <summary>
    /// Interaction logic for PersonEdit.xaml
    /// </summary>
    public partial class PersonEdit : Window
    {
        private Person person;
        private IEnumerable<Phone> phones;

        public PersonEdit(Person person)
        {
            this.person = person;
            InitializeComponent();
            TbFirstName.Text = person.FirstName;
            TbLastName.Text = person.LastName;
            
            if (person.Address == null)
            {
                TbStreet.IsReadOnly = true;
                TbStreet.Background = Brushes.Red;
                TbCity.IsReadOnly = true;
                TbCity.Background = Brushes.Red;
                TbPostCode.IsReadOnly = true;
                TbPostCode.Background = Brushes.Red;
            }
            else
            {
                TbStreet.Text = person.Address.Street;
                TbCity.Text = person.Address.City;
                TbPostCode.Text = person.Address.PostCode;
            }

            if (person.Phones != null)
            { 
                phones = DbOperations.Context.Query<Phone>().ToList();
                foreach (var phone in person.Phones)
                {
                    ListBoxItem item = new ListBoxItem();
                    item.Content = phone.Number + " " + phone.Operator + " " + phone.Type;
                    LbPhoneList.Items.Add(item.Content);
                }
            }
        }

        private void BtnAddPhone_Click(object sender, RoutedEventArgs e)
        {
            Phone phone;

            if (LbPhoneList.SelectedItem != null)
            {
                 phone = phones.First(x => $"{x.Number} {x.Operator} {x.Type}".Equals(LbPhoneList.SelectedItem));
            }
            else 
            {
                phone = new Phone();
                person.Phones.Add(phone);
            }

            PhoneEdit newWindow = new PhoneEdit(phone,person);
            newWindow.ShowDialog();
            LbPhoneList.Items.Clear();

            phones = DbOperations.Context.Query<Phone>().ToList();
            foreach (var phone1 in person.Phones)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = phone1.Number + " " + phone1.Operator + " " + phone1.Type;
                LbPhoneList.Items.Add(item.Content);
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            person.FirstName = TbFirstName.Text;
            person.LastName = TbLastName.Text;
            if (person.Address != null)
            {
            person.Address.Street = TbStreet.Text;
            person.Address.City = TbCity.Text;
            person.Address.PostCode = TbPostCode.Text;
            }

            DbOperations.Save(person);
            this.Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            DbOperations.Delete(person);
            this.Close();
        }

        private void BtnAddAdress_Click(object sender, RoutedEventArgs e)
        {
            person.Address = new Address();
            TbStreet.IsReadOnly = false;
            TbStreet.Background = Brushes.White;
            TbCity.IsReadOnly = false;
            TbCity.Background = Brushes.White;
            TbPostCode.IsReadOnly = false;
            TbPostCode.Background = Brushes.White;
        }

    }
}
