﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace hellory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtGiveMe.Text != "0" && txtGiveMe.Text!="") 
            {
                int deneme = 0;
                int a = Convert.ToInt32(txtGiveMe.Text);//get number of stones
                int t = a - 1;//delete full black line from 1 side it doesnt matter
                int j = Convert.ToInt32(Math.Pow(2, t));  // find  no of  variables
                                                              //        int arama = 0;

                int m = j - 1;
                lblToplam.Text = "every possibilities are:" + j.ToString();
                for (int l = 0; l <= m; l++)
                {


                    string bin = Convert.ToString(l, 2).PadLeft(Convert.ToInt32(t), '0');//all decimals turn to binary

                    char[] A = bin.ToCharArray();                                         //single number saparated in char array 
                    int[] Aint = Array.ConvertAll(A, c => (int)Char.GetNumericValue(c));//char array to int arrray

                    for (int i = 0; i < Aint.Length - 1; i++)
                    {
                        if (Aint[i] == Aint[i + 1] && Aint[i] == 1)//false possibilites next to element
                        {
                            // MessageBox.Show(Aint[i].ToString() + "bide" + Aint[i + 1].ToString());
                            deneme++;
                            break;
                        }
                    }

                }
                int q = Convert.ToInt32(j) - deneme;// every possibilities-false possibilities =true possibilies
                label1.Text = "possibles" + q.ToString();
            }
            else
            {
                MessageBox.Show("try more than 0");
                txtGiveMe.Text = "";
                lblToplam.Text = "";
                label1.Text = "";
            }

        }

        private void txtGiveMe_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
