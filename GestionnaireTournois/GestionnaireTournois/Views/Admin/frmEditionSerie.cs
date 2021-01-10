﻿using GestionnaireTournois.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionnaireTournois.Views.Admin
{
    public partial class frmEditionSerie : Form
    {

        private Serie serie;
        public Serie Serie { get => serie; set => serie = value; }
        public frmEditionSerie(Serie serie)
        {
            InitializeComponent();
            Serie = serie;
        }

    }
}