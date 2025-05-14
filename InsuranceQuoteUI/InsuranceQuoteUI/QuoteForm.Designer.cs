namespace InsuranceQuoteUI
{
    partial class QuoteForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTerm = new System.Windows.Forms.Label();
            this.lblSumInsured = new System.Windows.Forms.Label();
            this.numTerm = new System.Windows.Forms.NumericUpDown();
            this.numSumInsured = new System.Windows.Forms.NumericUpDown();
            this.btnGetQuote = new System.Windows.Forms.Button();
            this.lblQuoteId = new System.Windows.Forms.Label();
            this.txtQuoteId = new System.Windows.Forms.TextBox();
            this.btnRetrieveQuote = new System.Windows.Forms.Button();
            this.dgvQuotes = new System.Windows.Forms.DataGridView();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlQuoteDetails = new System.Windows.Forms.Panel();
            this.lblQuoteDetails = new System.Windows.Forms.Label();
            this.lblDetailsTerm = new System.Windows.Forms.Label();
            this.lblDetailsSumInsured = new System.Windows.Forms.Label();
            this.lblDetailsCreatedAt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numTerm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSumInsured)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuotes)).BeginInit();
            this.pnlQuoteDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(288, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Insurance Premium Quoting";
            // 
            // lblTerm
            // 
            this.lblTerm.AutoSize = true;
            this.lblTerm.Location = new System.Drawing.Point(14, 64);
            this.lblTerm.Name = "lblTerm";
            this.lblTerm.Size = new System.Drawing.Size(101, 15);
            this.lblTerm.TabIndex = 1;
            this.lblTerm.Text = "Term (in months):";
            // 
            // lblSumInsured
            // 
            this.lblSumInsured.AutoSize = true;
            this.lblSumInsured.Location = new System.Drawing.Point(14, 93);
            this.lblSumInsured.Name = "lblSumInsured";
            this.lblSumInsured.Size = new System.Drawing.Size(79, 15);
            this.lblSumInsured.TabIndex = 2;
            this.lblSumInsured.Text = "Sum Insured:";
            // 
            // numTerm
            // 
            this.numTerm.Location = new System.Drawing.Point(121, 62);
            this.numTerm.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numTerm.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTerm.Name = "numTerm";
            this.numTerm.Size = new System.Drawing.Size(120, 23);
            this.numTerm.TabIndex = 3;
            this.numTerm.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // numSumInsured
            // 
            this.numSumInsured.DecimalPlaces = 2;
            this.numSumInsured.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSumInsured.Location = new System.Drawing.Point(121, 91);
            this.numSumInsured.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numSumInsured.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSumInsured.Name = "numSumInsured";
            this.numSumInsured.Size = new System.Drawing.Size(120, 23);
            this.numSumInsured.TabIndex = 4;
            this.numSumInsured.ThousandsSeparator = true;
            this.numSumInsured.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            // 
            // btnGetQuote
            // 
            this.btnGetQuote.Location = new System.Drawing.Point(121, 120);
            this.btnGetQuote.Name = "btnGetQuote";
            this.btnGetQuote.Size = new System.Drawing.Size(120, 27);
            this.btnGetQuote.TabIndex = 5;
            this.btnGetQuote.Text = "Get Quote";
            this.btnGetQuote.UseVisualStyleBackColor = true;
            this.btnGetQuote.Click += new System.EventHandler(this.btnGetQuote_Click);
            // 
            // lblQuoteId
            // 
            this.lblQuoteId.AutoSize = true;
            this.lblQuoteId.Location = new System.Drawing.Point(14, 165);
            this.lblQuoteId.Name = "lblQuoteId";
            this.lblQuoteId.Size = new System.Drawing.Size(58, 15);
            this.lblQuoteId.TabIndex = 6;
            this.lblQuoteId.Text = "Quote ID:";
            // 
            // txtQuoteId
            // 
            this.txtQuoteId.Location = new System.Drawing.Point(121, 162);
            this.txtQuoteId.Name = "txtQuoteId";
            this.txtQuoteId.Size = new System.Drawing.Size(323, 23);
            this.txtQuoteId.TabIndex = 7;
            // 
            // btnRetrieveQuote
            // 
            this.btnRetrieveQuote.Location = new System.Drawing.Point(121, 191);
            this.btnRetrieveQuote.Name = "btnRetrieveQuote";
            this.btnRetrieveQuote.Size = new System.Drawing.Size(120, 27);
            this.btnRetrieveQuote.TabIndex = 8;
            this.btnRetrieveQuote.Text = "Retrieve Quote";
            this.btnRetrieveQuote.UseVisualStyleBackColor = true;
            this.btnRetrieveQuote.Click += new System.EventHandler(this.btnRetrieveQuote_Click);
            // 
            // dgvQuotes
            // 
            this.dgvQuotes.AllowUserToAddRows = false;
            this.dgvQuotes.AllowUserToDeleteRows = false;
            this.dgvQuotes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuotes.Location = new System.Drawing.Point(12, 367);
            this.dgvQuotes.Name = "dgvQuotes";
            this.dgvQuotes.ReadOnly = true;
            this.dgvQuotes.RowTemplate.Height = 25;
            this.dgvQuotes.Size = new System.Drawing.Size(507, 150);
            this.dgvQuotes.TabIndex = 9;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 534);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 15);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Status:";
            // 
            // pnlQuoteDetails
            // 
            this.pnlQuoteDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlQuoteDetails.Controls.Add(this.lblDetailsCreatedAt);
            this.pnlQuoteDetails.Controls.Add(this.lblDetailsSumInsured);
            this.pnlQuoteDetails.Controls.Add(this.lblDetailsTerm);
            this.pnlQuoteDetails.Controls.Add(this.lblQuoteDetails);
            this.pnlQuoteDetails.Location = new System.Drawing.Point(14, 233);
            this.pnlQuoteDetails.Name = "pnlQuoteDetails";
            this.pnlQuoteDetails.Size = new System.Drawing.Size(505, 119);
            this.pnlQuoteDetails.TabIndex = 11;
            // 
            // lblQuoteDetails
            // 
            this.lblQuoteDetails.AutoSize = true;
            this.lblQuoteDetails.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblQuoteDetails.Location = new System.Drawing.Point(3, 0);
            this.lblQuoteDetails.Name = "lblQuoteDetails";
            this.lblQuoteDetails.Size = new System.Drawing.Size(117, 21);
            this.lblQuoteDetails.TabIndex = 0;
            this.lblQuoteDetails.Text = "Quote Details:";
            // 
            // lblDetailsTerm
            // 
            this.lblDetailsTerm.AutoSize = true;
            this.lblDetailsTerm.Location = new System.Drawing.Point(12, 39);
            this.lblDetailsTerm.Name = "lblDetailsTerm";
            this.lblDetailsTerm.Size = new System.Drawing.Size(39, 15);
            this.lblDetailsTerm.TabIndex = 1;
            this.lblDetailsTerm.Text = "Term: ";
            // 
            // lblDetailsSumInsured
            // 
            this.lblDetailsSumInsured.AutoSize = true;
            this.lblDetailsSumInsured.Location = new System.Drawing.Point(12, 63);
            this.lblDetailsSumInsured.Name = "lblDetailsSumInsured";
            this.lblDetailsSumInsured.Size = new System.Drawing.Size(83, 15);
            this.lblDetailsSumInsured.TabIndex = 2;
            this.lblDetailsSumInsured.Text = "Sum Insured: ";
            // 
            // lblDetailsCreatedAt
            // 
            this.lblDetailsCreatedAt.AutoSize = true;
            this.lblDetailsCreatedAt.Location = new System.Drawing.Point(12, 87);
            this.lblDetailsCreatedAt.Name = "lblDetailsCreatedAt";
            this.lblDetailsCreatedAt.Size = new System.Drawing.Size(71, 15);
            this.lblDetailsCreatedAt.TabIndex = 3;
            this.lblDetailsCreatedAt.Text = "Created At: ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 561);
            this.Controls.Add(this.pnlQuoteDetails);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.dgvQuotes);
            this.Controls.Add(this.btnRetrieveQuote);
            this.Controls.Add(this.txtQuoteId);
            this.Controls.Add(this.lblQuoteId);
            this.Controls.Add(this.btnGetQuote);
            this.Controls.Add(this.numSumInsured);
            this.Controls.Add(this.numTerm);
            this.Controls.Add(this.lblSumInsured);
            this.Controls.Add(this.lblTerm);
            this.Controls.Add(this.lblTitle);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Insurance Quote UI";
            ((System.ComponentModel.ISupportInitialize)(this.numTerm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSumInsured)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuotes)).EndInit();
            this.pnlQuoteDetails.ResumeLayout(false);
            this.pnlQuoteDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTerm;
        private System.Windows.Forms.Label lblSumInsured;
        private System.Windows.Forms.NumericUpDown numTerm;
        private System.Windows.Forms.NumericUpDown numSumInsured;
        private System.Windows.Forms.Button btnGetQuote;
        private System.Windows.Forms.Label lblQuoteId;
        private System.Windows.Forms.TextBox txtQuoteId;
        private System.Windows.Forms.Button btnRetrieveQuote;
        private System.Windows.Forms.DataGridView dgvQuotes;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel pnlQuoteDetails;
        private System.Windows.Forms.Label lblDetailsCreatedAt;
        private System.Windows.Forms.Label lblDetailsSumInsured;
        private System.Windows.Forms.Label lblDetailsTerm;
        private System.Windows.Forms.Label lblQuoteDetails;
    }
}
