using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioBlazor.Pages.Bases
{
    public class AllPosibleSubstringBase : ComponentBase
    {
        protected class Substrings
        {
            public string Substring { get; set; }

            public Substrings(string substring)
            {
                this.Substring = substring;
            }
        }

        protected string str;
        protected List<Substrings> substringsList = new List<Substrings>();

        protected string success;
        protected string error;

        public async void AllPossibleSubstrings()
        {

            //Reset error message
            error = "";
            //Reset sucess message
            success = " ";

            if(str == null)
            {
                error = "Please enter a string";
            }
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    for (int j = i; j < str.Length; j++)
                    {
                        stringBuilder.Append(str[j]);
                        string s = stringBuilder.ToString();
                        Substrings substrings = new Substrings(s);
                        substringsList.Add(substrings);
                        await Task.Delay(100);
                        StateHasChanged();
                    }
                }

                await Task.Delay(500);
                success = "Success!";
                StateHasChanged();
            }
        }
    }
}
