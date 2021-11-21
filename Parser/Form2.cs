using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parser
{
    public partial class Form2 : Form
    {
        private Form1 _form1;
        private bool isMainFormColored = false;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Form1 f)
        {
            InitializeComponent();
            _form1 = f;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _form1.RunFromAnotherForm();

            if (!isMainFormColored)
            {
                _form1.BackColor = Color.Red;
                isMainFormColored = true;
            }
            else
            {
                _form1.BackColor = Color.DarkCyan;
                isMainFormColored = false;
            }
        }
    }
}
