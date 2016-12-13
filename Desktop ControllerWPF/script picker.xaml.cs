using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Desktop_ControllerWPF
{
    /// <summary>
    /// Interaction logic for script_picker.xaml
    /// </summary>
    public partial class script_picker : Window
    {
        public string stringresult;

        public void Data(int del)
        {
            DataSet DS = new DataSet();
            DS.ReadXml(@"Resources/scrsaves.xml");
            DataTable DT = DS.Tables["Scripts"];

            if (del == 1)
            {
                DT.Rows.RemoveAt(scriptGrid.SelectedIndex);
                DT.WriteXml(@"Resources/scrsaves.xml");
            }
            DataView DV = new DataView(DT);

            DV.Table.Columns.Remove("ID");
            DV.Table.Columns.Remove("school");

            scriptGrid.ItemsSource = DV;

        }

        public script_picker()
        {
            InitializeComponent();
            Data(0);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (System.Windows.MessageBox.Show("Are you sure you want to delete this script?", "Delete Script?", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                Data(1);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            DataRowView DRV = (DataRowView)scriptGrid.SelectedItem;
            stringresult = (DRV["Script"]).ToString();
            this.Close();
        }
    }
}
