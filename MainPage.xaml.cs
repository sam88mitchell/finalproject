using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace stock_databasegui
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string WriteStockDataQuery = "SET IDENTITY_INSERT stock_data ON INSERT INTO stock_data (stockid, stock_type, stock_amount, stock_pricing) VALUES ('', '', '" + stockData.Text + "', '')";

            try
            {
                using (SqlConnection conn = new SqlConnection((App.Current as App).Connectionstring))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {

                            cmd.CommandText = WriteStockDataQuery;
                            cmd.ExecuteNonQuery();
                            Debug.WriteLine("completed");
                        }
                    }
                }
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exceptioon: " + eSql.Message);
            }
        }
    }
}
