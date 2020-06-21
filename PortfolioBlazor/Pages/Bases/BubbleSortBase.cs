using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// This program will populate database and then will sort it from lowest to highest or other way around.
/// </summary>
/// <param name="graphObject">It represents one graph column</param>
/// <param name="largest">It looks for largest value in the given List so it can determine percentage for each of the columns</param>
/// <param name="top_scale">This will show top scale score on the chart</param>
/// <param name="middle_scale">This will show middle scale score on the chart</param>
/// <param name="bottom_scale">This will show bottom scale score on the chart which always is equal to 0</param>
/// 
/// <param name="success_populate">It shows 'Success!' if population of the table will be successfull</param>
/// <param name="error_populate">It shows 'Error' if population of the table will be unsuccessfull</param>
/// <param name="success_sort">It shows 'Success!' if sorting function finished correctly</param>
/// <param name="error_sort">It shows error if if sorting function went incorrectly</param>
///
/// 


namespace PortfolioBlazor.Pages.Bases
{
    public class BubbleSortBase : ComponentBase
    {
        protected class graphObject
        {
            public int number { get; set; }
            public int percentage { get; set; }
            public string name { get; set; }

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
                string p = percentage.ToString() + "%";
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

            if(monthlySales.Count == 0)
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
                    monthlySales[i].percentage = (int)Math.Round((double)(100 * monthlySales[i].number) / largest);
                    top_scale = largest.ToString();
                    middle_scale = ((int)Math.Round((double)largest / 2)).ToString();
                }
                success_populate = "Success!";
                await Task.Delay(100);
                StateHasChanged();

            }
        }

        public async void BubbleSort()
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
                graphObject holder;
                int counter = monthlySales.Count();

                for (int i = 0; i < counter - 1; i++)
                {
                    for (int j = 0; j < counter - i - 1; j++)
                    {
                        if (monthlySales[j].number > monthlySales[j + 1].number)
                        {
                            holder = monthlySales[j];
                            monthlySales[j] = monthlySales[j + 1];
                            monthlySales[j + 1] = holder;

                            await Task.Delay(500);
                            StateHasChanged();
                        }
                    }
                }
                success_sort = "Success!";
                StateHasChanged();
            }
        }
    }
}
