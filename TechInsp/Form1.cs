using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using Npgsql;

namespace TechInsp
{
    public partial class Form1 : Form
    {
        NpgsqlConnection conAdmin;
        NpgsqlConnection conInspector;
        NpgsqlConnection conUser;
        NpgsqlConnection conCur;

        NpgsqlCommand cmd;
        DataTable dtOwner;
        DataTable dtVehicle;
        DataTable dtOwVeh;
        DataTable dtInspection;
        DataTable dtSchedule;

        string conStrAdmin = $"Server=localhost;Port=5432;" +
                             $"User Id=Admin;Password=Admin;Database=Technical inspection";

        string conStrInsp = $"Server=localhost;Port=5432;" +
                             $"User Id=Inspector;Password=inspector;Database=Technical inspection";

        string conStrUser = $"Server=localhost;Port=5432;" +
                             $"User Id=User;Password=User;Database=Technical inspection";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conAdmin = new NpgsqlConnection(conStrAdmin);
            conInspector = new NpgsqlConnection(conStrInsp);
            conUser = new NpgsqlConnection(conStrUser);

            conCur = conAdmin;
            cmd = new NpgsqlCommand(null, conCur);
            dtOwner = new DataTable();
            dtVehicle = new DataTable();
            dtOwVeh = new DataTable();
            dtInspection = new DataTable();
            dtSchedule = new DataTable();   

            
            rbAdmin.Checked = true;
            
        }

        private void FillComboBox(ComboBox cb, string query)
        {
            try
            {
                cmd.CommandText = query;
                cmd.Connection = conCur;
                conCur.Open();

                cb.Items.Clear();

                var res = cmd.ExecuteReader();
                StringBuilder val = new StringBuilder();

                while (res.Read())
                {
                    for (int i = 0; i < res.FieldCount; i++) val.Append(res.GetValue(i).ToString() + " ");
                    cb.Items.Add(val);
                    val.Clear();
                }
                conCur.Close();
            }
            catch (Exception ex)
            {
                conCur.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void rbUser_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUser.Checked) conCur = conUser;
        }

