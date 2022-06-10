using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using Lab10Lib;
using Lab12;


namespace Lab16
{
    public partial class MainForm : Form
    {
        private BalancedTree<Receipt> _balancedTree;
        Random _random;

        BinaryFormatter binFormatter = new BinaryFormatter();

        DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(BalancedTree<Receipt>));

        XmlSerializer xmlFormatter = new XmlSerializer(typeof(BalancedTree<Receipt>));

        SaveFileDialog saveFileDialog = new SaveFileDialog();
        OpenFileDialog openFileDialog = new OpenFileDialog();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _balancedTree = new BalancedTree<Receipt>();
            _random = new Random();
        }

        private void ShowElements()
        {
            lb_Output.Items.Clear();

            foreach(var item in _balancedTree)
            {
                lb_Output.Items.Add(item.ToString());
            }
        }    

        private void b_Add_Click(object sender, EventArgs e)
        {
            if (tb_Payer.Text.Length == 0 || tb_Bank.Text.Length == 0 || tb_Price.Text.Length == 0)
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }

            if(!float.TryParse(tb_Price.Text, out float price))
            {
                MessageBox.Show("Поле Price нельзя определить как число");
                return;
            }

            _balancedTree.Add(new Receipt(tb_Payer.Text, tb_Bank.Text, price));

            ShowElements();
        }

        private void btnShowElements_Click(object sender, EventArgs e)
        {
            ShowElements();
        }

        private void b_Remove_Click(object sender, EventArgs e)
        {
            if (tb_Payer.Text.Length == 0 || tb_Bank.Text.Length == 0 || tb_Price.Text.Length == 0)
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
            if (!float.TryParse(tb_Price.Text, out float price))
            {
                MessageBox.Show("Поле Price нельзя определить как число");
                return;
            }

            Receipt r = new Receipt(tb_Payer.Text, tb_Bank.Text, price);
            if (!_balancedTree.Remove(r)) MessageBox.Show("Элемент не найден");

            ShowElements();
        }

        private void lb_Output_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lb_Output.SelectedItem == null) return;
                string[] elem = lb_Output.SelectedItem.ToString().Split(new char[] {' ', ','}, System.StringSplitOptions.RemoveEmptyEntries);

            tb_Payer.Text = elem[1];
            tb_Bank.Text = elem[2];
            tb_Price.Text = elem[3];
        }

        private void b_RandomAdd_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                _balancedTree.Add(new Receipt(_random.Next(1, 1000).ToString(), _random.Next(1, 1000).ToString(), _random.Next(1, 1000)));
            }
            ShowElements();
        }

        private void b_Update_Click(object sender, EventArgs e)
        {
            if (lb_Output.SelectedItem == null)
            {
                MessageBox.Show("Не выбран элемент для изменения");
                return;
            }

            if (tb_Payer.Text.Length == 0 || tb_Bank.Text.Length == 0 || tb_Price.Text.Length == 0)
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
            if (!float.TryParse(tb_Price.Text, out float price))
            {
                MessageBox.Show("Поле Price нельзя определить как число");
                return;
            }

            string[] elem = lb_Output.SelectedItem.ToString().Split(new char[] { ' ', ',' }, System.StringSplitOptions.RemoveEmptyEntries);

            _balancedTree.FindChangeItem(new Receipt(elem[1], elem[2], int.Parse(elem[3])), new Receipt(tb_Payer.Text, tb_Bank.Text, price));

            ShowElements();
        }

        private void btnSelectionClear_Click(object sender, EventArgs e)
        {
            lb_Output.ClearSelected();
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            _balancedTree.Clear();
            ShowElements();
        }

        private void b_bin_ser_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Binary file|*.bin";
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;

            using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate))
            {
                binFormatter.Serialize(fs, _balancedTree);
                fs.Close();
            }
        }

        private void b_bin_des_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Binary file|*.bin";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel) return;

            try
            {
                using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    _balancedTree = (BalancedTree<Receipt>)binFormatter.Deserialize(fs);
                    fs.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void b_xml_ser_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "XML|*.xml";
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;

            using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate))
            {
                xmlFormatter.Serialize(fs, _balancedTree);
            }
        }

        private void b_xml_des_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "XML|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel) return;

            try
            {
                using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    _balancedTree = (BalancedTree<Receipt>)xmlFormatter.Deserialize(fs);
                    fs.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void b_json_ser_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "JSON|*.json";
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;

            using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, _balancedTree);
            }
        }

        private void b_json_des_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "JSON|*.json";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel) return;

            try
            {
                using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    _balancedTree = (BalancedTree<Receipt>)jsonFormatter.ReadObject(fs);
                    fs.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSelectRec_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Payer name");
            dt.Columns.Add("Bank name");
            dt.Columns.Add("Price");
            try
            {
                using (var context = new DbDocEntities())
                {
                    foreach (var item in context.Receipt)
                    {
                        dt.Rows.Add(item.Id, item.PayerName, item.BankName, item.Price);
                    }
                }
                dgvReceipt.DataSource = dt;
                dgvReceipt.ClearSelection();
                if (dt.Rows.Count == 0) MessageBox.Show("Пустая таблица");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnInsertRec_Click(object sender, EventArgs e)
        {
            if (tbPayer.Text.Length == 0 || tbBank.Text.Length == 0 || tbPrice.Text.Length == 0)
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }

            if (!float.TryParse(tbPrice.Text, out float price))
            {
                MessageBox.Show("Поле Price нельзя определить как число");
                return;
            }

            try
            {
                using (var context = new DbDocEntities())
                {
                    context.Receipt.Add(new TReceipt() { PayerName = tbPayer.Text, BankName = tbBank.Text, Price = price }) ;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvReceipt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvReceipt.SelectedRows.Count == 0) return;

            tbPayer.Text = dgvReceipt.SelectedRows[0].Cells[1].Value.ToString();
            tbBank.Text = dgvReceipt.SelectedRows[0].Cells[2].Value.ToString();
            tbPrice.Text = dgvReceipt.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void btnUpdateRec_Click(object sender, EventArgs e)
        {
            if (dgvReceipt.SelectedRows.Count == 0) return;

            if (tbPayer.Text.Length == 0 || tbBank.Text.Length == 0 || tbPrice.Text.Length == 0)
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }

            if (!float.TryParse(tbPrice.Text, out float price))
            {
                MessageBox.Show("Поле Price нельзя определить как число");
                return;
            }
            var pk = int.Parse(dgvReceipt.SelectedRows[0].Cells[0].Value.ToString());
            try
            {
                using (var context = new DbDocEntities())
                {
                    var row = context.Receipt.Where(x => x.Id == pk).FirstOrDefault();
                    row.PayerName = tbPayer.Text;
                    row.BankName = tbBank.Text;
                    row.Price = price;
                    context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteRec_Click(object sender, EventArgs e)
        {
            if (dgvReceipt.SelectedRows.Count == 0) return;
            int pk = int.Parse(dgvReceipt.SelectedRows[0].Cells[0].Value.ToString());
            try
            {
                using (var context = new DbDocEntities())
                {
                    context.Receipt.Remove(context.Receipt.Where(x => x.Id == pk).FirstOrDefault());
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvGranter_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGranter.SelectedRows.Count == 0) return;

            tbGranter.Text = dgvGranter.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void btnGranterSel_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Granter name");
            try
            {
                using (var context = new DbDocEntities())
                {
                    foreach (var item in context.Granter)
                    {
                        dt.Rows.Add(item.Id, item.GranterName);
                    }
                }
                dgvGranter.DataSource = dt;
                dgvGranter.ClearSelection();
                if (dt.Rows.Count == 0) MessageBox.Show("Пустая таблица");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGranterIns_Click(object sender, EventArgs e)
        {
            if (tbGranter.Text.Length == 0)
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }

            try
            {
                using (var context = new DbDocEntities())
                {
                    context.Granter.Add(new TGranter() { GranterName = tbGranter.Text });
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGranterUpd_Click(object sender, EventArgs e)
        {
            if (dgvGranter.SelectedRows.Count == 0) return;

            if (tbGranter.Text.Length == 0)
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }

            var pk = int.Parse(dgvGranter.SelectedRows[0].Cells[0].Value.ToString());
            try
            {
                using (var context = new DbDocEntities())
                {
                    var row = context.Granter.Where(x => x.Id == pk).FirstOrDefault();
                    row.GranterName = tbGranter.Text;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGranterDelete_Click(object sender, EventArgs e)
        {
            if (dgvGranter.SelectedRows.Count == 0) return;
            int pk = int.Parse(dgvGranter.SelectedRows[0].Cells[0].Value.ToString());
            try
            {
                using (var context = new DbDocEntities())
                {
                    context.Granter.Remove(context.Granter.Where(x => x.Id == pk).FirstOrDefault());
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGRSel_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Granter name");
            dt.Columns.Add("Payer name");
            dt.Columns.Add("Bank name");
            dt.Columns.Add("Price");

            try
            {
                using (var context = new DbDocEntities())
                {
                    var query = from G in context.Granter
                                join GR in context.GranterReceipt on G.Id equals GR.Id
                                join R in context.Receipt on GR.Receipt_id equals R.Id
                                select new { id = GR.Id, GName = G.GranterName, PName = R.PayerName, BName = R.BankName, Price = R.Price };
                    
                    foreach (var item in query)
                    {
                        dt.Rows.Add(item.id, item.GName ,item.PName, item.BName, item.Price);
                    }
                }
                dgvGR.DataSource = dt;
                dgvGR.ClearSelection();
                if (dt.Rows.Count == 0) MessageBox.Show("Пустая таблица");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbReceipt_DropDown(object sender, EventArgs e)
        {
            cbReceipt.Items.Clear();

            try
            {
                using (var context = new DbDocEntities())
                {
                    foreach (var item in context.Receipt)
                    {
                        cbReceipt.Items.Add($"{item.Id} {item.PayerName} {item.BankName} {item.Price}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbGranter_DropDown(object sender, EventArgs e)
        {
            cbGranter.Items.Clear();

            try
            {
                using (var context = new DbDocEntities())
                {
                    foreach (var item in context.Granter)
                    {
                        cbGranter.Items.Add($"{item.Id} {item.GranterName}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGrIns_Click(object sender, EventArgs e)
        {
            if (cbGranter.Text.Length == 0 || cbReceipt.Text.Length == 0)
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }

            var rPK = cbReceipt.Text.Split(' ')[0];
            var gPK = cbGranter.Text.Split(' ')[0];

            

            try
            {
                using (var context = new DbDocEntities())
                {
                    context.GranterReceipt.Add(new TGranterReceipt() { Receipt_id = int.Parse(rPK), Granter_id = int.Parse(gPK) });
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPayerQRes_Click(object sender, EventArgs e)
        {
            if (tbPayerQ.Text.Length == 0) return;

            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Payer name");
            dt.Columns.Add("Bank name");
            dt.Columns.Add("Price");
            try
            {
                using (var context = new DbDocEntities())
                {
                    var res = from el in context.Receipt where el.PayerName == tbPayerQ.Text select el;
                    foreach (var item in res)
                    {
                        dt.Rows.Add(item.Id, item.PayerName, item.BankName, item.Price);
                    }
                }
                dgvFind.DataSource = dt;
                dgvFind.ClearSelection();
                if (dt.Rows.Count == 0) MessageBox.Show("Пустая таблица");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAggrRes_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Sum");

            try
            {
                using (var context = new DbDocEntities())
                {
                    var res = context.Receipt.Sum(el => el.Price);

                    dt.Rows.Add(res);

                }
                dgvAggr.DataSource = dt;
                dgvAggr.ClearSelection();
                if (dt.Rows.Count == 0) MessageBox.Show("Пустая таблица");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPSort_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Payer name");
            dt.Columns.Add("Bank name");
            dt.Columns.Add("Price");
            try
            {
                using (var context = new DbDocEntities())
                {
                    var res = context.Receipt.OrderBy(el => el.PayerName);
                    foreach (var item in res)
                    {
                        dt.Rows.Add(item.Id, item.PayerName, item.BankName, item.Price);
                    }
                }
                dgvSort.DataSource = dt;
                dgvSort.ClearSelection();
                if (dt.Rows.Count == 0) MessageBox.Show("Пустая таблица");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBSort_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Payer name");
            dt.Columns.Add("Bank name");
            dt.Columns.Add("Price");
            try
            {
                using (var context = new DbDocEntities())
                {
                    var res = context.Receipt.OrderBy(el => el.BankName);
                    foreach (var item in res)
                    {
                        dt.Rows.Add(item.Id, item.PayerName, item.BankName, item.Price);
                    }
                }
                dgvSort.DataSource = dt;
                dgvSort.ClearSelection();
                if (dt.Rows.Count == 0) MessageBox.Show("Пустая таблица");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrSort_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Payer name");
            dt.Columns.Add("Bank name");
            dt.Columns.Add("Price");
            try
            {
                using (var context = new DbDocEntities())
                {
                    var res = context.Receipt.OrderBy(el => el.Price);
                    foreach (var item in res)
                    {
                        dt.Rows.Add(item.Id, item.PayerName, item.BankName, item.Price);
                    }
                }
                dgvSort.DataSource = dt;
                dgvSort.ClearSelection();

                if (dt.Rows.Count == 0) MessageBox.Show("Пустая таблица");
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }
        }
    }
}
