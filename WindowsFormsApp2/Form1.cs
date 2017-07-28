using Air.TE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;

namespace FareComparison
{
    public partial class Form1 : Form
    {

        List<Flight> checkerflights = new List<Flight>();
        List<Flight> compflights = new List<Flight>();
        string temptext1;
        public Connection session;
        public Connection Compsession1;
        public Connection Compsession2;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("2BY2");
            comboBox1.Items.Add("2CQ2");
            if (comboBox1.SelectedText == "2BY2") richTextBox2.Text = "IPCC: ";
            else richTextBox2.Text = "IPCC: ";
            richTextBox2.Text += "Airline" + "   " + "Ori-Dest" + "         " + "Date         "+ "Base Fare" + "       " + "Tax" + "       " + "Fare Type" + "   " + "Rate" + "    " + "Commission" + "  " +"Commission fee" + "    " + "Net Total" + Environment.NewLine;
        }

        public void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
       
        
        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            checkerflights.Clear();
            richTextBox1.Text = "";
            richTextBox1.Refresh();
            richTextBox2.Clear();
            richTextBox2.Refresh();
            string [] cmdArray = cmd.Text.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (var ca in cmdArray)
            {
                if (ca.Length != 19)
                {
                    MessageBox.Show(string.Format("Command {0} is wrong. Length not correct", ca));
                    return;
                }
                Flight f1 = new Flight();
                f1.ori = ca.Substring(0,3).ToUpper();
                f1.dest = ca.Substring(3, 3).ToUpper();
                f1.departD = ca.Substring(6,5).ToUpper();
                f1.returnD = ca.Substring(11, 5).ToUpper();
                f1.airline = ca.Substring(17,2).ToUpper();
                checkerflights.Add(f1);
            }
            if(comboBox1.Text == "")
            {
                MessageBox.Show("IPCC invalid");
                return;
            }
            if (comboBox1.Text == "2BY2")
            {
                richTextBox2.Text += "IPCC: " + comboBox1.SelectedItem + "       " + "Currency: CAD" + Environment.NewLine;
                Flight.Currency = "CAD";
            }
            if (comboBox1.Text == "2CQ2")
            {
                richTextBox2.Text += "IPCC: " + comboBox1.SelectedItem + "       " + "Currency: USD" + Environment.NewLine;
                Flight.Currency = "USD";
            }
            richTextBox2.Text += "Airline" + "   " + "Ori-Dest" + "         " + "Date         " + "Base Fare" + "       " + "Tax" + "       " + "Fare Type" + "   " + "Rate" + "    " + "Commission" + "  " + "Commission fee" + "    " + "Net Total" + Environment.NewLine;
            foreach (var f in checkerflights)
            {
                session = new Air.TE.Connection(Air.TE.Application.Type.TourEastB2B, WebService.Type.SabreCommand).GetByPcc(comboBox1.Text);
                Flight.session = session;
                f.progRun();
                richTextBox1.Text += f.textBox1.Replace('Â', '¥');
                richTextBox2.Text += ((f.errorMsg != "") ? f.errorMsg : f.Msg);
                richTextBox2.Refresh();
           }
            Cursor.Current = Cursors.Default;
        }



        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




        private void label3_Click(object sender, EventArgs e)
        {

        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        

        public void origin_KeyUp(object sender, KeyEventArgs e)
        {
            origin.CharacterCasing = CharacterCasing.Upper;
        }

        public void dest_KeyUp(object sender, KeyEventArgs e)
        {
            dest.CharacterCasing = CharacterCasing.Upper;
        }

        public void date1_KeyUp(object sender, KeyEventArgs e)
        {
            date1.CharacterCasing = CharacterCasing.Upper;
        }

        public void date2_KeyUp(object sender, KeyEventArgs e)
        {
            date2.CharacterCasing = CharacterCasing.Upper;
        }

        public void airline_KeyUp(object sender, KeyEventArgs e)
        {
            airline.CharacterCasing = CharacterCasing.Upper;
        }

        public void origin_TextChanged(object sender, EventArgs e)
        { 
            
        }

        

        private void Export_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string path = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)).ToString();
            try
            {
                //create excel
                ExcelPackage ExcelPkg = new ExcelPackage();
                ExcelWorksheet wsSheet1 = ExcelPkg.Workbook.Worksheets.Add("Sheet1");
                using (ExcelRange Rng0 = wsSheet1.Cells[1, 1, 1, 10])
                {
                    Rng0.Merge = true;
                    Rng0.Style.Font.Size = 15;
                    if (comboBox1.Text == "2BY2") wsSheet1.Cells[1, 1].Value = "PCC: " + comboBox1.Text + "           " + "Currency: CAD" + "                                         " + "Reporting Date: " + DateTime.Now;
                    if (comboBox1.Text == "2CQ2") wsSheet1.Cells[1, 1].Value = "PCC: " + comboBox1.Text + "           " + "Currency: USD" + "                                         " + "Reporting Date: " + DateTime.Now;

                    //set row color
                    Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#FFDFB5");
                    Rng0.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng0.Style.Fill.BackgroundColor.SetColor(colFromHex);
                }
                using (ExcelRange Rng = wsSheet1.Cells[2, 1, checkerflights.Count() + 2, 10])
                {



                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Font.Size = 12;
                    Rng.Style.Font.Bold = false;
                    Rng.Style.Font.Italic = false;
                    wsSheet1.PrinterSettings.FitToPage = true;

                    //set right align
                    wsSheet1.Column(4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    wsSheet1.Column(5).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    wsSheet1.Column(7).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    wsSheet1.Column(8).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    wsSheet1.Column(9).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    //set center align
                    wsSheet1.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    wsSheet1.Row(1).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    wsSheet1.Row(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    wsSheet1.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    wsSheet1.Column(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    wsSheet1.Column(3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    wsSheet1.Column(6).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    //set col width
                    for (int col = 1; col < 11; col++)
                    {
                        if (col == 1) wsSheet1.Column(col).Width = 8;
                        else if (col == 7) wsSheet1.Column(col).Width = 8;
                        else if (col == 3 || col == 8) wsSheet1.Column(col).Width = 14;
                        else wsSheet1.Column(col).Width = 10;
                    }
                    wsSheet1.Column(10).Width = 60;

                    

                    for (int row = 2; row < checkerflights.Count() + 3; row++)
                    {
                        wsSheet1.Row(row).Height = 20;
                    }

                    wsSheet1.Row(1).Height = 30;

                    wsSheet1.Protection.IsProtected = false;
                    wsSheet1.Protection.AllowSelectLockedCells = false;
                    wsSheet1.Cells[2, 1].Value = "Airline";
                    wsSheet1.Cells[2, 2].Value = "Ori-Dest";
                    wsSheet1.Cells[2, 3].Value = "Date";
                    wsSheet1.Cells[2, 4].Value = "Base Fare";
                    wsSheet1.Cells[2, 5].Value = "Tax";
                    wsSheet1.Cells[2, 6].Value = "Fare Type";
                    wsSheet1.Cells[2, 7].Value = "Rate";
                    wsSheet1.Cells[2, 8].Value = "Commission";
                    wsSheet1.Cells[2, 9].Value = "Net Total";
                    wsSheet1.Cells[2, 10].Value = "Error Message";

                    int i = 3;
                    foreach (var f in checkerflights)
                    {
                        if (f.errorMsg != "")
                        {
                            wsSheet1.Row(i).Height = 45;
                            wsSheet1.Row(i).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            wsSheet1.Cells[i, 1].Value = f.airline;
                            wsSheet1.Cells[i, 2].Value = f.ori + "-" + f.dest;
                            wsSheet1.Cells[i, 3].Value = f.departD + "-" + f.returnD;
                            wsSheet1.Cells[i, 4].Value = "N/A";
                            wsSheet1.Cells[i, 5].Value = "N/A";
                            wsSheet1.Cells[i, 6].Value = "N/A";
                            wsSheet1.Cells[i, 7].Value = "N/A";
                            wsSheet1.Cells[i, 8].Value = "N/A";
                            wsSheet1.Cells[i, 9].Value = "N/A";
                            wsSheet1.Cells[i, 10].Value = f.errorMsg.Replace('Â','"');
                            //ErrorMsg wrap text
                            wsSheet1.Cells[i,10].Style.WrapText = true;
                        }
                        else
                        {
                            wsSheet1.Cells[i, 1].Value = f.airline;
                            wsSheet1.Cells[i, 2].Value = f.ori + "-" + f.dest;
                            wsSheet1.Cells[i, 3].Value = f.departD + "-" + f.returnD;
                            wsSheet1.Cells[i, 4].Value = f.baseFare;
                            wsSheet1.Cells[i, 5].Value = f.tax;
                            wsSheet1.Cells[i, 6].Value = f.fareType;
                            wsSheet1.Cells[i, 7].Value = f.rate;
                            wsSheet1.Cells[i, 8].Value = Math.Round(Convert.ToDouble(f.Commission), 2);
                            wsSheet1.Cells[i, 9].Value = Math.Round(Convert.ToDouble(f.total), 2);
                            wsSheet1.Cells[i, 10].Value = "Fare Basis: " + string.Join(" + ", f.fareBasis);
                        }

                        i++;
                    }

                    //set landscape
                    wsSheet1.PrinterSettings.Orientation = eOrientation.Landscape;

                    ExcelPkg.SaveAs(new FileInfo(path + "\\New.xlsx"));
                    System.Diagnostics.Process.Start(path + "\\New.xlsx");
                    ExcelPkg.Dispose();
                    Cursor.Current = Cursors.Default;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(path + "\\New.xlsx is already open" + Environment.NewLine + "Please close it and click 'Export Button' again" );
            }
        }

        private void ADD_Click(object sender, EventArgs e)
        {
            if (origin.Text.Length != 3)
            {
                MessageBox.Show(string.Format("Origin input is wrong. Length not correct"));
                return;
            }
            if (dest.Text.Length != 3)
            {
                MessageBox.Show(string.Format("Destination input is wrong. Length not correct"));
                return;
            }
            if (date1.Text.Length != 5)
            {
                MessageBox.Show(string.Format("Departure date input is wrong. Length not correct"));
                return;
            }
            if (date2.Text.Length != 5)
            {
                MessageBox.Show(string.Format("Return date input is wrong. Length not correct"));
                return;
            }
            if (airline.Text.Length != 2)
            {
                MessageBox.Show(string.Format("Airline input is wrong. Length not correct"));
                return;
            }
            cmd.Text += origin.Text + dest.Text + date1.Text + date2.Text + "-" + airline.Text+Environment.NewLine;
        }

        
        private void Clear_Click(object sender, EventArgs e)
        {
            checkerflights.Clear();
            cmd.Clear();
            cmd.Refresh();
        }

        

        public void dest_TextChanged(object sender, EventArgs e)
        {

        }

        public void date1_TextChanged(object sender, EventArgs e)
        {

        }

        public void date2_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmd_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Search_Click(object sender, EventArgs e)
        {
            List<int> matchposition = new List<int>();
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                int index = 0;
                int counts = 0;
                string match = "";
                string findtext = SearchBox.Text.ToUpper();
                int presscount = 0;

                if (findtext != "")
                {
                        temptext1 = richTextBox1.Text;
                        richTextBox1.Text = temptext1;
                        richTextBox1.Refresh();
                        matchposition.Clear();
                        while (index < richTextBox1.Text.LastIndexOf(findtext))
                        {
                            richTextBox1.Find(findtext, index, richTextBox1.TextLength, RichTextBoxFinds.None);
                            richTextBox1.SelectionBackColor = Color.Yellow;
                            richTextBox1.SelectionColor = Color.Black;
                            counts = counts + 1;

                            index = richTextBox1.Text.IndexOf(findtext, index) + 1;
                            matchposition.Add(index - 1); //get matched index
                        }

                        if (counts > 1)
                        {
                            match = "matches.";
                        }
                        else
                        {
                            match = "match.";
                        }

                        if (counts != 0)
                        {
                            //MessageBox.Show("Found " + counts.ToString() + " " + match);
                        }
                        else
                        {
                            MessageBox.Show("No match found !");
                        }

                        if (matchposition.Count() > 0)
                        {
                            richTextBox1.SelectionStart = matchposition[0];
                            richTextBox1.Focus();
                        }
                        richTextBox1.Refresh();
               }
                else
                {
                    MessageBox.Show("Nothing to find !");
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);

            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            temptext1 = richTextBox1.Text;
            richTextBox1.Text = temptext1;
            richTextBox1.Refresh();
        }

        private void sign_Click(object sender, EventArgs e)
        {
            SearchBox.Text += "¥";
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CompOri.Text.Length != 3)
            {
                MessageBox.Show(string.Format("Origin input is wrong. Length not correct"));
                return;
            }
            if (CompDest.Text.Length != 3)
            {
                MessageBox.Show(string.Format("Destination input is wrong. Length not correct"));
                return;
            }
            if (CompDepart.Text.Length != 5)
            {
                MessageBox.Show(string.Format("Departure date input is wrong. Length not correct"));
                return;
            }
            if (CompReturn.Text.Length != 5)
            {
                MessageBox.Show(string.Format("Return date input is wrong. Length not correct"));
                return;
            }
            if (CompAirline.Text.Length != 2)
            {
                MessageBox.Show(string.Format("Airline input is wrong. Length not correct"));
                return;
            }
            CompCMD.Text += CompOri.Text + CompDest.Text + CompDepart.Text + CompReturn.Text + "-" + CompAirline.Text + Environment.NewLine;
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void CompOri_TextChanged(object sender, EventArgs e)
        {

        }

        private void CheckPCC_TextChanged(object sender, EventArgs e)
        {

        }

        private void CompDest_TextChanged(object sender, EventArgs e)
        {

        }

        private void CompDepart_TextChanged(object sender, EventArgs e)
        {

        }

        private void CompReturn_TextChanged(object sender, EventArgs e)
        {

        }

        private void CompAirline_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void CompOri_KeyUp(object sender, KeyEventArgs e)
        {
            CompOri.CharacterCasing = CharacterCasing.Upper;
        }

        private void CompDest_KeyUp(object sender, KeyEventArgs e)
        {
            CompDest.CharacterCasing = CharacterCasing.Upper;
        }

        private void CompDepart_KeyUp(object sender, KeyEventArgs e)
        {
            CompDepart.CharacterCasing = CharacterCasing.Upper;
        }

        private void CompReturn_KeyUp(object sender, KeyEventArgs e)
        {
            CompReturn.CharacterCasing = CharacterCasing.Upper;
        }

        private void CompAirline_KeyUp(object sender, KeyEventArgs e)
        {
            CompAirline.CharacterCasing = CharacterCasing.Upper;
        }

        private void MasterPCC_KeyUp(object sender, KeyEventArgs e)
        {
            MasterPCC.CharacterCasing = CharacterCasing.Upper;

        }

        private void CheckPCC_KeyUp(object sender, KeyEventArgs e)
        {
            CheckPCC.CharacterCasing = CharacterCasing.Upper;
        }

        private void CompClear_Click(object sender, EventArgs e)
        {
            compflights.Clear();
            CompCMD.Clear();
            CompCMD.Refresh();
        }

        private void CompRun_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ComparisonTable.Rows.Clear();
            ComparisonTable.Refresh();
            string[] cmdArray = CompCMD.Text.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (var ca in cmdArray)
            {
                if (ca.Length != 19)
                {
                    MessageBox.Show(string.Format("Command {0} is wrong. Length not correct", ca));
                    return;
                }
                Flight f1 = new Flight();
                f1.ori = ca.Substring(0, 3).ToUpper();
                f1.dest = ca.Substring(3, 3).ToUpper();
                f1.departD = ca.Substring(6, 5).ToUpper();
                f1.returnD = ca.Substring(11, 5).ToUpper();
                f1.airline = ca.Substring(17, 2).ToUpper();
                compflights.Add(f1);
            }
            Compsession1 = new Air.TE.Connection(Air.TE.Application.Type.TourEastB2B, WebService.Type.SabreCommand).GetByPcc(MasterPCC.Text);
            Compsession2 = new Air.TE.Connection(Air.TE.Application.Type.TourEastB2B, WebService.Type.SabreCommand).GetByPcc(MasterPCC.Text);
            int i = 1;
            foreach (var f in compflights)
            {
                f.compRun(Compsession1);
                string total1 = "";
                if (f.total == "")
                {
                    total1 = f.total;
                }
                else
                {
                   total1 = "N/A";
                }
                f.compRun(Compsession2);
                string total2 = "";
                if (f.total == "")
                {
                   total2 = f.total;
                }
                else
                {
                    total2 = "N/A";
                }
                string result = "";
                if (total1 == "N/A" || total2 == "N/A")
                {
                    result = "Not available";
                }
                else
                {
                    result = (total1 == total2)? "Matched" : "Unmatched";
                }
                string fareBasisResult;
                if (f.fareBasis == null)
                {
                    fareBasisResult = f.errorMsg;
                }
                else
                {
                    fareBasisResult = string.Join(" + ", f.fareBasis);
                }
                ComparisonTable.Rows.Add("#" + i.ToString(), f.airline, f.ori + "-" + f.dest + "       " + f.departD + "-" + f.returnD + "     FareBasis: " + fareBasisResult, total1, total2, result);
                i++;
            }
        }
    }
}
