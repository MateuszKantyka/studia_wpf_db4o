using db4o_mk_1.Controller;
using db4o_mk_1.Model;
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
    /// Interaction logic for PhoneEdit.xaml
    /// </summary>
    public partial class PhoneEdit : Window
    {
        private Person person;
        private Phone phone;

        public PhoneEdit(Phone phone, Person person)
        {
            InitializeComponent();
            this.person = person;
            this.phone = phone;

            TbNumber.Text = phone.Number;
            TbOperator.Text = phone.Operator;
            TbType.Text = phone.Type;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            phone.Number = TbNumber.Text;
            phone.Operator = TbOperator.Text;
            phone.Type = TbType.Text;
            DbOperations.Save(person.Phones);
            this.Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            person.Phones.Remove(phone);
            DbOperations.Delete(phone);
            DbOperations.Save(person);

            this.Close();
        }
    }
}
