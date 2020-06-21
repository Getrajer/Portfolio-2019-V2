using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioBlazor.Pages.Bases
{
    public class ClockBase : ComponentBase
    {
        protected double hour_percentage = 440;
        protected double hour;
        protected double minute_percentage = 440;
        protected double minute;
        protected double second_percentage = 440;
        protected double second;

        protected override async Task OnInitializedAsync()
        {
            for (int i = 0; i < 2; i++)
            {
                var date = DateTime.Now;
                double temp = 440 - (440 * date.Hour) / 24;
                hour_percentage = Math.Round(temp);
                hour = date.Hour;

                double temp2 = 440 - (440 * date.Minute) / 60;
                minute_percentage = Math.Round(temp2);
                minute = date.Minute;

                double temp3 = 440 - (440 * date.Second) / 60;
                second_percentage = Math.Round(temp3);
                second = date.Second;

                i--;
                StateHasChanged();
                await Task.Delay(1000);
            }
        }
    }
}
