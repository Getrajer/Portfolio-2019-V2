using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioBlazor.Pages.Bases
{
    public class QuickSortBase : ComponentBase
    {
        public class graphObject
        {
            public int number { get; set; }
            public int column_percentage { get; set; }
            public int pie_percentage { get; set; }
            public string name { get; set; }
            public string color { get; set; }

            public graphObject()
            {
            }

            public graphObject(int _number, string _name)
            {
                this.number = _number;
                this.name = _name;
            }

            public string returnPercentage()
            {
                string p = column_percentage.ToString() + "%";
                return p;
            }
        }

        protected string success_populate;
        protected string error_populate;

        protected string success_sort;
        protected string error_sort;

        protected string top_scale;
        protected string middle_scale;
        protected static string bottom_scale = "0";

        //
        List<string> colorsList = new List<string> {
        "FF0000", "00FF00", "0000FF", "FFFF00", "FF00FF", "00FFFF", "000000",
        "800000", "008000", "000080", "808000", "800080", "008080", "808080",
        "C00000", "00C000", "0000C0", "C0C000", "C000C0", "00C0C0", "C0C0C0",
        "400000", "004000", "000040", "404000", "400040", "004040", "404040",
        "200000", "002000", "000020", "202000", "200020", "002020", "202020",
        "600000", "006000", "000060", "606000", "600060", "006060", "606060",
        "A00000", "00A000", "0000A0", "A0A000", "A000A0", "00A0A0", "A0A0A0",
        "E00000", "00E000", "0000E0", "E0E000", "E000E0", "00E0E0", "E0E0E0",
        };

        protected string pie_chart_colors = " conic-gradient(";

        graphObject january = new graphObject(399, "january");
        graphObject febuary = new graphObject(20, "febuary");
        graphObject march = new graphObject(120, "march");
        graphObject april = new graphObject(340, "april");
        graphObject may = new graphObject(200, "may");
        graphObject june = new graphObject(100, "june");
        graphObject july = new graphObject(90, "july");
        graphObject august = new graphObject(100, "august");
        graphObject september = new graphObject(200, "september");
        graphObject october = new graphObject(300, "october");
        graphObject november = new graphObject(50, "november");
        graphObject december = new graphObject(60, "december");
        protected List<graphObject> monthlySales = new List<graphObject>();
        
        public async void PopulateDataTable()
        {
            //Reset communicates
            success_populate = "";
            success_sort = "";
            error_sort = "";
            error_populate = "";

            //Reset Chart
            monthlySales.Clear();

            monthlySales.Add(january);
            monthlySales.Add(febuary);
            monthlySales.Add(march);
            monthlySales.Add(april);
            monthlySales.Add(may);
            monthlySales.Add(june);
            monthlySales.Add(july);
            monthlySales.Add(august);
            monthlySales.Add(september);
            monthlySales.Add(october);
            monthlySales.Add(november);
            monthlySales.Add(december);


            if (monthlySales.Count == 0)
            {
                error_populate = "Ups something went wrong try again";
            }
            else
            {
                int largest = 0;

                //Find LargestNumber
                for (int i = 0; i < monthlySales.Count; i++)
                {
                    if (largest <= monthlySales[i].number)
                    {
                        largest = monthlySales[i].number;
                    }
                }

                //Calculate Percentage
                for (int i = 0; i < monthlySales.Count; i++)
                {
                    monthlySales[i].column_percentage = (int)Math.Round((double)(100 * monthlySales[i].number) / largest);
                    top_scale = largest.ToString();
                    middle_scale = ((int)Math.Round((double)largest / 2)).ToString();
                }
                success_populate = "Success!";
                await Task.Delay(100);
                StateHasChanged();
            }
        }

        public async void quickSort(List<graphObject> graphObjects, int start, int end)
        {
            int i;
            if(start < end)
            {
                i = Partition(graphObjects, start, end);

                quickSort(graphObjects, start, i - 1);
                await Task.Delay(1000);
                StateHasChanged();
                quickSort(graphObjects, i + 1, end);
                await Task.Delay(1000);
                StateHasChanged();

            }
        }

        private int Partition(List<graphObject> graphObjects, int start, int end)
        {
            graphObject temp;
            graphObject p = graphObjects[end];
            int i = start - 1;

            for(int j = start; j <= end - 1; j++)
            {
                if(graphObjects[j].number <= p.number)
                {
                    i++;
                    temp = graphObjects[i];
                    graphObjects[i] = graphObjects[j];
                    graphObjects[j] = temp;
                }
            }

            temp = graphObjects[i + 1];
            graphObjects[i + 1] = graphObjects[end];
            graphObjects[end] = temp;
            return i + 1;
        }

        

        public async void QuickSortChart()
        {
            //Reset communicates
            success_populate = "";
            success_sort = "";
            error_sort = "";
            error_populate = "";

            if (monthlySales == null || monthlySales.Count == 0)
            {
                error_sort = "Chart is empty cannot sort it!";
            }
            else
            {
                quickSort(monthlySales, 0, monthlySales.Count - 1);

                

                success_sort = "Success!";
                StateHasChanged();
            }

            
        }

        /*
        public async void GeneratePieChart()
        {
            int total = 0;

            //Create Pie Chart
            //Find Total
            for (int i = 0; i < monthlySales.Count; i++)
            {
                total = total + monthlySales[i].number;
            }

            //Calculate Percentage
            for (int i = 0; i < monthlySales.Count; i++)
            {
                int percentComplete = (int)Math.Round((double)(100 * monthlySales[i].number) / total * 3.6);
                monthlySales[i].pie_percentage = percentComplete;
                monthlySales[i].color = "#" + colorsList[i];


                //Creating pie chart 
                if (i == 0)
                {
                    pie_chart_colors = pie_chart_colors + " " + monthlySales[i].color + " " + monthlySales[i].pie_percentage + "%, ";
                }
                else if (i != monthlySales.Count - 1)
                {
                    pie_chart_colors = pie_chart_colors + monthlySales[i].color + " " + monthlySales[i].pie_percentage + "%,";
                }
                else
                {
                    pie_chart_colors = pie_chart_colors + monthlySales[i].color + " " + monthlySales[i].pie_percentage + "%"; ;
                }
            }
            StateHasChanged();
        }*/
    }
}
