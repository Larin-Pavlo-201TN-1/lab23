using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab23
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTextBoxEditingControl tb = (DataGridViewTextBoxEditingControl)e.Control;
            tb.KeyPress += new KeyPressEventHandler(dataGrid_KeyPress);
            e.Control.KeyPress += new KeyPressEventHandler(dataGrid_KeyPress);

        }
        private void dataGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                return;
            }
            e.Handled = true;
            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x, y;
            int a, b, t;
            int[,] arr = new int[dataGrid.Rows.Count, dataGrid.ColumnCount];
            for(int i = 0; i < dataGrid.Rows.Count; i++)
            {
                for(int j = 0; j < dataGrid.ColumnCount; j++)
                {
                    arr[i, j] = Convert.ToInt32(dataGrid[j, i].Value);
                }
            }
            Diagram.Series[0].Points.Clear();
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                a = arr[i, 0];
                b = arr[i, 1];
                t = arr[i, 2];
                x = a * Math.Cos(t * Math.PI / 180) * (Math.Cos(t * Math.PI / 180) + b);
                y = Math.Sin(t * Math.PI / 180) * (Math.Sin(t * Math.PI / 180) + b);
                Diagram.Series[0].Points.AddXY(x, y);
            }
        }
    }
}
