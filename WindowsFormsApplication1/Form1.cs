using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Windows.Media;
using System.Collections;
using System.Threading;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Util;
using Emgu.CV.Structure;
namespace WindowsFormsApplication1
{
    public partial class  Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Image<Bgr, Byte> pic ;
        Image<Bgr, Byte> pic_backup;
        Image<Bgra, Byte> pic_roi;
        Node[,] pic_nodes;
        List<int[]> click_points = new List<int[]>();
        Dictionary<int, List<int[]>> all_contour_points = new Dictionary<int, List<int[]>>();
        private void zedGraphControl1_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //pic = new Image<Bgr, Byte>("C:\\Users\\chou\\Desktop\\emma.jpg");
            //pic_nodes = new Node[pic.Rows, pic.Cols];
            //pictureBox1.Image = pic.ToBitmap();
            // Initiallition the Nodes
            //for (int i = 0; i < pic.Rows; i++)
            //    for (int j = 0; j < pic.Cols; j++)
            //    {
            //        pic_nodes[i, j] = new Node(i, j);
            //    }
            MessageBox.Show(Math.Abs(pic.Data[50 , 40, 2]).ToString());
        }
        private void imageBox1_Click(object sender, EventArgs e)
        {
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Calculate Lin_ Cost 
            Cal_link_cost();
            Image<Bgr, Byte> cost_graph = pic.Resize(3, Emgu.CV.CvEnum.Inter.Nearest); 
            for (int i = 1; i < cost_graph.Rows - 1; i = i + 3)
                for (int j = 1; j < cost_graph.Cols - 1; j = j + 3)
                {
                    int ii = (i - 1) / 3;
                    int jj = (j - 1) / 3;
                    //cost_graph[i, j] = pic[ii, jj];
                    for (int k = 0; k < 3; k++)
                    {
                        cost_graph.Data[i, j, k] = pic.Data[ii, jj, k];
                        cost_graph.Data[i, j + 1, k] = (byte)pic_nodes[ii, jj].link_cost[0];
                        cost_graph.Data[i - 1, j + 1, k] = (byte)pic_nodes[ii, jj].link_cost[1];
                        cost_graph.Data[i - 1, j, k] = (byte)pic_nodes[ii, jj].link_cost[2];
                        cost_graph.Data[i - 1, j - 1, k] = (byte)pic_nodes[ii, jj].link_cost[3];
                        cost_graph.Data[i, j - 1, k] = (byte)pic_nodes[ii, jj].link_cost[4];
                        cost_graph.Data[i + 1, j - 1, k] = (byte)pic_nodes[ii, jj].link_cost[5];
                        cost_graph.Data[i + 1, j, k] = (byte)pic_nodes[ii, jj].link_cost[6];
                        cost_graph.Data[i + 1, j + 1, k] = (byte)pic_nodes[ii, jj].link_cost[7];
                    }
                    //    cost_graph[i, j + 1] = new Bgr(pic_nodes[ii, jj].link_cost[0], pic_nodes[ii, jj].link_cost[0], pic_nodes[ii, jj].link_cost[0]);
                    //cost_graph[i - 1, j + 1] = new Bgr(pic_nodes[ii, jj].link_cost[1], pic_nodes[ii, jj].link_cost[1], pic_nodes[ii, jj].link_cost[1]);
                    //cost_graph[i - 1, j] = new Bgr(pic_nodes[ii, jj].link_cost[2], pic_nodes[ii, jj].link_cost[2], pic_nodes[ii, jj].link_cost[2]);
                    //cost_graph[i - 1, j - 1] = new Bgr(pic_nodes[ii, jj].link_cost[3], pic_nodes[ii, jj].link_cost[3], pic_nodes[ii, jj].link_cost[3]);
                    //cost_graph[i, j - 1] = new Bgr(pic_nodes[ii, jj].link_cost[4], pic_nodes[ii, jj].link_cost[4], pic_nodes[ii, jj].link_cost[4]);
                    //cost_graph[i + 1, j - 1] = new Bgr(pic_nodes[ii, jj].link_cost[5], pic_nodes[ii, jj].link_cost[5], pic_nodes[ii, jj].link_cost[5]);
                    //cost_graph[i + 1, j] = new Bgr(pic_nodes[ii, jj].link_cost[6], pic_nodes[ii, jj].link_cost[6], pic_nodes[ii, jj].link_cost[6]);
                    //cost_graph[i + 1, j + 1] = new Bgr(pic_nodes[ii, jj].link_cost[7], pic_nodes[ii, jj].link_cost[7], pic_nodes[ii, jj].link_cost[7]);
                }
            pictureBox1.Image = cost_graph.ToBitmap();
        }
        //Calculate Link_Cost
        public void Cal_link_cost()
        {
            double[,] DRGB_link = new double[3, 8];
            double D_max = 0;
            //Calculate D_link cost
            for (int row = 1; row < pic.Rows - 1; row++)
                for (int col = 1; col < pic.Cols - 1; col++)
                {
                    for (int k = 0; k < 3;k++)
                    {
                        DRGB_link[k, 0] = Math.Abs(pic.Data[row - 1, col, k] + pic.Data[row - 1, col + 1, k] - pic.Data[row + 1, col, k] - pic.Data[row + 1, col + 1, k]) / 4;
                        DRGB_link[k, 1] = Math.Abs(pic.Data[row - 1, col, k] - pic.Data[row, col + 1, k]) / Math.Sqrt(2);
                        DRGB_link[k, 2] = Math.Abs(pic.Data[row - 1, col - 1, k] + pic.Data[row, col - 1, k] - pic.Data[row - 1, col + 1, k] - pic.Data[row, col + 1, k]) / 4;
                        DRGB_link[k, 3] = Math.Abs(pic.Data[row - 1, col, k] - pic.Data[row, col - 1, k]) / Math.Sqrt(2);
                        DRGB_link[k, 4] = Math.Abs(pic.Data[row - 1, col, k] + pic.Data[row - 1, col - 1, k] - pic.Data[row + 1, col, k] - pic.Data[row + 1, col - 1, k]) / 4;
                        DRGB_link[k, 5] = Math.Abs(pic.Data[row + 1, col, k] - pic.Data[row, col - 1, k]) / Math.Sqrt(2);
                        DRGB_link[k, 6] = Math.Abs(pic.Data[row, col - 1, k] + pic.Data[row + 1, col - 1, k] - pic.Data[row, col + 1, k] - pic.Data[row + 1, col + 1, k]) / 4;
                        DRGB_link[k, 7] = Math.Abs(pic.Data[row + 1, col, k] - pic.Data[row, col + 1, k]) / Math.Sqrt(2);
                    }                   
                    for (int k = 0; k < 8; k++)
                    {
                        pic_nodes[row, col].link_cost[k] = Math.Sqrt((DRGB_link[0, k] * DRGB_link[0, k] + DRGB_link[1, k] * DRGB_link[1, k] + DRGB_link[2, k] * DRGB_link[2, k]) / 3);
                        if (D_max < pic_nodes[row, col].link_cost[k])
                            D_max = pic_nodes[row, col].link_cost[k];
                    }                 
                }
            //Calculate the link_cost
            double[] length = new double[8] { 1, Math.Sqrt(2), 1, Math.Sqrt(2), 1, Math.Sqrt(2), 1, Math.Sqrt(2) };
            for (int i = 1; i < pic.Rows-1; i++)
                for (int j = 1; j < pic.Cols-1; j++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        pic_nodes[i, j].link_cost[k] = (D_max - pic_nodes[i, j].link_cost[k]) * length[k];
                    }
                }
        }
        //Generate Path Tree
        //public void Path_tree(int[] pos_seed)
        //{
        //    int[] neighbor_x = new int[8] { 0, -1, -1, -1, 0, 1, 1, 1 };
        //    int[] neighbor_y = new int[8] { 1, 1, 0, -1, -1, -1, 0, 1 };
        //    Dictionary<int[],double> pq = new Dictionary<int[],double>();
        //    pic_nodes[pos_seed[0], pos_seed[1]].total_cost = 0;
        //    pic_nodes[pos_seed[0], pos_seed[1]].Parent = null;
        //    //Insert seed into pq
        //    pq.Add( pos_seed,pic_nodes[pos_seed[0], pos_seed[1]].total_cost);
        //    while (pq.Count > 0) //while pq is not empty
        //    {
        //        int[] pos_q = new int[2];
        //        double total_cost_q = pq.Values.Min();
        //        foreach (KeyValuePair<int[], double> kvp in pq)
        //        {
        //            if (kvp.Value.Equals(pq.Values.Min()))
        //            {
        //                pos_q = kvp.Key;
        //                break;
        //            }
        //        }
        //        //pos_q = pq.Values.First();
        //        pq.Remove(pos_q);//Exactmin! Only one line for C#!
        //        pic_nodes[pos_q[0], pos_q[1]].state = 2;
        //        for (int i = 0; i < 8; i++)
        //        {
        //            int[] pos_r = new int[2];
        //            pos_r[0] = pos_q[0] + neighbor_x[i];
        //            pos_r[1] = pos_q[1] + neighbor_y[i];
        //            if (pos_r[0] >0 && pos_r[0] < pic.Rows - 1 && pos_r[1] >0 && pos_r[1] <pic.Cols - 1)
        //            {
        //                if (pic_nodes[pos_r[0], pos_r[1]].state == 0)
        //                {
        //                    pic_nodes[pos_r[0], pos_r[1]].Parent = pos_q;
        //                    //pic_nodes[pos_r[0], pos_r[1]].total_cost = pic_nodes[pos_q[0], pos_q[1]].total_cost + pic_nodes[pos_q[0], pos_q[1]].link_cost[i];
        //                    pic_nodes[pos_r[0], pos_r[1]].total_cost = total_cost_q + pic_nodes[pos_q[0], pos_q[1]].link_cost[i];
        //                    pq.Add(pos_r,pic_nodes[pos_r[0], pos_r[1]].total_cost);                            
        //                    pic_nodes[pos_r[0], pos_r[1]].state = 1;
        //                }
        //                else if (pic_nodes[pos_r[0], pos_r[1]].state == 1)
        //                {
        //                    if (pic_nodes[pos_r[0], pos_r[1]].total_cost > total_cost_q + pic_nodes[pos_q[0], pos_q[1]].link_cost[i])
        //                    {
        //                        pic_nodes[pos_r[0], pos_r[1]].Parent = pos_q;
        //                        pic_nodes[pos_r[0], pos_r[1]].total_cost = total_cost_q + pic_nodes[pos_q[0], pos_q[1]].link_cost[i];
        //                        //pq[pic_nodes[pos_r[0], pos_r[1]].total_cost] = pos_r;
        //                        //pq.Add(pic_nodes[pos_r[0], pos_r[1]].total_cost, pos_r);
        //                        foreach (KeyValuePair<int[], double> kvp in pq)
        //                        {
        //                            if (kvp.Key.Equals(pos_r))
        //                            {
        //                                pq.Remove(kvp.Key);
        //                                pq.Add(kvp.Key, pic_nodes[pos_r[0], pos_r[1]].total_cost);
        //                                break;
        //                            }
        //                        }
        //                    }
        //                }
        //                //if (pic_nodes[pos_r[0], pos_r[1]].state != 2)
        //                //{
        //                //    double temp_cost = pic_nodes[pos_r[0], pos_r[1]].total_cost;
        //                //    pic_nodes[pos_r[0], pos_r[1]].total_cost = Math.Min(temp_cost, pic_nodes[pos_q[0], pos_q[1]].total_cost + pic_nodes[pos_q[0], pos_q[1]].link_cost[i]);
        //                //    if (!Math.Equals(temp_cost, pic_nodes[pos_r[0], pos_r[1]].total_cost))
        //                //    {
        //                //        pic_nodes[pos_r[0], pos_r[1]].Parent = pos_q;
        //                //        if (!pq.ContainsKey(pos_r))
        //                //            pq.Add(pos_r, pic_nodes[pos_r[0], pos_r[1]].total_cost);
        //                //        else
        //                //            foreach (KeyValuePair<int[], double> kvp in pq)
        //                //            {
        //                //                if (kvp.Key.Equals(pos_r))
        //                //                {
        //                //                    pq.Remove(kvp.Key);
        //                //                    pq.Add(kvp.Key, pic_nodes[pos_r[0], pos_r[1]].total_cost);
        //                //                    break;
        //                //                }
        //                //            }
        //                //    }
        //                //}
        //            }
        //        }
        //    }
        //}
        public void Path_tree(int[] pos_seed)
        {
            foreach (Node node in pic_nodes)
            {
                node.state = 0;
                node.Parent = null;
            }
            int[] neighbor_x = new int[8] { 0, -1, -1, -1, 0, 1, 1, 1 };
            int[] neighbor_y = new int[8] { 1, 1, 0, -1, -1, -1, 0, 1 };
            int expanded_num = 1;
            PriorityQueue pq = new PriorityQueue();
            pic_nodes[pos_seed[0], pos_seed[1]].priority = 0;
            pic_nodes[pos_seed[0], pos_seed[1]].Parent = null;
            pq.Add(pic_nodes[pos_seed[0], pos_seed[1]]);
            while (pq.hasNextPixel()) //while pq is not empty
            {
                Node temp_node = pq.nextPixel;
                double total_cost_q = temp_node.priority;
                int[] pos_q = new int[2];
                pos_q[0] = temp_node.pos_x;
                pos_q[1] = temp_node.pos_y;
                pic_nodes[temp_node.pos_x,temp_node.pos_y].state = 2;
                pic_nodes[temp_node.pos_x, temp_node.pos_y].expanded_num = expanded_num;
                expanded_num++;
                for (int i = 0; i < 8; i++)
                {
                    int[] pos_r = new int[2];
                    pos_r[0] = pos_q[0] + neighbor_x[i];
                    pos_r[1] = pos_q[1] + neighbor_y[i];
                    if (pos_r[0] >0 && pos_r[0] < pic.Rows-1  && pos_r[1] > 0 && pos_r[1] < pic.Cols-1 )
                    {
                        if (pic_nodes[pos_r[0], pos_r[1]].state != 2)
                        {
                            if (pq.Contains(pic_nodes[pos_r[0],pos_r[1]]))
                            {
                                if(pic_nodes[pos_q[0], pos_q[1]].priority + pic_nodes[pos_q[0], pos_q[1]].link_cost[i]<pic_nodes[pos_r[0],pos_r[1]].priority)
                                {
                                    pic_nodes[pos_r[0],pos_r[1]].Parent=pos_q;
                                    pic_nodes[pos_r[0], pos_r[1]].priority = pic_nodes[pos_q[0], pos_q[1]].link_cost[i] + pic_nodes[pos_q[0], pos_q[1]].priority;
                                }
                            }
                            else
                            {
                                pic_nodes[pos_r[0], pos_r[1]].Parent = pos_q;
                                pic_nodes[pos_r[0], pos_r[1]].priority = pic_nodes[pos_q[0], pos_q[1]].link_cost[i] + pic_nodes[pos_q[0], pos_q[1]].priority;
                                pq.Add(pic_nodes[pos_r[0], pos_r[1]]);
                            }
                        }
                    }
                }
            }
        }
        //Generate Live Wire
        Image<Bgr, Byte> live_wire;
        Image<Gray, Byte> mask;
        public List<int[]> Live_wire(int[] pos_mouse)
        {
            List<int[]> contour_points = new List<int[]>();
            //contour_points.Clear();
            live_wire = pic.Clone();
          //  mask_temp = mask.Clone();
            int[] temp = pos_mouse;
            if (temp[0] == 0)
                temp[0] += 1;
            else if (temp[0] == pic.Rows - 1)
                temp[0] -= 1;
            else if (temp[1] == 0)
                temp[1] += 1;
            else if (temp[1] == pic.Cols - 1)
                temp[1] -= 1;
                while (temp[0]!=pos_seed[0] || temp[1]!=pos_seed[1])
                {
                    live_wire.Data[temp[0], temp[1], 0] = 0;
                    live_wire.Data[temp[0], temp[1], 1] = 0;
                    live_wire.Data[temp[0], temp[1], 2] = 255;
                    contour_points.Add(new int[]{temp[0],temp[1]});
                   //mask_temp.Data[temp[0], temp[1],0] = 255;
                    temp = pic_nodes[temp[0], temp[1]].Parent;
                    if (temp == null)
                    {
                        live_wire = pic.Clone();
                 //       mask_temp = mask.Clone();
                        contour_points.Clear();
                        break;
                    }
                }
                if (contour_points.Count> 0)
                    contour_points.Add(pos_seed);
                return contour_points;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //Image<Bgr, Byte> live_wire;
            int[] pos_seed = new int[2] { 112, 222 };
            int[] pos_mouse = new int[2] { 254, 176 };
            Path_tree(pos_seed);
            Live_wire(pos_mouse);
            pictureBox1.Image = live_wire.ToBitmap();
        }
        bool mouse_click = false;// 第一次点击的标志
        bool move_flag = false;//移动图片的标志
        int[] pos_mouse=new int[2];
        int[] pos_seed = new int[2];
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (toolStripButton1.Enabled == true)
            {
                move_flag = true;
                pos_mouse[0] = e.X;
                pos_mouse[1] = e.Y;
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            move_flag = false;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move_flag)
            {
                pictureBox1.Left += Convert.ToInt16(e.X - pos_mouse[0]);
                pictureBox1.Top += Convert.ToInt16(e.Y - pos_mouse[1]);
            }
            //textBox1.Text = "X: "+e.Y.ToString()+"  "+"Y: "+e.X.ToString();
            toolStripStatusLabel1.Text = "Row: " + e.Y.ToString() + "  " + "Col: " + e.X.ToString();
            if (toolStripButton1.Enabled == false && mouse_click==true )
            {
                if (min_path_flag == false)
                {
                    pos_mouse[0] = e.Y;
                    pos_mouse[1] = e.X;
                    Live_wire(pos_mouse);
                    pictureBox1.Image = live_wire.ToBitmap();   
                }
                else
                {
                    //Image<Bgr, Byte> min_path = new Image<Bgr, Byte>(pic.Cols * 3, pic.Rows * 3, new Bgr(0, 0, 0));
                        min_path = path_tree.Clone();
                        //pictureBox1.Image = min_path.ToBitmap();
                        pos_mouse[0] = (e.Y - 1) / 3;
                        pos_mouse[1] = (e.X - 1) / 3;
                        List<int[]> contour_points = Live_wire(pos_mouse);
                        foreach (var item in contour_points)
                        {
                            min_path.Data[item[0] * 3 + 1, item[1] * 3 + 1, 0] = 0;
                            min_path.Data[item[0] * 3 + 1, item[1] * 3 + 1, 1] = 0;
                            min_path.Data[item[0] * 3 + 1, item[1] * 3 + 1, 2] = 255;
                        }
                        pictureBox1.Image = min_path.ToBitmap();
                }
            }
        }
        void Cal_path_tree()
        {          
            Path_tree(pos_seed);
        }
        Thread cal;
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (toolStripButton1.Enabled == false && min_path_flag==false)
            {
                if (!mouse_click)
                {
                    pos_seed[0] = e.Y;
                    pos_seed[1] = e.X;
                    mouse_click = true;
                    click_points.Add(new int[2]{e.Y,e.X});
                }
                else
                 {
                    //pic_backup = pic.Clone();
                    //pic = live_wire.Clone();
                   // mask_backup = mask.Clone();
                 //  mask = mask_temp.Clone();
                     List<int[]> contour_points=Live_wire(pos_mouse);
                     foreach (int[] point in contour_points)
                     {
                         pic.Data[point[0], point[1], 0] = 0;
                         pic.Data[point[0], point[1], 1] = 0;
                         pic.Data[point[0], point[1], 2] = 255;
                     }
                    pos_seed[0] = e.Y;
                    pos_seed[1] = e.X;//
                    click_points.Add(new int[2] { e.Y, e.X });
                    all_contour_points.Add(click_points.Count - 1, contour_points);
                }
                //textBox2.Text += pos_seed[0].ToString() + " , " + pos_seed[1].ToString() + Environment.NewLine;
                toolStripStatusLabel2.Text  += pos_seed[0].ToString() + " , " + pos_seed[1].ToString() + Environment.NewLine;
                try
                {
                    cal.Abort();
                }
                catch { }
                cal = new Thread(Cal_path_tree);
                cal.Priority = ThreadPriority.Highest;
                cal.Start();
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = pic.ToBitmap();
                pictureBox1.Cursor = Cursors.Cross;
                toolStripButton1.Enabled = false;
                toolStripButton2.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Open Image First!");
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                cal.Abort();
            }
            catch{}
            // Open picture
            OpenFileDialog openfile = new OpenFileDialog();
            if(openfile.ShowDialog()==DialogResult.OK)
            {
                string name = openfile.FileName;
                pic = new Image<Bgr, Byte>(name);
                pictureBox1.Image = pic.ToBitmap();
                // Initial pic_nodes
                pic_nodes = new Node[pic.Rows, pic.Cols];
                for (int i = 0; i < pic.Rows; i++)
                    for (int j = 0; j < pic.Cols; j++)
                    {
                        pic_nodes[i, j] = new Node(i, j);
                    }
                Cal_link_cost();
                toolStripStatusLabel1.Text = null;
                toolStripStatusLabel2.Text = null;
                toolStripButton1.Enabled = true;
                toolStripButton2.Enabled = false;
                min_path_flag = false;
                trackBar1.Visible = false;
                click_points.Clear();
                all_contour_points.Clear();
                mask = new Image<Gray, Byte>(pic.Cols, pic.Rows);
                pic_roi = new Image<Bgra, Byte>(pic.Cols, pic.Rows,new Bgra(0,0,0,0));
                pic_backup = pic.Clone();
            }
        }
        //Stop
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (mouse_click && !toolStripButton1.Enabled && click_points.Count>2)//最后结束
            {
                //Calculate contour
                mouse_click = false;
                toolStripButton1.Enabled = true;
                pictureBox1.Image = pic.ToBitmap();
                pos_seed = click_points[0];
                pos_mouse = click_points[click_points.Count - 1];
                try
                {
                    cal.Abort();
                }
                catch { }
                cal = new Thread(Cal_path_tree);
                cal.Priority = ThreadPriority.Highest;
                cal.Start();
                List<int[]> contour_points = new List<int[]>();
                while (contour_points.Count == 0)
                {
                    contour_points = Live_wire(pos_mouse);
                }
                foreach (int[] point in contour_points)
                {
                    pic.Data[point[0], point[1], 0] = 0;
                    pic.Data[point[0], point[1], 1] = 0;
                    pic.Data[point[0], point[1], 2] = 255;
                }
                pictureBox1.Image = pic.ToBitmap();
                all_contour_points.Add(click_points.Count, contour_points);
                //calculate mask
                foreach (var item in all_contour_points)
                    foreach (int[] point in item.Value)
                    {
                        mask.Data[point[0], point[1], 0] = 255;
                    }
                    //mask._Dilate(60);
                    //mask._Erode(60);
                mask = Fill_contour(mask);
                for (int i = 0; i < mask.Rows; i++)
                    for (int j = 0; j < mask.Cols;j++ )
                    {
                        if (mask.Data[i, j, 0] == 0)
                        {
                            mask.Data[i, j, 0] = 255;
                            pic_roi.Data[i, j, 0] = pic.Data[i, j, 0];
                            pic_roi.Data[i, j, 1] = pic.Data[i, j, 1];
                            pic_roi.Data[i, j, 2] = pic.Data[i, j, 2];
                            pic_roi.Data[i, j, 3] = 255;
                        }
                        else if (mask.Data[i, j, 0] == 255)
                        {
                            mask.Data[i, j, 0] = 0;
                            //pic_roi.Data[i, j, 0] = 0;
                        }
                    }
                // calculate the roi
                        toolStripButton2.Enabled = false;
            }
            else if(mouse_click==false&& toolStripButton1.Enabled==false)
            {
                click_points.Clear();
                //textBox2.Clear();
                toolStripStatusLabel2.Text = null;
                all_contour_points.Clear();
                pic = pic_backup.Clone();
                mouse_click = false;
                toolStripButton1.Enabled = true;
                toolStripButton2.Enabled = false;
                pictureBox1.Image = pic.ToBitmap();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }
        private void toolStripButton5_Click(object sender, EventArgs e) //undo
        {
            if (toolStripButton2.Enabled == true) //Still working
            {
                if (click_points.Count == 0)
                {
                    MessageBox.Show("No point to delete!");
                }
                else if (click_points.Count == 1)
                {
                    mouse_click = false;
                    click_points.Clear();
                    pictureBox1.Image = pic.ToBitmap();
                    //textBox2.Clear();
                    toolStripStatusLabel2.Text = null;
                    try
                    {
                        cal.Abort();
                    }
                    catch { }
                }
                else
                {
                    click_points.RemoveAt(click_points.Count - 1);
                    all_contour_points.Remove(click_points.Count);
                    //textBox2.Clear();
                    toolStripStatusLabel2.Text = null;
                    foreach (int[] point in click_points)
                    {
                        //textBox2.Text += point[0].ToString() + " , " + point[1].ToString() + Environment.NewLine;
                        toolStripStatusLabel2.Text  += point[0].ToString() + " , " + point[1].ToString() + Environment.NewLine;
                    }
                    pic = pic_backup.Clone();
                    foreach (var item in all_contour_points)
                        foreach (int[] point in item.Value)
                        {
                            pic.Data[point[0], point[1], 0] = 0;
                            pic.Data[point[0], point[1], 1] = 0;
                            pic.Data[point[0], point[1], 2] = 255;
                        }
                    pictureBox1.Image = pic.ToBitmap();
                    pos_seed = click_points[click_points.Count - 1];
                    try
                    {
                        cal.Abort();
                    }
                    catch { }
                    cal = new Thread(Cal_path_tree);
                    cal.Priority = ThreadPriority.Highest;
                    cal.Start();
                }
            }
            else //work done
            {
                click_points.Clear();
                //textBox2.Clear();
                toolStripStatusLabel2.Text = null;
                all_contour_points.Clear();
                pic = pic_backup.Clone();
                mouse_click = false;
                toolStripButton1.Enabled = true;
                toolStripButton2.Enabled = false;
                pictureBox1.Image = pic.ToBitmap();
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
        }
        //save contour
        private void saveContourToolStripMenuItem_Click(object sender, EventArgs e)  
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save Image With Contour";
            //sfd.ShowDialog();
            sfd.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|PNG Image|*.png";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (sfd.FileName != "")
                {
                    // Saves the Image via a FileStream created by the OpenFile method.
                    System.IO.FileStream fs =
                       (System.IO.FileStream)sfd.OpenFile();
                    // Saves the Image in the appropriate ImageFormat based upon the
                    // File type selected in the dialog box.
                    // NOTE that the FilterIndex property is one-based.
                    switch (sfd.FilterIndex)
                    {
                        case 1:
                            this.pictureBox1.Image.Save(fs,
                               System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case 2:
                            this.pictureBox1.Image.Save(fs,
                               System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                        case 3:
                            this.pictureBox1.Image.Save(fs,
                               System.Drawing.Imaging.ImageFormat.Png);
                            break;
                    }
                    fs.Close();
                }
            }
        }
        Image<Gray,Byte> Fill_contour(Image<Gray,Byte> mask)
        {
            Image<Gray, Byte> resultimage = mask.Clone();
            resultimage._Dilate(1);
            Image<Gray, Byte> mymask = new Image<Gray, Byte>(resultimage.Width + 2, resultimage.Height + 2);
            Rectangle rect = new System.Drawing.Rectangle(0, 0, 10000, 10000);
            CvInvoke.FloodFill(resultimage, mymask, new System.Drawing.Point(0, 0), new MCvScalar(255), out rect, new MCvScalar(0), new MCvScalar(0),
                 Emgu.CV.CvEnum.Connectivity.EightConnected, Emgu.CV.CvEnum.FloodFillType.Default);
            resultimage._Erode(1);
            return resultimage;          
        }
        Image<Gray,Byte> My_dilate(Image<Gray,Byte> contour,int Max_row,int Min_row,int Max_col,int Min_col)
        {
            for(int i=Min_row;i<=Max_row;i++)
                for(int j=Min_col;j<Max_col;j++)
                {
                    for (int ii = i - 1; ii <= i + 1; ii++)
                        for (int jj = j - 1; jj < j + 1; jj++)
                            if (contour.Data[ii, jj, 0] == 255)
                            {
                                contour.Data[i, j, 0] = 255;
                                break;                                
                            }
                }
            return contour;
        }
        Image<Gray, Byte> My_erode(Image<Gray, Byte> contour, int Max_row, int Min_row, int Max_col, int Min_col)
        {
            for (int i = Min_row; i <= Max_row; i++)
                for (int j = Min_col; j < Max_col; j++)
                {
                    for (int ii = i - 1; ii <= i + 1; ii++)
                        for (int jj = j - 1; jj < j + 1; jj++)
                            if (contour.Data[ii, jj, 0] == 0)
                            {
                                contour.Data[i, j, 0] = 0;
                                break;
                            }
                }
            return contour;
        }
        private void imageWithContourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if(toolStripButton2.Enabled==true)
                {
                    mouse_click = true;
                    toolStripButton1.Enabled = false;
                    min_path_flag = false;
                    pictureBox1.Image = pic.ToBitmap();
                }
                else
                {
                    pictureBox1.Image = pic.ToBitmap();
                    min_path_flag = false;
                }
                trackBar1.Visible = false;
            }
            catch { }
        }
        private void imageOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                mouse_click = false;
                toolStripButton1.Enabled = true;
                pictureBox1.Image = pic_backup.ToBitmap();
            }
            catch { }
        }
        private void toolStripButton3_Click(object sender, EventArgs e) //Zoom in
        {
            if(toolStripButton1.Enabled==true && toolStripButton2.Enabled==false)
            {
                Image<Bgr, Byte> pic_zoom = new Image<Bgr, Byte>((Bitmap)pictureBox1.Image);
                pic_zoom = pic_zoom.Resize(1.5, Emgu.CV.CvEnum.Inter.Cubic).Clone();
                pictureBox1.Image = pic_zoom.ToBitmap();
            }
        }
        private void toolStripButton1_EnabledChanged(object sender, EventArgs e)
        {
            //if (toolStripButton1.Enabled == false)
            //    toolStripButton2.Enabled = true;
            //else
            //    toolStripButton2.Enabled = false;
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (toolStripButton1.Enabled == true && toolStripButton2.Enabled == false)
            {
                Image<Bgr,Byte> pic_zoom = new Image<Bgr, Byte>((Bitmap)pictureBox1.Image);
                pic_zoom = pic_zoom.Resize(1 / 1.5, Emgu.CV.CvEnum.Inter.Cubic).Clone();
                pictureBox1.Image = pic_zoom.ToBitmap();
            }
        }
        private void pixelNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                mouse_click = false;
                toolStripButton1.Enabled = true;
                Image<Bgr, Byte> pixel_node = new Image<Bgr, Byte>(pic.Cols*3, pic.Rows*3, new Bgr(0, 0, 0));
                for (int i = 1; i < pixel_node.Rows - 1; i = i + 3)
                    for (int j = 1; j < pixel_node.Cols - 1; j = j + 3)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            pixel_node.Data[i, j, k] = pic_backup.Data[(i - 1) / 3, (j - 1) / 3, k];
                        }
                    }
                pictureBox1.Image = pixel_node.ToBitmap();
            }
            catch
            {
            }
        }
        Image<Bgr,Byte> Cal_cost_graph()
        {
            Image<Bgr, Byte> cost_graph = new Image<Bgr, Byte>(pic.Cols * 3, pic.Rows * 3, new Bgr(0, 0, 0));
            double scalar = 1.5;
            for (int i = 1; i < cost_graph.Rows - 1; i = i + 3)
                for (int j = 1; j < cost_graph.Cols - 1; j = j + 3)
                {
                    int ii = (i - 1) / 3;
                    int jj = (j - 1) / 3;
                    for (int k = 0; k < 3; k++)
                    {
                        cost_graph.Data[i, j, k] = pic_backup.Data[ii, jj, k];
                        cost_graph.Data[i, j + 1, k] = (byte)(pic_nodes[ii, jj].link_cost[0]/scalar);
                        cost_graph.Data[i - 1, j + 1, k] = (byte)(pic_nodes[ii, jj].link_cost[1] / scalar);
                        cost_graph.Data[i - 1, j, k] = (byte)(pic_nodes[ii, jj].link_cost[2] / scalar);
                        cost_graph.Data[i - 1, j - 1, k] = (byte)(pic_nodes[ii, jj].link_cost[3] / scalar);
                        cost_graph.Data[i, j - 1, k] = (byte)(pic_nodes[ii, jj].link_cost[4] / scalar);
                        cost_graph.Data[i + 1, j - 1, k] = (byte)(pic_nodes[ii, jj].link_cost[5] / scalar);
                        cost_graph.Data[i + 1, j, k] = (byte)(pic_nodes[ii, jj].link_cost[6] / scalar);
                        cost_graph.Data[i + 1, j + 1, k] = (byte)(pic_nodes[ii, jj].link_cost[7] / scalar);
                    }
                }
            return cost_graph;
        }
        private void costGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                mouse_click = false;
                toolStripButton1.Enabled = true;
                Image<Bgr, Byte> cost_graph = Cal_cost_graph();
                pictureBox1.Image = cost_graph.ToBitmap();
            }
            catch
            {
            }
        }
        Image<Bgr, Byte> path_tree;
        private void pathTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (click_points.Count > 0 && toolStripButton2.Enabled==true)
            {
                mouse_click = false;
                toolStripButton1.Enabled = true;                
                try
                {
                    cal.Abort();
                }
                catch { }
                Path_tree(pos_seed);
                path_tree = new Image<Bgr, Byte>(pic.Cols * 3, pic.Rows * 3, new Bgr(0, 0, 0));
                for (int i = 4; i < path_tree.Rows - 4; i = i + 3)
                    for (int j = 4; j < path_tree.Cols - 4;j=j+3 )
                    {
                        int ii = (i - 1) / 3;
                        int jj = (j - 1) / 3;
                        if (ii != pos_seed[0] || jj != pos_seed[1])
                        {
                            int x = pic_nodes[ii, jj].Parent[0] - pic_nodes[ii, jj].pos_x;
                            int y = pic_nodes[ii, jj].Parent[1] - pic_nodes[ii, jj].pos_y;
                            for (int k = 0; k < 2; k++)
                            {
                                path_tree.Data[i, j, k] = 255;
                            }
                            path_tree.Data[i + x, j + y, 1] = 255;
                            path_tree.Data[i + x, j + y, 2] = 255;
                            path_tree.Data[i + x + x, j + y + y, 1] = 127;
                            path_tree.Data[i + x + x, j + y + y, 2] = 127;            
                        }
                    }
                pictureBox1.Image = path_tree.ToBitmap();
                //track bar
                trackBar1.Visible = true;
                trackBar1.Value = 100;
            }
        }
        bool min_path_flag = false;
        Image<Bgr, Byte> min_path;
        private void minPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (click_points.Count > 0&&toolStripButton2.Enabled==true)
            {
                mouse_click = true;
                toolStripButton1.Enabled = false;                
                min_path_flag = true;
                min_path = path_tree.Clone();
                pictureBox1.Image = min_path.ToBitmap();
                trackBar1.Visible = false;
            }
        }
        private void minPathToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
        }
        private void saveMaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try {
                pictureBox1.Image = mask.ToBitmap();
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Save Image With Contour";
                //sfd.ShowDialog();
                sfd.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|PNG Image|*.png";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (sfd.FileName != "")
                    {
                        // Saves the Image via a FileStream created by the OpenFile method.
                        System.IO.FileStream fs =
                           (System.IO.FileStream)sfd.OpenFile();
                        // Saves the Image in the appropriate ImageFormat based upon the
                        // File type selected in the dialog box.
                        // NOTE that the FilterIndex property is one-based.
                        switch (sfd.FilterIndex)
                        {
                            case 1:
                                this.pictureBox1.Image.Save(fs,
                                   System.Drawing.Imaging.ImageFormat.Jpeg);
                                break;
                            case 2:
                                this.pictureBox1.Image.Save(fs,
                                   System.Drawing.Imaging.ImageFormat.Bmp);
                                break;
                            case 3:
                                this.pictureBox1.Image.Save(fs,
                                   System.Drawing.Imaging.ImageFormat.Png);
                                break;
                        }
                        fs.Close();
                    }
                }
            }
            catch { }
        }
        private void imageMaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                mouse_click = false;
                toolStripButton1.Enabled = true;
                pictureBox1.Image = mask.ToBitmap();
            }
            catch { }
        }
        private void imageROIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                mouse_click = false;
                toolStripButton1.Enabled = true;
                pictureBox1.Image = pic_roi.ToBitmap();
            }
            catch { }
        }
        private void saveROIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = pic_roi.ToBitmap();
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Save Image With Contour";
                //sfd.ShowDialog();
                sfd.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|PNG Image|*.png";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (sfd.FileName != "")
                    {
                        // Saves the Image via a FileStream created by the OpenFile method.
                        System.IO.FileStream fs =
                           (System.IO.FileStream)sfd.OpenFile();
                        // Saves the Image in the appropriate ImageFormat based upon the
                        // File type selected in the dialog box.
                        // NOTE that the FilterIndex property is one-based.
                        switch (sfd.FilterIndex)
                        {
                            case 1:
                                this.pictureBox1.Image.Save(fs,
                                   System.Drawing.Imaging.ImageFormat.Jpeg);
                                break;
                            case 2:
                                this.pictureBox1.Image.Save(fs,
                                   System.Drawing.Imaging.ImageFormat.Bmp);
                                break;
                            case 3:
                                this.pictureBox1.Image.Save(fs,
                                   System.Drawing.Imaging.ImageFormat.Png);
                                break;
                        }
                        fs.Close();
                    }
                }
            }
            catch { }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Image<Bgr, Byte> path_tree_partial = new Image<Bgr, Byte>(pic.Cols * 3, pic.Rows * 3, new Bgr(0, 0, 0));
            double num = (double)trackBar1.Value * pic.Rows * pic.Cols;
            num = num / 100.0;
            for (int i = 4; i < path_tree_partial.Rows - 4; i = i + 3)
                for (int j = 4; j < path_tree_partial.Cols - 4; j = j + 3)
                {
                    int ii = (i - 1) / 3;
                    int jj = (j - 1) / 3;
                    if (ii != pos_seed[0] || jj != pos_seed[1])
                    {
                        if (pic_nodes[ii, jj].expanded_num <= num)
                        {
                            int x = pic_nodes[ii, jj].Parent[0] - pic_nodes[ii, jj].pos_x;
                            int y = pic_nodes[ii, jj].Parent[1] - pic_nodes[ii, jj].pos_y;
                            for (int k = 0; k < 2; k++)
                            {
                                path_tree_partial.Data[i, j, k] = 255;
                            }
                            path_tree_partial.Data[i + x, j + y, 1] = 255;
                            path_tree_partial.Data[i + x, j + y, 2] = 255;
                            path_tree_partial.Data[i + x + x, j + y + y, 1] = 127;
                            path_tree_partial.Data[i + x + x, j + y + y, 2] = 127;
                        }
                    }
                }
            pictureBox1.Image = path_tree_partial.ToBitmap();
        }
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
        }
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void normalizedBoxFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void gaussianFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void normalizedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolStripButton1.Enabled == true && mouse_click == false)
            {
                CvInvoke.Blur(pic, pic, new Size(5, 5), new Point(-1, -1));
                pic_backup = pic.Clone();
                Cal_link_cost();
                pictureBox1.Image = pic.ToBitmap();
            }
        }
        private void gaussianFilterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (toolStripButton1.Enabled == true && mouse_click == false)
            {
                //CvInvoke.Blur(pic, pic, new Size(5, 5), new Point(-1, -1));
                CvInvoke.GaussianBlur(pic, pic, new Size(5, 5), 0);
                pic_backup = pic.Clone();
                Cal_link_cost();
                pictureBox1.Image = pic.ToBitmap();
            }
        }
    }
}
