namespace XRT.PowerApps.VSHelper.Dialogs
{
    partial class Config
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config));
            this.tabOptions = new System.Windows.Forms.TabControl();
            this.tabConnection = new System.Windows.Forms.TabPage();
            this.btnTest = new System.Windows.Forms.Button();
            this.lblClientSecret = new System.Windows.Forms.Label();
            this.txtClientSecret = new System.Windows.Forms.TextBox();
            this.txtClientId = new System.Windows.Forms.TextBox();
            this.lblClientId = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.lblURL = new System.Windows.Forms.Label();
            this.tabPublishAll = new System.Windows.Forms.TabPage();
            this.chkAllowNew = new System.Windows.Forms.CheckBox();
            this.lblAllowCreate = new System.Windows.Forms.Label();
            this.tabRetrieveAll = new System.Windows.Forms.TabPage();
            this.lblExamplePath = new System.Windows.Forms.Label();
            this.llOpenSourceRoot = new System.Windows.Forms.LinkLabel();
            this.chkIncludeSolutions = new System.Windows.Forms.CheckBox();
            this.lblIncludeSolutionInPath = new System.Windows.Forms.Label();
            this.lblRootPath = new System.Windows.Forms.Label();
            this.txtRoot = new System.Windows.Forms.TextBox();
            this.grpSolutions = new System.Windows.Forms.GroupBox();
            this.radPublisher = new System.Windows.Forms.RadioButton();
            this.radSolutions = new System.Windows.Forms.RadioButton();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.lblFilterBy = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblExamplePathDetail = new System.Windows.Forms.Label();
            this.tabOptions.SuspendLayout();
            this.tabConnection.SuspendLayout();
            this.tabPublishAll.SuspendLayout();
            this.tabRetrieveAll.SuspendLayout();
            this.grpSolutions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabOptions
            // 
            this.tabOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabOptions.Controls.Add(this.tabConnection);
            this.tabOptions.Controls.Add(this.tabPublishAll);
            this.tabOptions.Controls.Add(this.tabRetrieveAll);
            this.tabOptions.Location = new System.Drawing.Point(1, 3);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.SelectedIndex = 0;
            this.tabOptions.Size = new System.Drawing.Size(581, 513);
            this.tabOptions.TabIndex = 0;
            // 
            // tabConnection
            // 
            this.tabConnection.Controls.Add(this.btnTest);
            this.tabConnection.Controls.Add(this.lblClientSecret);
            this.tabConnection.Controls.Add(this.txtClientSecret);
            this.tabConnection.Controls.Add(this.txtClientId);
            this.tabConnection.Controls.Add(this.lblClientId);
            this.tabConnection.Controls.Add(this.txtURL);
            this.tabConnection.Controls.Add(this.lblURL);
            this.tabConnection.Location = new System.Drawing.Point(4, 22);
            this.tabConnection.Name = "tabConnection";
            this.tabConnection.Padding = new System.Windows.Forms.Padding(3);
            this.tabConnection.Size = new System.Drawing.Size(573, 487);
            this.tabConnection.TabIndex = 0;
            this.tabConnection.Text = "Connection";
            this.tabConnection.UseVisualStyleBackColor = true;
            // 
            // btnTest
            // 
            this.btnTest.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTest.Location = new System.Drawing.Point(4, 182);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(138, 26);
            this.btnTest.TabIndex = 20;
            this.btnTest.Text = "Test Connection";
            this.btnTest.UseVisualStyleBackColor = true;
            // 
            // lblClientSecret
            // 
            this.lblClientSecret.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClientSecret.AutoSize = true;
            this.lblClientSecret.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientSecret.Location = new System.Drawing.Point(4, 120);
            this.lblClientSecret.Name = "lblClientSecret";
            this.lblClientSecret.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblClientSecret.Size = new System.Drawing.Size(85, 27);
            this.lblClientSecret.TabIndex = 18;
            this.lblClientSecret.Text = "Client Secret";
            // 
            // txtClientSecret
            // 
            this.txtClientSecret.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClientSecret.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientSecret.Location = new System.Drawing.Point(4, 151);
            this.txtClientSecret.Name = "txtClientSecret";
            this.txtClientSecret.Size = new System.Drawing.Size(565, 25);
            this.txtClientSecret.TabIndex = 19;
            // 
            // txtClientId
            // 
            this.txtClientId.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClientId.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientId.Location = new System.Drawing.Point(4, 92);
            this.txtClientId.Name = "txtClientId";
            this.txtClientId.Size = new System.Drawing.Size(564, 25);
            this.txtClientId.TabIndex = 17;
            // 
            // lblClientId
            // 
            this.lblClientId.AutoSize = true;
            this.lblClientId.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientId.Location = new System.Drawing.Point(4, 61);
            this.lblClientId.Name = "lblClientId";
            this.lblClientId.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblClientId.Size = new System.Drawing.Size(62, 27);
            this.lblClientId.TabIndex = 16;
            this.lblClientId.Text = "Client ID";
            // 
            // txtURL
            // 
            this.txtURL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtURL.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtURL.Location = new System.Drawing.Point(4, 31);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(561, 25);
            this.txtURL.TabIndex = 15;
            // 
            // lblURL
            // 
            this.lblURL.AutoSize = true;
            this.lblURL.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblURL.Location = new System.Drawing.Point(4, 3);
            this.lblURL.Name = "lblURL";
            this.lblURL.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblURL.Size = new System.Drawing.Size(32, 27);
            this.lblURL.TabIndex = 14;
            this.lblURL.Text = "URL";
            // 
            // tabPublishAll
            // 
            this.tabPublishAll.Controls.Add(this.chkAllowNew);
            this.tabPublishAll.Controls.Add(this.lblAllowCreate);
            this.tabPublishAll.Location = new System.Drawing.Point(4, 22);
            this.tabPublishAll.Name = "tabPublishAll";
            this.tabPublishAll.Padding = new System.Windows.Forms.Padding(3);
            this.tabPublishAll.Size = new System.Drawing.Size(573, 487);
            this.tabPublishAll.TabIndex = 1;
            this.tabPublishAll.Text = "Publish";
            this.tabPublishAll.UseVisualStyleBackColor = true;
            // 
            // chkAllowNew
            // 
            this.chkAllowNew.AutoSize = true;
            this.chkAllowNew.Location = new System.Drawing.Point(3, 34);
            this.chkAllowNew.Name = "chkAllowNew";
            this.chkAllowNew.Size = new System.Drawing.Size(15, 14);
            this.chkAllowNew.TabIndex = 17;
            this.chkAllowNew.UseVisualStyleBackColor = true;
            // 
            // lblAllowCreate
            // 
            this.lblAllowCreate.AutoSize = true;
            this.lblAllowCreate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllowCreate.Location = new System.Drawing.Point(3, 3);
            this.lblAllowCreate.Name = "lblAllowCreate";
            this.lblAllowCreate.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblAllowCreate.Size = new System.Drawing.Size(228, 27);
            this.lblAllowCreate.TabIndex = 16;
            this.lblAllowCreate.Text = "Allow new Resources to be created?";
            // 
            // tabRetrieveAll
            // 
            this.tabRetrieveAll.Controls.Add(this.lblExamplePathDetail);
            this.tabRetrieveAll.Controls.Add(this.lblExamplePath);
            this.tabRetrieveAll.Controls.Add(this.llOpenSourceRoot);
            this.tabRetrieveAll.Controls.Add(this.chkIncludeSolutions);
            this.tabRetrieveAll.Controls.Add(this.lblIncludeSolutionInPath);
            this.tabRetrieveAll.Controls.Add(this.lblRootPath);
            this.tabRetrieveAll.Controls.Add(this.txtRoot);
            this.tabRetrieveAll.Controls.Add(this.grpSolutions);
            this.tabRetrieveAll.Controls.Add(this.txtFilterValue);
            this.tabRetrieveAll.Controls.Add(this.lblFilterBy);
            this.tabRetrieveAll.Location = new System.Drawing.Point(4, 22);
            this.tabRetrieveAll.Name = "tabRetrieveAll";
            this.tabRetrieveAll.Size = new System.Drawing.Size(573, 487);
            this.tabRetrieveAll.TabIndex = 2;
            this.tabRetrieveAll.Text = "Retrieve All";
            this.tabRetrieveAll.UseVisualStyleBackColor = true;
            // 
            // lblExamplePath
            // 
            this.lblExamplePath.AutoSize = true;
            this.lblExamplePath.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExamplePath.Location = new System.Drawing.Point(7, 208);
            this.lblExamplePath.Name = "lblExamplePath";
            this.lblExamplePath.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblExamplePath.Size = new System.Drawing.Size(177, 23);
            this.lblExamplePath.TabIndex = 31;
            this.lblExamplePath.Text = "WebResources will be created at:";
            // 
            // llOpenSourceRoot
            // 
            this.llOpenSourceRoot.AutoSize = true;
            this.llOpenSourceRoot.Location = new System.Drawing.Point(531, 117);
            this.llOpenSourceRoot.Name = "llOpenSourceRoot";
            this.llOpenSourceRoot.Size = new System.Drawing.Size(33, 13);
            this.llOpenSourceRoot.TabIndex = 30;
            this.llOpenSourceRoot.TabStop = true;
            this.llOpenSourceRoot.Text = "Open";
            // 
            // chkIncludeSolutions
            // 
            this.chkIncludeSolutions.AutoSize = true;
            this.chkIncludeSolutions.Location = new System.Drawing.Point(3, 191);
            this.chkIncludeSolutions.Name = "chkIncludeSolutions";
            this.chkIncludeSolutions.Size = new System.Drawing.Size(15, 14);
            this.chkIncludeSolutions.TabIndex = 29;
            this.chkIncludeSolutions.UseVisualStyleBackColor = true;
            // 
            // lblIncludeSolutionInPath
            // 
            this.lblIncludeSolutionInPath.AutoSize = true;
            this.lblIncludeSolutionInPath.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncludeSolutionInPath.Location = new System.Drawing.Point(0, 161);
            this.lblIncludeSolutionInPath.Name = "lblIncludeSolutionInPath";
            this.lblIncludeSolutionInPath.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblIncludeSolutionInPath.Size = new System.Drawing.Size(155, 27);
            this.lblIncludeSolutionInPath.TabIndex = 28;
            this.lblIncludeSolutionInPath.Text = "Include Solution Name?";
            // 
            // lblRootPath
            // 
            this.lblRootPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRootPath.AutoSize = true;
            this.lblRootPath.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRootPath.Location = new System.Drawing.Point(3, 103);
            this.lblRootPath.Name = "lblRootPath";
            this.lblRootPath.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblRootPath.Size = new System.Drawing.Size(82, 27);
            this.lblRootPath.TabIndex = 25;
            this.lblRootPath.Text = "Source Root";
            // 
            // txtRoot
            // 
            this.txtRoot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRoot.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoot.Location = new System.Drawing.Point(3, 133);
            this.txtRoot.Name = "txtRoot";
            this.txtRoot.Size = new System.Drawing.Size(565, 25);
            this.txtRoot.TabIndex = 26;
            // 
            // grpSolutions
            // 
            this.grpSolutions.Controls.Add(this.radPublisher);
            this.grpSolutions.Controls.Add(this.radSolutions);
            this.grpSolutions.Location = new System.Drawing.Point(83, 2);
            this.grpSolutions.Name = "grpSolutions";
            this.grpSolutions.Size = new System.Drawing.Size(170, 30);
            this.grpSolutions.TabIndex = 22;
            this.grpSolutions.TabStop = false;
            // 
            // radPublisher
            // 
            this.radPublisher.AutoSize = true;
            this.radPublisher.Location = new System.Drawing.Point(91, 9);
            this.radPublisher.Name = "radPublisher";
            this.radPublisher.Size = new System.Drawing.Size(73, 17);
            this.radPublisher.TabIndex = 23;
            this.radPublisher.TabStop = true;
            this.radPublisher.Text = "Publishers";
            this.radPublisher.UseVisualStyleBackColor = true;
            // 
            // radSolutions
            // 
            this.radSolutions.AutoSize = true;
            this.radSolutions.Location = new System.Drawing.Point(3, 9);
            this.radSolutions.Name = "radSolutions";
            this.radSolutions.Size = new System.Drawing.Size(68, 17);
            this.radSolutions.TabIndex = 22;
            this.radSolutions.TabStop = true;
            this.radSolutions.Text = "Solutions";
            this.radSolutions.UseVisualStyleBackColor = true;
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilterValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterValue.Location = new System.Drawing.Point(3, 34);
            this.txtFilterValue.Multiline = true;
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(561, 66);
            this.txtFilterValue.TabIndex = 17;
            // 
            // lblFilterBy
            // 
            this.lblFilterBy.AutoSize = true;
            this.lblFilterBy.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterBy.Location = new System.Drawing.Point(3, 0);
            this.lblFilterBy.Name = "lblFilterBy";
            this.lblFilterBy.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblFilterBy.Size = new System.Drawing.Size(59, 27);
            this.lblFilterBy.TabIndex = 16;
            this.lblFilterBy.Text = "Filter By";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(440, 523);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(138, 26);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // lblExamplePathDetail
            // 
            this.lblExamplePathDetail.AutoSize = true;
            this.lblExamplePathDetail.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExamplePathDetail.Location = new System.Drawing.Point(7, 235);
            this.lblExamplePathDetail.Name = "lblExamplePathDetail";
            this.lblExamplePathDetail.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblExamplePathDetail.Size = new System.Drawing.Size(0, 23);
            this.lblExamplePathDetail.TabIndex = 32;
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabOptions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "Config";
            this.Text = "PowerApps VS Helper Config";
            this.tabOptions.ResumeLayout(false);
            this.tabConnection.ResumeLayout(false);
            this.tabConnection.PerformLayout();
            this.tabPublishAll.ResumeLayout(false);
            this.tabPublishAll.PerformLayout();
            this.tabRetrieveAll.ResumeLayout(false);
            this.tabRetrieveAll.PerformLayout();
            this.grpSolutions.ResumeLayout(false);
            this.grpSolutions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabOptions;
        private System.Windows.Forms.TabPage tabConnection;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lblClientSecret;
        private System.Windows.Forms.TextBox txtClientSecret;
        private System.Windows.Forms.TextBox txtClientId;
        private System.Windows.Forms.Label lblClientId;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label lblURL;
        private System.Windows.Forms.TabPage tabPublishAll;
        private System.Windows.Forms.TabPage tabRetrieveAll;
        private System.Windows.Forms.CheckBox chkAllowNew;
        private System.Windows.Forms.Label lblAllowCreate;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Label lblFilterBy;
        private System.Windows.Forms.GroupBox grpSolutions;
        private System.Windows.Forms.RadioButton radPublisher;
        private System.Windows.Forms.RadioButton radSolutions;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkIncludeSolutions;
        private System.Windows.Forms.Label lblIncludeSolutionInPath;
        private System.Windows.Forms.Label lblRootPath;
        private System.Windows.Forms.TextBox txtRoot;
        private System.Windows.Forms.LinkLabel llOpenSourceRoot;
        private System.Windows.Forms.Label lblExamplePath;
        private System.Windows.Forms.Label lblExamplePathDetail;
    }
}