        private void rbAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAdmin.Checked) conCur = conAdmin;
        }

        private void rbInspector_CheckedChanged(object sender, EventArgs e)
        {
            if (rbInspector.Checked) conCur = conInspector;
        }

        private void LoadGrid(DataGridView dgv, string tableName, DataTable dt, string collumns = "*")
        {
            try
            {
                dt.Clear();
                dt.Columns.Clear();
              
                cmd.Connection = conCur;
                conCur.Open();

                cmd.CommandText = $"SELECT {collumns} FROM {tableName};";
                dt.Load(cmd.ExecuteReader());
                dgv.DataSource = dt;

                conCur.Close();
            }
            catch (Exception ex)
            {
                conCur.Close();
                MessageBox.Show(ex.Message);
            }

        }
        private void btnOwnerLoadGrid_Click(object sender, EventArgs e)
        {
            LoadGrid(dgvOwner, "vowner", dtOwner);
            dgvOwner.ClearSelection();
        }

        private void btnOwnIns_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Connection = conCur;
                conCur.Open();

                StringBuilder query = new StringBuilder("INSERT INTO vowner (first_name, last_name, patronymic, passport_number, driver_license) values (");
                query.Append($"'{txbOwnFName.Text}',");
                query.Append($"'{txbOwnLName.Text}',");
                query.Append($"'{txbOwnPatr.Text}',");
                query.Append(txbOwnPass.Text.Length > 0 ? $"'{txbOwnPass.Text}', " : "null, ");
                query.Append(txbOwnLic.Text.Length > 0 ? $"'{txbOwnLic.Text}'" : "null");
                query.Append(");");

                cmd.CommandText = query.ToString();
                cmd.ExecuteNonQuery();

                conCur.Close();

                MessageBox.Show("Элемент успешно добавлен");

                LoadGrid(dgvOwner, "vowner", dtOwner);
                dgvOwner.ClearSelection();
            }
            catch (Exception ex)
            {
                conCur.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOwnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOwner.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Ошибка, не выбрана строка для обновления");
                    return;
                }

                cmd.Connection = conCur;
                conCur.Open();

                string pk = dgvOwner.SelectedRows[0].Cells[0].FormattedValue.ToString();

                StringBuilder query = new StringBuilder("UPDATE vowner SET ");
                query.Append($"first_name = '{txbOwnFName.Text}', ");
                query.Append($"last_name = '{txbOwnLName.Text}', ");
                query.Append($"patronymic = '{txbOwnPatr.Text}', ");
                query.Append($"passport_number = '{txbOwnPass.Text}', ");
                query.Append($"driver_license = '{txbOwnLic.Text}' ");
                query.Append($"WHERE owner_id = {pk}");

                cmd.CommandText = query.ToString();
                MessageBox.Show("Успешно изменён " + cmd.ExecuteNonQuery().ToString() + " элемент");

                conCur.Close();

                LoadGrid(dgvOwner, "vowner", dtOwner);
                dgvOwner.ClearSelection();
            }
            catch (Exception ex)
            {
                conCur.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvOwner_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOwner.SelectedRows.Count == 0) return;

            txbOwnFName.Text = dgvOwner.SelectedRows[0].Cells[2].FormattedValue.ToString();
            txbOwnLName.Text = dgvOwner.SelectedRows[0].Cells[3].FormattedValue.ToString();
            txbOwnPatr.Text = dgvOwner.SelectedRows[0].Cells[4].FormattedValue.ToString();
            txbOwnPass.Text = dgvOwner.SelectedRows[0].Cells[1].FormattedValue.ToString();
            txbOwnLic.Text = dgvOwner.SelectedRows[0].Cells[5].FormattedValue.ToString();
        }

        private void btnOwnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOwner.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Ошибка, не выбрана строка для удаления");
                    return;
                }

                cmd.Connection = conCur;
                conCur.Open();

                string pk = dgvOwner.SelectedRows[0].Cells[0].FormattedValue.ToString();

                cmd.CommandText = $"DELETE FROM vowner WHERE owner_id = {pk};";
                MessageBox.Show("Успешно удалён " + cmd.ExecuteNonQuery().ToString() + " элемент");

                conCur.Close();

                LoadGrid(dgvOwner, "vowner", dtOwner);
                dgvOwner.ClearSelection();
            }
            catch (Exception ex)
            {
                conCur.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnVehLoadGrid_Click(object sender, EventArgs e)
        {
            LoadGrid(dgvVeh, "vehicle", dtVehicle);
            dgvVeh.ClearSelection();
        }

        private void dgvVeh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVeh.SelectedRows.Count == 0) return;

            txbVin.Text = dgvVeh.SelectedRows[0].Cells[0].FormattedValue.ToString();
            txbBrand.Text = dgvVeh.SelectedRows[0].Cells[1].FormattedValue.ToString();
            txbModel.Text = dgvVeh.SelectedRows[0].Cells[2].FormattedValue.ToString();
            txbYear.Text = dgvVeh.SelectedRows[0].Cells[3].FormattedValue.ToString();
            txbPower.Text = dgvVeh.SelectedRows[0].Cells[4].FormattedValue.ToString();
            cbCateg.Text = dgvVeh.SelectedRows[0].Cells[5].FormattedValue.ToString();
            txbReg.Text = dgvVeh.SelectedRows[0].Cells[6].FormattedValue.ToString();
            txbFrame.Text = dgvVeh.SelectedRows[0].Cells[7].FormattedValue.ToString();
            txbBody.Text = dgvVeh.SelectedRows[0].Cells[8].FormattedValue.ToString();
        }

        private void cbCateg_DropDown(object sender, EventArgs e)
        {  
            FillComboBox(cbCateg, "select * from veh_category;");
        }

        private void btnVehIns_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Connection = conCur;
                conCur.Open();

                StringBuilder query = new StringBuilder("INSERT INTO vehicle values (");
                query.Append(txbVin.Text.Length > 0 ? $"'{txbVin.Text}', " : "null, ");
                query.Append(txbBrand.Text.Length > 0 ? $"'{txbBrand.Text}', " : "null, ");
                query.Append(txbModel.Text.Length > 0 ? $"'{txbModel.Text}', " : "null, ");
                query.Append(txbYear.Text.Length > 0 ? $"{txbYear.Text}, " : "null, ");
                query.Append(txbPower.Text.Length > 0 ? $"{txbPower.Text}, " : "null, ");
                query.Append(cbCateg.Text.Length > 0 ? $"'{cbCateg.Text}', " : "null, ");
                query.Append(txbReg.Text.Length > 0 ? $"'{txbReg.Text}', " : "null, ");
                query.Append(txbFrame.Text.Length > 0 ? $"'{txbFrame.Text}', " : "null, ");
                query.Append(txbBody.Text.Length > 0 ? $"'{txbBody.Text}' " : "null ");
                query.Append(");");

                cmd.CommandText = query.ToString();
                cmd.ExecuteNonQuery();

                conCur.Close();

                MessageBox.Show("Элемент успешно добавлен");
                LoadGrid(dgvVeh, "vehicle", dtVehicle);
                dgvVeh.ClearSelection();
            }
            catch (Exception ex)
            {
                conCur.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnVehUpd_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVeh.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Ошибка, не выбрана строка для обновления");
                    return;
                }

                cmd.Connection = conCur;
                conCur.Open();

                string pk = dgvVeh.SelectedRows[0].Cells[0].FormattedValue.ToString();

                StringBuilder query = new StringBuilder("UPDATE vehicle SET ");
                query.Append($"vin_num = " + (txbVin.Text.Length > 0 ? $"'{txbVin.Text}', " : "null, "));
                query.Append($"brand = " + (txbBrand.Text.Length > 0 ? $"'{txbBrand.Text}', " : "null, "));
                query.Append($"model = " + (txbModel.Text.Length > 0 ? $"'{txbModel.Text}', " : "null, "));
                query.Append($"year_man = " + (txbYear.Text.Length > 0 ? $"{txbYear.Text}, " : "null, "));
                query.Append($"power_eng = " + (txbPower.Text.Length > 0 ? $"{txbPower.Text}, " : "null, "));
                query.Append($"veh_category = " + (cbCateg.Text.Length > 0 ? $"'{cbCateg.Text}', " : "null, "));
                query.Append($"register_plate = " + (txbReg.Text.Length > 0 ? $"'{txbReg.Text}', " : "null, "));
                query.Append($"frame_number = " + (txbFrame.Text.Length > 0 ? $"'{txbFrame.Text}', " : "null, "));
                query.Append($"body_number = " + (txbBody.Text.Length > 0 ? $"'{txbBody.Text}' " : "null "));

                query.Append($"WHERE vin_num = '{pk}'");

                cmd.CommandText = query.ToString();
                MessageBox.Show("Успешно изменён " + cmd.ExecuteNonQuery().ToString() + " элемент");

                conCur.Close();

                LoadGrid(dgvVeh, "vehicle", dtVehicle);
                dgvVeh.ClearSelection();
            }
            catch (Exception ex)
            {
                conCur.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnVehDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVeh.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Ошибка, не выбрана строка для удаления");
                    return;
                }

                cmd.Connection = conCur;
                conCur.Open();

                string pk = dgvVeh.SelectedRows[0].Cells[0].FormattedValue.ToString();

                cmd.CommandText = $"DELETE FROM vehicle WHERE vin_num = '{pk}';";
                MessageBox.Show("Успешно удалён " + cmd.ExecuteNonQuery().ToString() + " элемент");

                conCur.Close();

                LoadGrid(dgvVeh, "vehicle", dtVehicle);
                dgvVeh.ClearSelection();
            }
            catch (Exception ex)
            {
                conCur.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOwVehLoadGrid_Click(object sender, EventArgs e)
        {
            LoadGrid(dgvOwVeh, "owner_veh", dtOwVeh);
            dgvOwner.ClearSelection();
        }

        private void cbOwner_DropDown(object sender, EventArgs e)
        {
            FillComboBox(cbOwner, "Select passport_number, last_name, first_name from vowner;");
        }

        private void cbVehicle_DropDown(object sender, EventArgs e)
        {
            FillComboBox(cbVehicle, "Select vin_num, brand, model from vehicle;");
        }

        private void btnOwVehAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if(cbOwner.Text.Length == 0 || cbVehicle.Text.Length == 0) return;

                cmd.Connection = conCur;
                conCur.Open();

                cmd.CommandText = $"select owner_id from vowner where passport_number = '{cbOwner.Text.Split(' ')[0]}';";
                var res = cmd.ExecuteReader();
                if (!res.Read())
                {
                    MessageBox.Show("Номер паспорта не найден");
                    conCur.Close();
                    return;
                }
                string ownerPK = res.GetValue(0).ToString();
                res.Close();

                cmd.CommandText = $"select vin_num from vehicle where vin_num = '{cbVehicle.Text.Split(' ')[0]}';";
                res = cmd.ExecuteReader();
                if (!res.Read())
                {
                    MessageBox.Show("Вин номер не найден");
                    conCur.Close();
                    return;
                }
                string vehiclePK = res.GetValue(0).ToString();
                res.Close();

                StringBuilder query = new StringBuilder("INSERT INTO owner_veh (owner_id, vin_num) values (");
                query.Append(ownerPK.Length > 0 ? $"{ownerPK}, " : "null, ");
                query.Append(vehiclePK.Length > 0 ? $"'{vehiclePK}' " : "null ");

                query.Append(");");

                cmd.CommandText = query.ToString();
                cmd.ExecuteNonQuery();

                conCur.Close();

                MessageBox.Show("Элемент успешно добавлен");
                LoadGrid(dgvOwVeh, "owner_veh", dtOwVeh);
                dgvOwVeh.ClearSelection();
            }
            catch (Exception ex)
            {
                conCur.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void cbOwHist_DropDown(object sender, EventArgs e)
        {
            FillComboBox(cbOwHist, "Select passport_number, last_name, first_name from vowner;");
        }

        private void btnOwHistRes_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbOwHist.Text.Length == 0) return;
                conCur.Open();
                dtOwVeh.Clear();
                dtOwVeh.Columns.Clear();

                cmd.Connection = conCur;
                cmd.CommandText = $"select owner_id from vowner where passport_number = '{cbOwHist.Text.Split(' ')[0]}';";
                var res = cmd.ExecuteReader();
                if (!res.Read())
                {
                    MessageBox.Show("Номер паспорта не найден");
                    conCur.Close();
                    return;
                }
                string ownerPK = res.GetValue(0).ToString();
                res.Close();

                cmd.CommandText = "select passport_number, last_name, first_name, v.vin_num, brand, model, year_man, power_eng, veh_category, register_plate " +
                                   "from vowner as o join owner_veh as ov on (o.owner_id = ov.owner_id) join vehicle as v on (ov.vin_num = v.vin_num) " + 
                                   $"where o.owner_id = {ownerPK} order by ov.owner_veh_id asc;";

                dtOwVeh.Load(cmd.ExecuteReader());
                dgvOwVeh.DataSource = dtOwVeh;
                dgvOwVeh.ClearSelection();

                conCur.Close();
            }
            catch (Exception ex)
            {
                conCur.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void cbVehHist_DropDown(object sender, EventArgs e)
        {
            FillComboBox(cbVehHist, "Select vin_num, brand, model from vehicle;");
        }

        private void btnVehHistRes_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbVehHist.Text.Length == 0) return;
                conCur.Open();
                dtOwVeh.Clear();
                dtOwVeh.Columns.Clear();

                cmd.Connection = conCur;
                cmd.CommandText = $"select vin_num from vehicle where vin_num = '{cbVehHist.Text.Split(' ')[0]}';";
                var res = cmd.ExecuteReader();
                if (!res.Read())
                {
                    MessageBox.Show("Номер паспорта не найден");
                    conCur.Close();
                    return;
                }
                string vehiclePK = res.GetValue(0).ToString();
                res.Close();

                cmd.CommandText = "select v.vin_num, brand, model, passport_number, last_name, first_name, patronymic, driver_license " +
                                   "from vowner as o join owner_veh as ov on (o.owner_id = ov.owner_id) join vehicle as v on (ov.vin_num = v.vin_num) " +
                                   $"where v.vin_num = '{vehiclePK}' order by ov.owner_veh_id asc;";

                dtOwVeh.Load(cmd.ExecuteReader());
                dgvOwVeh.DataSource = dtOwVeh;
                dgvOwVeh.ClearSelection();

                conCur.Close();
            }
            catch (Exception ex)
            {
                conCur.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbOwVehCur_DropDown(object sender, EventArgs e)
        {
            FillComboBox(cmbOwVehCur, "Select passport_number, last_name, first_name from vowner;");
        }

        private void btnOwVehCurRes_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbOwVehCur.Text.Length == 0) return;
                conCur.Open();
                dtOwVeh.Clear();
                dtOwVeh.Columns.Clear();

                cmd.Connection = conCur;
                cmd.CommandText = $"select owner_id from vowner where passport_number = '{cmbOwVehCur.Text.Split(' ')[0]}';";
                var res = cmd.ExecuteReader();
                if (!res.Read())
                {
                    MessageBox.Show("Номер паспорта не найден");
                    conCur.Close();
                    return;
                }
                string ownerPK = res.GetValue(0).ToString();
                res.Close();

                cmd.CommandText = "SELECT passport_number, last_name, first_name, v.vin_num, brand, model, year_man, power_eng, veh_category, register_plate " +
                                   "FROM vowner AS o JOIN owner_veh AS ov ON (o.owner_id = ov.owner_id) JOIN vehicle AS v ON (ov.vin_num = v.vin_num) " +
                                   $"WHERE o.owner_id = {ownerPK} AND ov.owner_veh_id = " +
                                   "(SELECT MAX(owner_veh_id) FROM owner_veh WHERE vin_num = v.vin_num)" +
                                   "ORDER BY ov.owner_veh_id ASC;";

                dtOwVeh.Load(cmd.ExecuteReader());
                dgvOwVeh.DataSource = dtOwVeh;
                dgvOwVeh.ClearSelection();

                conCur.Close();
            }
            catch (Exception ex)
            {
                conCur.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void cbVehOwCur_DropDown(object sender, EventArgs e)
        {
            FillComboBox(cbVehOwCur, "Select vin_num, brand, model from vehicle;");
        }

        private void btnVehOwCurRes_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbVehOwCur.Text.Length == 0) return;
                conCur.Open();
                dtOwVeh.Clear();
                dtOwVeh.Columns.Clear();

                cmd.Connection = conCur;
                cmd.CommandText = $"select vin_num from vehicle where vin_num = '{cbVehOwCur.Text.Split(' ')[0]}';";
                var res = cmd.ExecuteReader();
                if (!res.Read())
                {
                    MessageBox.Show("Номер паспорта не найден");
                    conCur.Close();
                    return;
                }
                string vehiclePK = res.GetValue(0).ToString();
                res.Close();

                cmd.CommandText = "SELECT v.vin_num, brand, model, passport_number, last_name, first_name, patronymic, driver_license " +
                                   "FROM vowner AS o JOIN owner_veh AS ov ON (o.owner_id = ov.owner_id) JOIN vehicle AS v ON (ov.vin_num = v.vin_num) " +
                                   $"WHERE v.vin_num = '{vehiclePK}' AND ov.owner_veh_id = " +
                                   "(SELECT MAX(owner_veh_id) FROM owner_veh WHERE vin_num = v.vin_num)" +
                                   "ORDER BY ov.owner_veh_id ASC;";

                dtOwVeh.Load(cmd.ExecuteReader());
                dgvOwVeh.DataSource = dtOwVeh;
                dgvOwVeh.ClearSelection();

                conCur.Close();
            }
            catch (Exception ex)
            {
                conCur.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnInspLoadGrid_Click(object sender, EventArgs e)
        {
            LoadGrid(dgvInspection, "inspection i join technical_condition t on (i.tech_cond_id = t.tech_cond_id)", dtInspection,
                "inspection_id, vin_num, date::timestamp, brake_system, steering, external_lights, wiper, tires_wheels, engine, other_elements");
            dgvInspection.ClearSelection();
        }

        private void cmbVehInsp_DropDown(object sender, EventArgs e)
        {
            FillComboBox(cmbVehInsp, "Select vin_num, brand, model from vehicle;");
        }

        private void btnInspAdd_Click(object sender, EventArgs e)
        {
            if (cmbVehInsp.Text.Length == 0) return;
            try
            {
                cmd.Connection = conCur;
                conCur.Open();

                cmd.CommandText = $"select vin_num from vehicle where vin_num = '{cmbVehInsp.Text.Split(' ')[0]}';";
                var res = cmd.ExecuteReader();
                if (!res.Read())
                {
                    MessageBox.Show("Вин номер не найден");
                    conCur.Close();
                    return;
                }
                string vehiclePK = res.GetValue(0).ToString();
                res.Close();

                StringBuilder query = new StringBuilder("Begin; INSERT INTO technical_condition (brake_system, steering, external_lights, wiper, tires_wheels, engine, other_elements) values (");
                query.Append($"{cbBrake.Checked}, ");
                query.Append($"{cbSteer.Checked}, ");
                query.Append($"{cbLight.Checked}, ");
                query.Append($"{cbWiper.Checked}, ");
                query.Append($"{cbTires.Checked}, ");
                query.Append($"{cbEngine.Checked}, ");
                query.Append($"{cbOther.Checked} ");
                query.Append(");");

                cmd.CommandText = query.ToString();
                cmd.ExecuteNonQuery();

                query.Clear();

                query.Append("insert into inspection (vin_num, tech_cond_id, date) values (");
                query.Append($"'{vehiclePK}', ");
                query.Append("(select max(tech_cond_id) from technical_condition),");
                query.Append("localtimestamp); commit;");

                cmd.CommandText = query.ToString();
                cmd.ExecuteNonQuery();

                conCur.Close();

                MessageBox.Show("Элемент успешно добавлен");

                LoadGrid(dgvInspection, "inspection i join technical_condition t on (i.tech_cond_id = t.tech_cond_id)", dtInspection,
                "inspection_id, vin_num, date::timestamp, brake_system, steering, external_lights, wiper, tires_wheels, engine, other_elements");
                dgvInspection.ClearSelection();
            }
            catch (Exception ex)
            {
                conCur.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvInspection_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbVehInspHist_DropDown(object sender, EventArgs e)
        {
            FillComboBox(cmbVehInspHist, "Select vin_num, brand, model from vehicle;");
        }

        private void btnVehInspHistRes_Click(object sender, EventArgs e)
        {
            if (cmbVehInspHist.Text.Length == 0) return;
            try
            {
                cmd.Connection = conCur;
                conCur.Open();

                cmd.CommandText = $"select vin_num from vehicle where vin_num = '{cmbVehInspHist.Text.Split(' ')[0]}';";
                var res = cmd.ExecuteReader();
                if (!res.Read())
                {
                    MessageBox.Show("Вин номер не найден");
                    conCur.Close();
                    return;
                }
                string vehiclePK = res.GetValue(0).ToString();
                res.Close();

                conCur.Close();

                LoadGrid(dgvInspection, $"inspection i join technical_condition t on (i.tech_cond_id = t.tech_cond_id) where vin_num = '{vehiclePK}'", dtInspection,
                "inspection_id, vin_num, date::timestamp, brake_system, steering, external_lights, wiper, tires_wheels, engine, other_elements");
                dgvInspection.ClearSelection();
            }
            catch (Exception ex)
            {
                conCur.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSchdLoadGrid_Click(object sender, EventArgs e)
        {
            LoadGrid(dgvSchedule, "schedule order by schedule_id", dtSchedule);
            dgvSchedule.ClearSelection();
        }

        private void cbVehSch_DropDown(object sender, EventArgs e)
        {
            FillComboBox(cbVehSch, "Select vin_num, brand, model from vehicle;");
        }

        private void btnSchIns_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Connection = conCur;
                conCur.Open();

                StringBuilder query = new StringBuilder("INSERT INTO schedule (vin_num, owner_wishes, date) values (");
                query.Append(cbVehSch.Text.Length > 0 ? $"'{cbVehSch.Text.Split(' ')[0]}', " : "null, ");
                query.Append(rtbOwWish.Text.Length > 0 ? $"'{rtbOwWish.Text}', " : "null, ");
                query.Append(dtpVehSch.Text.Length > 0 ? $"'{dtpVehSch.Value}' " : "null ");
                query.Append(");");

                cmd.CommandText = query.ToString();
                cmd.ExecuteNonQuery();

                conCur.Close();

                MessageBox.Show("ТС успешно записано на осмотр");
                LoadGrid(dgvSchedule, "schedule order by schedule_id", dtSchedule);
                dgvSchedule.ClearSelection();
            }
            catch (Exception ex)
            {
                conCur.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvSchedule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSchedule.SelectedRows.Count == 0) return;
            try
            {
                cmd.Connection = conCur;
                conCur.Open();
                cmd.CommandText = $"select vin_num, brand, model from vehicle where vin_num = '{dgvSchedule.SelectedRows[0].Cells[1].FormattedValue.ToString()}'";
                var res = cmd.ExecuteReader();
                while (res.Read())
                {
                    cbVehSch.Text = res.GetValue(0).ToString() + " " + res.GetValue(1).ToString() + " " + res.GetValue(2).ToString();
                }

                conCur.Close();

                dtpVehSch.Value = DateTime.Parse(dgvSchedule.SelectedRows[0].Cells[3].FormattedValue.ToString());
                rtbOwWish.Text = dgvSchedule.SelectedRows[0].Cells[2].FormattedValue.ToString();

            }
            catch (Exception ex)
            {
                conCur.Close();
                MessageBox.Show(ex.Message);
            }
            
            
        }

        private void btnSchUpd_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSchedule.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Ошибка, не выбрана строка для обновления");
                    return;
                }

                cmd.Connection = conCur;
                conCur.Open();

                string pk = dgvSchedule.SelectedRows[0].Cells[0].FormattedValue.ToString();

                StringBuilder query = new StringBuilder("UPDATE schedule SET ");
                query.Append($"vin_num = " + (cbVehSch.Text.Length > 0 ? $"'{cbVehSch.Text.Split(' ')[0]}', " : "null, "));
                query.Append($"owner_wishes = " + (rtbOwWish.Text.Length > 0 ? $"'{rtbOwWish.Text}', " : "null, "));
                query.Append($"date = " + (dtpVehSch.Text.Length > 0 ? $"'{dtpVehSch.Value}' " : "null "));
                query.Append($"WHERE schedule_id = {pk}");

                cmd.CommandText = query.ToString();
                MessageBox.Show("Успешно изменён " + cmd.ExecuteNonQuery().ToString() + " элемент");

                conCur.Close();

                LoadGrid(dgvSchedule, "schedule order by schedule_id", dtSchedule);
                dgvSchedule.ClearSelection();
            }
            catch (Exception ex)
            {
                conCur.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSchDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSchedule.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Ошибка, не выбрана строка для обновления");
                    return;
                }

                cmd.Connection = conCur;
                conCur.Open();

                string pk = dgvSchedule.SelectedRows[0].Cells[0].FormattedValue.ToString();


                cmd.CommandText = $"Delete from schedule where schedule_id = {pk} ";
                MessageBox.Show("Успешно удалён " + cmd.ExecuteNonQuery().ToString() + " элемент");

                conCur.Close();

                LoadGrid(dgvSchedule, "schedule order by schedule_id", dtSchedule);
                dgvSchedule.ClearSelection();
            }
            catch (Exception ex)
            {
                conCur.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void cbVehNearSch_DropDown(object sender, EventArgs e)
        {
            FillComboBox(cbVehNearSch, "Select vin_num, brand, model from vehicle;");
        }

        private void btnVehNearSchRes_Click(object sender, EventArgs e)
        {
            try
            {
                string vin_num = cbVehNearSch.Text.Split(' ')[0];
                LoadGrid(dgvSchedule, $"schedule where vin_num = '{vin_num}' and date > now() order by date", dtSchedule, "vin_num, owner_wishes, date");
            }
            catch (Exception ex)
            {
                conCur.Close();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
