//*******************************************************************
// Programmer: Pema Thinley
// Date: 23 May 2020
// Software: Microsoft Visual Studio 2019 Community Edition
// Platform: Microsoft Windows 10 Professional 64bit Version 1803
// Purpose: Code for Sorting using Comparator
//*******************************************************************

using System;
using System.Collections; 
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_2E
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        string fileName;
        const int rows = 4;  //constant variable to hold number of rows
        const int cols = 2;  //constant variable to hold number of columns
        int[,] finesArray = new int[rows, cols]; //2D array to hold the fines read from file
        int[] sortArray = new int[rows]; //1D array to hold the fines
        private StreamReader fileReader;
        private void button1_Click(object sender, EventArgs e)
        {
            string readfile; // reading row 
            dlgOpen.Filter = "Text files (*.txt)|*.txt"; //setting filter to allow only text file
            if (dlgOpen.ShowDialog() == DialogResult.OK)
                fileName = dlgOpen.FileName;
            FileStream input = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            //Set file from where data is read
            fileReader = new StreamReader(input);

            for (int i = 0; i < rows; i++)
            {
                readfile = fileReader.ReadLine();// read a recod from the file
                sortArray[i] = Convert.ToInt32(readfile);
                lstUnsorted.Items.Add(sortArray[i]); //add content of the array to the unsorted list

            }

            //For sorting the array using Sort(Array, IComparer) Method
            IComparer cmp = new compare();
            Array.Sort(sortArray, cmp);
            for (int i = 0; i < rows; i++)
            {
                lstSorted.Items.Add(sortArray[i]); //Add content of the array to sorted list

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

    class compare : IComparer //Comparator class
    {
        // Call CaseInsensitiveComparer.Compare 
        public int Compare(Object x, Object y)
        {
            return (new CaseInsensitiveComparer()).Compare(x, y);
        }
    }
}
