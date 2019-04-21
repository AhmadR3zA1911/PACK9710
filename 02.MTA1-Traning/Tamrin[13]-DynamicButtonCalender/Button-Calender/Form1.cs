using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Button_Calender
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        
        // global variable
        List<Button> Buttonz = new List<Button>();
        string year = "";
        string month = "";

        private void frmMain_Load(object sender, EventArgs e)
        {
            AddRangeNumbeCMByear(); // load year cmb
            AddRangeNumbeCMBMonth(); //  Load Month
            
        }
        

        /// <summary>
        /// Add Year To CmbYear From 1300 unti now
        /// </summary>
        private void AddRangeNumbeCMByear()
        {
            PersianCalendar p = new PersianCalendar();

            for (int i = 1300; i <= p.GetYear(DateTime.Now); i++)
            {
                cmbYear.Items.Add(i);
            }
        }

        /// <summary>
        /// Add Month to Month 
        /// </summary>
        private void AddRangeNumbeCMBMonth()
        {


            for (int i = 01; i <= 12; i++)
            {
                cmbMonth.Items.Add(i);
            }
        }

        /// <summary>
        /// Get Day of Month (31 Or 30)
        /// </summary>
        /// <param name="y"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        private int CheckNumberOfDayInMonth(string y, string m)
        {
            PersianCalendar p = new PersianCalendar();


            int day = p.GetDaysInMonth(Convert.ToInt32(y), Convert.ToInt32(m));
            return day;
        }

        /// <summary>
        /// create dynamically button and Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShow_Click(object sender, EventArgs e)
        {
           
            if (Buttonz.Count>0) // if form has buttons remove all of them : ) 
            {
                foreach (var b in Buttonz)
                {
                    this.Controls.Remove(b);
                }
                Buttonz.Clear();
            }

            
            if (cmbMonth.SelectedItem != null && cmbYear.SelectedItem != null) // user selected cmb
            {
                year = cmbYear.SelectedItem.ToString(); //global 
                month = cmbMonth.SelectedItem.ToString(); // global 

                int d = CheckNumberOfDayInMonth(year, month); // get day
                int top = 90;
                int left = 50;
                for (int i = 1; i <= d; i++)
                {
                    if (left>=433) // Each row must have 9 button :D 
                    {
                        top += 30; 
                        left = 50;
                    }

                    Button b = new Button();
                    this.Controls.Add(b);
                    //b.Location = new Point(62, i + 23);
                    b.Top = top;
                    b.Left = left;
                    b.Name = "btn" + i.ToString();
                    b.Text = i.ToString();
                    b.Size = new System.Drawing.Size(39, 23);
                    b.Click += new EventHandler(this.Button_Click); // show date 
                    Buttonz.Add(b);
                    left = left + 46;
                }
            }

        }

        /// <summary>
        /// envent for created button for show Shamsi and Gregorian
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click (object sender , EventArgs e)
        {
            PersianCalendar p = new PersianCalendar();
            Button btn = sender as Button;
            string g = p.ToDateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(btn.Text),0,0,0,0).ToShortDateString();
            string s = year + "/" + month + "/" + btn.Text;
            MessageBox.Show("Shamsi: "+s+"\n\n"+ "Gregorian: " + g, "Shamsi And Gregorian");
        }
    }
}
