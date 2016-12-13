using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.DirectoryServices;
using System.Data;

namespace DataSync
{
    class Program
    {
            
       


        static void Main(string[] args)
        {
            Console.WriteLine("do you want to sync now? Y/N");
            string a = Console.ReadLine().ToLower();

            if (a == "y")
            {
                        System.IO.File.WriteAllText("MyDataset.xml", string.Empty);

                        DirectoryEntry entry = new DirectoryEntry("LDAP://OU=Some OU,DC=Something,DC=local");
                        DirectorySearcher search = new DirectorySearcher(entry);
                        string query = "(&(objectCategory=computer)(name=*))";           //primaryGroupID=515 is domain computers group
                        search.Filter = query;
                        search.PropertiesToLoad.Add("name");
                        search.PageSize = 5000;
                        SearchResultCollection mySearchResultColl = search.FindAll();

                        search.Dispose();
                        
                        DataTable Results = new DataTable();
                        Results.Columns.Add("Name");

                        foreach (SearchResult sr in mySearchResultColl)
                        {
                            DataRow dr = Results.NewRow();
                            DirectoryEntry de = sr.GetDirectoryEntry();
                            dr["Name"] = de.Properties["name"].Value;
                            Results.Rows.Add(dr);
                            de.Close();
                        }
                        DataSet dataSet = new DataSet();

                        dataSet.Tables.Add(Results);

                        dataSet.WriteXml("MyDataset.xml");

                Console.WriteLine("Your data has been synced.");
                Console.ReadLine();
                
            }
        }
    }
}
