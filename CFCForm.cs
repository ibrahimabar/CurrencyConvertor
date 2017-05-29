using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurrencyFileConvertor
{
    public partial class CFCForm : Form
    {


        public List<Currency> MyCurrencyList = new List<Currency>();
        public CFCForm()
        {
            InitializeComponent();

            // Read each line of the file into a string array. Each element 
            // of the array is one line of the file. 
            string[] lines = System.IO.File.ReadAllLines("currencyValues.txt");

            Currency[] valuesList = new Currency[5]; 
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + line);

                string[] words = line.Split(';');
                Currency newCur = new Currency(words[0],double.Parse(words[2]));
                MyCurrencyList.Add(newCur);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            double result = 0;
            double amount = double.Parse(txtAmount.Text);

            string curFrom = cmbFrom.SelectedItem.ToString();
            string curTo = cmbTo.SelectedItem.ToString();

            if (curFrom == "USD")
            {
                result = amount / MyCurrencyList.Find(item => item.value == curTo).rate;
            }
            else if (curTo == "USD")
            {
                result = amount * MyCurrencyList.Find(item => item.value == curFrom).rate;
            }
            else
            {
                result = amount * MyCurrencyList.Find(item => item.value == curFrom).rate / MyCurrencyList.Find(item => item.value == curTo).rate;
            }

            MessageBox.Show("Result is " + Math.Round(result, 2));
        }

        private void CFCForm_Load(object sender, EventArgs e)
        {
            cmbFrom.SelectedIndex = 0;
            cmbTo.SelectedIndex = 2;
        }
    }
}
