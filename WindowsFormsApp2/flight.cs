using Air.TE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FareComparison
{
    class Flight
    {
        char seg = ' ';
        public string ori { set; get; }
        public string dest { set; get; }
        public string departD { set; get; }
        public string returnD { set; get; }
        public string airline { set; get; }
        public string baseFare { set; get; }
        public string tax { set; get; }
        public string total { set; get; }
        public string Commission = "            0    ";
        public string rate = "  0    ";
        public string fareType { get; set; }
        public string Msg { set; get; }
        public string errorMsg = "";
        public string flightClass = "";
        public string textBox1;
        public static Connection session;
        public static string Currency;
        public string itinerary = "";
        public List<string> trip1;
        public List<string> trip2;
        public List<string> opAir1 = new List<string>();
        public List<string> opAir2 = new List<string>();
        public bool departSame = false;
        public bool returnSame = false;
        public string[] fareBasis;
        public string[] WPNC;
        public string[] arrayOfWPPJCB;
        public bool commissionExist = false;
        string seperator = "-------------------------------------------";

        //if oriPlace does not exist return -1
        //if exists return its pos
        public static int oriChecker(string s, string oriPlace)
        {
            int pos = -1;
            if (oriPlace == "DCA" && Regex.Matches(s, "DC").Count != 2) return -1;
            pos = s.IndexOf(oriPlace);
            return pos;
        }

        public void addOpAir(string s, int i)
        {
            if (i == 1)
            {
                if (s[3] == '/') opAir1.Add(s.Substring(4, 2));
                else opAir1.Add(s.Substring(1, 2));
            }
            else if (i == 2)
            {
                if (s[3] == '/') opAir2.Add(s.Substring(4, 2));
                else opAir2.Add(s.Substring(1, 2));
            }
        }
        //if oriPlace does not exist return -1
        //if exists return its pos
        public static int destChecker(string s, string destPlace)
        {
            int pos = -1;
            if (destPlace == "DCA" && Regex.Matches(s, "DC").Count != 2) return -1;
            pos = s.IndexOf(destPlace);
            return pos;
        }


        //check if there is flight
        public static bool isFlight(string[] s)
        {
            foreach (string myString in s)
            {
                if (myString[3] == ' ' && myString[0] != ' ') return true;
            }
            return false;
        }

        //check if there is all same airline flight. exists return the line number otherwise return -1
        public static int checkAllDirect(string[] s, string airline, string oriPlace, string destPlace)
        {
            for (int lineNum = 0; lineNum < s.Length; lineNum++)
            {
                if (s[lineNum][0] == '.' || s[lineNum][0] == ' ' && s[lineNum][1] != ' ')
                {
                    continue;
                }
                if (s[lineNum].Substring(1, 2) == airline && s[lineNum][3] == ' ' && oriChecker(s[lineNum], oriPlace) != -1)
                {
                    if (destChecker(s[lineNum], destPlace) != -1) return lineNum;
                    for (int j = 1; j + lineNum < s.Length; j++)
                    {

                        if (s[lineNum + j][3] == ' ' && destChecker(s[lineNum + j], destPlace) != -1)
                        {
                            return lineNum;
                        }
                        else if (s[lineNum + j][3] == ' ') continue;
                        else if (s[lineNum + j][3] != ' ') break;
                    }
                }
            }
            return -1;
        }
        //check if there is transpacific itinery
        public static bool isChange(string[] s)
        {
            foreach (string myString in s)
            {
                if (myString[3] == '/' && myString[0] != ' ') return true;
            }
            return false;
        }

        //check if there is no transit flight 
        public static bool IsNoTransitFlight(string[] s, string oriPlace)
        {
            foreach (string myString in s)
            {
                if (myString[3] == ' ' && myString[0] != ' ' && myString.Substring(33, 3) == oriPlace) return true;
            }
            return false;
        }

        //there is transpacific flight return the seat line
        public string transFullSeat(string[] ticketInfo, string oriPlace, string destPlace, string date, int flightNum)
        {
            Cursor.Current = Cursors.WaitCursor;
            string display = "";
            int i = 0;
            string ticketLine = "";

            int res = checkAllDirect(ticketInfo, this.airline, oriPlace, destPlace);
            //all same ori airline exists
            if (res != -1)
            {
                if (oriPlace == ori) departSame = true;
                if (oriPlace == dest) returnSame = true;
                int pos = oriChecker(ticketInfo[res], oriPlace);
                this.seg = ticketInfo[res][0];
                ticketLine = ticketInfo[res].Substring(12, pos - 13) + (ticketInfo[res + 1][0] == ' ' ? ticketInfo[res + 1].Substring(12, ticketInfo[res + 1].Length - 12) : "");
                return ticketLine;
            }


            else
            {

                //no all same ori airline exists
                for (; i < ticketInfo.Length; i++)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    bool airLineContain = false;
                    int pos = oriChecker(ticketInfo[i], oriPlace);
                    if (ticketInfo[i][0] == '.' || ticketInfo[i].Substring(1, 2) == "  ") continue;
                    if (pos != -1)
                    {
                        if (destChecker(ticketInfo[i], destPlace) != -1) continue;
                        display = ticketInfo[i] + Environment.NewLine;
                        addOpAir(ticketInfo[i], flightNum);
                        if (ticketInfo[i].Substring(1, 3) == airline + " ") airLineContain = true;
                        for (int j = 1; i + j < ticketInfo.Length; j++)
                        {
                            if (ticketInfo[i + j].Substring(1, 3) == airline + " ") airLineContain = true;
                            if (destChecker(ticketInfo[i + j], destPlace) != -1)
                            {
                                display += ticketInfo[i + j] + Environment.NewLine;
                                addOpAir(ticketInfo[i + j], flightNum);
                                break;
                            }
                            display += ticketInfo[i + j] + Environment.NewLine;
                            if (ticketInfo[i + j].Substring(1, 2) == this.airline) addOpAir(ticketInfo[i + j], flightNum);
                        }
                        if (airLineContain)
                        {
                            Cursor.Current = Cursors.Default;
                            var confirmResult = MessageBox.Show("Is it the itinery you want: " + Environment.NewLine + display,
                                        "confirm transpacific itinery: " + airline + "  " + oriPlace + "-" + destPlace + " " + date,
                                        MessageBoxButtons.YesNo);
                            if (confirmResult == DialogResult.Yes)
                            {
                                this.seg = ticketInfo[i][0];
                                ticketLine = ticketInfo[i].Substring(12, pos - 13) + (ticketInfo[i + 1][0] == ' ' ? ticketInfo[i + 1].Substring(12, ticketInfo[i + 1].Length - 12) : "");
                                break;
                            }
                            else if (confirmResult == DialogResult.No)
                            {
                                if (flightNum == 1) opAir1.Clear();
                                else if (flightNum == 2) opAir2.Clear();
                                continue;
                            }
                        }
                        else
                        {
                            if (flightNum == 1) opAir1.Clear();
                            else if (flightNum == 2) opAir2.Clear();
                        }
                    }
                }
                Cursor.Current = Cursors.WaitCursor;
                return ticketLine;
            }
        }


        //there is no transpacific flight return the seat line
        public string untransFullSeat(string[] ticketInfo, string oriPlace, string destPlace, string date)
        {
            int i = 0;
            string ticketLine = "";
            foreach (var line in ticketInfo)
            {
                int pos = oriChecker(line, oriPlace);
                if (line.Substring(1, 2) != this.airline)
                {
                    i++;
                    continue;
                }
                if (line[3] == ' ' && pos != -1)
                {
                    this.seg = line[0];
                    ticketLine = line.Substring(9, pos - 10) + (ticketInfo[i + 1][0] == ' ' ? ticketInfo[i + 1].Substring(9, ticketInfo[i + 1].Length - 9) : "");
                    break;
                }
                i++;
            }
            return ticketLine;
        }


        //purchase ticket

        public void ticketPurchase(string oriPlace, string destPlace, string date, int flightNum)
        {
            string buyCmd;
            string seat = "";
            string fullSeat = "";
            string cmd = "1" + date + oriPlace + destPlace + "¥" + this.airline;
            Air.TE.SabreCommand.Request(cmd, session);
            fullSeat = Air.TE.SabreCommand.Request("1*C", session);
            textBox1 += cmd + Environment.NewLine;
            textBox1 += "full seats list of departure flight" + Environment.NewLine + fullSeat + Environment.NewLine + seperator + Environment.NewLine;
            string[] array = fullSeat.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string line = "";
            if (!(Flight.isFlight(array)))
            {
                errorMsg = airline + "        " + ori + "-" + dest + "       " + departD + "-" + returnD + "      " + "Error: there is no flight on " + date + Environment.NewLine;
                return;
            }
            if (Flight.isChange(array))
            {
                line = this.transFullSeat(array, oriPlace, destPlace, date, flightNum);
            }
            else
            {
                departSame = true;
                line = this.untransFullSeat(array, oriPlace, destPlace, date);
            }
            Cursor.Current = Cursors.WaitCursor;
            if (line == "")
            {
                Air.TE.SabreCommand.Request("1*", session);
                fullSeat = Air.TE.SabreCommand.Request("1*C", session);
                textBox1 += "1*" + Environment.NewLine + fullSeat + Environment.NewLine + seperator + Environment.NewLine;
                array = fullSeat.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (!(Flight.isFlight(array)))
                {
                    errorMsg = airline + "        " + ori + "-" + dest + "       " + departD + "-" + returnD + "      " + "Error: there is no flight on " + date + Environment.NewLine;
                    return;
                }
                if (Flight.isChange(array))
                {
                    line = this.transFullSeat(array, oriPlace, destPlace, date, flightNum);
                }
                else
                {
                    returnSame = true;
                    line = this.untransFullSeat(array, oriPlace, destPlace, date);
                }
            }

            if (line == "")
            {
                this.errorMsg = airline + "        " + ori + "-" + dest + "       " + departD + "-" + returnD + "      " + "Error: there is no flight on " + date + Environment.NewLine;
                return;
            }
            string[] seatInfo = line.Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
            int len = seatInfo.Length;
            for (int j = len - 1; j > 0; j--)
            {
                int num = seatInfo[j][1] - '0'; //seat amount
                if (num > 0)
                {
                    // print the lowest available seat
                    seat = seatInfo[j][0].ToString();
                    break;
                }
            }
            if (seat == "") errorMsg = airline + "        " + ori + "-" + dest + "       " + departD + "-" + returnD + "      " + "Error: there is no seat for the itinerary: " + line + Environment.NewLine;
            else
            {
                if (flightClass == "") flightClass = seat;
                else if (flightClass != seat) flightClass += "+" + seat;
            }
            //buy ticket
            buyCmd = "01" + seat + this.seg.ToString() + "*";
            Air.TE.SabreCommand.Request(buyCmd, session);
        }




        public void WPNCRequest()
        {
            var WPNCMsg = Air.TE.SabreCommand.Request("WPNCB", session);
            //select WPNC line
            string[] arrayOfWPNC = WPNCMsg.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            this.WPNC = arrayOfWPNC;
            if (arrayOfWPNC.Length == 1)
            {
                errorMsg = airline + "        " + ori + "-" + dest + "       " + departD + "-" + returnD + arrayOfWPNC[0] + Environment.NewLine;
            }
            else
            {
                foreach (string WPNCLine in arrayOfWPNC)
                {
                    if (WPNCLine[0] == ' ' && WPNCLine[1] == '1' && WPNCLine[2] == '-')
                    {
                        for (int i = 0; i < WPNCLine.Length; i++)
                        {
                            if (WPNCLine.Substring(i, 2) == "XT")
                            {
                                int taxIndex = i - 6;
                                tax = WPNCLine.Substring(taxIndex, 6);
                            }
                            if (WPNCLine.Substring(i, 3) == "ADT")
                            {
                                int len = 7;
                                int totalIndex = i - 7;
                                if (WPNCLine[totalIndex] == 'D')
                                {
                                    totalIndex++;
                                    len--;
                                }
                                total = WPNCLine.Substring(totalIndex, len);
                                baseFare = (Convert.ToDecimal(total) - Convert.ToDecimal(tax)).ToString().PadLeft(8, ' ');
                                textBox1 += "WPNC price" + Environment.NewLine + WPNCMsg + Environment.NewLine + seperator + Environment.NewLine + Environment.NewLine;
                                return;
                            }
                        }
                    }
                }
            }
            if (WPNC.Length < 4) this.errorMsg = airline + "        " + ori + "-" + dest + "       " + departD + "-" + returnD + "      " + "Error: " + WPNC[0] + Environment.NewLine;

        }

        public int WPPJCBRequest()
        {
            var WPPJCBMsg = Air.TE.SabreCommand.Request("WPNC¥PJCB", session);
            arrayOfWPPJCB = WPPJCBMsg.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (arrayOfWPPJCB.Length > 5)
            {
                foreach (string line in arrayOfWPPJCB)
                {
                    if (line[0] == ' ' && line[1] == '1' && line[2] == '-')
                    {
                        for (int i = 0; i < line.Length; i++)
                        {
                            if (line.Substring(i, 2) == "XT")
                            {
                                int taxIndex = i - 6;
                                tax = line.Substring(taxIndex, 6);
                            }
                            if (line.Substring(i, 3) == "JCB")
                            {
                                int totalIndex = i - 7;
                                int len = 7;
                                if (line[totalIndex] == 'D')
                                {
                                    totalIndex++;
                                    len--;
                                }
                                total = line.Substring(totalIndex, len);
                                baseFare = (Convert.ToDecimal(total) - Convert.ToDecimal(tax)).ToString().PadLeft(8, ' ');
                                textBox1 += "WPPJCB price" + Environment.NewLine + WPPJCBMsg + Environment.NewLine + seperator + Environment.NewLine + Environment.NewLine;
                                return 1;
                            }
                        }
                    }
                }
            }
            return 0;
        }

        public void progRun()
        {
            string ticketInfo = "";
            try
            {
                int flightNum = 1;
                this.ticketPurchase(this.ori, this.dest, this.departD, flightNum);
                if (this.errorMsg == "")
                {
                    flightNum = 2;
                    this.ticketPurchase(this.dest, this.ori, this.returnD, flightNum);
                    if (this.flightClass.Length == 1) this.flightClass += "  ";
                    if (this.errorMsg == "")
                    {
                        ticketInfo = Air.TE.SabreCommand.Request("*IA", session);
                        this.itinerary = ticketInfo;
                        textBox1 += "Itinery" + Environment.NewLine + ticketInfo + Environment.NewLine + seperator + Environment.NewLine;
                        if (this.WPPJCBRequest() == 0)
                        {
                            this.WPNCRequest();
                            this.itinerary = Air.TE.SabreCommand.Request("*IA", session);
                            if (WPNC.Length > 3)
                            {
                                getWPNCFareBasis();
                                getCommission();
                                this.total = (Convert.ToDecimal(this.total) - Convert.ToDecimal(this.Commission)).ToString();
                            }
                            this.fareType = "PUB";
                            Msg = airline + "        " + ori + "-" + dest + "       " + departD + "-" + returnD + "     " + baseFare + "       " + tax + "       " + fareType + "      " + rate + "       " + (commissionExist ? "YES" : "NO  ") + "       " + Math.Round(Convert.ToDouble(Commission), 2) + "            " + Math.Round(Convert.ToDouble(total), 2) + Environment.NewLine;
                        }
                        else
                        {
                            getWPPJCBFareBasis();
                            this.fareType = "NET";
                            Msg = airline + "        " + ori + "-" + dest + "       " + departD + "-" + returnD + "     " + baseFare + "       " + tax + "       " + fareType + "      " + rate + "       " + (commissionExist ? "YES" : "NO") + "         " + Math.Round(Convert.ToDouble(Commission), 2) + "              " + Math.Round(Convert.ToDouble(total), 2) + Environment.NewLine;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                textBox1 = ex.Message;
            }
        }

        //ＡＰＣ not necessary to read
        public List<string> getTrip(string oriPlace, string destPlace)
        {
            string[] itin = this.itinerary.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            List<string> trip = new List<string>();
            for (int i = 0; i < itin.Length; i++)
            {
                var place = oriChecker(itin[i], oriPlace);
                if (place != -1 && itin[i][place - 1] == ' ')
                {
                    for (; i < itin.Length; i++)
                    {
                        if (destChecker(itin[i], destPlace) != -1)
                        {
                            trip.Add(itin[i]);
                            break;
                        }
                        else trip.Add(itin[i]);
                    }
                }
                if (trip.Count != 0) break;
            }
            return trip;
        }
        public void getCommission()
        {
            this.trip1 = getTrip(ori, dest);
            this.trip2 = getTrip(dest, ori);
            Air.Pricing.Context context = new Air.Pricing.Context();
            Air.Pricing.Itin APCItin = null;
            string fareBasis1 = "";
            string fareBasis2 = "";

            try
            {
                DateTime.Now.AddHours(+3);
                if (fareBasis.Length != 1 && fareBasis.Length != 2) return;
                else if (fareBasis.Length == 1)
                {
                    fareBasis1 = fareBasis[0];
                    fareBasis2 = fareBasis[0];
                }
                else if (fareBasis.Length == 2)
                {
                    fareBasis1 = fareBasis[0];
                    fareBasis2 = fareBasis[1];
                }
                // ADT - pub fare 1 // JCB - Net fare 2
                APCItin = new Air.Pricing.Itins(context).Create(
                                                  airline: this.airline, // VALIDATING CARRIER - BR
                                                  utc: DateTime.Now.AddHours(+3).ToUniversalTime(), // no TKT deadline put 3h plus
                                                  posCountry: this.getCounrtyCode(),
                                                  fareType: 1,
                                                  amount: Convert.ToDecimal(this.total),
                                                  tax: Convert.ToDecimal(this.tax),
                                                  markupGroup: 1,
                                                  currency: Flight.Currency,
                                                  client: 100, // TE
                                                  markupClient: 100, // TE
                                                  contractClient: 100 // TE
                                                );
                //Depart trip
                var itinTrip1 = APCItin.Trips.Add(context, this.ori, this.dest, (new CreateDate(departD.Substring(2, 3), departD.Substring(0, 2), trip1[0].Substring(31, 5))).createDateTime());
                int op1 = 0;
                int op2 = 0;
                foreach (var seg in trip1)
                {
                    var departMonth = seg.Substring(13, 3);
                    var departDay = seg.Substring(11, 2);
                    var departTime = seg.Substring(31, 5);
                    var oriPlace = seg.Substring(19, 3);
                    var destPlace = seg.Substring(22, 3);
                    var endMonth = seg.Substring(13, 3);
                    var arrivalTime = seg[43] == '/' ? (new CreateDate(seg.Substring(13, 3), seg.Substring(11, 2), seg.Substring(37, 5))).createDateTime()
                                                     : (new CreateDate(seg.Substring(46, 3), seg.Substring(44, 2), seg.Substring(37, 5))).createDateTime();
                    var departDateTime = new CreateDate(departMonth, departDay, departTime).createDateTime();

                    itinTrip1.Segments.Add(context, origin: oriPlace,
                                                destination: destPlace,
                                                     departure: (new CreateDate(departMonth, departDay, departTime)).createDateTime(),
                                                    arrival: arrivalTime,
                                                    marketingAirline: this.airline,
                                                    operatingAirline: departSame == true ? this.airline : opAir1[op1],
                                                    flight: Convert.ToInt32(seg.Substring(5, 4)),
                                                    @class: seg.Substring(9, 1),
                                                    fareBasis: fareBasis1,
                                                    stop: 0,
                                                    trip: 1,
                                                    equipment: "");
                    op1++;
                }
                //Return trip
                var itinTrip2 = APCItin.Trips.Add(context, this.dest, this.ori, (new CreateDate(trip2[0].Substring(13, 3), trip2[0].Substring(11, 2), trip2[0].Substring(31, 5))).createDateTime());
                foreach (var seg in trip2)
                {
                    var departMonth = seg.Substring(13, 3);
                    var departDay = seg.Substring(11, 2);
                    var departTime = seg.Substring(31, 5);
                    var oriPlace = seg.Substring(19, 3);
                    var destPlace = seg.Substring(22, 3);
                    var endMonth = seg.Substring(13, 3);
                    var arrivalTime = seg[43] == '/' ? (new CreateDate(seg.Substring(13, 3), seg.Substring(11, 2), seg.Substring(37, 5))).createDateTime()
                                                     : (new CreateDate(seg.Substring(46, 3), seg.Substring(44, 2), seg.Substring(37, 5))).createDateTime();
                    var departDateTime = new CreateDate(departMonth, departDay, departTime).createDateTime();

                    itinTrip2.Segments.Add(context, origin: oriPlace,
                                                destination: destPlace,
                                                     departure: (new CreateDate(departMonth, departDay, departTime)).createDateTime(),
                                                    arrival: arrivalTime,
                                                    marketingAirline: this.airline,
                                                    operatingAirline: departSame == true ? this.airline : opAir2[op2],
                                                    flight: Convert.ToInt32(seg.Substring(5, 4)),
                                                    @class: seg.Substring(9, 1),
                                                    fareBasis: fareBasis2,
                                                    stop: 0,
                                                    trip: 1,
                                                    equipment: "");
                    op2++;
                }
                var itinPricing = new Air.Pricing.ItinPricing(context, APCItin, null);


                Air.Pricing.FitContract fitContract = itinPricing.FitContracts.Best;

                var contract = fitContract.Contract;
                if (contract != null)
                {
                    this.commissionExist = true;
                    var rate = fitContract.Commission.Rate;
                    this.rate = rate.ToString();
                    var amount = fitContract.Commission.Amount;
                    this.Commission = (Convert.ToDecimal(baseFare) * rate).ToString();
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void getWPPJCBFareBasis()
        {
            foreach (var line in this.arrayOfWPPJCB)
            {
                if (line.Substring(0, 6) == "JCB-01")
                {
                    fareBasis = line.Substring(8).Split(' ');
                    return;
                }
            }
        }


        public void getWPNCFareBasis()
        {
            foreach (var line in this.WPNC)
            {
                if (line.Substring(0, 6) == "ADT-01")
                {
                    fareBasis = line.Substring(8).Split(' ');
                    return;
                }
            }
        }
        public string segToFare(string seg, DateTime dp)
        {
            var segTime = 'X';
            string fb = "";
            var segClass = seg[9];
            if ((dp.DayOfWeek == DayOfWeek.Saturday) || (dp.DayOfWeek == DayOfWeek.Sunday))
            {
                segTime = 'W';
            }

            foreach (var f in fareBasis)
            {
                if (this.airline == "CX") f.Replace("CX", "");
                if ((f.Substring(1).Contains(segTime) || (!f.Substring(1).Contains('W') && !f.Substring(1).Contains('W'))) && segClass == f[0])
                {
                    fb = f;
                    break;
                }
            }
            return fb;
        }

        public string getCounrtyCode()
        {
            using (var ctx = new Air.Pricing.Context())
            {
                var location = ctx.Set<Air.Pricing.Location>().SingleOrDefault(i => i.Code == this.ori);

                var country = location.Country.Code;
                return country;

            }

        }

        public void compRun(Connection session1)
        {
            try
            {
                session = session1;
                string ticketInfo = "";
                int flightNum = 1;
                this.ticketPurchase(this.ori, this.dest, this.departD, flightNum);
                if (this.errorMsg == "")
                {
                    flightNum = 2;
                    this.ticketPurchase(this.dest, this.ori, this.returnD, flightNum);
                    if (this.flightClass.Length == 1) this.flightClass += "  ";
                    if (this.errorMsg == "")
                    {
                        ticketInfo = Air.TE.SabreCommand.Request("*IA", session);
                        this.itinerary = ticketInfo;
                        if (this.WPPJCBRequest() == 0)
                        {
                            total = "N/A";
                        }
                        else getWPPJCBFareBasis();
                    }
                }
                else total = errorMsg;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
