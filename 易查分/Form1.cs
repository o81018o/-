using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Fleck;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        StreamReader streamReader;
        StreamReader streamReader_;
        StreamWriter streamWriter;
        WebSocketServer server;
        WebSocketServer server_;
        int index = 1,count = 0;
        bool ig = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if(ig)
            {
                server.Dispose();
                server_.Dispose();
                ig = false;
                button1.Text = "启  动";
                label1.Text = "运行中断";
                streamWriter.Close();
                streamReader.Close();
                streamReader_.Close();
                streamReader.Dispose();
                streamReader_.Dispose();
                streamWriter.Dispose();
                return;
            }
            streamReader = new StreamReader(@"d://1.txt");
            streamReader_ = new StreamReader(@"d://2.txt");
            streamWriter = new StreamWriter(@"d://3.txt", false, Encoding.UTF8);
            server = new WebSocketServer("ws://0.0.0.0:7181");
            server_ = new WebSocketServer("ws://0.0.0.0:7182");
            count = 0;
            index = ((int)numericUpDown1.Value);
            for (int i = 0;i < index - 1; i++)
            {
                streamReader.ReadLine();
                streamReader_.ReadLine();
            }
            FleckLog.Level = LogLevel.Debug;
            server.Start(socket =>
            {
                socket.OnMessage = str =>
                {
                    Invoke(new Action(() => { listBox1.Items.Add(str); listBox1.SelectedIndex = listBox1.Items.Count - 1; }));
                    streamWriter.WriteLine(str);
                    count++;
                    Invoke(new Action(() => { label3.Text = "接收数量：" + count; }));
                };
            });
            server_.Start(socket =>
            {
                socket.OnMessage = str =>
                {
                    var line = streamReader.ReadLine();
                    line += ' ';
                    line += streamReader_.ReadLine();
                    socket.Send(line);
                    index++;
                    Invoke(new Action(() => { label2.Text = "当前条目：" + index; }));
                };
            });
            button1.Text = "停  止";
            label1.Text = "正在运行";
            ig = true;
        }
    }
}
