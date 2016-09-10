using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure.Interception;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PriceCompare.Entities;
using PriceCompare.Logic;
using PriceCompareDataAccess.Entities;


namespace PriceCompare.View
{
    public partial class Main : Form
    {
        private readonly IManager _manager ;
        private Task _itemDataGridLoadTask;
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();
        private readonly User _user;

        public Main(IManager manager, User user)
        {

            InitializeComponent();
            _manager = manager;
            _user = user;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblUserName.Text = $"Hello, {_user.UserId}!";

            _itemDataGridLoadTask = Task.Run(() => ItemDataGridLoaded(), _cts.Token);

            dataGridItems.DataError += new DataGridViewDataErrorEventHandler(dataGridItems_DataError);

        }

        private void Reset()
        {
            _manager.ResetShoppingCart();
            dataGridItems.DataSource = null;

        }
        private void dataGridItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Enter only positive numbers in Amount column!");
        }

        private  void ItemDataGridLoaded()
        {
            
            BeginInvoke((Action) ( () =>
            {
                List<Item> res =  _manager.GetAllItems();

                Parallel.ForEach(res, item => item.Amount = 0);

                dataGridItems.DataSource = res;

                DataGridViewVisible(dataGridItems);


                //dataGridItems.Columns[dataGridItems.ColumnCount - 1].Visible = false;
                var dataGridViewColumn = dataGridItems.Columns["Amount"];
                if (dataGridViewColumn != null) dataGridViewColumn.ReadOnly = false;

                btnAddToCart.Enabled = true;
            }));
            

        }

        private void DataGridViewVisible(DataGridView dataGridView)
        {
            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                dataGridView.Columns[i].Visible = true;
                dataGridView.Columns[i].ReadOnly = true;
               

                if (i >= 0 && i <= 3)
                {
                    dataGridView.Columns[i].Visible = false;

                }
                dataGridView.Columns[dataGridView.ColumnCount - 1].Visible = false;

            }
        }
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
                
            if (!ValidateAmountEntered())
            {
                MessageBox.Show("Enter only positive numbers in Amount column!");

                return;
            }

          
            List<Item> allItems  =  (List<Item>)dataGridItems.DataSource;

           
            if (!_manager.SetShoppingCart(allItems))
            {
                MessageBox.Show("No items selected!");
            }
            else
            {
                MessageBox.Show("Added To Cart!");
            }
        }

   
        private bool ValidateAmountEntered()
        {

            bool res = false;
            int number = 0;

            for (int i = 0; i < dataGridItems.RowCount; i++)
            {
                res = int.TryParse(dataGridItems["Amount", i].Value.ToString(), out number);


                if (!res || number < 0 )
                {
                    return false;
                }
            }


            return true;
        }

        private void btnItems_Click(object sender, EventArgs e)
        {
            PanelVisible("panelItems");

           
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            PanelVisible("panelCompare");

            BeginInvoke((Action)(() =>
            {
               // await Task.WhenAll(new Task[] { _initializeDataTask, _itemDataGridLoadTask });
                listBoxChainCompare.Items.Clear();
                listBoxMostExpensiveItems.Items.Clear();
                listBoxCheapesetItems.Items.Clear();
                

                if (_manager.IsShoppingCartEmpty())
                {
                    return;
                }
                //List<Tuple<string, string, double>> comparedList = _manager.CompareShoppingCartByChains();
                Dictionary<string, List<Tuple<string, double>>> compareResult = _manager.CompareShoppingCartByStores();
                Dictionary<string, List<Tuple<string, double>>> mostThreeExpensiveItems = _manager.GetMostThreeExpensiveItems();
                Dictionary<string, List<Tuple<string, double>>> cheapestThreeItems = _manager.GetCheapestThreeItems();


                foreach (var chain in compareResult)
                {

                    listBoxChainCompare.Items.Add(chain.Key);
                    foreach (var store in chain.Value)
                    {
                        listBoxChainCompare.Items.Add($"Store: {store.Item1} ,Total: {store.Item2} ");
                    }
                    listBoxChainCompare.Items.Add("");
                    listBoxChainCompare.Items.Add("");
                }

                //foreach (var chain in comparedList)
                //{

                //    listBoxChainCompare.Items.Add($"{chain.Item1} :");
                //    listBoxChainCompare.Items.Add($"{chain.Item2} ");
                //    listBoxChainCompare.Items.Add($"{chain.Item3} ");

                //    listBoxChainCompare.Items.Add($" ");
                //    listBoxChainCompare.Items.Add($" ");
                //}

                PrintToListBox(mostThreeExpensiveItems, listBoxMostExpensiveItems);
                PrintToListBox(cheapestThreeItems,listBoxCheapesetItems);
            }));

        }

        private void PrintToListBox(Dictionary<string, List<Tuple<string, double>>> cheapestThreeItems, ListBox listbox)
        {
            foreach (var chain in cheapestThreeItems)
            {
                listbox.Items.Add(chain.Key);
                foreach (var item in chain.Value)
                {
                    listbox.Items.Add($"Item: {item.Item1} ,Price: {item.Item2} ");
                }
                listbox.Items.Add("");
                listbox.Items.Add("");
            }
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            PanelVisible("panelShoppingCart");
            btnSaveCartToFile.Enabled = false;
            BeginInvoke((Action) (() =>
            {
                if (_manager.IsShoppingCartEmpty())
                {
                    return;
                }

                btnSaveCartToFile.Enabled = true;
                dataGridViewCart.DataSource = _manager?.GetShoppingCartItems();
                DataGridViewVisible(dataGridViewCart);

            }));

        }

        private void btnSaveCartToFile_Click(object sender, EventArgs e)
        {
             _manager.SaveShoppingCartToFile();
        }

        private void btnLoadCartFromFile_Click(object sender, EventArgs e)
        {

            if (! _manager.LoadShoppingCartFromFile())
            {
                return;
            }
            dataGridViewCart.DataSource = _manager.GetShoppingCartItems();
            DataGridViewVisible(dataGridViewCart);

        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Task.Run(() => _manager.Logout(_user));
            if ( !_itemDataGridLoadTask.IsCompleted)
            {
                _cts.Cancel();
            }
            Reset();


        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Task.Run(() => _manager.Logout(_user));
            Reset();
            this.Close();
        }

        private void PanelVisible(string panelName)
        {
            foreach (var panel in this.Controls.OfType<Panel>()
                .Where(p => (p.Name != "panelHeader"
                && p.Name != "panelSide"
                && p.Name != "panelLogo")))
            {
                panel.Visible = panel.Name == panelName;
                panel.Dock = DockStyle.Fill;
            }
        }

        private void btnExcelChart_Click(object sender, EventArgs e)
        {
           // PanelVisible("panelExcelChart");
           // pictureBoxChart.Image?.Dispose();
            BeginInvoke((Action) (async () =>
            {
                bool result = await Task.Run(()=>_manager.CreateExcelChartOfChainsCart());
                if (result)
                {
                    MessageBox.Show("Excel file created!");
                }
                else if (_manager.IsShoppingCartEmpty())
                {
                    MessageBox.Show("Cart is empty!");
                }
                else
                {
                    MessageBox.Show("Exception Occured while releasing object");

                }
            }));

        }

        private void btnResetSelectedItem_Click(object sender, EventArgs e)
        {
            BeginInvoke((Action) (() =>
            {
                for (int i = 0; i < dataGridItems.RowCount; i++)
                {
                    dataGridItems.Rows[i].Cells["Amount"].Value = 0;
                }
            }));
        }
    }
}
