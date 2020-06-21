using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Text;

namespace PortfolioBlazor.Pages.Bases
{
    public class ReverseEachWordInStringBase : ComponentBase
    {
        protected string str;
        protected string reversed;
        protected string error;
        protected string success;

        public void ReverseWords()
        {

            if(str == null)
            {
                error = "Please enter anything";
            }

            else
            {
                StringBuilder output = new StringBuilder();
                List<char> charList = new List<char>();

                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == ' ' || i == str.Length - 1)
                    {
                        if (i == str.Length - 1)
                        {
                            charList.Add(str[i]);
                        }

                        for (int j = charList.Count - 1; j >= 0; j--)
                        {
                            output.Append(charList[j]);
                        }
                        output.Append(' ');
                        charList = new List<char>();

                    }
                    else
                    {
                        charList.Add(str[i]);
                    }
                }

                reversed = output.ToString();
            }
        }
    }
}
