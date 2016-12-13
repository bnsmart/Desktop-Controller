using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.DirectoryServices;
using System.IO;


namespace Desktop_Controller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }     

        string apploc = "";
        string x = "";
        string comp = "";

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            dialog.ShowDialog();

                apploc = dialog.FileName;

                applocF.Text = apploc;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PsExecute("psexec.exe","inst");
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            PsExecute("PsShutdown.exe", "shut");
        }

        private void PsExecute(string type, string command)
        {
            if (ResultTable.SelectedRows.Count > 0)
            {

                if (apploc == "" && command == "inst")
                {
                    MessageBox.Show("Please Select a file");
                }
                else
                {
                    Process p = new Process();

                    string computers = "";

                    if (Uninstall.Checked)
                    {
                        x = "x";
                    }
                    else
                    {
                        x = "i";
                    };
                    var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                    var complete = Path.Combine(systemPath, "errorLog.txt");
                    //MessageBox.Show(complete);
                    using (var f = File.CreateText(complete))
                    {
                        foreach (DataGridViewRow com in ResultTable.SelectedRows)
                        {
                            computers = Convert.ToString(com.Cells["Name"].Value);
                            try
                            {
                                p.StartInfo.UseShellExecute = false;
                                //You can start any process, HelloWorld is a do -nothing example.
                                p.StartInfo.RedirectStandardOutput = true;
                                p.StartInfo.RedirectStandardError = true;
                                p.StartInfo.FileName = type;
                                //MessageBox.Show(@"\\" + computers + " -u Domain" + @"\user -p password msiexec.exe /" + x + @" """ + apploc + @""" /qn");
                                if (command == "shut")
                                {
                                    p.StartInfo.Arguments = @"\\" + computers + " -u Domain" + @"\user -p password -r -t 1 -n 3";
                                }
                                else if (command == "off")
                                {
                                    p.StartInfo.Arguments = @"\\" + computers + " -u Domain" + @"\user -p password -s -t 1 - n 3";
                                }
                                else if (command == "inst")
                                {
                                    p.StartInfo.Arguments = @"\\" + computers + " -u Domain" + @"\user -p password msiexec.exe /" + x + @" """ + apploc + @""" /quiet /qn /norestart";
                                }
                                else if (command == "cid")
                                {
                                    p.StartInfo.Arguments = @"\\" + computers + " -u Domain" + @"\user -p password -r -t 1 -n 3";
                                }

                                p.StartInfo.CreateNoWindow = false;
                                p.EnableRaisingEvents = true;
                                p.Start();
                                // This code assumes the process you are starting will terminate itself. 
                                // Given that is is started without a window so you cannot terminate it 
                                // on the desktop, it must terminate itself or you can do it programmatically
                                // from this application using the Kill method.


                                //string output = p.StandardOutput.ReadToEnd();
                                //p.WaitForExit();
                                //string errormessage = p.StandardError.ReadToEnd();
                                p.WaitForExit();

                                f.WriteLine(p.StandardError.ReadToEnd());

                                //MessageBox.Show(output);
                                //MessageBox.Show(errormessage);

                                //Console.WriteLine(errormessage.ToString());
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

        private void Shutdown_Click(object sender, EventArgs e)
        {
            PsExecute("PsShutdown.exe", "off");
        }

        private void SearchBx_TextChanged(object sender, EventArgs e)
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

                ResultTable.DataSource = dataView;
            }

        }

        private void ping_Click(object sender, EventArgs e)
        {
            PsExecute("psgetsid.exe", "cid");
        }

        private void applocF_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
