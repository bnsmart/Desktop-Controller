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
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using System.Data;
using System.Xml.Linq;

namespace Desktop_ControllerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string x = "";
        string comp = "";
        string school = "";
        string msiExec = "";

        private void PsExecute(string type, string command)
        {
            if (ResultTable.SelectedItems.Count > 0)
            {

                if (command == "" & type == "Psexec.exe")
                {
                    MessageBox.Show("Please enter a command");
                }
                else
                {
                    Process p = new Process();

                    string computers = "";

                    if (Uninstall.IsChecked == true)
                    {
                        x = "/x ";
                    }
                    else
                    {
                        x = "/i ";
                    };

                    try
                    {
                        Uri uri = new Uri(applocF.Text.Replace('"', ' ').Trim());
                        msiExec = "msiexec.exe ";
                    }
                    catch (Exception a)
                    {
                        msiExec = " ";
                        x = "";
                    }
                    var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                    var complete = System.IO.Path.Combine(systemPath, "errorLog.txt");
                    //MessageBox.Show(complete);
                    using (var f = File.CreateText(complete))
                    {
                        foreach (DataRowView com in ResultTable.SelectedItems)
                        {
                            DataRow row = com.Row;
                            computers = row.ItemArray[0].ToString();
                            try
                            {
                                p.StartInfo.UseShellExecute = false;

                                p.StartInfo.RedirectStandardOutput = true;
                                p.StartInfo.RedirectStandardError = true;
                                p.StartInfo.FileName = type;

                                if (type == "psexec.exe")
                                {
                                    //MessageBox.Show(@"\\" + computers + " -u Domain" + @"\user -p password " + msiExec + x + command);
                                    p.StartInfo.Arguments = @"\\" + computers + " -u Domain" + @"\user -p password " + msiExec + x + command;
                                }
                                else if (type == "PsShutdown.exe")
                                {
                                    //MessageBox.Show(@"\\" + computers + " -u Domain" + @"\user -p password " + command);
                                    p.StartInfo.Arguments = @"\\" + computers + " -u Domain" + @"\user -p password " + command;
                                }

                                p.StartInfo.CreateNoWindow = false;
                                p.EnableRaisingEvents = true;
                                p.Start();

                                p.WaitForExit();

                                f.WriteLine(p.StandardError.ReadToEnd());

                            }
                            catch (Exception a)
                            {
                                MessageBox.Show(a.Message);
                            }
                        }
                        Process.Start("notepad.exe", complete);
                    }
                    p.Close();
                }
            }
            else
            {
                MessageBox.Show("No selected computers.");
            }
        }

        private void ping_Click(object sender, EventArgs e)
        {
            PsExecute("psgetsid.exe", "cid");
        }

        private void SearchBx_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchBx.Text))
            {

            }
            else
            {
                comp = SearchBx.Text;

                DataSet dataSet = new DataSet();

                dataSet.ReadXml("MyDataset.xml");

                DataView dataView = dataSet.Tables[0].DefaultView;

                dataView.RowFilter = "Name LIKE '*" + comp + "*'";

                ResultTable.ItemsSource = dataView;
            }

        }

        private void browse_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            dialog.ShowDialog();


            applocF.Text = "\"" + dialog.FileName + "\"";
        }

        private void msiinst_Click(object sender, RoutedEventArgs e)
        {
            PsExecute("psexec.exe", applocF.Text);
        }

        private void Restart_Click_1(object sender, RoutedEventArgs e)
        {
            PsExecute("PsShutdown.exe", "-r -t 1");
        }

        private void shutdown_Click_1(object sender, RoutedEventArgs e)
        {
            PsExecute("PsShutdown.exe", "-s -t 1");
        }

        private void ssave_Click(object sender, RoutedEventArgs e)
        {
            if (applocF.Text == "")
            {
                MessageBox.Show("Please enter some script");
            }
            else
            {
                try
                {
                    Uri uri = new Uri(applocF.Text.Replace('"', ' ').Trim());
                    school = (uri.Host);
                }
                catch (Exception a)
                {
                    school = "General Use";
                }
                XDocument doc = XDocument.Load(@"Resources\scrsaves.xml");
                var count = doc.Descendants("ID").Count();
                XElement scrpits = new XElement("Scripts",
                    new XElement("ID", count + 1),
                    new XElement("School", school.Replace('/', ' ').Trim()),
                    new XElement("Script", applocF.Text));
                doc.Root.Add(scrpits);
                doc.Save(@"Resources\scrsaves.xml");
                MessageBox.Show("Script Saved");
            }

        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            script_picker formTask = new script_picker();
            formTask.ShowDialog();
            applocF.Text = formTask.stringresult;
        }
    }
}
