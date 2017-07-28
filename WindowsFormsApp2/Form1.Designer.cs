namespace FareComparison
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.origin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dest = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.date1 = new System.Windows.Forms.TextBox();
            this.date2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.airline = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ADD = new System.Windows.Forms.Button();
            this.Export = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.cmd = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.Search = new System.Windows.Forms.Button();
            this.Reset = new System.Windows.Forms.Button();
            this.sign = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.tab1 = new System.Windows.Forms.TabControl();
            this.FareChecker = new System.Windows.Forms.TabPage();
            this.FareComparison = new System.Windows.Forms.TabPage();
            this.PCC2 = new System.Windows.Forms.Label();
            this.PCC1 = new System.Windows.Forms.Label();
            this.MasterPCC = new System.Windows.Forms.TextBox();
            this.CheckPCC = new System.Windows.Forms.TextBox();
            this.CompRun = new System.Windows.Forms.Button();
            this.CompClear = new System.Windows.Forms.Button();
            this.CompAdd = new System.Windows.Forms.Button();
            this.CompOri = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.CompDest = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.CompDepart = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.CompReturn = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.CompAirline = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.CompCMD = new System.Windows.Forms.RichTextBox();
            this.ComparisonTable = new System.Windows.Forms.DataGridView();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpAirline = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPCC1Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPCC2Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tab1.SuspendLayout();
            this.FareChecker.SuspendLayout();
            this.FareComparison.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ComparisonTable)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(348, 364);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.richTextBox1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(427, 29);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(744, 358);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(86, 367);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "IPCC:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(129, 367);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(134, 21);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // origin
            // 
            this.origin.Location = new System.Drawing.Point(3, 24);
            this.origin.Name = "origin";
            this.origin.Size = new System.Drawing.Size(60, 20);
            this.origin.TabIndex = 13;
            this.origin.TextChanged += new System.EventHandler(this.origin_TextChanged);
            this.origin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.origin_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Origin";
            // 
            // dest
            // 
            this.dest.Location = new System.Drawing.Point(67, 24);
            this.dest.Name = "dest";
            this.dest.Size = new System.Drawing.Size(56, 20);
            this.dest.TabIndex = 15;
            this.dest.TextChanged += new System.EventHandler(this.dest_TextChanged);
            this.dest.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dest_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Dest";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Depart Date";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // date1
            // 
            this.date1.Location = new System.Drawing.Point(131, 24);
            this.date1.Name = "date1";
            this.date1.Size = new System.Drawing.Size(67, 20);
            this.date1.TabIndex = 18;
            this.date1.TextChanged += new System.EventHandler(this.date1_TextChanged);
            this.date1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.date1_KeyUp);
            // 
            // date2
            // 
            this.date2.Location = new System.Drawing.Point(209, 24);
            this.date2.Name = "date2";
            this.date2.Size = new System.Drawing.Size(55, 20);
            this.date2.TabIndex = 19;
            this.date2.TextChanged += new System.EventHandler(this.date2_TextChanged);
            this.date2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.date2_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(206, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Return Date";
            // 
            // airline
            // 
            this.airline.Location = new System.Drawing.Point(288, 24);
            this.airline.Name = "airline";
            this.airline.Size = new System.Drawing.Size(54, 20);
            this.airline.TabIndex = 21;
            this.airline.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.airline.KeyUp += new System.Windows.Forms.KeyEventHandler(this.airline_KeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(285, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Airline";
            // 
            // ADD
            // 
            this.ADD.Location = new System.Drawing.Point(346, 22);
            this.ADD.Name = "ADD";
            this.ADD.Size = new System.Drawing.Size(73, 23);
            this.ADD.TabIndex = 24;
            this.ADD.Text = "ADD";
            this.ADD.UseVisualStyleBackColor = true;
            this.ADD.Click += new System.EventHandler(this.ADD_Click);
            // 
            // Export
            // 
            this.Export.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Export.Location = new System.Drawing.Point(3, 585);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(1168, 36);
            this.Export.TabIndex = 25;
            this.Export.Text = "Export";
            this.Export.UseVisualStyleBackColor = true;
            this.Export.Click += new System.EventHandler(this.Export_Click);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(346, 72);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(71, 23);
            this.Clear.TabIndex = 28;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // cmd
            // 
            this.cmd.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd.Location = new System.Drawing.Point(3, 63);
            this.cmd.Name = "cmd";
            this.cmd.Size = new System.Drawing.Size(339, 302);
            this.cmd.TabIndex = 30;
            this.cmd.Text = "";
            this.cmd.TextChanged += new System.EventHandler(this.cmd_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Input:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 364);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 16);
            this.label8.TabIndex = 32;
            this.label8.Text = "Output:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.Location = new System.Drawing.Point(3, 393);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(1168, 186);
            this.richTextBox2.TabIndex = 33;
            this.richTextBox2.Text = "";
            this.richTextBox2.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // SearchBox
            // 
            this.SearchBox.Location = new System.Drawing.Point(496, 6);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(200, 20);
            this.SearchBox.TabIndex = 34;
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(817, 4);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(80, 23);
            this.Search.TabIndex = 35;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(929, 3);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(75, 23);
            this.Reset.TabIndex = 36;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // sign
            // 
            this.sign.Location = new System.Drawing.Point(713, 4);
            this.sign.Name = "sign";
            this.sign.Size = new System.Drawing.Size(75, 23);
            this.sign.TabIndex = 37;
            this.sign.Text = "¥";
            this.sign.UseVisualStyleBackColor = true;
            this.sign.Click += new System.EventHandler(this.sign_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(425, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "Search Box:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // tab1
            // 
            this.tab1.Controls.Add(this.FareChecker);
            this.tab1.Controls.Add(this.FareComparison);
            this.tab1.Location = new System.Drawing.Point(-1, 0);
            this.tab1.Name = "tab1";
            this.tab1.SelectedIndex = 0;
            this.tab1.Size = new System.Drawing.Size(1182, 650);
            this.tab1.TabIndex = 39;
            // 
            // FareChecker
            // 
            this.FareChecker.Controls.Add(this.origin);
            this.FareChecker.Controls.Add(this.Export);
            this.FareChecker.Controls.Add(this.richTextBox2);
            this.FareChecker.Controls.Add(this.Reset);
            this.FareChecker.Controls.Add(this.sign);
            this.FareChecker.Controls.Add(this.richTextBox1);
            this.FareChecker.Controls.Add(this.Search);
            this.FareChecker.Controls.Add(this.label9);
            this.FareChecker.Controls.Add(this.label2);
            this.FareChecker.Controls.Add(this.dest);
            this.FareChecker.Controls.Add(this.SearchBox);
            this.FareChecker.Controls.Add(this.label3);
            this.FareChecker.Controls.Add(this.date1);
            this.FareChecker.Controls.Add(this.label4);
            this.FareChecker.Controls.Add(this.date2);
            this.FareChecker.Controls.Add(this.label8);
            this.FareChecker.Controls.Add(this.comboBox1);
            this.FareChecker.Controls.Add(this.button1);
            this.FareChecker.Controls.Add(this.label5);
            this.FareChecker.Controls.Add(this.label1);
            this.FareChecker.Controls.Add(this.Clear);
            this.FareChecker.Controls.Add(this.cmd);
            this.FareChecker.Controls.Add(this.label7);
            this.FareChecker.Controls.Add(this.ADD);
            this.FareChecker.Controls.Add(this.airline);
            this.FareChecker.Controls.Add(this.label6);
            this.FareChecker.Location = new System.Drawing.Point(4, 22);
            this.FareChecker.Name = "FareChecker";
            this.FareChecker.Padding = new System.Windows.Forms.Padding(3);
            this.FareChecker.Size = new System.Drawing.Size(1174, 624);
            this.FareChecker.TabIndex = 0;
            this.FareChecker.Text = "FareChecker";
            this.FareChecker.UseVisualStyleBackColor = true;
            // 
            // FareComparison
            // 
            this.FareComparison.Controls.Add(this.PCC2);
            this.FareComparison.Controls.Add(this.PCC1);
            this.FareComparison.Controls.Add(this.MasterPCC);
            this.FareComparison.Controls.Add(this.CheckPCC);
            this.FareComparison.Controls.Add(this.CompRun);
            this.FareComparison.Controls.Add(this.CompClear);
            this.FareComparison.Controls.Add(this.CompAdd);
            this.FareComparison.Controls.Add(this.CompOri);
            this.FareComparison.Controls.Add(this.label19);
            this.FareComparison.Controls.Add(this.CompDest);
            this.FareComparison.Controls.Add(this.label18);
            this.FareComparison.Controls.Add(this.CompDepart);
            this.FareComparison.Controls.Add(this.label17);
            this.FareComparison.Controls.Add(this.CompReturn);
            this.FareComparison.Controls.Add(this.label16);
            this.FareComparison.Controls.Add(this.CompAirline);
            this.FareComparison.Controls.Add(this.label15);
            this.FareComparison.Controls.Add(this.CompCMD);
            this.FareComparison.Controls.Add(this.ComparisonTable);
            this.FareComparison.Location = new System.Drawing.Point(4, 22);
            this.FareComparison.Name = "FareComparison";
            this.FareComparison.Padding = new System.Windows.Forms.Padding(3);
            this.FareComparison.Size = new System.Drawing.Size(1174, 624);
            this.FareComparison.TabIndex = 1;
            this.FareComparison.Text = "FareComparison";
            this.FareComparison.UseVisualStyleBackColor = true;
            // 
            // PCC2
            // 
            this.PCC2.AutoSize = true;
            this.PCC2.Location = new System.Drawing.Point(392, 14);
            this.PCC2.Name = "PCC2";
            this.PCC2.Size = new System.Drawing.Size(59, 13);
            this.PCC2.TabIndex = 39;
            this.PCC2.Text = "CheckPCC";
            // 
            // PCC1
            // 
            this.PCC1.AutoSize = true;
            this.PCC1.Location = new System.Drawing.Point(325, 15);
            this.PCC1.Name = "PCC1";
            this.PCC1.Size = new System.Drawing.Size(60, 13);
            this.PCC1.TabIndex = 38;
            this.PCC1.Text = "MasterPCC";
            // 
            // MasterPCC
            // 
            this.MasterPCC.Location = new System.Drawing.Point(324, 31);
            this.MasterPCC.Name = "MasterPCC";
            this.MasterPCC.Size = new System.Drawing.Size(61, 20);
            this.MasterPCC.TabIndex = 37;
            this.MasterPCC.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.MasterPCC.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MasterPCC_KeyUp);
            // 
            // CheckPCC
            // 
            this.CheckPCC.Location = new System.Drawing.Point(391, 31);
            this.CheckPCC.Name = "CheckPCC";
            this.CheckPCC.Size = new System.Drawing.Size(72, 20);
            this.CheckPCC.TabIndex = 36;
            this.CheckPCC.TextChanged += new System.EventHandler(this.CheckPCC_TextChanged);
            this.CheckPCC.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CheckPCC_KeyUp);
            // 
            // CompRun
            // 
            this.CompRun.Location = new System.Drawing.Point(388, 231);
            this.CompRun.Name = "CompRun";
            this.CompRun.Size = new System.Drawing.Size(75, 23);
            this.CompRun.TabIndex = 35;
            this.CompRun.Text = "Run";
            this.CompRun.UseVisualStyleBackColor = true;
            this.CompRun.Click += new System.EventHandler(this.CompRun_Click);
            // 
            // CompClear
            // 
            this.CompClear.Location = new System.Drawing.Point(388, 202);
            this.CompClear.Name = "CompClear";
            this.CompClear.Size = new System.Drawing.Size(75, 23);
            this.CompClear.TabIndex = 34;
            this.CompClear.Text = "Clear";
            this.CompClear.UseVisualStyleBackColor = true;
            this.CompClear.Click += new System.EventHandler(this.CompClear_Click);
            // 
            // CompAdd
            // 
            this.CompAdd.Location = new System.Drawing.Point(391, 57);
            this.CompAdd.Name = "CompAdd";
            this.CompAdd.Size = new System.Drawing.Size(75, 23);
            this.CompAdd.TabIndex = 33;
            this.CompAdd.Text = "Add";
            this.CompAdd.UseVisualStyleBackColor = true;
            this.CompAdd.Click += new System.EventHandler(this.button2_Click);
            // 
            // CompOri
            // 
            this.CompOri.Location = new System.Drawing.Point(9, 31);
            this.CompOri.Name = "CompOri";
            this.CompOri.Size = new System.Drawing.Size(60, 20);
            this.CompOri.TabIndex = 23;
            this.CompOri.TextChanged += new System.EventHandler(this.CompOri_TextChanged);
            this.CompOri.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CompOri_KeyUp);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(19, 15);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(34, 13);
            this.label19.TabIndex = 24;
            this.label19.Text = "Origin";
            // 
            // CompDest
            // 
            this.CompDest.Location = new System.Drawing.Point(73, 31);
            this.CompDest.Name = "CompDest";
            this.CompDest.Size = new System.Drawing.Size(56, 20);
            this.CompDest.TabIndex = 25;
            this.CompDest.TextChanged += new System.EventHandler(this.CompDest_TextChanged);
            this.CompDest.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CompDest_KeyUp);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(70, 15);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 13);
            this.label18.TabIndex = 26;
            this.label18.Text = "Dest";
            // 
            // CompDepart
            // 
            this.CompDepart.Location = new System.Drawing.Point(135, 31);
            this.CompDepart.Name = "CompDepart";
            this.CompDepart.Size = new System.Drawing.Size(62, 20);
            this.CompDepart.TabIndex = 28;
            this.CompDepart.TextChanged += new System.EventHandler(this.CompDepart_TextChanged);
            this.CompDepart.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CompDepart_KeyUp);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(132, 15);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 13);
            this.label17.TabIndex = 27;
            this.label17.Text = "Depart Date";
            // 
            // CompReturn
            // 
            this.CompReturn.Location = new System.Drawing.Point(203, 31);
            this.CompReturn.Name = "CompReturn";
            this.CompReturn.Size = new System.Drawing.Size(55, 20);
            this.CompReturn.TabIndex = 29;
            this.CompReturn.TextChanged += new System.EventHandler(this.CompReturn_TextChanged);
            this.CompReturn.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CompReturn_KeyUp);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(200, 15);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 13);
            this.label16.TabIndex = 30;
            this.label16.Text = "Return Date";
            // 
            // CompAirline
            // 
            this.CompAirline.Location = new System.Drawing.Point(264, 31);
            this.CompAirline.Name = "CompAirline";
            this.CompAirline.Size = new System.Drawing.Size(54, 20);
            this.CompAirline.TabIndex = 31;
            this.CompAirline.TextChanged += new System.EventHandler(this.CompAirline_TextChanged);
            this.CompAirline.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CompAirline_KeyUp);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(271, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 32;
            this.label15.Text = "Airline";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // CompCMD
            // 
            this.CompCMD.Location = new System.Drawing.Point(9, 57);
            this.CompCMD.Name = "CompCMD";
            this.CompCMD.Size = new System.Drawing.Size(376, 197);
            this.CompCMD.TabIndex = 1;
            this.CompCMD.Text = "";
            this.CompCMD.TextChanged += new System.EventHandler(this.richTextBox3_TextChanged);
            // 
            // ComparisonTable
            // 
            this.ComparisonTable.AllowUserToOrderColumns = true;
            this.ComparisonTable.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ComparisonTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ComparisonTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.number,
            this.OpAirline,
            this.flight,
            this.IPCC1Price,
            this.IPCC2Price,
            this.status});
            this.ComparisonTable.Location = new System.Drawing.Point(6, 260);
            this.ComparisonTable.Name = "ComparisonTable";
            this.ComparisonTable.Size = new System.Drawing.Size(1162, 358);
            this.ComparisonTable.TabIndex = 0;
            this.ComparisonTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // number
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.number.DefaultCellStyle = dataGridViewCellStyle1;
            this.number.HeaderText = "number";
            this.number.Name = "number";
            this.number.ReadOnly = true;
            // 
            // OpAirline
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.OpAirline.DefaultCellStyle = dataGridViewCellStyle2;
            this.OpAirline.HeaderText = "OpAirline";
            this.OpAirline.Name = "OpAirline";
            this.OpAirline.ReadOnly = true;
            // 
            // flight
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.flight.DefaultCellStyle = dataGridViewCellStyle3;
            this.flight.HeaderText = "flight";
            this.flight.Name = "flight";
            this.flight.ReadOnly = true;
            this.flight.Width = 500;
            // 
            // IPCC1Price
            // 
            this.IPCC1Price.HeaderText = "IPCC1Price";
            this.IPCC1Price.Name = "IPCC1Price";
            this.IPCC1Price.ReadOnly = true;
            // 
            // IPCC2Price
            // 
            this.IPCC2Price.HeaderText = "IPCC2Price";
            this.IPCC2Price.Name = "IPCC2Price";
            this.IPCC2Price.ReadOnly = true;
            // 
            // status
            // 
            this.status.HeaderText = "status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 649);
            this.Controls.Add(this.tab1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fare Checker v.2.0.6";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tab1.ResumeLayout(false);
            this.FareChecker.ResumeLayout(false);
            this.FareChecker.PerformLayout();
            this.FareComparison.ResumeLayout(false);
            this.FareComparison.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ComparisonTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox origin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox date1;
        private System.Windows.Forms.TextBox date2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox airline;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ADD;
        private System.Windows.Forms.Button Export;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.RichTextBox cmd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button sign;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabControl tab1;
        private System.Windows.Forms.TabPage FareChecker;
        private System.Windows.Forms.TabPage FareComparison;
        private System.Windows.Forms.DataGridView ComparisonTable;
        private System.Windows.Forms.Button CompRun;
        private System.Windows.Forms.Button CompClear;
        private System.Windows.Forms.Button CompAdd;
        private System.Windows.Forms.TextBox CompOri;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox CompDest;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox CompDepart;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox CompReturn;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox CompAirline;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RichTextBox CompCMD;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpAirline;
        private System.Windows.Forms.DataGridViewTextBoxColumn flight;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPCC1Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPCC2Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.TextBox MasterPCC;
        private System.Windows.Forms.TextBox CheckPCC;
        private System.Windows.Forms.Label PCC2;
        private System.Windows.Forms.Label PCC1;
    }
}

