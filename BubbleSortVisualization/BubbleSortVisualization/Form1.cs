using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace BubbleSortVisualization
{
    public partial class Form1 : Form
    {
        private List<int> SortableList = new List<int>() { 9,8,7,6,5,4,3,2,1};  

        public Form1()
        {
            InitializeComponent();
        }

        public void RenderInitialList()
        {
            foreach (int number in SortableList) initialBox.Items.Add(number);
        }

        public void Sort()
        {
            int a;
            int b;
            int replacementCounter = 0;

            for (int j = SortableList.Count - 1; j > 0; j--)
            {
                for (int i = 0; i < j; i++)
                {
                    a = SortableList[i];
                    b = SortableList[i + 1];

                    if (a > b)
                    {
                        SortableList[i] = b;
                        SortableList[i + 1] = a;
                        replacementCounter += 1;
                    }
                    RefreshListBox();
                    Application.DoEvents();
                    Thread.Sleep(300);
                }
                if (replacementCounter == 0) break;
            }
            resultBox.BackColor = Color.Green;
            resultBox.ForeColor = Color.White;
        }

        private void RefreshListBox()
        {
            resultBox.Items.Clear();
            foreach (int number in SortableList)
            {
                resultBox.Items.Add(number);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RenderInitialList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sort();
        }
    }
}
