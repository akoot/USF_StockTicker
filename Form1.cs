using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Stock_Ticker
{
    public partial class Form1 : Form
    {
        // I would like to have a dictionary of CandleSticks so that I can call them by their symbol
        private Dictionary<String, Stock> Stocks = new Dictionary<String, Stock>();
        private DirectoryInfo StockDataFolderInfo = new DirectoryInfo("Stock Data");
        private TimePeriod? selectedTimePeriod; // Could just get the value selected in the Form but..
        private Chart form2 = new Chart(); // THIS is for a nice fullscreen chart that is otherwise impossible to see correctly, enjoy!
        public Form1()
        {
            // Load all the candlesticks before the UI loads so that there aren't any errors.
            LoadCandleSticks();

            InitializeComponent();
        }

        // Get name parts, I will use this again soon. Why? because it's funny!
        private String[] GetNameParts(string filename)
        {
            return filename.Split(new char[] { '-', '.' });
        }

        // Use a method to load the candlesticks into memory when the program loads.
        private void LoadCandleSticks()
        {
            // Go through all the files in the StockDataFolder.
            foreach (FileInfo file in StockDataFolderInfo.GetFiles())
            {
                // Splitting on '-' and '.' because '-' is between the name and the time period, and the '.' because of the extension.
                // If they didn't have extensions, I would juse split on '-' but alas.
                String[] nameParts = GetNameParts(file.Name);

                // The name is the first part of the filename so it will be index 0 of the string array.
                String symbol = nameParts[0];

                // Create stock if it doesn't exist
                if (!Stocks.ContainsKey(symbol) )
                {
                    Stocks.Add(symbol, new Stock());
                }

                // https://learn.microsoft.com/en-us/dotnet/api/system.enum.parse?redirectedfrom=MSDN&view=net-7.0#System_Enum_Parse_System_Type_System_String_System_Boolean_
                // I like using enums but researching them I read that they were a waste of time in C# or something (Java enjoyer). Too bad I guess, I will use them anyways
                TimePeriod timePeriod = (TimePeriod)Enum.Parse(typeof(TimePeriod), nameParts[1].ToUpper()); // What an annoying way to do this in C#, perhaps it's not meant to be!

                // Go through all of the lines in each file and turn them into CandleStick objects.
                foreach (String line in File.ReadLines(file.FullName))
                {
                    // CSV format as the name implies is separated by commas. Went over in class how you can have StringSplitOptions to remove empty entries.
                    // Sounds pretty convinient but I wonder how useful it really is for this app.
                    String[] csv = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    String dateString = csv[0].Trim('"'); // https://stackoverflow.com/a/38944638
                    if (dateString.Equals("Date")) { continue; } // Skip the rest of the code if it's the header, who needs it!

                    // It may be very bad practice for other data sets but I know for a fact that this one will not have "Date" as the date.

                    // Console.WriteLine($"{symbol}:{timePeriod}{strings[0]}:{strings[1]}:{strings[2]}"); // It's called we do a little testing!
                    CandleStick candleStick = new CandleStick(
                        DateTime.Parse(dateString),
                        double.Parse(csv[1]),
                        double.Parse(csv[2]),
                        double.Parse(csv[3]),
                        double.Parse(csv[4]),
                        double.Parse(csv[5])
                        );
                    Stocks[symbol].AddCandleStick(timePeriod, candleStick);
                }
            }
            // tests
            //Console.WriteLine(Stocks["AAPL"]);
            //Console.WriteLine("--All--");
            //printCandleSticks(Stocks["AAPL"].GetCandleSticks(TimePeriod.WEEK));
            //Console.WriteLine("--Test--");
            //printCandleSticks(FilterCandleSticks(Stocks["AAPL"].GetCandleSticks(TimePeriod.DAY), DateTime.Parse("2022-01-13"), DateTime.Parse("2022-01-19")));
        }

        // why is commenting out code in vs so painful?
        private void printCandleSticks(List<CandleStick> candleSticks)
        {
            foreach (CandleStick candleStick in candleSticks)
            {
                Console.WriteLine(candleStick);
            }
        }

        // Filters all of the candlesticks based on the start date and end date using a foreach loop.
        private List<CandleStick> FilterCandleSticks(List<CandleStick> candleSticks, DateTime startDate, DateTime endDate)
        {
            List<CandleStick> filteredList = new List<CandleStick>();
            foreach (CandleStick candleStick in candleSticks)
            {
                // I just assumed that dates could be given the ole "less than/greater than" operators, big if true?
                if (candleStick.Date >= startDate && candleStick.Date <= endDate)
                {
                    filteredList.Add(candleStick);
                }
            }
            return filteredList;
        }


        // Gets the candlesticks for the time period (day/week/month)
        private List<CandleStick> GetCandleSticks(string symbol, TimePeriod timePeriod)
        {
            return Stocks[symbol].GetCandleSticks(timePeriod);
        }

        // simply asked chatgpt to make this for me
        static string ConvertToTitleCase(string input)
        {
            // Split the input by underscores
            string[] words = input.Split('_');

            // Initialize a StringBuilder to build the output string
            StringBuilder sb = new StringBuilder();

            foreach (string word in words)
            {
                // Convert the first character of each word to uppercase
                // and the remaining characters to lowercase
                string formattedWord = char.ToUpper(word[0]) + word.Substring(1).ToLower();

                // Append the formatted word to the StringBuilder
                sb.Append(formattedWord).Append(" ");
            }

            // Remove the trailing space and return the final title case string
            return sb.ToString().Trim();
        }

        // Load method
        private void Form1_Load(object sender, EventArgs e)
        {
            // nevermind, don't do anything after all
            // maybe some other day...
            // wait i remember now, i need to fill up the patternBox
            foreach (var pattern in Enum.GetNames(typeof(Pattern)))
            {
                patternBox.Items.Add(ConvertToTitleCase(pattern));
            }
        }

        private void UpdateComboBox()
        {
            // Update selectedTimePeriod
            if (monthlyRadioButton.Checked) selectedTimePeriod = TimePeriod.MONTH;
            else if (weeklyRadioButton.Checked) selectedTimePeriod = TimePeriod.WEEK;
            else if (dailyRadioButton.Checked) selectedTimePeriod = TimePeriod.DAY;

            // Setup the ComboBox
            comboBox1.Items.Clear();
            foreach (string  symbol in Stocks.Keys)
            {
                // why would I go back and rename everything when I can just do this?
                // Of course, in real life nobody should do this but...
                comboBox1.Items.Add(symbol + "-" + ConvertToTitleCase(selectedTimePeriod.ToString()) + ".csv");
            }
        }

        // when the load button is clicked
        private void loadStockButton_Click(object sender, EventArgs e)
        {
            updateLeChart();
        }

        // when the monthly radio button is toggled
        private void monthlyRadioButton_CheckedChanged(object sender, EventArgs e)
        {

            UpdateComboBox();
        }

        // when the weekly radio button is toggled
        private void weeklyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateComboBox();
        }

        // when the daily radio button is toggled
        private void dailyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateComboBox();
        }

        // This method updates all of the information in the chart, including the title and series and of course, data source
        private void updateLeChart()
        {
            if (comboBox1.SelectedItem == null)
            if (selectedTimePeriod == null) return;
            // put a nice error message here

            // this is so funny, earlier i did this exact same thing! once again i cannot reiterate how i could simply go back and change how the values are stored
            // in the first place, but instead i have decided to perform this disgrace and write these comments :)
            string selectedCSV_LOL = comboBox1.SelectedItem.ToString();
            String[] selectedParts = GetNameParts(selectedCSV_LOL); // HAHAHA
            String selectedStock = selectedParts[0]; // they let you use lowercase string and uppercase String? This is such a funny programming language!

            // Filter the sticks based on the selected CSV file
            List<CandleStick> filteredCandleSticks = FilterCandleSticks(GetCandleSticks(selectedStock, (TimePeriod)selectedTimePeriod), startDate.Value, endDate.Value);
            var chart = form2.leChart;
            chart.DataSource = filteredCandleSticks;
            chart.DataBind();

            // Design
            chart.Titles[0].Text = selectedCSV_LOL;
            var legend = chart.Legends[0];
            legend.Title = "The Legend of Zelda";
            legend.CustomItems.Clear();

            Series series = chart.Series[0];
            series.Color = Color.Gray;
            series.Name = selectedTimePeriod.ToString();

            form2.Show();

            if (patternBox.SelectedItem == null) return;

            Pattern pattern = (Pattern)Enum.Parse(typeof(Pattern), patternBox.SelectedItem.ToString().ToUpper().Replace(" ", "_"));

            // This could be extracted into a function but OH WELL!
            switch (pattern)
            {
                case Pattern.DOJI_NEUTRAL:
                    {
                        legend.CustomItems.Add(Color.Orange, "Doji Neutral");
                        for (int i = 0; i < filteredCandleSticks.Count; i++)
                        {
                            if (filteredCandleSticks[i].GetPattern() == pattern)
                                series.Points[i].Color = Color.Orange;
                        }

                        break;
                    }

                case Pattern.DOJI_LONG_LEGGED:
                    {
                        legend.CustomItems.Add(Color.Yellow, "Doji Long-Legged");
                        for (int i = 0; i < filteredCandleSticks.Count; i++)
                        {
                            if (filteredCandleSticks[i].GetPattern() == pattern)
                                series.Points[i].Color = Color.Yellow;
                        }

                        break;
                    }

                case Pattern.DOJI_GRAVESTONE:
                    {
                        legend.CustomItems.Add(Color.OrangeRed, "Doji Gravestone");
                        for (int i = 0; i < filteredCandleSticks.Count; i++)
                        {
                            if (filteredCandleSticks[i].GetPattern() == pattern)
                                series.Points[i].Color = Color.OrangeRed;
                        }

                        break;
                    }
                case Pattern.DOJI_DRAGONFLY:
                    {
                        legend.CustomItems.Add(Color.DarkOrange, "Doji Dragonfly");
                        for (int i = 0; i < filteredCandleSticks.Count; i++)
                        {
                            if (filteredCandleSticks[i].GetPattern() == pattern)
                                series.Points[i].Color = Color.DarkOrange;
                        }

                        break;
                    }
                case Pattern.MARUBOZU:
                    {
                        legend.CustomItems.Add(Color.Blue, "Blue");
                        for (int i = 0; i < filteredCandleSticks.Count; i++)
                        {
                            if (filteredCandleSticks[i].GetPattern() == pattern)
                                series.Points[i].Color = Color.Blue;
                        }

                        break;
                    }
                case Pattern.HAMMER:
                    {
                        legend.CustomItems.Add(Color.Violet, "Hammer");
                        for (int i = 0; i < filteredCandleSticks.Count; i++)
                        {
                            if (filteredCandleSticks[i].GetPattern() == pattern)
                                series.Points[i].Color = Color.Violet;
                        }

                        break;
                    }
                case Pattern.BULLISH:
                    {
                        legend.CustomItems.Add(Color.Green, "Bullish");
                        foreach (int i in AlgorithmEnjoyer.FindBullishEngulfingPatterns(filteredCandleSticks))
                        {
                            series.Points[i].Color = Color.Green;
                        }
                        break;
                    }
                case Pattern.BEARISH:
                    {
                        legend.CustomItems.Add(Color.Red, "Bearish");
                        foreach (int i in AlgorithmEnjoyer.FindBearishEngulfingPatterns(filteredCandleSticks))
                        {
                            series.Points[i].Color = Color.Red;
                        }
                        break;
                    }
            }

            

            
        }
    }
}
