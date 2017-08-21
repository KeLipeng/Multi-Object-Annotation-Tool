using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;
namespace TargetLableTool
{
    public partial class TargetLableTool : Form
    {
        public TargetLableTool()
        {
            InitializeComponent();

            labelPic = this.labelPicBox.CreateGraphics();
            referPic = this.referPicBox.CreateGraphics();
            Form.CheckForIllegalCrossThreadCalls = false;
            labelPicWidth = Convert.ToInt32(labelPic.DpiX);
            labelPicHight = Convert.ToInt32(labelPic.DpiY);
            referPicWidth = Convert.ToInt32(referPic.DpiX);
            referPicHight = Convert.ToInt32(referPic.DpiY);

           
        }

        private void TargetLableTool_Load(object sender, EventArgs e)
        {

        }
        int labelPicWidth,labelPicHight, referPicWidth, referPicHight; 
        private Point start = new Point();
        private Point end = new Point();
        private Point IdPoint = new Point();
        private bool blDraw = false;
        private bool IgRMode = false;
        int Img_W = 960;
        int Img_H = 540;
        double scaleCoe_W = 960 / 900.0;        // width Scale coefficient from the image 
        double scaleCoe_H = 540 / 450.0;


        int RoIbutton = 0;          //use to indicate the RoIButton status
        Graphics labelPic, referPic;
        int current_frame = 1;      // current frame
        int current_indice = 0;     // the current indice of LableMat
        int num_max = 1;            // total num of the frames
        double[,] lableMat = new double[400000, 6];     //store the bounding box of target
        int interval = 1;           // step of the frame increase
        double[,] IgR = new double[100, 4];   //RoI region points
        int num_corner = 0;         //number of the RoI corners(or ignore region)

        int maxID = 1;              //max ID up to now
        int insertMode = 0;         //flag of insert button
        string fileName = "fileName_fileName_fileName_fileName_fileName_fileName";          //initial name of fileName
        string imgFolderPath = "";      //image Folder
        int viewFrameIndex = 1;         // Frame index for preview
        int viewStatuas = 0;

        //Encode image path
        public string Img_path(int num_frame)
        {

            string path = imgFolderPath;
            if (num_frame < 10)
                return path + "\\image\\img0000" + num_frame.ToString() + ".jpg";
            else if (num_frame < 100)
                return path + "\\image\\img000" + num_frame.ToString() + ".jpg";
            else if (num_frame < 1000)
                return path + "\\image\\img00" + num_frame.ToString() + ".jpg";
            else if (num_frame < 10000)
                return path + "\\image\\img0" + num_frame.ToString() + ".jpg";
            else
                return "";
        }

        // This function is for RoI drawing, it is useless now.
        public void Confirm_Click(object sender, EventArgs e)
        {
            /*
            for (int i = 0; i < num_corner; i++)
            {
                if (Math.Abs(RoI[i, 0]) < 20)
                    RoI[i, 0] = 0;
                else if (Math.Abs(RoI[i, 0] - 900) < 20)
                    RoI[i, 0] = 900;
                if (Math.Abs(RoI[i, 1]) < 20)
                    RoI[i, 1] = 0;
                else if (Math.Abs(RoI[i, 1] - 506) < 20)
                    RoI[i, 1] = 506;
            }
             */
            current_frame = Convert.ToInt32(setFrame.Text);

            

            string path = Img_path(current_frame);
            Image myImage = System.Drawing.Image.FromFile(path);
            scaleCoe_W = myImage.Width / 900.0;
            scaleCoe_H = myImage.Height / 506.0;

            this.labelPicBox.Image = myImage;
            DrawRoI(1, 1, current_frame);
            DrawRoI(2, 2, current_frame);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        // drawing ignore region 
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            labelPic = this.labelPicBox.CreateGraphics();
            start.X = e.X;
            start.Y = e.Y;
            end.X = e.X;
            end.Y = e.Y;
            blDraw = true;
            if (IgRMode)
            {
                IgR[num_corner, 0] = start.X;
                IgR[num_corner, 1] = start.Y;
               // num_corner = num_corner + 1;
            }
        }

