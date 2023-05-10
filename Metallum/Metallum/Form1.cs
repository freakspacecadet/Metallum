using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using WMPLib;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.Remoting.Services;
using AxWMPLib;

namespace Metallum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label6.Hide();
            label4.Hide();
            numericUpDown2.Hide();

            
            

        }

        System.Media.SoundPlayer player = new System.Media.SoundPlayer();

        string name;
        string rok_zalozenia;
        string rok_rozpadu;
        string data_albumu;
        string gatunek;
        string album;
        int ac = 0;
        bool saved;
        string fname = "Untitled";
        string[] tracks = new string[3];
        string[] titles = new string[3];
        int i = 1;
        

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label2.Text = textBox1.Text;
            saved = false;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Notatka()
        {
            richTextBox2.Text = "";
            richTextBox2.Text += "Zespół " + name + "został założony w " + rok_zalozenia + " roku";
            if (checkBox1.Checked == true)
            {
                richTextBox2.Text += " i zakończył działalność w " + rok_rozpadu;
            }
            richTextBox2.Text += ". ";
            richTextBox2.Text += "Grupa wykonuje przede wszystkim utwory z gatunku " + gatunek + ". ";

            if (richTextBox1.Text != "" && richTextBox1.Text != "\n")
            {
                richTextBox2.Text += "Wydali następujące albumy:\n";
                richTextBox2.Text += richTextBox1.Text;
            }

            if (richTextBox3.Text != "")
            {
                richTextBox2.Text += "\n Link do strony zespołu:";
                richTextBox2.Text += richTextBox3.Text;
            }
        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            Notatka();

            if (fname == "Untitled")
            {
                zapiszJakoToolStripMenuItem_Click(sender, e);
            }
            else
            {
                richTextBox2.SaveFile(fname);
                saved = true;
            }
            //richTextBox2.SaveFile(fname);
        }

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            saved = false;
            rok_zalozenia = Convert.ToString(numericUpDown1.Value);
            numericUpDown2.Minimum = numericUpDown1.Value;
            label5.Text = rok_zalozenia + " -";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            saved = false;
            if (checkBox1.Checked) {
                label4.Show();
                numericUpDown2.Minimum = numericUpDown1.Value;
                numericUpDown2.Show();
                label6.Text = Convert.ToString(numericUpDown2.Value);
                label6.Show();
            }
            else
            {
                label4.Hide();
                //numericUpDown2.Minimum = numericUpDown1.Value;
                numericUpDown2.Hide();
                //label6.Text = Convert.ToString(numericUpDown2.Value);
                label6.Hide();
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            saved = false;
            rok_rozpadu = Convert.ToString(numericUpDown2.Value);
            label6.Text = rok_rozpadu;
        }

        private void wyjdźToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saved == false)
            {
                if (MessageBox.Show("Czy na pewno chcesz utracić wszystkie zmiany?", "Ostrzeżenie", MessageBoxButtons.YesNoCancel) == DialogResult.Yes) {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }
            
        }

        private void oProgramieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Generator krótkich notatek o zespołach metalowych. \n (C) A.S. 2023", "O programie");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            saved = true;
            richTextBox2.Hide();
            label9.Text = "";
            data_albumu = "01.01.1900";
            album = "Album";
            ac = 0;

            


            tracks[0] = @"C:\Users\mesel\source\repos\Metallum\Metallum\Tunes\Iron-Maiden-The-Trooper.wav";
            tracks[1] = @"C:\Users\mesel\source\repos\Metallum\Metallum\Tunes\Megadeth-Peace-Sells.wav";
            tracks[2] = @"C:\Users\mesel\source\repos\Metallum\Metallum\Tunes\Death-Pull-The-Plug.wav";
            //tracks[3] = 

            titles[0] = "Iron Maiden - The Trooper";
            titles[1] = "Megadeth - Peace Sells";
            titles[2] = "Death - Pull The Plug";

            axWindowsMediaPlayer1.URL = @"C:\Users\mesel\source\repos\Metallum\Metallum\Tunes\Iron-Maiden-The-Trooper.wav";
            axWindowsMediaPlayer1.Ctlcontrols.play();
            label13.Text = "Iron Maiden - The Trooper";
        }

        private void muzyka(object sender, EventArgs e)
        {
            if (true)
            {
                
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gatunek = comboBox1.Text;
            saved = false;

            label8.Text = Convert.ToString(comboBox1.Text);

            if (Convert.ToString(comboBox1.SelectedItem) == "heavy metal")
            {
                
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            data_albumu = Convert.ToString(dateTimePicker1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            album = textBox2.Text;

        }

        private void button1_Click(object sender, EventArgs e)
        {
           richTextBox1.Text += "\n" + data_albumu + " " + album;
            ac++;
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //richTextBox1.Lines = "i";
            ac--;
            richTextBox1.Lines = richTextBox1.Lines.Take(richTextBox1.Lines.Length - 1).ToArray();
            //richTextBox1.Lines = Convert.ToString(richTextBox1.Lines.Take(richTextBox1.Lines.Length - 1));
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            saved = false;
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void zapiszJakoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Notatka();

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //saveFileDialog1.ShowDialog();
                richTextBox2.SaveFile(saveFileDialog1.FileName);
                saveFileDialog1.DefaultExt = ".rtx";
                fname = saveFileDialog1.FileName;
                //label1.Text = name;
                saved = true;
                //label1.Text = "saved";
            }
        }

        private void Wyczysc()
        {
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            label5.Text = "1900 -";
            label2.Text = "Untitled";
            textBox2.Text = "";
            label8.Text = "";
            label6.Hide();
            label4.Hide();
            numericUpDown2.Hide();
            checkBox1.Checked = false;
            richTextBox3.Text = "";

            numericUpDown1.Value = 1900;
            textBox1.Text = "";
            comboBox1.SelectedItem = null;
            textBox3.Text = "";
        }

        private void nowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saved == true)
            {
                Wyczysc();
            }
            else
            {
                var result = MessageBox.Show("Czy chcesz zapisać zmiany?", "Ostrzeżenie", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    zapiszToolStripMenuItem_Click(sender, e);
                    if (saved == true)
                    {
                        Wyczysc();
                        
                    }

                }
                else if (result == DialogResult.No)
                {
                    Wyczysc();
                    
                }

            }
            
        }

        

        private void muzykaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = @"C:\Users\mesel\source\repos\Metallum\Metallum\Tunes\Iron-Maiden-The-Trooper.wav";
            axWindowsMediaPlayer1.Ctlcontrols.play();
            //player.SoundLocation = @"C:\Users\mesel\source\repos\Metallum\Metallum\Tunes\Iron-Maiden-The-Trooper.wav";
            //player.Load();
            //player.Play();
            //label13.Text = "Iron Maiden - The Trooper";



            //player.SoundLocation = @"C:\Users\mesel\source\repos\Metallum\Metallum\Tunes\Death-Pull-The-Plug.wav";
           // label13.Text = "Death - Pull The Plug";
            //player.Load();
           // player.Play();

            //player.PlayLooping();


           // player.SoundLocation = @"C:\Users\mesel\source\repos\Metallum\Metallum\Tunes\Megadeth-Peace-Sells.wav";
            //label13.Text = "Megadeth - Peace Sells";
            //player.Load();
            //player.Play();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "||")
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                button4.Text = "▶︎";
            }
            else
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
                button4.Text = "||";
            }
            
            //label13.Text = "Iron Maiden - The Trooper";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            richTextBox3.Text = textBox3.Text;
        }

        private void plikToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button4.Text == "▶︎")
            {
                button4.Text = "||";
            }
            if (i < 2)
            {
                axWindowsMediaPlayer1.URL = tracks[i];
                axWindowsMediaPlayer1.Ctlcontrols.play();
                label13.Text = titles[i];
                i++;

            }
            else
            {
                
                axWindowsMediaPlayer1.URL = tracks[i];
                axWindowsMediaPlayer1.Ctlcontrols.play();
                label13.Text = titles[i];
                i = 0;
            }
        }
    }
}
