﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PasswordGeneratorApp
{
    public partial class Password_Generator : Form
    {
        public bool check_box = false;

        public Password_Generator()
        {
            InitializeComponent();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Generator generator = new Generator();
            Generated_password.Text = generator.Pass_roll(Password_length.Text, check_box);
            
        }

        private void Save_to_txt_button_Click(object sender, EventArgs e)
        {
            if(Pass_txt_name.Text == "")
            {

            }
            else
            {
                saveFile(Generated_password.Text, Pass_txt_name.Text);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
        public void saveFile(string input, string title)
        {
            string dirParameter = AppDomain.CurrentDomain.BaseDirectory + @"\" + title + ".txt";
            FileStream fParameter = new FileStream(dirParameter, FileMode.Create, FileAccess.Write);
            StreamWriter m_WriterParameter = new StreamWriter(fParameter);
            m_WriterParameter.BaseStream.Seek(0, SeekOrigin.End);
            m_WriterParameter.Write(input);
            m_WriterParameter.Flush();
            m_WriterParameter.Close();
            System.Windows.Forms.MessageBox.Show("File saved");
        }

        private void Password_length_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Generated_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Pass_txt_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            check_box = !check_box;
        }
    }

    public class Functions
    {
        public string Generate(int pass_length, string password, string characters, char[] letter_array, bool check_box, string normal_letters)
        {
            Random random = new Random();
            if (check_box == true)
            {
                for (int i = 0; i < pass_length; i++)
                {
                    password += letter_array[random.Next(0, letter_array.Length - 1)];
                }
            }
            else
            {
                for (int i = 0; i < pass_length; i++)
                {
                    password += normal_letters[random.Next(0, normal_letters.Length - 1)];
                }
            }
            
            return password;
        }
    }

    public class Generator
    {
        public string Pass_roll(string pass_length, bool check_box)
        {
            string password = "";
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string specChar = "!#$%&'()*+-/:;<=?@[_{|~";
            string allCharacters = letters + specChar;
            char[] array_of_characters = allCharacters.ToCharArray();
            Functions instance = new Functions();
            int length = 0;
                    try
                    {
                        length = Convert.ToInt32(pass_length);

                    }
                    catch (System.FormatException)
                    {
                    }
                password = instance.Generate(length, password, allCharacters, array_of_characters, check_box, letters);
            return password;
        }
    }
}
