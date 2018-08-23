namespace AdoNetModelFirst
{
    partial class LogsPanel
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogsPanel));
            this.buttonDelete = new Bunifu.Framework.UI.BunifuImageButton();
            this.labelNameUser = new System.Windows.Forms.Label();
            this.labelNameBook = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxDebstor = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.buttonDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.BackColor = System.Drawing.Color.Transparent;
            this.buttonDelete.Image = ((System.Drawing.Image)(resources.GetObject("buttonDelete.Image")));
            this.buttonDelete.ImageActive = null;
            this.buttonDelete.Location = new System.Drawing.Point(801, 15);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(58, 52);
            this.buttonDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonDelete.TabIndex = 0;
            this.buttonDelete.TabStop = false;
            this.buttonDelete.Zoom = 10;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // labelNameUser
            // 
            this.labelNameUser.AutoSize = true;
            this.labelNameUser.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNameUser.ForeColor = System.Drawing.Color.White;
            this.labelNameUser.Location = new System.Drawing.Point(3, 12);
            this.labelNameUser.Name = "labelNameUser";
            this.labelNameUser.Size = new System.Drawing.Size(60, 21);
            this.labelNameUser.TabIndex = 2;
            this.labelNameUser.Text = "label1";
            // 
            // labelNameBook
            // 
            this.labelNameBook.AutoSize = true;
            this.labelNameBook.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNameBook.ForeColor = System.Drawing.Color.White;
            this.labelNameBook.Location = new System.Drawing.Point(3, 46);
            this.labelNameBook.Name = "labelNameBook";
            this.labelNameBook.Size = new System.Drawing.Size(60, 21);
            this.labelNameBook.TabIndex = 2;
            this.labelNameBook.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Сдана в библиотеку";
            // 
            // checkBoxDebstor
            // 
            this.checkBoxDebstor.AutoSize = true;
            this.checkBoxDebstor.Location = new System.Drawing.Point(223, 82);
            this.checkBoxDebstor.Name = "checkBoxDebstor";
            this.checkBoxDebstor.Size = new System.Drawing.Size(18, 17);
            this.checkBoxDebstor.TabIndex = 3;
            this.checkBoxDebstor.UseVisualStyleBackColor = true;
            this.checkBoxDebstor.CheckedChanged += new System.EventHandler(this.checkBoxDebstor_CheckedChanged);
            // 
            // LogsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxDebstor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelNameBook);
            this.Controls.Add(this.labelNameUser);
            this.Controls.Add(this.buttonDelete);
            this.Name = "LogsPanel";
            this.Size = new System.Drawing.Size(862, 119);
            ((System.ComponentModel.ISupportInitialize)(this.buttonDelete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuImageButton buttonDelete;
        private System.Windows.Forms.Label labelNameUser;
        private System.Windows.Forms.Label labelNameBook;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxDebstor;
    }
}