        // show up when draw rectangle(bbox or ignore region)
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (blDraw)
            {
                labelPic.DrawRectangle(new Pen(Color.White), start.X, start.Y, e.X - start.X, e.Y - start.Y);
                labelPicBox.Refresh();
            }
        }

        // Draw BBox and Ignore region
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            // Draw Red rectangle for bbox and show target ID number
            if (blDraw && !IgRMode)
            {
                labelPic.DrawRectangle(new Pen(Color.Red), start.X, start.Y, e.X - start.X, e.Y - start.Y);

                lableMat[current_indice, 0] = start.X;
                lableMat[current_indice, 1] = start.Y;
                lableMat[current_indice, 2] = e.X;
                lableMat[current_indice, 3] = e.Y;
                lableMat[current_indice, 4] = current_frame;
                setNewID.Focus();
                if (current_frame == 1)
                {
                    // show bbox and ID in first frame
                    lableMat[current_indice, 5] = maxID;
                    labelPic.DrawString(maxID.ToString(), new Font("Arial", 16), new SolidBrush(Color.Black), start.X, start.Y);
                    infoDisp.Text = infoDisp.Text + start.X.ToString() + "," + start.Y.ToString() + "," + e.X.ToString() + "," + e.Y.ToString() + "," + current_frame.ToString() + "," + maxID.ToString() + "\n";
                    infoDisp.Focus();
                    infoDisp.Select(infoDisp.Text.Length, 0);
                    setNewID.Focus();
                    maxID = maxID + 1;
                    current_indice = current_indice + 1;

                }

                setNewID.Select(infoDisp.Text.Length, 0);

                DrawRoI(1, 1, current_frame); // show ignore region
                Thread.Sleep(100);
            }
            else if (blDraw && IgRMode)
            {
                IgR[num_corner, 2] = e.X;
                IgR[num_corner, 3] = e.Y;
                DrawRoI(1, 1, current_frame); // show ignore region
                num_corner = num_corner + 1;
            }
            blDraw = false;
        }

        // Jump to next frame
        private void next_Click(object sender, EventArgs e)
        {
            if ((current_frame % interval) == 1)
                SaveData();
            if (current_frame <= (num_max - interval))
            {
                current_frame = current_frame + interval;
                string path = Img_path(current_frame);
                Image myImage = System.Drawing.Image.FromFile(path);
                this.labelPicBox.Image = myImage;
                this.setFrame.Text = current_frame.ToString();
                DrawRoI(1, 1, current_frame);
            }
            string pathLast = Img_path(current_frame - interval);
            Image ImageLast = System.Drawing.Image.FromFile(pathLast);
            this.referPicBox.Image = ImageLast;
            DrawRoI(2, 2, current_frame);
        }

        private void back_Click(object sender, EventArgs e)
        {

        }

        private void Draw_RoI_Click(object sender, EventArgs e)
        {
            interval = Convert.ToInt32(setInterval.Text);

            int all_num = 0;
            var files = Directory.GetFiles(imgFolderPath + "\\image\\", "*.jpg");

            foreach (var file in files)
                all_num = all_num + 1;
            num_max = all_num;
            this.Frame.Text = num_max.ToString();


            string path = imgFolderPath + "\\image\\img00001.jpg";
            Image myImage = System.Drawing.Image.FromFile(path);
            scaleCoe_W = myImage.Width / 900.0;
            scaleCoe_H = myImage.Height / 506.0;
            this.labelPicBox.Image = myImage;
            int flag_mark = 0;
            string folderPath = imgFolderPath;
            for (int i = 0; folderPath.Length > i; i++)
                if (folderPath[i] == (char)92)
                    flag_mark = i;
            infoDisp.Text = string.Empty;
            for (int i = flag_mark + 1; folderPath.Length > i; i++)
            {
                infoDisp.Text = infoDisp.Text + folderPath[i];
            }
            fileName = infoDisp.Text;
            infoDisp.Text = string.Empty;


            if (RoIbutton == 0)
            {
                RoIbutton = 1;
                IgRMode = true;
                Draw_RoI.Text = "End Draw RoI";
            }
            else if (RoIbutton == 1)
            {
                RoIbutton = 0;
                IgRMode = false;
                Draw_RoI.Text = "Draw RoI";
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            IgRMode = true;
            //RoI =null;
            num_corner = 0;

        }

        private void DrawRoI(int windowsNum, double size, int frame)
        {
            

            //Point startPoint = new Point(,30);
            //Point endPoint = new Point(200,90);
            if ((windowsNum == 1) && (frame <= num_max))
            {
                string path = Img_path(frame);
                Image myImage = System.Drawing.Image.FromFile(path);
                this.labelPicBox.Image = myImage;

                this.labelPicBox.Refresh();
                for (int j = 0; j < num_corner; j++)
                {
                    labelPic.FillRectangle(new SolidBrush(Color.FromArgb(204, Color.Black)), (int)(IgR[j, 0]), (int)(IgR[j, 1]), (int)(IgR[j, 2] - IgR[j, 0]), (int)(IgR[j, 3] - IgR[j, 1]));
                }
                
                //Draw the IgR

                labelPic.DrawString('#' + frame.ToString(), new Font("Arial", 38), new SolidBrush(Color.White), 10, 10);
                //Draw the Bounding box of the target and the ID
                for (int k = 0; k < 400000; k++)
                {
                    if (Convert.ToInt32(lableMat[k, 4]) == frame)
                    {
                        labelPic.DrawString(lableMat[k, 5].ToString(), new Font("Arial", 32), new SolidBrush(Color.Red), (float)lableMat[k, 0], (float)lableMat[k, 1]);
                        labelPic.DrawRectangle(new Pen(Color.Red, 5), (float)lableMat[k, 0], (float)lableMat[k, 1], (float)lableMat[k, 2] - (float)lableMat[k, 0], (float)lableMat[k, 3] - (float)lableMat[k, 1]);
                    }
                }

                
            }
            else if (windowsNum == 2)
            {
                if (frame >= (interval + 1))
                {
                    string path = Img_path(frame - interval);
                    Image lastImage = System.Drawing.Image.FromFile(path);
                    this.referPicBox.Image = lastImage;
                    this.referPicBox.Refresh();
                    for (int j = 0; j < num_corner; j++)
                    {
                        referPic.FillRectangle(new SolidBrush(Color.FromArgb(204, Color.Black)), (int)(IgR[j, 0] / size), (int)(IgR[j, 1] / size), (int)((IgR[j, 2] -IgR[j, 0])/ size), (int)((IgR[j, 3]-IgR[j, 1]) / size));
                    }

                    referPic.DrawString('#' + (frame - interval).ToString(), new Font("Arial", 28), new SolidBrush(Color.White), 10, 10);
                    for (int k = 0; k < 400000; k++)
                    {
                        if (Convert.ToInt32(lableMat[k, 4]) == (frame - interval))
                        {
                            referPic.DrawString(lableMat[k, 5].ToString(), new Font("Arial", 20), new SolidBrush(Color.Red), (float)(lableMat[k, 0] / size), (float)(lableMat[k, 1] / size));
                            referPic.DrawRectangle(new Pen(Color.Red, 4), (float)(lableMat[k, 0] / size), (float)(lableMat[k, 1] / size), (float)(lableMat[k, 2] / size) - (float)(lableMat[k, 0] / size), (float)(lableMat[k, 3] / size) - (float)(lableMat[k, 1] / size));
                        }
                    }

                    
   
                }
            }
        }


        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }



        public void GetId()
        {
            int flag = -1;
            for (int i = 0; i < 400000; i++)
            {
                if ((lableMat[i, 0] / 2) <= IdPoint.X && (lableMat[i, 1] / 2) <= IdPoint.Y && (lableMat[i, 2] / 2) >= IdPoint.X && (lableMat[i, 3] / 2) >= IdPoint.Y && Convert.ToInt32(lableMat[i, 4]) == (current_frame - interval))
                {
                    flag = Convert.ToInt32(lableMat[i, 5]);
                }
            }
            if (flag != -1)
            {
                lableMat[current_indice, 5] = flag;
                infoDisp.Text = infoDisp.Text + Convert.ToInt32(lableMat[current_indice, 0]).ToString() + "," + Convert.ToInt32(lableMat[current_indice, 1]).ToString() + "," + Convert.ToInt32(lableMat[current_indice, 2]).ToString() + "," + Convert.ToInt32(lableMat[current_indice, 3]).ToString() + "," + Convert.ToInt32(lableMat[current_indice, 4]).ToString() + "," + Convert.ToInt32(lableMat[current_indice, 5]).ToString() + "\n";
                infoDisp.Focus();
                infoDisp.Select(infoDisp.Text.Length, 0);
                setNewID.Focus();
                current_indice = current_indice + 1;
            }
            else
                MessageBox.Show("Fail to label the Target");
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            // g2 = this.pictureBox1.CreateGraphics();
            IdPoint.X = e.X;
            IdPoint.Y = e.Y;
            GetId();
            DrawRoI(2, 2, current_frame);
        }
        string inputid = string.Empty;


        private void richTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                inputid = setNewID.Text;
                lableMat[current_indice, 5] = int.Parse(inputid);
                maxID = (Convert.ToInt32(lableMat[current_indice, 5]) >= maxID) ? (Convert.ToInt32(lableMat[current_indice, 5] + 1)) : maxID;
                infoDisp.Text = infoDisp.Text + Convert.ToInt32(lableMat[current_indice, 0]).ToString() + "," + Convert.ToInt32(lableMat[current_indice, 1]).ToString() + "," + Convert.ToInt32(lableMat[current_indice, 2]).ToString() + "," + Convert.ToInt32(lableMat[current_indice, 3]).ToString() + "," + Convert.ToInt32(lableMat[current_indice, 4]).ToString() + "," + Convert.ToInt32(lableMat[current_indice, 5]).ToString() + "\n";
                infoDisp.Focus();
                infoDisp.Select(infoDisp.Text.Length, 0);
                setNewID.Focus();
                current_indice = current_indice + 1;
                setNewID.Text = string.Empty;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lableMat[current_indice, 5] = maxID;
            infoDisp.Text = infoDisp.Text + Convert.ToInt32(lableMat[current_indice, 0]).ToString() + "," + Convert.ToInt32(lableMat[current_indice, 1]).ToString() + "," + Convert.ToInt32(lableMat[current_indice, 2]).ToString() + "," + Convert.ToInt32(lableMat[current_indice, 3]).ToString() + "," + Convert.ToInt32(lableMat[current_indice, 4]).ToString() + "," + Convert.ToInt32(lableMat[current_indice, 5]).ToString() + "\n";
            infoDisp.Focus();
            infoDisp.Select(infoDisp.Text.Length, 0);
            setNewID.Focus();
            current_indice = current_indice + 1;
            maxID = maxID + 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveData();
        }


        private void loadData_Click(object sender, EventArgs e)
        {
            //Get the File Name to load the _Config.txt and _RoI.txt and fileName.txt
            interval = Convert.ToInt32(setInterval.Text);
            string path = imgFolderPath + "\\image\\img00001.jpg";
            Image myImage = System.Drawing.Image.FromFile(path);
            scaleCoe_W = myImage.Width / 900.0;
            scaleCoe_H = myImage.Height / 506.0;
            int flag_mark = 0;
            string folderPath = imgFolderPath;
            for (int i = 0; folderPath.Length > i; i++)
                if (folderPath[i] == (char)92)
                    flag_mark = i;
            infoDisp.Text = string.Empty;
            for (int i = flag_mark + 1; folderPath.Length > i; i++)
            {
                infoDisp.Text = infoDisp.Text + folderPath[i];
            }
            fileName = infoDisp.Text;
            infoDisp.Text = string.Empty;
            StreamReader rd;
            try
            {
                rd = File.OpenText(imgFolderPath + "\\" + fileName + "_" + interval.ToString() + ".txt");
            }
            catch
            {
                rd = File.OpenText(imgFolderPath + "\\" + fileName + ".txt");
            }
            lableMat = new double[400000, 6];
            for (int i = 0; i < 400000; )  //read the data to RAM
            {
                string line = rd.ReadLine();
                if (line != null)
                {
                    string[] data = line.Split(',');
                    /*
                    for (int j = 0; j < 4; j++)
                    {
                        //transTem =  double.Parse(data[j])/2.13333;
                        //lableMat[i, j] = (int)transTem;
                        lableMat[i, j] = (double.Parse(data[j]) / scaleCoe);
                    }
                     */
                    lableMat[i, 0] = (double.Parse(data[0]) / scaleCoe_W); // LeftTop_x
                    lableMat[i, 2] = (double.Parse(data[2]) / scaleCoe_W); // RightDown_x
                    lableMat[i, 1] = (double.Parse(data[1]) / scaleCoe_H); // LeftTop_x
                    lableMat[i, 3] = (double.Parse(data[3]) / scaleCoe_H); // RightDown_y

                    for (int k = 4; k < 6; k++)
                        lableMat[i, k] = double.Parse(data[k]);
                    i = i + 1;
                    current_indice = i;
                }
                else
                    break;
            }
            rd.Close();

            if (current_indice == 0 && Convert.ToInt32(lableMat[current_indice, 4]) == 0)
                current_frame = 1;
            else if (current_indice == 0 && Convert.ToInt32(lableMat[current_indice, 4]) != 0)
                current_frame = Convert.ToInt32(lableMat[current_indice, 4]);
            else
                current_frame = Convert.ToInt32(lableMat[current_indice - 1, 4]);
            maxID = Convert.ToInt32(GetMax(5)) + 1;

            int all_num = 0;
            var files = Directory.GetFiles(imgFolderPath + "\\image\\", "*.jpg");
            foreach (var file in files)
                all_num = all_num + 1;
            num_max = all_num;

            //Load the _RoI.txt
            rd = File.OpenText(imgFolderPath + "\\" + fileName + "_IgR.txt");

            for (int i = 0; i < 100; )  //read the data to RAM
            {
                string line = rd.ReadLine();
                if (line != null)
                {
                    string[] data = line.Split(',');
                    /*
                    for (int j = 0; j < 4; j++)
                    {
                        
                        IgR[i, j] = (double.Parse(data[j]) / scaleCoe);
                    }
                    */
                    IgR[i, 0] = (double.Parse(data[0]) / scaleCoe_W);
                    IgR[i, 1] = (double.Parse(data[1]) / scaleCoe_H);
                    IgR[i, 2] = (double.Parse(data[2]) / scaleCoe_W);
                    IgR[i, 3] = (double.Parse(data[3]) / scaleCoe_H);
                    i = i + 1;
                    num_corner = i;
                }
                else
                    break;
            }
            rd.Close();

            //Write the current img number and sum img number
            setFrame.Text = current_frame.ToString();
            Frame.Text = num_max.ToString();

            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            path = Img_path(current_frame);
            myImage = System.Drawing.Image.FromFile(path);
            scaleCoe_W = myImage.Width / 900.0;
            scaleCoe_H = myImage.Height / 506.0;
            this.labelPicBox.Image = myImage;

            DrawRoI(1, 1, current_frame);
            sw1.Stop();

            if (current_frame >= (interval + 1))
            {
                string pathLast = Img_path(current_frame - interval);
                Image ImageLast = System.Drawing.Image.FromFile(pathLast);
                this.referPicBox.Image = ImageLast;
                DrawRoI(2, 2, current_frame);
            }


        }



        private void SaveData()
        {

            string temWrite = "";
            StreamWriter RoI_W = new StreamWriter(imgFolderPath + "\\" + fileName + "_IgR.txt");
            //begin to write file
            for (int i = 0; i < num_corner; i++)
            {
                temWrite = (scaleCoe_W * IgR[i, 0]) + "," + (scaleCoe_H * IgR[i, 1]) +','+ (scaleCoe_W * IgR[i, 2]) + "," + (scaleCoe_H * IgR[i, 3])+"\n";
                RoI_W.Write(temWrite);
            }
            //clean up cache
            RoI_W.Flush();
            //clear flow
            RoI_W.Close();


            StreamWriter label_W = new StreamWriter(imgFolderPath + "\\" + fileName + "_" + interval.ToString() + ".txt");
            for (int i = 0; i < 400000; i++)
            {
                if (lableMat[i, 4] != 0)
                {
                    temWrite = ((scaleCoe_W * lableMat[i, 0])).ToString() + "," + ((scaleCoe_H * lableMat[i, 1])).ToString() + "," + ((scaleCoe_W * lableMat[i, 2])).ToString() + "," + ((scaleCoe_H * lableMat[i, 3])).ToString() + "," + lableMat[i, 4].ToString() + "," + lableMat[i, 5].ToString() + "\n";
                    label_W.Write(temWrite);
                }

            }

            // clear the buffer
            label_W.Flush();
            // turn off the stream
            label_W.Close();

        }


        public void Sort_Lable()
        {
            double[] temp = new double[6];
            int current_indice = 0;
            for (int i = 0; i < lableMat.GetLongLength(0); i++)
                if (Convert.ToInt32(lableMat[i, 4]) >= 1)
                {
                    current_indice = i;
                }

            for (int i = 0; i <= current_indice; i++)
            {
                for (int j = i; j <= current_indice; j++)
                {
                    if (lableMat[i, 4] > lableMat[j, 4])
                    {
                        for (int k = 0; k < 6; k++)
                        {
                            temp[k] = lableMat[i, k];
                        }
                        for (int k = 0; k < 6; k++)
                        {
                            lableMat[i, k] = lableMat[j, k];
                        }
                        for (int k = 0; k < 6; k++)
                        {
                            lableMat[j, k] = temp[k];
                        }

                    }
                }
            }


        }

        public int GetStart(int frame)
        {
            int start_index = 0;
            for (int i = 0; i < lableMat.GetLongLength(0); i++)
                if (Convert.ToInt32(lableMat[i, 4]) == frame)
                {
                    start_index = i;
                    break;
                }
            return start_index;
        }

        public int GetEnd(int frame)
        {
            int end_index = 0;
            for (int i = 0; i < lableMat.GetLongLength(0); i++)
                if (Convert.ToInt32(lableMat[i, 4]) == frame)
                {
                    end_index = i;
                }
            return end_index;
        }

        public double GetMax(int dimension)
        {
            double temp = 0;
            for (int i = 0; i < lableMat.GetLongLength(0); i++)
            {
                if (temp < lableMat[i, dimension])
                {
                    temp = lableMat[i, dimension];
                }
            }
            return temp;
        }



        private void ViewLable_Click(object sender, EventArgs e)
        {
            if (viewStatuas == 0 && viewFrameIndex <= (num_max - interval))
            {
                viewStatuas = 1;
                ViewLable.Image = imageList1.Images[1];
                playBar.Value = Convert.ToInt32(viewFrameIndex / GetMax(4) * 5000);
                Thread t1 = new Thread(new ThreadStart(ViewPlay));

                t1.Start();
            }
            else if (viewStatuas == 0)
            {
                viewStatuas = 1;
                viewFrameIndex = 1;
                this.ViewLable.Image = imageList1.Images[1];
                playBar.Value = Convert.ToInt32(viewFrameIndex / GetMax(4) * 5000);
                this.Refresh();
                Thread.Sleep(100);

                Thread t1 = new Thread(new ThreadStart(ViewPlay));

                t1.Start();
            }
            else if (viewStatuas == 1)
            {
                viewStatuas = 0;
                this.ViewLable.Image = imageList1.Images[0];
                this.Refresh();
                Thread.Sleep(100);
                DrawRoI(1, 1, viewFrameIndex);

            }

        }

        public void ViewPlay()
        {
            for (; (viewFrameIndex <= GetMax(4)) && (viewStatuas == 1); )
            {

                if (viewStatuas == 0)
                    break;
                string path = Img_path(viewFrameIndex);
                Image myImage = System.Drawing.Image.FromFile(path);
                labelPicBox.Image = myImage;

                labelPicBox.Refresh();
                labelPic.DrawString(viewFrameIndex.ToString(), new Font("Arial", 18), new SolidBrush(Color.Red), 20, 20);
                //Draw the RoI
                for (int j = 0; j < num_corner; j++)
                {
                    labelPic.FillRectangle(new SolidBrush(Color.FromArgb(127, Color.Black)), (int)(IgR[j, 0]), (int)(IgR[j, 1]), (int)(IgR[j, 2] - IgR[j, 0]), (int)(IgR[j, 3] - IgR[j, 1]));    
                }

                //Draw the Bounding box of the target and the ID
                for (int k = 0; k <= current_indice; k++)
                {
                    if (Convert.ToInt32(lableMat[k, 4]) == viewFrameIndex)
                    {
                        labelPic.DrawString(lableMat[k, 5].ToString(), new Font("Arial", 16), new SolidBrush(Color.Black), (float)lableMat[k, 0], (float)lableMat[k, 1]);
                        labelPic.DrawRectangle(new Pen(Color.Blue), (float)lableMat[k, 0], (float)lableMat[k, 1], (float)lableMat[k, 2] - (float)lableMat[k, 0], (float)lableMat[k, 3] - (float)lableMat[k, 1]);
                    }
                }

                Thread.Sleep(20 * interval);
                viewFrameIndex = viewFrameIndex + interval;
            }

        }

        private void EndBack_Click(object sender, EventArgs e)
        {
           
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            insert.Enabled = false;
            insertMode = 1;
            current_frame = Convert.ToInt32(setFrame.Text);

            DrawRoI(1, 1, current_frame);
            int LastIndice = (Convert.ToInt32((num_max / interval)) * interval);
            int iklp = (num_max / interval);

            if (LastIndice == num_max)
                LastIndice = LastIndice + 1 - interval;
            infoDisp.Text = LastIndice.ToString() + " " + iklp.ToString() + " " + (3 / 2).ToString();
            if (current_frame <= LastIndice)
            {
                DrawRoI(2, 2, current_frame);
            }
            else
            {
                DrawRoI(2, 2, LastIndice + interval);
            }
        }

        private void EndInsert_Click(object sender, EventArgs e)
        {
            insert.Enabled = true;
            insertMode = 0;
            current_frame = Convert.ToInt32(GetMax(4));
            setFrame.Text = current_frame.ToString();
            DrawRoI(1, 1, current_frame);
            DrawRoI(2, 2, current_frame);
        }

        private void OpenImgPath_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();

            System.Windows.Forms.DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                imgFolderPath = folderBrowserDialog.SelectedPath;

            }
        }

        private void ViewBack_Click(object sender, EventArgs e)
        {
            if (viewFrameIndex >= (interval + 1))
            {
                viewFrameIndex = viewFrameIndex - interval;
                playBar.Value = Convert.ToInt32(viewFrameIndex / GetMax(4) * 5000);
                DrawRoI(1, 1, viewFrameIndex);
            }
        }

        private void ViewNext_Click(object sender, EventArgs e)
        {
            if (viewFrameIndex < (num_max - interval))
            {
                viewFrameIndex = viewFrameIndex + interval;
                playBar.Value = Convert.ToInt32(viewFrameIndex / GetMax(4) * 5000);
                DrawRoI(1, 1, viewFrameIndex);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void DeleteTarget_Click(object sender, EventArgs e)
        {
            //double[] temp = new double[6];
            current_frame = int.Parse(this.setFrame.Text);
            if (setID.Text == "")
            {
                MessageBox.Show("Please input the Target ID you want to Delete!");
                DrawRoI(1, 1, current_frame);
                DrawRoI(2, 2, current_frame);
                return;
            }
            else if (setID.Text != "")
            {
                for (int k = 0; k < 400000; k++)
                {
                    if (Convert.ToInt32(lableMat[k, 4]) == 0)
                    {
                        current_indice = k;
                        break;
                    }
                }
                for (int i = 0; i < 400000; i++)
                {

                    if ((Convert.ToInt32(lableMat[i, 4]) == current_frame) && (Convert.ToInt32(lableMat[i, 5]) == int.Parse(this.setID.Text)))
                    {

                        int deleteI = i;
                        while (deleteI < current_indice)
                        {
                            for (int j = 0; j < 6; j++)
                            {
                                lableMat[deleteI, j] = lableMat[deleteI + 1, j];
                            }
                            deleteI = deleteI + 1;
                        }

                    }


                }
                MessageBox.Show("Delete Target " + this.setID.Text+" in Frame" + current_frame.ToString());
            }


            DrawRoI(1, 1, current_frame);
            DrawRoI(2, 2, current_frame);
        }

        private void EndDelete_Click(object sender, EventArgs e)
        {
            current_frame = Convert.ToInt32(GetMax(4));
            for (int k = 0; k < 400000; k++)
            {
                if (Convert.ToInt32(lableMat[k, 4]) == 0)
                {
                    current_indice = k;
                    break;
                }
            }
            maxID = Convert.ToInt32(GetMax(5)) + 1;
            setFrame.Text = current_frame.ToString();
            DrawRoI(1, 1, current_frame);
            DrawRoI(2, 2, current_frame);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (Convert.ToInt32(playBar.Value * GetMax(4) / 5000) > GetMax(4))

                viewFrameIndex = Convert.ToInt32(GetMax(4));
            else if (Convert.ToInt32(playBar.Value * GetMax(4) / 5000) < 1)
                viewFrameIndex = 1;
            else
                viewFrameIndex = Convert.ToInt32(playBar.Value * GetMax(4) / 5000);

            DrawRoI(1, 1, viewFrameIndex);
        }

        private void newTarget_Click(object sender, EventArgs e)
        {
            lableMat[current_indice, 5] = maxID;
            infoDisp.Text = infoDisp.Text + Convert.ToInt32(lableMat[current_indice, 0]).ToString() + "," + Convert.ToInt32(lableMat[current_indice, 1]).ToString() + "," + Convert.ToInt32(lableMat[current_indice, 2]).ToString() + "," + Convert.ToInt32(lableMat[current_indice, 3]).ToString() + "," + Convert.ToInt32(lableMat[current_indice, 4]).ToString() + "," + Convert.ToInt32(lableMat[current_indice, 5]).ToString() + "\n";
            infoDisp.Focus();
            infoDisp.Select(infoDisp.Text.Length, 0);
            setNewID.Focus();
            current_indice = current_indice + 1;
            maxID = maxID + 1;
        }

        private void modify_Click(object sender, EventArgs e)
        {
            current_frame = int.Parse(this.setFrame.Text);
            if (setID.Text == "")
            {
                MessageBox.Show("Please input the Target ID you want to modify");
                DrawRoI(1, 1, current_frame);
                DrawRoI(2, 2, current_frame);
                return;
            }
            else if (setID.Text != "")
            {
                for (int i = 0; i < 400000; i++)
                {
                    if ((Convert.ToInt32(lableMat[i, 4]) == current_frame) && (Convert.ToInt32(lableMat[i, 5]) == int.Parse(this.setID.Text)))
                    {
                        current_indice = i;
                        break;
                    }

                }
                MessageBox.Show("Begain to modify Target " + Convert.ToInt32(lableMat[current_indice, 5]).ToString() + " in Frame " + current_frame.ToString());
            }
            this.infoDisp.Text = "Modify " + current_frame.ToString() + " Target " + Convert.ToInt32(lableMat[current_indice, 5]).ToString() + "\n";
            int tem_ID = 0;
            for (int i = 0; i < current_indice; i++)
                tem_ID = (tem_ID > Convert.ToInt32(lableMat[i, 5])) ? tem_ID : Convert.ToInt32(lableMat[i, 5]);
            maxID = tem_ID + 1;
            DrawRoI(1, 1, current_frame);
            DrawRoI(2, 2, current_frame);

        }

        private void reDrawRoI_Click(object sender, EventArgs e)
        {
            IgRMode = false;
            //RoI =null;
            num_corner = 0;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void endModify_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 400000; i++)
            {
                if (Convert.ToInt32(lableMat[i, 4]) == 0)
                {
                    current_indice = i;
                    break;
                }
            }
            maxID = Convert.ToInt32(GetMax(5)) + 1;
            current_frame = Convert.ToInt32(GetMax(4));
            setFrame.Text = current_frame.ToString();
            DrawRoI(1, 1, current_frame);
            DrawRoI(2, 2, current_frame);
            insert.Enabled = true;
            insertMode = 0;
        }

    }
}
