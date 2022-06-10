namespace Lab16
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.Serialization = new System.Windows.Forms.TabPage();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnSelectionClear = new System.Windows.Forms.Button();
            this.btnShowElements = new System.Windows.Forms.Button();
            this.b_RandomAdd = new System.Windows.Forms.Button();
            this.b_Update = new System.Windows.Forms.Button();
            this.b_Remove = new System.Windows.Forms.Button();
            this.b_Add = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_Price = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Bank = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Payer = new System.Windows.Forms.TextBox();
            this.lb_Output = new System.Windows.Forms.ListBox();
            this.b_json_des = new System.Windows.Forms.Button();
            this.b_xml_des = new System.Windows.Forms.Button();
            this.b_bin_des = new System.Windows.Forms.Button();
            this.b_json_ser = new System.Windows.Forms.Button();
            this.b_xml_ser = new System.Windows.Forms.Button();
            this.b_bin_ser = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbBank = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbPayer = new System.Windows.Forms.TextBox();
            this.btnDeleteRec = new System.Windows.Forms.Button();
            this.btnUpdateRec = new System.Windows.Forms.Button();
            this.btnInsertRec = new System.Windows.Forms.Button();
            this.btnSelectRec = new System.Windows.Forms.Button();
            this.dgvReceipt = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.tbGranter = new System.Windows.Forms.TextBox();
            this.btnGranterDelete = new System.Windows.Forms.Button();
            this.btnGranterUpd = new System.Windows.Forms.Button();
            this.btnGranterIns = new System.Windows.Forms.Button();
            this.btnGranterSel = new System.Windows.Forms.Button();
            this.dgvGranter = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.cbGranter = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbReceipt = new System.Windows.Forms.ComboBox();
            this.btnGRDel = new System.Windows.Forms.Button();
            this.btnGRUpd = new System.Windows.Forms.Button();
            this.btnGrIns = new System.Windows.Forms.Button();
            this.btnGRSel = new System.Windows.Forms.Button();
            this.dgvGR = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dgvFind = new System.Windows.Forms.DataGridView();
            this.tbPayerQ = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnPayerQRes = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.btnAggrRes = new System.Windows.Forms.Button();
            this.dgvAggr = new System.Windows.Forms.DataGridView();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.btnPSort = new System.Windows.Forms.Button();
            this.dgvSort = new System.Windows.Forms.DataGridView();
            this.btnBSort = new System.Windows.Forms.Button();
            this.btnPrSort = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.Serialization.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceipt)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGranter)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGR)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFind)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAggr)).BeginInit();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSort)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.Serialization);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1120, 450);
            this.tabControl.TabIndex = 0;
            // 
            // Serialization
            // 
            this.Serialization.Controls.Add(this.btnRemoveAll);
            this.Serialization.Controls.Add(this.btnSelectionClear);
            this.Serialization.Controls.Add(this.btnShowElements);
            this.Serialization.Controls.Add(this.b_RandomAdd);
            this.Serialization.Controls.Add(this.b_Update);
            this.Serialization.Controls.Add(this.b_Remove);
            this.Serialization.Controls.Add(this.b_Add);
            this.Serialization.Controls.Add(this.label3);
            this.Serialization.Controls.Add(this.tb_Price);
            this.Serialization.Controls.Add(this.label2);
            this.Serialization.Controls.Add(this.tb_Bank);
            this.Serialization.Controls.Add(this.label1);
            this.Serialization.Controls.Add(this.tb_Payer);
            this.Serialization.Controls.Add(this.lb_Output);
            this.Serialization.Controls.Add(this.b_json_des);
            this.Serialization.Controls.Add(this.b_xml_des);
            this.Serialization.Controls.Add(this.b_bin_des);
            this.Serialization.Controls.Add(this.b_json_ser);
            this.Serialization.Controls.Add(this.b_xml_ser);
            this.Serialization.Controls.Add(this.b_bin_ser);
            this.Serialization.Location = new System.Drawing.Point(4, 22);
            this.Serialization.Name = "Serialization";
            this.Serialization.Padding = new System.Windows.Forms.Padding(3);
            this.Serialization.Size = new System.Drawing.Size(1112, 424);
            this.Serialization.TabIndex = 0;
            this.Serialization.Text = "Serialization";
            this.Serialization.UseVisualStyleBackColor = true;
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(324, 143);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(85, 23);
            this.btnRemoveAll.TabIndex = 20;
            this.btnRemoveAll.Text = "Remove All";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnSelectionClear
            // 
            this.btnSelectionClear.Location = new System.Drawing.Point(377, 398);
            this.btnSelectionClear.Name = "btnSelectionClear";
            this.btnSelectionClear.Size = new System.Drawing.Size(125, 23);
            this.btnSelectionClear.TabIndex = 19;
            this.btnSelectionClear.Text = "Убрать выделение";
            this.btnSelectionClear.UseVisualStyleBackColor = true;
            this.btnSelectionClear.Click += new System.EventHandler(this.btnSelectionClear_Click);
            // 
            // btnShowElements
            // 
            this.btnShowElements.Location = new System.Drawing.Point(246, 398);
            this.btnShowElements.Name = "btnShowElements";
            this.btnShowElements.Size = new System.Drawing.Size(125, 23);
            this.btnShowElements.TabIndex = 18;
            this.btnShowElements.Text = "Вывести элементы";
            this.btnShowElements.UseVisualStyleBackColor = true;
            this.btnShowElements.Click += new System.EventHandler(this.btnShowElements_Click);
            // 
            // b_RandomAdd
            // 
            this.b_RandomAdd.Location = new System.Drawing.Point(324, 201);
            this.b_RandomAdd.Name = "b_RandomAdd";
            this.b_RandomAdd.Size = new System.Drawing.Size(85, 23);
            this.b_RandomAdd.TabIndex = 16;
            this.b_RandomAdd.Text = "Random add";
            this.b_RandomAdd.UseVisualStyleBackColor = true;
            this.b_RandomAdd.Click += new System.EventHandler(this.b_RandomAdd_Click);
            // 
            // b_Update
            // 
            this.b_Update.Location = new System.Drawing.Point(324, 172);
            this.b_Update.Name = "b_Update";
            this.b_Update.Size = new System.Drawing.Size(85, 23);
            this.b_Update.TabIndex = 15;
            this.b_Update.Text = "Update";
            this.b_Update.UseVisualStyleBackColor = true;
            this.b_Update.Click += new System.EventHandler(this.b_Update_Click);
            // 
            // b_Remove
            // 
            this.b_Remove.Location = new System.Drawing.Point(324, 116);
            this.b_Remove.Name = "b_Remove";
            this.b_Remove.Size = new System.Drawing.Size(85, 23);
            this.b_Remove.TabIndex = 14;
            this.b_Remove.Text = "Remove";
            this.b_Remove.UseVisualStyleBackColor = true;
            this.b_Remove.Click += new System.EventHandler(this.b_Remove_Click);
            // 
            // b_Add
            // 
            this.b_Add.Location = new System.Drawing.Point(324, 87);
            this.b_Add.Name = "b_Add";
            this.b_Add.Size = new System.Drawing.Size(85, 23);
            this.b_Add.TabIndex = 13;
            this.b_Add.Text = "Add";
            this.b_Add.UseVisualStyleBackColor = true;
            this.b_Add.Click += new System.EventHandler(this.b_Add_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(255, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Price";
            // 
            // tb_Price
            // 
            this.tb_Price.Location = new System.Drawing.Point(324, 61);
            this.tb_Price.MaxLength = 5;
            this.tb_Price.Name = "tb_Price";
            this.tb_Price.Size = new System.Drawing.Size(85, 20);
            this.tb_Price.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Bank name";
            // 
            // tb_Bank
            // 
            this.tb_Bank.Location = new System.Drawing.Point(324, 35);
            this.tb_Bank.MaxLength = 5;
            this.tb_Bank.Name = "tb_Bank";
            this.tb_Bank.Size = new System.Drawing.Size(85, 20);
            this.tb_Bank.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(255, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Payer name";
            // 
            // tb_Payer
            // 
            this.tb_Payer.Location = new System.Drawing.Point(324, 9);
            this.tb_Payer.MaxLength = 5;
            this.tb_Payer.Name = "tb_Payer";
            this.tb_Payer.Size = new System.Drawing.Size(85, 20);
            this.tb_Payer.TabIndex = 7;
            // 
            // lb_Output
            // 
            this.lb_Output.Dock = System.Windows.Forms.DockStyle.Left;
            this.lb_Output.FormattingEnabled = true;
            this.lb_Output.Location = new System.Drawing.Point(3, 3);
            this.lb_Output.Name = "lb_Output";
            this.lb_Output.Size = new System.Drawing.Size(237, 418);
            this.lb_Output.TabIndex = 6;
            this.lb_Output.SelectedIndexChanged += new System.EventHandler(this.lb_Output_SelectedIndexChanged);
            // 
            // b_json_des
            // 
            this.b_json_des.Location = new System.Drawing.Point(988, 50);
            this.b_json_des.Name = "b_json_des";
            this.b_json_des.Size = new System.Drawing.Size(118, 23);
            this.b_json_des.TabIndex = 5;
            this.b_json_des.Text = "JSON deserialization";
            this.b_json_des.UseVisualStyleBackColor = true;
            this.b_json_des.Click += new System.EventHandler(this.b_json_des_Click);
            // 
            // b_xml_des
            // 
            this.b_xml_des.Location = new System.Drawing.Point(864, 50);
            this.b_xml_des.Name = "b_xml_des";
            this.b_xml_des.Size = new System.Drawing.Size(118, 23);
            this.b_xml_des.TabIndex = 4;
            this.b_xml_des.Text = "XML deserialization";
            this.b_xml_des.UseVisualStyleBackColor = true;
            this.b_xml_des.Click += new System.EventHandler(this.b_xml_des_Click);
            // 
            // b_bin_des
            // 
            this.b_bin_des.Location = new System.Drawing.Point(740, 50);
            this.b_bin_des.Name = "b_bin_des";
            this.b_bin_des.Size = new System.Drawing.Size(118, 23);
            this.b_bin_des.TabIndex = 3;
            this.b_bin_des.Text = "Bin deserialization";
            this.b_bin_des.UseVisualStyleBackColor = true;
            this.b_bin_des.Click += new System.EventHandler(this.b_bin_des_Click);
            // 
            // b_json_ser
            // 
            this.b_json_ser.Location = new System.Drawing.Point(988, 6);
            this.b_json_ser.Name = "b_json_ser";
            this.b_json_ser.Size = new System.Drawing.Size(118, 23);
            this.b_json_ser.TabIndex = 2;
            this.b_json_ser.Text = "JSON serialization";
            this.b_json_ser.UseVisualStyleBackColor = true;
            this.b_json_ser.Click += new System.EventHandler(this.b_json_ser_Click);
            // 
            // b_xml_ser
            // 
            this.b_xml_ser.Location = new System.Drawing.Point(864, 6);
            this.b_xml_ser.Name = "b_xml_ser";
            this.b_xml_ser.Size = new System.Drawing.Size(118, 23);
            this.b_xml_ser.TabIndex = 1;
            this.b_xml_ser.Text = "XML serialization";
            this.b_xml_ser.UseVisualStyleBackColor = true;
            this.b_xml_ser.Click += new System.EventHandler(this.b_xml_ser_Click);
            // 
            // b_bin_ser
            // 
            this.b_bin_ser.Location = new System.Drawing.Point(740, 6);
            this.b_bin_ser.Name = "b_bin_ser";
            this.b_bin_ser.Size = new System.Drawing.Size(118, 23);
            this.b_bin_ser.TabIndex = 0;
            this.b_bin_ser.Text = "Bin serialization";
            this.b_bin_ser.UseVisualStyleBackColor = true;
            this.b_bin_ser.Click += new System.EventHandler(this.b_bin_ser_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1112, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Database";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Location = new System.Drawing.Point(0, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1109, 418);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.tbPrice);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.tbBank);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.tbPayer);
            this.tabPage1.Controls.Add(this.btnDeleteRec);
            this.tabPage1.Controls.Add(this.btnUpdateRec);
            this.tabPage1.Controls.Add(this.btnInsertRec);
            this.tabPage1.Controls.Add(this.btnSelectRec);
            this.tabPage1.Controls.Add(this.dgvReceipt);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1101, 392);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Receipt";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(480, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Price";
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(549, 60);
            this.tbPrice.MaxLength = 5;
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(85, 20);
            this.tbPrice.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(480, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Bank name";
            // 
            // tbBank
            // 
            this.tbBank.Location = new System.Drawing.Point(549, 34);
            this.tbBank.MaxLength = 5;
            this.tbBank.Name = "tbBank";
            this.tbBank.Size = new System.Drawing.Size(85, 20);
            this.tbBank.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(480, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Payer name";
            // 
            // tbPayer
            // 
            this.tbPayer.Location = new System.Drawing.Point(549, 8);
            this.tbPayer.MaxLength = 5;
            this.tbPayer.Name = "tbPayer";
            this.tbPayer.Size = new System.Drawing.Size(85, 20);
            this.tbPayer.TabIndex = 13;
            // 
            // btnDeleteRec
            // 
            this.btnDeleteRec.Location = new System.Drawing.Point(650, 64);
            this.btnDeleteRec.Name = "btnDeleteRec";
            this.btnDeleteRec.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteRec.TabIndex = 4;
            this.btnDeleteRec.Text = "Delete";
            this.btnDeleteRec.UseVisualStyleBackColor = true;
            this.btnDeleteRec.Click += new System.EventHandler(this.btnDeleteRec_Click);
            // 
            // btnUpdateRec
            // 
            this.btnUpdateRec.Location = new System.Drawing.Point(650, 35);
            this.btnUpdateRec.Name = "btnUpdateRec";
            this.btnUpdateRec.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateRec.TabIndex = 3;
            this.btnUpdateRec.Text = "Update";
            this.btnUpdateRec.UseVisualStyleBackColor = true;
            this.btnUpdateRec.Click += new System.EventHandler(this.btnUpdateRec_Click);
            // 
            // btnInsertRec
            // 
            this.btnInsertRec.Location = new System.Drawing.Point(650, 6);
            this.btnInsertRec.Name = "btnInsertRec";
            this.btnInsertRec.Size = new System.Drawing.Size(75, 23);
            this.btnInsertRec.TabIndex = 2;
            this.btnInsertRec.Text = "Insert";
            this.btnInsertRec.UseVisualStyleBackColor = true;
            this.btnInsertRec.Click += new System.EventHandler(this.btnInsertRec_Click);
            // 
            // btnSelectRec
            // 
            this.btnSelectRec.Location = new System.Drawing.Point(477, 358);
            this.btnSelectRec.Name = "btnSelectRec";
            this.btnSelectRec.Size = new System.Drawing.Size(75, 23);
            this.btnSelectRec.TabIndex = 1;
            this.btnSelectRec.Text = "Select";
            this.btnSelectRec.UseVisualStyleBackColor = true;
            this.btnSelectRec.Click += new System.EventHandler(this.btnSelectRec_Click);
            // 
            // dgvReceipt
            // 
            this.dgvReceipt.AllowUserToAddRows = false;
            this.dgvReceipt.AllowUserToDeleteRows = false;
            this.dgvReceipt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceipt.Location = new System.Drawing.Point(6, 6);
            this.dgvReceipt.Name = "dgvReceipt";
            this.dgvReceipt.ReadOnly = true;
            this.dgvReceipt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReceipt.Size = new System.Drawing.Size(465, 380);
            this.dgvReceipt.TabIndex = 0;
            this.dgvReceipt.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReceipt_CellClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.tbGranter);
            this.tabPage3.Controls.Add(this.btnGranterDelete);
            this.tabPage3.Controls.Add(this.btnGranterUpd);
            this.tabPage3.Controls.Add(this.btnGranterIns);
            this.tabPage3.Controls.Add(this.btnGranterSel);
            this.tabPage3.Controls.Add(this.dgvGranter);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1101, 392);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Granter";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(474, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Granter name";
            // 
            // tbGranter
            // 
            this.tbGranter.Location = new System.Drawing.Point(549, 5);
            this.tbGranter.MaxLength = 10;
            this.tbGranter.Name = "tbGranter";
            this.tbGranter.Size = new System.Drawing.Size(85, 20);
            this.tbGranter.TabIndex = 20;
            // 
            // btnGranterDelete
            // 
            this.btnGranterDelete.Location = new System.Drawing.Point(812, 3);
            this.btnGranterDelete.Name = "btnGranterDelete";
            this.btnGranterDelete.Size = new System.Drawing.Size(75, 23);
            this.btnGranterDelete.TabIndex = 19;
            this.btnGranterDelete.Text = "Delete";
            this.btnGranterDelete.UseVisualStyleBackColor = true;
            this.btnGranterDelete.Click += new System.EventHandler(this.btnGranterDelete_Click);
            // 
            // btnGranterUpd
            // 
            this.btnGranterUpd.Location = new System.Drawing.Point(731, 3);
            this.btnGranterUpd.Name = "btnGranterUpd";
            this.btnGranterUpd.Size = new System.Drawing.Size(75, 23);
            this.btnGranterUpd.TabIndex = 18;
            this.btnGranterUpd.Text = "Update";
            this.btnGranterUpd.UseVisualStyleBackColor = true;
            this.btnGranterUpd.Click += new System.EventHandler(this.btnGranterUpd_Click);
            // 
            // btnGranterIns
            // 
            this.btnGranterIns.Location = new System.Drawing.Point(650, 3);
            this.btnGranterIns.Name = "btnGranterIns";
            this.btnGranterIns.Size = new System.Drawing.Size(75, 23);
            this.btnGranterIns.TabIndex = 17;
            this.btnGranterIns.Text = "Insert";
            this.btnGranterIns.UseVisualStyleBackColor = true;
            this.btnGranterIns.Click += new System.EventHandler(this.btnGranterIns_Click);
            // 
            // btnGranterSel
            // 
            this.btnGranterSel.Location = new System.Drawing.Point(477, 355);
            this.btnGranterSel.Name = "btnGranterSel";
            this.btnGranterSel.Size = new System.Drawing.Size(75, 23);
            this.btnGranterSel.TabIndex = 16;
            this.btnGranterSel.Text = "Select";
            this.btnGranterSel.UseVisualStyleBackColor = true;
            this.btnGranterSel.Click += new System.EventHandler(this.btnGranterSel_Click);
            // 
            // dgvGranter
            // 
            this.dgvGranter.AllowUserToAddRows = false;
            this.dgvGranter.AllowUserToDeleteRows = false;
            this.dgvGranter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGranter.Location = new System.Drawing.Point(6, 3);
            this.dgvGranter.Name = "dgvGranter";
            this.dgvGranter.ReadOnly = true;
            this.dgvGranter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGranter.Size = new System.Drawing.Size(465, 380);
            this.dgvGranter.TabIndex = 15;
            this.dgvGranter.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGranter_CellClick);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.cbGranter);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.cbReceipt);
            this.tabPage4.Controls.Add(this.btnGRDel);
            this.tabPage4.Controls.Add(this.btnGRUpd);
            this.tabPage4.Controls.Add(this.btnGrIns);
            this.tabPage4.Controls.Add(this.btnGRSel);
            this.tabPage4.Controls.Add(this.dgvGR);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1101, 392);
            this.tabPage4.TabIndex = 2;
            this.tabPage4.Text = "GranterReceipt";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(927, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Granter";
            // 
            // cbGranter
            // 
            this.cbGranter.FormattingEnabled = true;
            this.cbGranter.Location = new System.Drawing.Point(977, 9);
            this.cbGranter.Name = "cbGranter";
            this.cbGranter.Size = new System.Drawing.Size(121, 21);
            this.cbGranter.TabIndex = 27;
            this.cbGranter.DropDown += new System.EventHandler(this.cbGranter_DropDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(752, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Receipt";
            // 
            // cbReceipt
            // 
            this.cbReceipt.FormattingEnabled = true;
            this.cbReceipt.Location = new System.Drawing.Point(802, 9);
            this.cbReceipt.Name = "cbReceipt";
            this.cbReceipt.Size = new System.Drawing.Size(121, 21);
            this.cbReceipt.TabIndex = 25;
            this.cbReceipt.DropDown += new System.EventHandler(this.cbReceipt_DropDown);
            // 
            // btnGRDel
            // 
            this.btnGRDel.Location = new System.Drawing.Point(992, 48);
            this.btnGRDel.Name = "btnGRDel";
            this.btnGRDel.Size = new System.Drawing.Size(75, 23);
            this.btnGRDel.TabIndex = 24;
            this.btnGRDel.Text = "Delete";
            this.btnGRDel.UseVisualStyleBackColor = true;
            // 
            // btnGRUpd
            // 
            this.btnGRUpd.Location = new System.Drawing.Point(911, 48);
            this.btnGRUpd.Name = "btnGRUpd";
            this.btnGRUpd.Size = new System.Drawing.Size(75, 23);
            this.btnGRUpd.TabIndex = 23;
            this.btnGRUpd.Text = "Update";
            this.btnGRUpd.UseVisualStyleBackColor = true;
            // 
            // btnGrIns
            // 
            this.btnGrIns.Location = new System.Drawing.Point(830, 48);
            this.btnGrIns.Name = "btnGrIns";
            this.btnGrIns.Size = new System.Drawing.Size(75, 23);
            this.btnGrIns.TabIndex = 22;
            this.btnGrIns.Text = "Insert";
            this.btnGrIns.UseVisualStyleBackColor = true;
            this.btnGrIns.Click += new System.EventHandler(this.btnGrIns_Click);
            // 
            // btnGRSel
            // 
            this.btnGRSel.Location = new System.Drawing.Point(741, 358);
            this.btnGRSel.Name = "btnGRSel";
            this.btnGRSel.Size = new System.Drawing.Size(75, 23);
            this.btnGRSel.TabIndex = 21;
            this.btnGRSel.Text = "Select";
            this.btnGRSel.UseVisualStyleBackColor = true;
            this.btnGRSel.Click += new System.EventHandler(this.btnGRSel_Click);
            // 
            // dgvGR
            // 
            this.dgvGR.AllowUserToAddRows = false;
            this.dgvGR.AllowUserToDeleteRows = false;
            this.dgvGR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGR.Location = new System.Drawing.Point(4, 3);
            this.dgvGR.Name = "dgvGR";
            this.dgvGR.ReadOnly = true;
            this.dgvGR.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGR.Size = new System.Drawing.Size(731, 380);
            this.dgvGR.TabIndex = 20;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.btnPayerQRes);
            this.tabPage5.Controls.Add(this.label10);
            this.tabPage5.Controls.Add(this.tbPayerQ);
            this.tabPage5.Controls.Add(this.dgvFind);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1101, 392);
            this.tabPage5.TabIndex = 3;
            this.tabPage5.Text = "Поиск по имени";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dgvFind
            // 
            this.dgvFind.AllowUserToAddRows = false;
            this.dgvFind.AllowUserToDeleteRows = false;
            this.dgvFind.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFind.Location = new System.Drawing.Point(4, 3);
            this.dgvFind.Name = "dgvFind";
            this.dgvFind.ReadOnly = true;
            this.dgvFind.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFind.Size = new System.Drawing.Size(731, 380);
            this.dgvFind.TabIndex = 21;
            // 
            // tbPayerQ
            // 
            this.tbPayerQ.Location = new System.Drawing.Point(845, 29);
            this.tbPayerQ.Name = "tbPayerQ";
            this.tbPayerQ.Size = new System.Drawing.Size(100, 20);
            this.tbPayerQ.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(741, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Имя плательщика";
            // 
            // btnPayerQRes
            // 
            this.btnPayerQRes.Location = new System.Drawing.Point(952, 25);
            this.btnPayerQRes.Name = "btnPayerQRes";
            this.btnPayerQRes.Size = new System.Drawing.Size(75, 23);
            this.btnPayerQRes.TabIndex = 24;
            this.btnPayerQRes.Text = "Результат";
            this.btnPayerQRes.UseVisualStyleBackColor = true;
            this.btnPayerQRes.Click += new System.EventHandler(this.btnPayerQRes_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.btnAggrRes);
            this.tabPage6.Controls.Add(this.dgvAggr);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1101, 392);
            this.tabPage6.TabIndex = 4;
            this.tabPage6.Text = "Агрегирование";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // btnAggrRes
            // 
            this.btnAggrRes.Location = new System.Drawing.Point(888, 360);
            this.btnAggrRes.Name = "btnAggrRes";
            this.btnAggrRes.Size = new System.Drawing.Size(75, 23);
            this.btnAggrRes.TabIndex = 28;
            this.btnAggrRes.Text = "Результат";
            this.btnAggrRes.UseVisualStyleBackColor = true;
            this.btnAggrRes.Click += new System.EventHandler(this.btnAggrRes_Click);
            // 
            // dgvAggr
            // 
            this.dgvAggr.AllowUserToAddRows = false;
            this.dgvAggr.AllowUserToDeleteRows = false;
            this.dgvAggr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAggr.Location = new System.Drawing.Point(4, 3);
            this.dgvAggr.Name = "dgvAggr";
            this.dgvAggr.ReadOnly = true;
            this.dgvAggr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAggr.Size = new System.Drawing.Size(731, 380);
            this.dgvAggr.TabIndex = 25;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.btnPrSort);
            this.tabPage7.Controls.Add(this.btnBSort);
            this.tabPage7.Controls.Add(this.btnPSort);
            this.tabPage7.Controls.Add(this.dgvSort);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(1101, 392);
            this.tabPage7.TabIndex = 5;
            this.tabPage7.Text = "Сортировка";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // btnPSort
            // 
            this.btnPSort.Location = new System.Drawing.Point(763, 360);
            this.btnPSort.Name = "btnPSort";
            this.btnPSort.Size = new System.Drawing.Size(114, 23);
            this.btnPSort.TabIndex = 30;
            this.btnPSort.Text = "Имя плательщика";
            this.btnPSort.UseVisualStyleBackColor = true;
            this.btnPSort.Click += new System.EventHandler(this.btnPSort_Click);
            // 
            // dgvSort
            // 
            this.dgvSort.AllowUserToAddRows = false;
            this.dgvSort.AllowUserToDeleteRows = false;
            this.dgvSort.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSort.Location = new System.Drawing.Point(4, 3);
            this.dgvSort.Name = "dgvSort";
            this.dgvSort.ReadOnly = true;
            this.dgvSort.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSort.Size = new System.Drawing.Size(731, 380);
            this.dgvSort.TabIndex = 29;
            // 
            // btnBSort
            // 
            this.btnBSort.Location = new System.Drawing.Point(883, 360);
            this.btnBSort.Name = "btnBSort";
            this.btnBSort.Size = new System.Drawing.Size(114, 23);
            this.btnBSort.TabIndex = 31;
            this.btnBSort.Text = "Название банка";
            this.btnBSort.UseVisualStyleBackColor = true;
            this.btnBSort.Click += new System.EventHandler(this.btnBSort_Click);
            // 
            // btnPrSort
            // 
            this.btnPrSort.Location = new System.Drawing.Point(1003, 360);
            this.btnPrSort.Name = "btnPrSort";
            this.btnPrSort.Size = new System.Drawing.Size(85, 23);
            this.btnPrSort.TabIndex = 32;
            this.btnPrSort.Text = "Стоимость";
            this.btnPrSort.UseVisualStyleBackColor = true;
            this.btnPrSort.Click += new System.EventHandler(this.btnPrSort_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 450);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl.ResumeLayout(false);
            this.Serialization.ResumeLayout(false);
            this.Serialization.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceipt)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGranter)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGR)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFind)).EndInit();
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAggr)).EndInit();
            this.tabPage7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage Serialization;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button b_json_des;
        private System.Windows.Forms.Button b_xml_des;
        private System.Windows.Forms.Button b_bin_des;
        private System.Windows.Forms.Button b_json_ser;
        private System.Windows.Forms.Button b_xml_ser;
        private System.Windows.Forms.Button b_bin_ser;
        private System.Windows.Forms.ListBox lb_Output;
        private System.Windows.Forms.TextBox tb_Payer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_Price;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_Bank;
        private System.Windows.Forms.Button b_Update;
        private System.Windows.Forms.Button b_Remove;
        private System.Windows.Forms.Button b_Add;
        private System.Windows.Forms.Button b_RandomAdd;
        private System.Windows.Forms.Button btnShowElements;
        private System.Windows.Forms.Button btnSelectionClear;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnSelectRec;
        private System.Windows.Forms.DataGridView dgvReceipt;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbBank;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPayer;
        private System.Windows.Forms.Button btnDeleteRec;
        private System.Windows.Forms.Button btnUpdateRec;
        private System.Windows.Forms.Button btnInsertRec;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbGranter;
        private System.Windows.Forms.Button btnGranterDelete;
        private System.Windows.Forms.Button btnGranterUpd;
        private System.Windows.Forms.Button btnGranterIns;
        private System.Windows.Forms.Button btnGranterSel;
        private System.Windows.Forms.DataGridView dgvGranter;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbGranter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbReceipt;
        private System.Windows.Forms.Button btnGRDel;
        private System.Windows.Forms.Button btnGRUpd;
        private System.Windows.Forms.Button btnGrIns;
        private System.Windows.Forms.Button btnGRSel;
        private System.Windows.Forms.DataGridView dgvGR;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button btnPayerQRes;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbPayerQ;
        private System.Windows.Forms.DataGridView dgvFind;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button btnAggrRes;
        private System.Windows.Forms.DataGridView dgvAggr;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Button btnPrSort;
        private System.Windows.Forms.Button btnBSort;
        private System.Windows.Forms.Button btnPSort;
        private System.Windows.Forms.DataGridView dgvSort;
    }
}

