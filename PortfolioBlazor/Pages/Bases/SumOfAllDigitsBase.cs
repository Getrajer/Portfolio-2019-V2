using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioBlazor.Pages.Bases
{
    public class SumOfAllDigitsBase : ComponentBase
    {
        protected int number;
        protected int output;

        protected string success;
        protected string error;

        public async void sumDigits()
        {
            //Reset error message
            error = "";
            //Reset sucess message
            success = " ";

            if (number < 1)
            {
                error = "Plese enter valid number higher than 0";
            }
            else
            {
                int sum = 0;
                int num = number;
                while (num > 0)
                {
                    sum = sum + num % 10;
                    num /= 10;
                    await Task.Delay(500);
                    output = sum;
                    StateHasChanged();

                }
                await Task.Delay(500);
                success = "Success!";
                StateHasChanged();
            }
        }
    }
}
