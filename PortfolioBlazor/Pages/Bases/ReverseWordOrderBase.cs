using Microsoft.AspNetCore.Components;
using System.Text;

namespace PortfolioBlazor.Pages.Bases
{
    public class ReverseWordOrderBase : ComponentBase
    {
        protected string str;
        protected string reversed;

        protected string success;
        protected string error;

        public async void ReverseWordOrder()
        {
            error = "";
            success = "";

            if(str == null)
            {
                error = "Enter anything to start program";
            }
            else
            {
                int i;
                StringBuilder reverseSentence = new StringBuilder();

                int Start = str.Length - 1;
                int End = str.Length - 1;

                while (Start > 0)
                {
                    if (str[Start] == ' ')
                    {
                        i = Start + 1;
                        while (i <= End)
                        {
                            reverseSentence.Append(str[i]);
                            i++;
                        }
                        reverseSentence.Append(' ');
                        End = Start - 1;
                    }
                    Start--;
                }

                for (i = 0; i <= End; i++)
                {
                    reverseSentence.Append(str[i]);

                }

                success = "Success!";
                StateHasChanged();
                reversed = reverseSentence.ToString();
            }
           
        }
    }
}
