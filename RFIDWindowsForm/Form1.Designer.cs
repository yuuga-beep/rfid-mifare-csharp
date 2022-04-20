
namespace RFIDWindowsForm
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
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.RichTextBoxApduLogs = new System.Windows.Forms.RichTextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.TextBoxATR = new System.Windows.Forms.TextBox();
            this.MaskedTextBoxKeyValueInput = new System.Windows.Forms.MaskedTextBox();
            this.TextBoxCardType = new System.Windows.Forms.TextBox();
            this.comboboxReaderNames = new System.Windows.Forms.ComboBox();
            this.lblcardnumber = new System.Windows.Forms.TextBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.Txtaddress = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.TextBoxStatus = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label16 = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.RichTextBoxApduLogs);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.TextBoxATR);
            this.GroupBox1.Controls.Add(this.MaskedTextBoxKeyValueInput);
            this.GroupBox1.Controls.Add(this.TextBoxCardType);
            this.GroupBox1.Controls.Add(this.comboboxReaderNames);
            this.GroupBox1.Controls.Add(this.lblcardnumber);
            this.GroupBox1.Location = new System.Drawing.Point(13, 13);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox1.Size = new System.Drawing.Size(421, 534);
            this.GroupBox1.TabIndex = 106;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "For Debugging Purposes";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(23, 31);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(100, 17);
            this.Label3.TabIndex = 95;
            this.Label3.Text = "Card Number :";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(24, 148);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(71, 17);
            this.Label2.TabIndex = 103;
            this.Label2.Text = "RFID Key:";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(23, 58);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(112, 17);
            this.Label5.TabIndex = 104;
            this.Label5.Text = "Binary Address :";
            // 
            // RichTextBoxApduLogs
            // 
            this.RichTextBoxApduLogs.Location = new System.Drawing.Point(27, 176);
            this.RichTextBoxApduLogs.Margin = new System.Windows.Forms.Padding(4);
            this.RichTextBoxApduLogs.Name = "RichTextBoxApduLogs";
            this.RichTextBoxApduLogs.ReadOnly = true;
            this.RichTextBoxApduLogs.ShortcutsEnabled = false;
            this.RichTextBoxApduLogs.Size = new System.Drawing.Size(360, 342);
            this.RichTextBoxApduLogs.TabIndex = 98;
            this.RichTextBoxApduLogs.Text = "";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(23, 117);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(89, 17);
            this.Label1.TabIndex = 102;
            this.Label1.Text = "Reader List :";
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(24, 79);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(113, 26);
            this.Label4.TabIndex = 87;
            this.Label4.Text = "Card Type:";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TextBoxATR
            // 
            this.TextBoxATR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxATR.Location = new System.Drawing.Point(145, 53);
            this.TextBoxATR.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxATR.Multiline = true;
            this.TextBoxATR.Name = "TextBoxATR";
            this.TextBoxATR.ReadOnly = true;
            this.TextBoxATR.Size = new System.Drawing.Size(241, 24);
            this.TextBoxATR.TabIndex = 88;
            // 
            // MaskedTextBoxKeyValueInput
            // 
            this.MaskedTextBoxKeyValueInput.Location = new System.Drawing.Point(145, 144);
            this.MaskedTextBoxKeyValueInput.Margin = new System.Windows.Forms.Padding(4);
            this.MaskedTextBoxKeyValueInput.Mask = ">>AA AA AA AA AA AA";
            this.MaskedTextBoxKeyValueInput.Name = "MaskedTextBoxKeyValueInput";
            this.MaskedTextBoxKeyValueInput.ShortcutsEnabled = false;
            this.MaskedTextBoxKeyValueInput.Size = new System.Drawing.Size(155, 22);
            this.MaskedTextBoxKeyValueInput.TabIndex = 97;
            this.MaskedTextBoxKeyValueInput.Text = "FFFFFFFFFFFF";
            // 
            // TextBoxCardType
            // 
            this.TextBoxCardType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxCardType.Location = new System.Drawing.Point(145, 79);
            this.TextBoxCardType.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxCardType.Name = "TextBoxCardType";
            this.TextBoxCardType.ReadOnly = true;
            this.TextBoxCardType.Size = new System.Drawing.Size(241, 23);
            this.TextBoxCardType.TabIndex = 89;
            // 
            // comboboxReaderNames
            // 
            this.comboboxReaderNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxReaderNames.FormattingEnabled = true;
            this.comboboxReaderNames.Location = new System.Drawing.Point(145, 111);
            this.comboboxReaderNames.Margin = new System.Windows.Forms.Padding(4);
            this.comboboxReaderNames.Name = "comboboxReaderNames";
            this.comboboxReaderNames.Size = new System.Drawing.Size(155, 24);
            this.comboboxReaderNames.TabIndex = 96;
            // 
            // lblcardnumber
            // 
            this.lblcardnumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcardnumber.Location = new System.Drawing.Point(145, 26);
            this.lblcardnumber.Margin = new System.Windows.Forms.Padding(4);
            this.lblcardnumber.Multiline = true;
            this.lblcardnumber.Name = "lblcardnumber";
            this.lblcardnumber.ReadOnly = true;
            this.lblcardnumber.Size = new System.Drawing.Size(241, 25);
            this.lblcardnumber.TabIndex = 101;
            // 
            // txtname
            // 
            this.txtname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtname.Location = new System.Drawing.Point(617, 36);
            this.txtname.Margin = new System.Windows.Forms.Padding(4);
            this.txtname.Multiline = true;
            this.txtname.Name = "txtname";
            this.txtname.ReadOnly = true;
            this.txtname.Size = new System.Drawing.Size(379, 31);
            this.txtname.TabIndex = 112;
            // 
            // Txtaddress
            // 
            this.Txtaddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtaddress.Location = new System.Drawing.Point(617, 84);
            this.Txtaddress.Margin = new System.Windows.Forms.Padding(4);
            this.Txtaddress.Multiline = true;
            this.Txtaddress.Name = "Txtaddress";
            this.Txtaddress.ReadOnly = true;
            this.Txtaddress.Size = new System.Drawing.Size(379, 31);
            this.Txtaddress.TabIndex = 111;
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(470, 122);
            this.Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(139, 39);
            this.Label6.TabIndex = 108;
            this.Label6.Text = "Card Status:";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TextBoxStatus
            // 
            this.TextBoxStatus.BackColor = System.Drawing.SystemColors.Control;
            this.TextBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxStatus.Location = new System.Drawing.Point(617, 126);
            this.TextBoxStatus.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxStatus.Name = "TextBoxStatus";
            this.TextBoxStatus.ReadOnly = true;
            this.TextBoxStatus.Size = new System.Drawing.Size(379, 30);
            this.TextBoxStatus.TabIndex = 107;
            this.TextBoxStatus.Text = "Initialize Smart Card resources.";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.Location = new System.Drawing.Point(470, 36);
            this.Label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(70, 25);
            this.Label9.TabIndex = 110;
            this.Label9.Text = "Name:";
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label16.Location = new System.Drawing.Point(470, 82);
            this.Label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(91, 25);
            this.Label16.TabIndex = 109;
            this.Label16.Text = "Address:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 581);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.Txtaddress);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.TextBoxStatus);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.Label16);
            this.Controls.Add(this.GroupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label5;
        private System.Windows.Forms.RichTextBox RichTextBoxApduLogs;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox TextBoxATR;
        private System.Windows.Forms.MaskedTextBox MaskedTextBoxKeyValueInput;
        internal System.Windows.Forms.TextBox TextBoxCardType;
        internal System.Windows.Forms.ComboBox comboboxReaderNames;
        internal System.Windows.Forms.TextBox lblcardnumber;
        internal System.Windows.Forms.TextBox txtname;
        internal System.Windows.Forms.TextBox Txtaddress;
        internal System.Windows.Forms.Label Label6;
        private System.Windows.Forms.TextBox TextBoxStatus;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label16;
    }
}

