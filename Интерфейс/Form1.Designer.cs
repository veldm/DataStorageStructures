namespace Интерфейс
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TreeTab = new System.Windows.Forms.TabPage();
            this.TimeResultTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchTB = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.RemoveTB = new System.Windows.Forms.TextBox();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.AddTB = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.ComboBox = new System.Windows.Forms.ComboBox();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.HashTab = new System.Windows.Forms.TabPage();
            this.ValueTB = new System.Windows.Forms.TextBox();
            this.TimeResultLabel = new System.Windows.Forms.Label();
            this.KeyTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Hash_SearchButton = new System.Windows.Forms.Button();
            this.Hash_DeleteButton = new System.Windows.Forms.Button();
            this.Hash_AddButton = new System.Windows.Forms.Button();
            this.ResultTB = new System.Windows.Forms.TextBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TabControl.SuspendLayout();
            this.TreeTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.HashTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TreeTab);
            this.TabControl.Controls.Add(this.HashTab);
            this.TabControl.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TabControl.Location = new System.Drawing.Point(7, 8);
            this.TabControl.MaximumSize = new System.Drawing.Size(1145, 601);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(1145, 601);
            this.TabControl.TabIndex = 0;
            this.TabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // TreeTab
            // 
            this.TreeTab.BackColor = System.Drawing.SystemColors.Control;
            this.TreeTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TreeTab.Controls.Add(this.TimeResultTB);
            this.TreeTab.Controls.Add(this.label1);
            this.TreeTab.Controls.Add(this.SearchTB);
            this.TreeTab.Controls.Add(this.SearchButton);
            this.TreeTab.Controls.Add(this.RemoveTB);
            this.TreeTab.Controls.Add(this.RemoveButton);
            this.TreeTab.Controls.Add(this.AddTB);
            this.TreeTab.Controls.Add(this.AddButton);
            this.TreeTab.Controls.Add(this.ComboBox);
            this.TreeTab.Controls.Add(this.PictureBox);
            this.TreeTab.Location = new System.Drawing.Point(4, 33);
            this.TreeTab.Name = "TreeTab";
            this.TreeTab.Padding = new System.Windows.Forms.Padding(3);
            this.TreeTab.Size = new System.Drawing.Size(1137, 564);
            this.TreeTab.TabIndex = 1;
            this.TreeTab.Text = "Деревья";
            // 
            // TimeResultTB
            // 
            this.TimeResultTB.Location = new System.Drawing.Point(856, 370);
            this.TimeResultTB.Multiline = true;
            this.TimeResultTB.Name = "TimeResultTB";
            this.TimeResultTB.Size = new System.Drawing.Size(268, 180);
            this.TimeResultTB.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(852, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 96);
            this.label1.TabIndex = 8;
            this.label1.Text = "При добавлении или удалении \r\nвершины происходит \r\nавтоматическая балансировка \r\n" +
    "дерева";
            // 
            // SearchTB
            // 
            this.SearchTB.Font = new System.Drawing.Font("Sitka Small", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchTB.Location = new System.Drawing.Point(1002, 198);
            this.SearchTB.Name = "SearchTB";
            this.SearchTB.Size = new System.Drawing.Size(122, 34);
            this.SearchTB.TabIndex = 7;
            this.SearchTB.TextChanged += new System.EventHandler(this.SearchTB_TextChanged);
            // 
            // SearchButton
            // 
            this.SearchButton.Enabled = false;
            this.SearchButton.Location = new System.Drawing.Point(856, 198);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(122, 34);
            this.SearchButton.TabIndex = 6;
            this.SearchButton.Text = "Найти";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // RemoveTB
            // 
            this.RemoveTB.Font = new System.Drawing.Font("Sitka Small", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RemoveTB.Location = new System.Drawing.Point(1002, 134);
            this.RemoveTB.Name = "RemoveTB";
            this.RemoveTB.Size = new System.Drawing.Size(122, 34);
            this.RemoveTB.TabIndex = 5;
            this.RemoveTB.TextChanged += new System.EventHandler(this.RemoveTB_TextChanged);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Enabled = false;
            this.RemoveButton.Location = new System.Drawing.Point(856, 134);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(122, 34);
            this.RemoveButton.TabIndex = 4;
            this.RemoveButton.Text = "Удалить";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // AddTB
            // 
            this.AddTB.Font = new System.Drawing.Font("Sitka Small", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddTB.Location = new System.Drawing.Point(1002, 67);
            this.AddTB.Name = "AddTB";
            this.AddTB.Size = new System.Drawing.Size(122, 34);
            this.AddTB.TabIndex = 3;
            this.AddTB.TextChanged += new System.EventHandler(this.AddTB_TextChanged);
            // 
            // AddButton
            // 
            this.AddButton.Enabled = false;
            this.AddButton.Location = new System.Drawing.Point(856, 67);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(122, 34);
            this.AddButton.TabIndex = 2;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ComboBox
            // 
            this.ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComboBox.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ComboBox.FormattingEnabled = true;
            this.ComboBox.Items.AddRange(new object[] {
            "Двоичное дерево поиска",
            "Декартово дерево",
            "Красно-чёрное дерево"});
            this.ComboBox.Location = new System.Drawing.Point(856, 11);
            this.ComboBox.Name = "ComboBox";
            this.ComboBox.Size = new System.Drawing.Size(268, 32);
            this.ComboBox.TabIndex = 1;
            this.ComboBox.TextChanged += new System.EventHandler(this.ComboBox_TextChanged);
            // 
            // PictureBox
            // 
            this.PictureBox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PictureBox.Location = new System.Drawing.Point(11, 11);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(835, 539);
            this.PictureBox.TabIndex = 0;
            this.PictureBox.TabStop = false;
            this.PictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_Paint);
            // 
            // HashTab
            // 
            this.HashTab.BackColor = System.Drawing.SystemColors.Control;
            this.HashTab.Controls.Add(this.ValueTB);
            this.HashTab.Controls.Add(this.TimeResultLabel);
            this.HashTab.Controls.Add(this.KeyTB);
            this.HashTab.Controls.Add(this.label3);
            this.HashTab.Controls.Add(this.Hash_SearchButton);
            this.HashTab.Controls.Add(this.Hash_DeleteButton);
            this.HashTab.Controls.Add(this.Hash_AddButton);
            this.HashTab.Controls.Add(this.ResultTB);
            this.HashTab.Location = new System.Drawing.Point(4, 33);
            this.HashTab.Name = "HashTab";
            this.HashTab.Padding = new System.Windows.Forms.Padding(3);
            this.HashTab.Size = new System.Drawing.Size(1137, 564);
            this.HashTab.TabIndex = 0;
            this.HashTab.Text = "Хэш-таблица";
            // 
            // ValueTB
            // 
            this.ValueTB.ForeColor = System.Drawing.Color.Silver;
            this.ValueTB.Location = new System.Drawing.Point(6, 67);
            this.ValueTB.Multiline = true;
            this.ValueTB.Name = "ValueTB";
            this.ValueTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ValueTB.Size = new System.Drawing.Size(646, 61);
            this.ValueTB.TabIndex = 7;
            this.ValueTB.Text = "<Введите значение>";
            this.ValueTB.Click += new System.EventHandler(this.ValueTB_Click);
            this.ValueTB.TextChanged += new System.EventHandler(this.ValueTB_TextChanged);
            this.ValueTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValueTB_KeyPress);
            this.ValueTB.Leave += new System.EventHandler(this.ValueTB_Leave);
            // 
            // TimeResultLabel
            // 
            this.TimeResultLabel.AutoSize = true;
            this.TimeResultLabel.Location = new System.Drawing.Point(6, 529);
            this.TimeResultLabel.Name = "TimeResultLabel";
            this.TimeResultLabel.Size = new System.Drawing.Size(45, 24);
            this.TimeResultLabel.TabIndex = 6;
            this.TimeResultLabel.Text = "       ";
            // 
            // KeyTB
            // 
            this.KeyTB.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KeyTB.ForeColor = System.Drawing.Color.Silver;
            this.KeyTB.Location = new System.Drawing.Point(412, 14);
            this.KeyTB.Multiline = true;
            this.KeyTB.Name = "KeyTB";
            this.KeyTB.Size = new System.Drawing.Size(240, 32);
            this.KeyTB.TabIndex = 5;
            this.KeyTB.Text = "<Введите ключ>";
            this.KeyTB.Click += new System.EventHandler(this.KeyTB_Click);
            this.KeyTB.TextChanged += new System.EventHandler(this.KeyTB_TextChanged);
            this.KeyTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyTB_KeyPress);
            this.KeyTB.Leave += new System.EventHandler(this.KeyTB_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(345, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ключ:";
            // 
            // Hash_SearchButton
            // 
            this.Hash_SearchButton.Location = new System.Drawing.Point(232, 14);
            this.Hash_SearchButton.Name = "Hash_SearchButton";
            this.Hash_SearchButton.Size = new System.Drawing.Size(107, 33);
            this.Hash_SearchButton.TabIndex = 3;
            this.Hash_SearchButton.Text = "Найти";
            this.Hash_SearchButton.UseVisualStyleBackColor = true;
            this.Hash_SearchButton.Click += new System.EventHandler(this.Hash_SearchButton_Click);
            // 
            // Hash_DeleteButton
            // 
            this.Hash_DeleteButton.Location = new System.Drawing.Point(119, 14);
            this.Hash_DeleteButton.Name = "Hash_DeleteButton";
            this.Hash_DeleteButton.Size = new System.Drawing.Size(107, 33);
            this.Hash_DeleteButton.TabIndex = 2;
            this.Hash_DeleteButton.Text = "Удалить";
            this.Hash_DeleteButton.UseVisualStyleBackColor = true;
            this.Hash_DeleteButton.Click += new System.EventHandler(this.Hash_DeleteButton_Click);
            // 
            // Hash_AddButton
            // 
            this.Hash_AddButton.Location = new System.Drawing.Point(6, 14);
            this.Hash_AddButton.Name = "Hash_AddButton";
            this.Hash_AddButton.Size = new System.Drawing.Size(107, 33);
            this.Hash_AddButton.TabIndex = 1;
            this.Hash_AddButton.Text = "Добавить";
            this.Hash_AddButton.UseVisualStyleBackColor = true;
            this.Hash_AddButton.Click += new System.EventHandler(this.Hash_AddButton_Click);
            // 
            // ResultTB
            // 
            this.ResultTB.Location = new System.Drawing.Point(6, 134);
            this.ResultTB.Multiline = true;
            this.ResultTB.Name = "ResultTB";
            this.ResultTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ResultTB.Size = new System.Drawing.Size(646, 392);
            this.ResultTB.TabIndex = 0;
            // 
            // ClearButton
            // 
            this.ClearButton.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearButton.Location = new System.Drawing.Point(1033, 3);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(115, 32);
            this.ClearButton.TabIndex = 1;
            this.ClearButton.Text = "Очистить";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(231, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "   ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 618);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.TabControl);
            this.MaximumSize = new System.Drawing.Size(1179, 657);
            this.Name = "Form1";
            this.Tag = "                                                                                 " +
    "                   Великов Д.А. ПИН-1706";
            this.Text = "Великов Д.А. ПИН-1706";
            this.TabControl.ResumeLayout(false);
            this.TreeTab.ResumeLayout(false);
            this.TreeTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.HashTab.ResumeLayout(false);
            this.HashTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage HashTab;
        private System.Windows.Forms.TabPage TreeTab;
        private System.Windows.Forms.ComboBox ComboBox;
        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.TextBox SearchTB;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox RemoveTB;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.TextBox AddTB;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.TextBox TimeResultTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ResultTB;
        private System.Windows.Forms.TextBox KeyTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Hash_SearchButton;
        private System.Windows.Forms.Button Hash_DeleteButton;
        private System.Windows.Forms.Button Hash_AddButton;
        private System.Windows.Forms.Label TimeResultLabel;
        private System.Windows.Forms.TextBox ValueTB;
    }
}

