﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElektronikaiAlkatreszKeszletNyilvantarto
{
    public partial class AlkatreszKeszletFrm : Form
    {
        public AlkatreszKeszletFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AlkatreszFelvitelFrm frm = new AlkatreszFelvitelFrm();
            frm.Show();
        }

        private void AlkatreszKeszletFrm_Load(object sender, EventArgs e)
        {
            //InicializaciosOsztaly.AdatokBetoltese();
        }
    }
}
