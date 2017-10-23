using db4o_mk_1.Controller;
using db4o_mk_1.Model;
using db4o_mk_1.View;
using Db4objects.Db4o;
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

namespace db4o_mk_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IEnumerable<Person> persons;

        public MainWindow()
        {
            InitializeComponent();

            DbOperations.Open();

            persons = DbOperations.Context.Query<Person>().ToList();
            foreach (var person in persons)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = person.FirstName + " " + person.LastName;
                ListOfPeople.Items.Add(item.Content);
            }           
        }

        ~MainWindow()
        {
            DbOperations.Close();
        }

        private void BtnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            var person1 = persons.FirstOrDefault(x => $"{x.FirstName} {x.LastName}".Equals(ListOfPeople.SelectedItem));

            if (person1 == null)
            {
                person1 = new Person("","");
            }

            PersonEdit newWindow = new PersonEdit(person1);
            newWindow.ShowDialog();
 
            ListOfPeople.Items.Clear();
            persons = DbOperations.Context.Query<Person>().ToList();
            foreach (var person in persons)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = person.FirstName + " " + person.LastName;
                ListOfPeople.Items.Add(item.Content);
            }

        }

        private void BtnStatic_Click(object sender, RoutedEventArgs e)
        {

            var nrPerson = DbOperations.Context.Query<Person>().Count;
            var nrAddress = DbOperations.Context.Query<Address>().Count;
            var nrPhones = DbOperations.Context.Query<Phone>().Count;

            MessageBox.Show("Liczba ludzi w bazie: " + nrPerson.ToString());
            MessageBox.Show("Liczba adresów w bazie: " + nrAddress.ToString());
            MessageBox.Show("Liczba telefonów w bazie: " + nrPhones.ToString());
        }
    }
}
