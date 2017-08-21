namespace TargetLableTool
{
    partial class TargetLableTool
    {
        /// <summary>
        /// Required designer variables.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up all resources that are being used.
        /// </summary>
        /// <param name="disposing">True if the managed resource should be freed; otherwise false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        //#region Windows 窗体设计器生成的代码 
        #region Windows The form designer generates the code

        /// <summary>

        /// Designer supports the required method - do not
        /// Use the code editor to modify the contents of this method.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TargetLableTool));
            this.nextFrame = new System.Windows.Forms.Button();
            this.modify = new System.Windows.Forms.Button();
            this.startLabel = new System.Windows.Forms.Button();
            this.labelPicBox = new System.Windows.Forms.PictureBox();
            this.infoDisp = new System.Windows.Forms.RichTextBox();
            this.setFrame = new System.Windows.Forms.TextBox();
            this.Frame = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.setNewID = new System.Windows.Forms.RichTextBox();
            this.referPicBox = new System.Windows.Forms.PictureBox();
            this.Draw_RoI = new System.Windows.Forms.Button();
            this.reDrawRoI = new System.Windows.Forms.Button();
            this.newTarget = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.loadData = new System.Windows.Forms.Button();
            this.ViewLable = new System.Windows.Forms.Button();
            this.insert = new System.Windows.Forms.Button();
            this.end_Del_Ins_Modi = new System.Windows.Forms.Button();
            this.OpenImgPath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.setID = new System.Windows.Forms.TextBox();
            this.ViewBack = new System.Windows.Forms.Button();
            this.ViewNext = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.labelInterval = new System.Windows.Forms.Label();
            this.setInterval = new System.Windows.Forms.TextBox();
            this.delete = new System.Windows.Forms.Button();
            this.playBar = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.labelPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.referPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playBar)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nextFrame
            // 
            this.nextFrame.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextFrame.Location = new System.Drawing.Point(349, 496);
            this.nextFrame.Name = "nextFrame";
            this.nextFrame.Size = new System.Drawing.Size(92, 36);
            this.nextFrame.TabIndex = 0;
            this.nextFrame.Text = "Next Frame";
            this.nextFrame.UseVisualStyleBackColor = true;
            this.nextFrame.Click += new System.EventHandler(this.next_Click);
            // 
            // modify
            // 
            this.modify.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modify.Location = new System.Drawing.Point(91, 3);
            this.modify.Name = "modify";
            this.modify.Size = new System.Drawing.Size(92, 30);
            this.modify.TabIndex = 1;
            this.modify.Text = "Modify";
            this.modify.UseVisualStyleBackColor = true;
            this.modify.Click += new System.EventHandler(this.modify_Click);
            // 
            // startLabel
            // 
            this.startLabel.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startLabel.Location = new System.Drawing.Point(258, 496);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(77, 36);
            this.startLabel.TabIndex = 5;
            this.startLabel.Text = "Start";
            this.startLabel.UseVisualStyleBackColor = true;
            this.startLabel.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // labelPicBox
            // 
            this.labelPicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPicBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelPicBox.Location = new System.Drawing.Point(451, 0);
            this.labelPicBox.Name = "labelPicBox";
            this.labelPicBox.Size = new System.Drawing.Size(900, 506);
            this.labelPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.labelPicBox.TabIndex = 6;
            this.labelPicBox.TabStop = false;
            this.labelPicBox.Click += new System.EventHandler(this.pictureBox1_Click);
            this.labelPicBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.labelPicBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.labelPicBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // infoDisp
            // 
            this.infoDisp.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoDisp.HideSelection = false;
            this.infoDisp.Location = new System.Drawing.Point(14, 381);
            this.infoDisp.Name = "infoDisp";
            this.infoDisp.Size = new System.Drawing.Size(203, 50);
            this.infoDisp.TabIndex = 7;
            this.infoDisp.Text = "";
            this.infoDisp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBox1_KeyPress);
            // 
            // setFrame
            // 
            this.setFrame.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setFrame.Location = new System.Drawing.Point(340, 315);
            this.setFrame.Name = "setFrame";
            this.setFrame.Size = new System.Drawing.Size(34, 23);
            this.setFrame.TabIndex = 8;
            this.setFrame.Text = "1";
            this.setFrame.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Frame
            // 
            this.Frame.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Frame.Location = new System.Drawing.Point(92, 497);
            this.Frame.Name = "Frame";
            this.Frame.Size = new System.Drawing.Size(47, 30);
            this.Frame.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 504);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "Frames";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(229, 316);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "Frame No.";
            // 
            // setNewID
            // 
            this.setNewID.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setNewID.Location = new System.Drawing.Point(257, 548);
            this.setNewID.Name = "setNewID";
            this.setNewID.Size = new System.Drawing.Size(77, 34);
            this.setNewID.TabIndex = 12;
            this.setNewID.Text = "";
            this.setNewID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBox2_KeyPress);
            // 
            // referPicBox
            // 
            this.referPicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.referPicBox.Location = new System.Drawing.Point(0, 0);
            this.referPicBox.Name = "referPicBox";
            this.referPicBox.Size = new System.Drawing.Size(450, 253);
            this.referPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.referPicBox.TabIndex = 13;
            this.referPicBox.TabStop = false;
            this.referPicBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseClick);
            this.referPicBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            // 
            // Draw_RoI
            // 
            this.Draw_RoI.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Draw_RoI.Location = new System.Drawing.Point(14, 438);
            this.Draw_RoI.Name = "Draw_RoI";
            this.Draw_RoI.Size = new System.Drawing.Size(81, 44);
            this.Draw_RoI.TabIndex = 14;
            this.Draw_RoI.Text = "Draw";
            this.Draw_RoI.UseVisualStyleBackColor = true;
            this.Draw_RoI.Click += new System.EventHandler(this.Draw_RoI_Click);
            // 
            // reDrawRoI
            // 
            this.reDrawRoI.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reDrawRoI.Location = new System.Drawing.Point(130, 438);
            this.reDrawRoI.Name = "reDrawRoI";
            this.reDrawRoI.Size = new System.Drawing.Size(87, 42);
            this.reDrawRoI.TabIndex = 15;
            this.reDrawRoI.Text = "Redraw";
            this.reDrawRoI.UseVisualStyleBackColor = true;
            this.reDrawRoI.Click += new System.EventHandler(this.reDrawRoI_Click);
            // 
            // newTarget
            // 
            this.newTarget.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newTarget.Location = new System.Drawing.Point(345, 548);
            this.newTarget.Name = "newTarget";
            this.newTarget.Size = new System.Drawing.Size(92, 36);
            this.newTarget.TabIndex = 16;
            this.newTarget.Text = "New";
            this.newTarget.UseVisualStyleBackColor = true;
            this.newTarget.Click += new System.EventHandler(this.newTarget_Click);
            // 
            // Save
            // 
            this.Save.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save.Location = new System.Drawing.Point(142, 548);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(78, 36);
            this.Save.TabIndex = 18;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // loadData
            // 
            this.loadData.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadData.Location = new System.Drawing.Point(139, 496);
            this.loadData.Name = "loadData";
            this.loadData.Size = new System.Drawing.Size(78, 36);
            this.loadData.TabIndex = 19;
            this.loadData.Text = "Load";
            this.loadData.UseVisualStyleBackColor = true;
            this.loadData.Click += new System.EventHandler(this.loadData_Click);
            // 
            // ViewLable
            // 
            this.ViewLable.Image = ((System.Drawing.Image)(resources.GetObject("ViewLable.Image")));
            this.ViewLable.Location = new System.Drawing.Point(902, 555);
            this.ViewLable.Name = "ViewLable";
            this.ViewLable.Size = new System.Drawing.Size(35, 38);
            this.ViewLable.TabIndex = 20;
            this.ViewLable.UseVisualStyleBackColor = true;
            this.ViewLable.Click += new System.EventHandler(this.ViewLable_Click);
            // 
            // insert
            // 
            this.insert.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insert.Location = new System.Drawing.Point(3, 40);
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(75, 30);
            this.insert.TabIndex = 21;
            this.insert.Text = "Insert";
            this.insert.UseVisualStyleBackColor = true;
            this.insert.Click += new System.EventHandler(this.Insert_Click);
            // 
            // end_Del_Ins_Modi
            // 
            this.end_Del_Ins_Modi.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.end_Del_Ins_Modi.Location = new System.Drawing.Point(91, 40);
            this.end_Del_Ins_Modi.Name = "end_Del_Ins_Modi";
            this.end_Del_Ins_Modi.Size = new System.Drawing.Size(92, 30);
            this.end_Del_Ins_Modi.TabIndex = 22;
            this.end_Del_Ins_Modi.Text = "End";
            this.end_Del_Ins_Modi.UseVisualStyleBackColor = true;
            this.end_Del_Ins_Modi.Click += new System.EventHandler(this.endModify_Click);
            // 
            // OpenImgPath
            // 
            this.OpenImgPath.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenImgPath.Location = new System.Drawing.Point(46, 299);
            this.OpenImgPath.Name = "OpenImgPath";
            this.OpenImgPath.Size = new System.Drawing.Size(156, 62);
            this.OpenImgPath.TabIndex = 24;
            this.OpenImgPath.Text = "Open File";
            this.OpenImgPath.UseVisualStyleBackColor = true;
            this.OpenImgPath.Click += new System.EventHandler(this.OpenImgPath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1025, 587);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 19);
            this.label1.TabIndex = 25;
            this.label1.Text = "Copyright © 2015 InSight Lab. All Rights Reserved";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(379, 317);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 23);
            this.label4.TabIndex = 27;
            this.label4.Text = "ID";
            // 
            // setID
            // 
            this.setID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setID.Location = new System.Drawing.Point(415, 315);
            this.setID.Name = "setID";
            this.setID.Size = new System.Drawing.Size(27, 26);
            this.setID.TabIndex = 28;
            // 
            // ViewBack
            // 
            this.ViewBack.Image = ((System.Drawing.Image)(resources.GetObject("ViewBack.Image")));
            this.ViewBack.Location = new System.Drawing.Point(816, 559);
            this.ViewBack.Name = "ViewBack";
            this.ViewBack.Size = new System.Drawing.Size(61, 31);
            this.ViewBack.TabIndex = 29;
            this.ViewBack.UseVisualStyleBackColor = true;
            this.ViewBack.Click += new System.EventHandler(this.ViewBack_Click);
            // 
            // ViewNext
            // 
            this.ViewNext.Image = ((System.Drawing.Image)(resources.GetObject("ViewNext.Image")));
            this.ViewNext.Location = new System.Drawing.Point(958, 559);
            this.ViewNext.Name = "ViewNext";
            this.ViewNext.Size = new System.Drawing.Size(61, 31);
            this.ViewNext.TabIndex = 30;
            this.ViewNext.UseVisualStyleBackColor = true;
            this.ViewNext.Click += new System.EventHandler(this.ViewNext_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "stop.jpg");
            this.imageList1.Images.SetKeyName(1, "start.jpg");
            // 
            // labelInterval
            // 
            this.labelInterval.AutoSize = true;
            this.labelInterval.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInterval.Location = new System.Drawing.Point(14, 557);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(77, 23);
            this.labelInterval.TabIndex = 31;
            this.labelInterval.Text = "Interval";
            // 
            // setInterval
            // 
            this.setInterval.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setInterval.Location = new System.Drawing.Point(97, 550);
            this.setInterval.Name = "setInterval";
            this.setInterval.Size = new System.Drawing.Size(39, 30);
            this.setInterval.TabIndex = 32;
            this.setInterval.Text = "5";
            this.setInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.setInterval.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // delete
            // 
            this.delete.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete.Location = new System.Drawing.Point(3, 3);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 30);
            this.delete.TabIndex = 33;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.DeleteTarget_Click);
            // 
            // playBar
            // 
            this.playBar.LargeChange = 5000;
            this.playBar.Location = new System.Drawing.Point(442, 559);
            this.playBar.Maximum = 5000;
            this.playBar.Minimum = 1;
            this.playBar.Name = "playBar";
            this.playBar.Size = new System.Drawing.Size(352, 45);
            this.playBar.TabIndex = 35;
            this.playBar.Value = 1;
            this.playBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.end_Del_Ins_Modi);
            this.panel1.Controls.Add(this.delete);
            this.panel1.Controls.Add(this.insert);
            this.panel1.Controls.Add(this.modify);
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(256, 406);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 74);
            this.panel1.TabIndex = 36;
            this.panel1.Tag = "Edit";
            // 
            // TargetLableTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 607);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.playBar);
            this.Controls.Add(this.setInterval);
            this.Controls.Add(this.labelInterval);
            this.Controls.Add(this.ViewNext);
            this.Controls.Add(this.ViewBack);
            this.Controls.Add(this.setID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OpenImgPath);
            this.Controls.Add(this.ViewLable);
            this.Controls.Add(this.loadData);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.newTarget);
            this.Controls.Add(this.reDrawRoI);
            this.Controls.Add(this.Draw_RoI);
            this.Controls.Add(this.referPicBox);
            this.Controls.Add(this.setNewID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Frame);
            this.Controls.Add(this.setFrame);
            this.Controls.Add(this.infoDisp);
            this.Controls.Add(this.labelPicBox);
            this.Controls.Add(this.startLabel);
            this.Controls.Add(this.nextFrame);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TargetLableTool";
            this.Text = "Annotation";
            this.Load += new System.EventHandler(this.TargetLableTool_Load);
            ((System.ComponentModel.ISupportInitialize)(this.labelPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.referPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playBar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button nextFrame;
        private System.Windows.Forms.Button modify;
        private System.Windows.Forms.Button startLabel;
        private System.Windows.Forms.PictureBox labelPicBox;
        private System.Windows.Forms.RichTextBox infoDisp;
        private System.Windows.Forms.TextBox setFrame;
        private System.Windows.Forms.TextBox Frame;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox setNewID;
        private System.Windows.Forms.PictureBox referPicBox;
        private System.Windows.Forms.Button Draw_RoI;
        private System.Windows.Forms.Button reDrawRoI;
        private System.Windows.Forms.Button newTarget;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button loadData;
        private System.Windows.Forms.Button ViewLable;
        private System.Windows.Forms.Button insert;
        private System.Windows.Forms.Button end_Del_Ins_Modi;
        private System.Windows.Forms.Button OpenImgPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox setID;
        private System.Windows.Forms.Button ViewBack;
        private System.Windows.Forms.Button ViewNext;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label labelInterval;
        private System.Windows.Forms.TextBox setInterval;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.TrackBar playBar;
        private System.Windows.Forms.Panel panel1;
    }
}

