using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioBlazor.Pages.Bases
{
    public class IsPrimeBase : ComponentBase
    {
        protected int number;
        protected string output;

        protected string success;
        protected string error;

        public async void isPrime()
        {

            //Reset error message
            error = "";
            //Reset sucess message
            success = " ";

            bool checker = false;
            if(number < 1)
            {
                error = "Please enter a valid number greater than 1";
            }
            else
            {
                if(number == 1) {checker = true; }
                if (number == 2) {checker = true; }
                if (number % 2 == 0) {checker = true; }

                var squareRoot = (int)Math.Floor(Math.Sqrt(number));

                for(int i = 3; i <= squareRoot; i = i + 2)
                {
                    if (number % i == 0) { checker = true; }
                }
                
                if(checker)
                {
                    output = "It is not a prime number";
                    await Task.Delay(500);
                    success = "Success!";
                    StateHasChanged();
                }
                else
                {
                    output = "It is a prime number";
                    await Task.Delay(500);
                    success = "Success!";
                    StateHasChanged();
                }
            }
        }
    }
}
