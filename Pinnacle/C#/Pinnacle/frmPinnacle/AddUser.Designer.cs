namespace frmPinnacle
{
    partial class AddUser
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabConsumerInfo = new System.Windows.Forms.TabControl();
            this.tabConsumer = new System.Windows.Forms.TabPage();
            this.butCancel = new System.Windows.Forms.Button();
            this.butAdd = new System.Windows.Forms.Button();
            this.grpDates = new System.Windows.Forms.GroupBox();
            this.dtIntake = new System.Windows.Forms.DateTimePicker();
            this.dtReferral = new System.Windows.Forms.DateTimePicker();
            this.lblIntake = new System.Windows.Forms.Label();
            this.lblReferral = new System.Windows.Forms.Label();
            this.txtUnits = new System.Windows.Forms.TextBox();
            this.lblUnits = new System.Windows.Forms.Label();
            this.cmbFunding = new System.Windows.Forms.ComboBox();
            this.lblFunding = new System.Windows.Forms.Label();
            this.lblService = new System.Windows.Forms.Label();
            this.lblDisability = new System.Windows.Forms.Label();
            this.cmbDisability = new System.Windows.Forms.ComboBox();
            this.cmbService = new System.Windows.Forms.ComboBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLast = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirst = new System.Windows.Forms.TextBox();
            this.lblVesid = new System.Windows.Forms.Label();
            this.txtVesid = new System.Windows.Forms.TextBox();
            this.txtAVR = new System.Windows.Forms.MaskedTextBox();
            this.txtSSN = new System.Windows.Forms.MaskedTextBox();
            this.lblAv = new System.Windows.Forms.Label();
            this.lblSSN = new System.Windows.Forms.Label();
            this.tabAssigned = new System.Windows.Forms.TabPage();
            this.butRemoveStaff = new System.Windows.Forms.Button();
            this.butAssign = new System.Windows.Forms.Button();
            this.butAddStaff = new System.Windows.Forms.Button();
            this.lstStaff = new System.Windows.Forms.ListBox();
            this.cmbCounselor = new System.Windows.Forms.ComboBox();
            this.lblCounselor = new System.Windows.Forms.Label();
            this.cmbStaff = new System.Windows.Forms.ComboBox();
            this.lblStaff = new System.Windows.Forms.Label();
            this.tabVoucher = new System.Windows.Forms.TabPage();
            this.grpVoucher = new System.Windows.Forms.GroupBox();
            this.butAddVoucher = new System.Windows.Forms.Button();
            this.grdVouchers = new System.Windows.Forms.DataGridView();
            this.contextVoucher = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dtVoucherStart = new System.Windows.Forms.MaskedTextBox();
            this.dtVoucherEnd = new System.Windows.Forms.MaskedTextBox();
            this.lblVoucherEnd = new System.Windows.Forms.Label();
            this.lblVoucherStart = new System.Windows.Forms.Label();
            this.tabConsumerInfo.SuspendLayout();
            this.tabConsumer.SuspendLayout();
            this.grpDates.SuspendLayout();
            this.tabAssigned.SuspendLayout();
            this.tabVoucher.SuspendLayout();
            this.grpVoucher.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVouchers)).BeginInit();
            this.contextVoucher.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabConsumerInfo
            // 
            this.tabConsumerInfo.Controls.Add(this.tabConsumer);
            this.tabConsumerInfo.Controls.Add(this.tabAssigned);
            this.tabConsumerInfo.Controls.Add(this.tabVoucher);
            this.tabConsumerInfo.Location = new System.Drawing.Point(3, 3);
            this.tabConsumerInfo.Name = "tabConsumerInfo";
            this.tabConsumerInfo.SelectedIndex = 0;
            this.tabConsumerInfo.Size = new System.Drawing.Size(493, 354);
            this.tabConsumerInfo.TabIndex = 28;
            this.tabConsumerInfo.Click += new System.EventHandler(this.tabConsumerInfo_Click);
            this.tabConsumerInfo.Enter += new System.EventHandler(this.tabConsumerInfo_Enter);
            // 
            // tabConsumer
            // 
            this.tabConsumer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabConsumer.Controls.Add(this.butCancel);
            this.tabConsumer.Controls.Add(this.butAdd);
            this.tabConsumer.Controls.Add(this.grpDates);
            this.tabConsumer.Controls.Add(this.txtUnits);
            this.tabConsumer.Controls.Add(this.lblUnits);
            this.tabConsumer.Controls.Add(this.cmbFunding);
            this.tabConsumer.Controls.Add(this.lblFunding);
            this.tabConsumer.Controls.Add(this.lblService);
            this.tabConsumer.Controls.Add(this.lblDisability);
            this.tabConsumer.Controls.Add(this.cmbDisability);
            this.tabConsumer.Controls.Add(this.cmbService);
            this.tabConsumer.Controls.Add(this.lblLastName);
            this.tabConsumer.Controls.Add(this.txtLast);
            this.tabConsumer.Controls.Add(this.lblFirstName);
            this.tabConsumer.Controls.Add(this.txtFirst);
            this.tabConsumer.Controls.Add(this.lblVesid);
            this.tabConsumer.Controls.Add(this.txtVesid);
            this.tabConsumer.Controls.Add(this.txtAVR);
            this.tabConsumer.Controls.Add(this.txtSSN);
            this.tabConsumer.Controls.Add(this.lblAv);
            this.tabConsumer.Controls.Add(this.lblSSN);
            this.tabConsumer.Location = new System.Drawing.Point(4, 22);
            this.tabConsumer.Name = "tabConsumer";
            this.tabConsumer.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsumer.Size = new System.Drawing.Size(485, 328);
            this.tabConsumer.TabIndex = 0;
            this.tabConsumer.Text = "Consumer";
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(273, 290);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(105, 23);
            this.butCancel.TabIndex = 48;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butAdd
            // 
            this.butAdd.Location = new System.Drawing.Point(108, 290);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(105, 23);
            this.butAdd.TabIndex = 47;
            this.butAdd.Text = "Add Consumer";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // grpDates
            // 
            this.grpDates.Controls.Add(this.dtIntake);
            this.grpDates.Controls.Add(this.dtReferral);
            this.grpDates.Controls.Add(this.lblIntake);
            this.grpDates.Controls.Add(this.lblReferral);
            this.grpDates.Location = new System.Drawing.Point(29, 190);
            this.grpDates.Name = "grpDates";
            this.grpDates.Size = new System.Drawing.Size(430, 59);
            this.grpDates.TabIndex = 46;
            this.grpDates.TabStop = false;
            this.grpDates.Text = "Dates";
            // 
            // dtIntake
            // 
            this.dtIntake.CustomFormat = "MM/dd/yyyy";
            this.dtIntake.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtIntake.Location = new System.Drawing.Point(270, 23);
            this.dtIntake.Name = "dtIntake";
            this.dtIntake.ShowCheckBox = true;
            this.dtIntake.Size = new System.Drawing.Size(102, 20);
            this.dtIntake.TabIndex = 13;
            // 
            // dtReferral
            // 
            this.dtReferral.CustomFormat = "MM/dd/yyyy";
            this.dtReferral.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtReferral.Location = new System.Drawing.Point(79, 23);
            this.dtReferral.Name = "dtReferral";
            this.dtReferral.ShowCheckBox = true;
            this.dtReferral.Size = new System.Drawing.Size(116, 20);
            this.dtReferral.TabIndex = 12;
            // 
            // lblIntake
            // 
            this.lblIntake.AutoSize = true;
            this.lblIntake.Location = new System.Drawing.Point(227, 28);
            this.lblIntake.Name = "lblIntake";
            this.lblIntake.Size = new System.Drawing.Size(37, 13);
            this.lblIntake.TabIndex = 11;
            this.lblIntake.Text = "Intake";
            // 
            // lblReferral
            // 
            this.lblReferral.AutoSize = true;
            this.lblReferral.Location = new System.Drawing.Point(26, 28);
            this.lblReferral.Name = "lblReferral";
            this.lblReferral.Size = new System.Drawing.Size(44, 13);
            this.lblReferral.TabIndex = 9;
            this.lblReferral.Text = "Referral";
            // 
            // txtUnits
            // 
            this.txtUnits.Location = new System.Drawing.Point(391, 148);
            this.txtUnits.Name = "txtUnits";
            this.txtUnits.Size = new System.Drawing.Size(47, 20);
            this.txtUnits.TabIndex = 43;
            this.txtUnits.Tag = "NotRequired";
            // 
            // lblUnits
            // 
            this.lblUnits.AutoSize = true;
            this.lblUnits.Location = new System.Drawing.Point(351, 152);
            this.lblUnits.Name = "lblUnits";
            this.lblUnits.Size = new System.Drawing.Size(31, 13);
            this.lblUnits.TabIndex = 45;
            this.lblUnits.Text = "Units";
            // 
            // cmbFunding
            // 
            this.cmbFunding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFunding.FormattingEnabled = true;
            this.cmbFunding.Location = new System.Drawing.Point(80, 148);
            this.cmbFunding.Name = "cmbFunding";
            this.cmbFunding.Size = new System.Drawing.Size(215, 21);
            this.cmbFunding.TabIndex = 42;
            this.cmbFunding.Tag = "NotRequired";
            // 
            // lblFunding
            // 
            this.lblFunding.AutoSize = true;
            this.lblFunding.Location = new System.Drawing.Point(26, 152);
            this.lblFunding.Name = "lblFunding";
            this.lblFunding.Size = new System.Drawing.Size(45, 13);
            this.lblFunding.TabIndex = 44;
            this.lblFunding.Text = "Funding";
            // 
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.Location = new System.Drawing.Point(335, 107);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(43, 13);
            this.lblService.TabIndex = 41;
            this.lblService.Text = "Service";
            // 
            // lblDisability
            // 
            this.lblDisability.AutoSize = true;
            this.lblDisability.Location = new System.Drawing.Point(26, 107);
            this.lblDisability.Name = "lblDisability";
            this.lblDisability.Size = new System.Drawing.Size(48, 13);
            this.lblDisability.TabIndex = 40;
            this.lblDisability.Text = "Disability";
            // 
            // cmbDisability
            // 
            this.cmbDisability.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDisability.FormattingEnabled = true;
            this.cmbDisability.Location = new System.Drawing.Point(80, 104);
            this.cmbDisability.Name = "cmbDisability";
            this.cmbDisability.Size = new System.Drawing.Size(215, 21);
            this.cmbDisability.TabIndex = 38;
            // 
            // cmbService
            // 
            this.cmbService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbService.FormattingEnabled = true;
            this.cmbService.Location = new System.Drawing.Point(388, 104);
            this.cmbService.Name = "cmbService";
            this.cmbService.Size = new System.Drawing.Size(50, 21);
            this.cmbService.TabIndex = 39;
            this.cmbService.Tag = "";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(234, 73);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(58, 13);
            this.lblLastName.TabIndex = 36;
            this.lblLastName.Text = "Last Name";
            // 
            // txtLast
            // 
            this.txtLast.Location = new System.Drawing.Point(297, 70);
            this.txtLast.MaxLength = 55;
            this.txtLast.Name = "txtLast";
            this.txtLast.Size = new System.Drawing.Size(164, 20);
            this.txtLast.TabIndex = 37;
            this.txtLast.Tag = "LastName";
            this.txtLast.Leave += new System.EventHandler(this.txtLast_Leave);
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(17, 73);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(57, 13);
            this.lblFirstName.TabIndex = 34;
            this.lblFirstName.Text = "First Name";
            // 
            // txtFirst
            // 
            this.txtFirst.Location = new System.Drawing.Point(80, 70);
            this.txtFirst.MaxLength = 25;
            this.txtFirst.Name = "txtFirst";
            this.txtFirst.Size = new System.Drawing.Size(144, 20);
            this.txtFirst.TabIndex = 35;
            this.txtFirst.Tag = "FirstName";
            this.txtFirst.Leave += new System.EventHandler(this.txtFirst_Leave);
            // 
            // lblVesid
            // 
            this.lblVesid.AutoSize = true;
            this.lblVesid.Location = new System.Drawing.Point(339, 28);
            this.lblVesid.Name = "lblVesid";
            this.lblVesid.Size = new System.Drawing.Size(39, 13);
            this.lblVesid.TabIndex = 33;
            this.lblVesid.Text = "VESID";
            // 
            // txtVesid
            // 
            this.txtVesid.Location = new System.Drawing.Point(385, 25);
            this.txtVesid.MaxLength = 6;
            this.txtVesid.Name = "txtVesid";
            this.txtVesid.Size = new System.Drawing.Size(50, 20);
            this.txtVesid.TabIndex = 30;
            // 
            // txtAVR
            // 
            this.txtAVR.Location = new System.Drawing.Point(218, 25);
            this.txtAVR.Mask = "0000000";
            this.txtAVR.Name = "txtAVR";
            this.txtAVR.Size = new System.Drawing.Size(50, 20);
            this.txtAVR.TabIndex = 29;
            this.txtAVR.Tag = "AVR";
            // 
            // txtSSN
            // 
            this.txtSSN.Location = new System.Drawing.Point(53, 25);
            this.txtSSN.Mask = "000-00-0000";
            this.txtSSN.Name = "txtSSN";
            this.txtSSN.Size = new System.Drawing.Size(68, 20);
            this.txtSSN.TabIndex = 28;
            this.txtSSN.Tag = "SSN";
            // 
            // lblAv
            // 
            this.lblAv.AutoSize = true;
            this.lblAv.Location = new System.Drawing.Point(181, 28);
            this.lblAv.Name = "lblAv";
            this.lblAv.Size = new System.Drawing.Size(31, 13);
            this.lblAv.TabIndex = 32;
            this.lblAv.Text = "AV #";
            // 
            // lblSSN
            // 
            this.lblSSN.AutoSize = true;
            this.lblSSN.Location = new System.Drawing.Point(14, 28);
            this.lblSSN.Name = "lblSSN";
            this.lblSSN.Size = new System.Drawing.Size(29, 13);
            this.lblSSN.TabIndex = 31;
            this.lblSSN.Text = "SSN";
            // 
            // tabAssigned
            // 
            this.tabAssigned.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabAssigned.Controls.Add(this.butRemoveStaff);
            this.tabAssigned.Controls.Add(this.butAssign);
            this.tabAssigned.Controls.Add(this.butAddStaff);
            this.tabAssigned.Controls.Add(this.lstStaff);
            this.tabAssigned.Controls.Add(this.cmbCounselor);
            this.tabAssigned.Controls.Add(this.lblCounselor);
            this.tabAssigned.Controls.Add(this.cmbStaff);
            this.tabAssigned.Controls.Add(this.lblStaff);
            this.tabAssigned.Location = new System.Drawing.Point(4, 22);
            this.tabAssigned.Name = "tabAssigned";
            this.tabAssigned.Padding = new System.Windows.Forms.Padding(3);
            this.tabAssigned.Size = new System.Drawing.Size(485, 328);
            this.tabAssigned.TabIndex = 1;
            this.tabAssigned.Text = "Assigned To";
            // 
            // butRemoveStaff
            // 
            this.butRemoveStaff.Location = new System.Drawing.Point(240, 70);
            this.butRemoveStaff.Name = "butRemoveStaff";
            this.butRemoveStaff.Size = new System.Drawing.Size(35, 23);
            this.butRemoveStaff.TabIndex = 28;
            this.butRemoveStaff.Text = "<-";
            this.butRemoveStaff.UseVisualStyleBackColor = true;
            this.butRemoveStaff.Click += new System.EventHandler(this.butRemoveStaff_Click);
            // 
            // butAssign
            // 
            this.butAssign.Location = new System.Drawing.Point(213, 267);
            this.butAssign.Name = "butAssign";
            this.butAssign.Size = new System.Drawing.Size(75, 23);
            this.butAssign.TabIndex = 27;
            this.butAssign.Text = "Assign";
            this.butAssign.UseVisualStyleBackColor = true;
            this.butAssign.Click += new System.EventHandler(this.butAssign_Click);
            // 
            // butAddStaff
            // 
            this.butAddStaff.Location = new System.Drawing.Point(240, 24);
            this.butAddStaff.Name = "butAddStaff";
            this.butAddStaff.Size = new System.Drawing.Size(35, 23);
            this.butAddStaff.TabIndex = 26;
            this.butAddStaff.Text = "->";
            this.butAddStaff.UseVisualStyleBackColor = true;
            this.butAddStaff.Click += new System.EventHandler(this.butAddStaff_Click);
            // 
            // lstStaff
            // 
            this.lstStaff.FormattingEnabled = true;
            this.lstStaff.Location = new System.Drawing.Point(294, 24);
            this.lstStaff.Name = "lstStaff";
            this.lstStaff.Size = new System.Drawing.Size(164, 69);
            this.lstStaff.TabIndex = 25;
            // 
            // cmbCounselor
            // 
            this.cmbCounselor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCounselor.FormattingEnabled = true;
            this.cmbCounselor.Location = new System.Drawing.Point(75, 112);
            this.cmbCounselor.Name = "cmbCounselor";
            this.cmbCounselor.Size = new System.Drawing.Size(146, 21);
            this.cmbCounselor.TabIndex = 22;
            this.cmbCounselor.Tag = "NotRequired";
            // 
            // lblCounselor
            // 
            this.lblCounselor.AutoSize = true;
            this.lblCounselor.Location = new System.Drawing.Point(14, 115);
            this.lblCounselor.Name = "lblCounselor";
            this.lblCounselor.Size = new System.Drawing.Size(54, 13);
            this.lblCounselor.TabIndex = 24;
            this.lblCounselor.Text = "Counselor";
            // 
            // cmbStaff
            // 
            this.cmbStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStaff.FormattingEnabled = true;
            this.cmbStaff.Location = new System.Drawing.Point(75, 24);
            this.cmbStaff.Name = "cmbStaff";
            this.cmbStaff.Size = new System.Drawing.Size(146, 21);
            this.cmbStaff.TabIndex = 21;
            this.cmbStaff.Tag = "NotRequired";
            // 
            // lblStaff
            // 
            this.lblStaff.AutoSize = true;
            this.lblStaff.Location = new System.Drawing.Point(36, 27);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(29, 13);
            this.lblStaff.TabIndex = 23;
            this.lblStaff.Text = "Staff";
            // 
            // tabVoucher
            // 
            this.tabVoucher.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabVoucher.Controls.Add(this.grpVoucher);
            this.tabVoucher.Location = new System.Drawing.Point(4, 22);
            this.tabVoucher.Name = "tabVoucher";
            this.tabVoucher.Size = new System.Drawing.Size(485, 328);
            this.tabVoucher.TabIndex = 2;
            this.tabVoucher.Text = "Vouchers";
            // 
            // grpVoucher
            // 
            this.grpVoucher.Controls.Add(this.butAddVoucher);
            this.grpVoucher.Controls.Add(this.grdVouchers);
            this.grpVoucher.Controls.Add(this.dtVoucherStart);
            this.grpVoucher.Controls.Add(this.dtVoucherEnd);
            this.grpVoucher.Controls.Add(this.lblVoucherEnd);
            this.grpVoucher.Controls.Add(this.lblVoucherStart);
            this.grpVoucher.Location = new System.Drawing.Point(15, 14);
            this.grpVoucher.Name = "grpVoucher";
            this.grpVoucher.Size = new System.Drawing.Size(430, 268);
            this.grpVoucher.TabIndex = 11;
            this.grpVoucher.TabStop = false;
            // 
            // butAddVoucher
            // 
            this.butAddVoucher.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butAddVoucher.Location = new System.Drawing.Point(168, 215);
            this.butAddVoucher.Name = "butAddVoucher";
            this.butAddVoucher.Size = new System.Drawing.Size(105, 30);
            this.butAddVoucher.TabIndex = 24;
            this.butAddVoucher.Text = "Add Voucher";
            this.butAddVoucher.UseVisualStyleBackColor = true;
            this.butAddVoucher.Click += new System.EventHandler(this.butAddVoucher_Click);
            // 
            // grdVouchers
            // 
            this.grdVouchers.AllowUserToAddRows = false;
            this.grdVouchers.AllowUserToDeleteRows = false;
            this.grdVouchers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVouchers.ContextMenuStrip = this.contextVoucher;
            this.grdVouchers.Location = new System.Drawing.Point(155, 50);
            this.grdVouchers.Name = "grdVouchers";
            this.grdVouchers.ReadOnly = true;
            this.grdVouchers.RowHeadersVisible = false;
            this.grdVouchers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdVouchers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdVouchers.Size = new System.Drawing.Size(145, 86);
            this.grdVouchers.TabIndex = 22;
            // 
            // contextVoucher
            // 
            this.contextVoucher.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextVoucher.Name = "contextVoucher";
            this.contextVoucher.Size = new System.Drawing.Size(108, 26);
            this.contextVoucher.Click += new System.EventHandler(this.contextVoucher_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // dtVoucherStart
            // 
            this.dtVoucherStart.Location = new System.Drawing.Point(139, 154);
            this.dtVoucherStart.Mask = "00/00/0000";
            this.dtVoucherStart.Name = "dtVoucherStart";
            this.dtVoucherStart.Size = new System.Drawing.Size(70, 20);
            this.dtVoucherStart.TabIndex = 0;
            this.dtVoucherStart.ValidatingType = typeof(System.DateTime);
            // 
            // dtVoucherEnd
            // 
            this.dtVoucherEnd.Location = new System.Drawing.Point(262, 154);
            this.dtVoucherEnd.Mask = "00/00/0000";
            this.dtVoucherEnd.Name = "dtVoucherEnd";
            this.dtVoucherEnd.Size = new System.Drawing.Size(68, 20);
            this.dtVoucherEnd.TabIndex = 1;
            this.dtVoucherEnd.ValidatingType = typeof(System.DateTime);
            // 
            // lblVoucherEnd
            // 
            this.lblVoucherEnd.AutoSize = true;
            this.lblVoucherEnd.Location = new System.Drawing.Point(227, 157);
            this.lblVoucherEnd.Name = "lblVoucherEnd";
            this.lblVoucherEnd.Size = new System.Drawing.Size(29, 13);
            this.lblVoucherEnd.TabIndex = 21;
            this.lblVoucherEnd.Text = "End:";
            // 
            // lblVoucherStart
            // 
            this.lblVoucherStart.AutoSize = true;
            this.lblVoucherStart.Location = new System.Drawing.Point(101, 157);
            this.lblVoucherStart.Name = "lblVoucherStart";
            this.lblVoucherStart.Size = new System.Drawing.Size(32, 13);
            this.lblVoucherStart.TabIndex = 20;
            this.lblVoucherStart.Text = "Start:";
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabConsumerInfo);
            this.Name = "AddUser";
            this.Size = new System.Drawing.Size(499, 357);
            this.tabConsumerInfo.ResumeLayout(false);
            this.tabConsumer.ResumeLayout(false);
            this.tabConsumer.PerformLayout();
            this.grpDates.ResumeLayout(false);
            this.grpDates.PerformLayout();
            this.tabAssigned.ResumeLayout(false);
            this.tabAssigned.PerformLayout();
            this.tabVoucher.ResumeLayout(false);
            this.grpVoucher.ResumeLayout(false);
            this.grpVoucher.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVouchers)).EndInit();
            this.contextVoucher.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabConsumerInfo;
        private System.Windows.Forms.TabPage tabConsumer;
        private System.Windows.Forms.TextBox txtUnits;
        private System.Windows.Forms.Label lblUnits;
        private System.Windows.Forms.ComboBox cmbFunding;
        private System.Windows.Forms.Label lblFunding;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.Label lblDisability;
        private System.Windows.Forms.ComboBox cmbDisability;
        private System.Windows.Forms.ComboBox cmbService;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLast;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirst;
        private System.Windows.Forms.Label lblVesid;
        private System.Windows.Forms.TextBox txtVesid;
        private System.Windows.Forms.MaskedTextBox txtAVR;
        private System.Windows.Forms.MaskedTextBox txtSSN;
        private System.Windows.Forms.Label lblAv;
        private System.Windows.Forms.Label lblSSN;
        private System.Windows.Forms.TabPage tabAssigned;
        private System.Windows.Forms.Button butAddStaff;
        private System.Windows.Forms.ListBox lstStaff;
        private System.Windows.Forms.ComboBox cmbCounselor;
        private System.Windows.Forms.Label lblCounselor;
        private System.Windows.Forms.ComboBox cmbStaff;
        private System.Windows.Forms.Label lblStaff;
        private System.Windows.Forms.GroupBox grpDates;
        private System.Windows.Forms.Label lblIntake;
        private System.Windows.Forms.Label lblReferral;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.Button butAssign;
        private System.Windows.Forms.TabPage tabVoucher;
        private System.Windows.Forms.GroupBox grpVoucher;
        private System.Windows.Forms.Button butAddVoucher;
        private System.Windows.Forms.DataGridView grdVouchers;
        private System.Windows.Forms.MaskedTextBox dtVoucherStart;
        private System.Windows.Forms.MaskedTextBox dtVoucherEnd;
        private System.Windows.Forms.Label lblVoucherEnd;
        private System.Windows.Forms.Label lblVoucherStart;
        private System.Windows.Forms.Button butRemoveStaff;
        private System.Windows.Forms.ContextMenuStrip contextVoucher;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dtIntake;
        private System.Windows.Forms.DateTimePicker dtReferral;
    }
}
