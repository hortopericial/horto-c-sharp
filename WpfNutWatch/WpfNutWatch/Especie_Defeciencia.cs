﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WpfNutWatch
{
    public partial class Especie_Defeciencia : Form
    {
        public Especie_Defeciencia()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Deficiencia formDef = new Deficiencia();
            formDef.ShowDialog();
        }
    }
}
