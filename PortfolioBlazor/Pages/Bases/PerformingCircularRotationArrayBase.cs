using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioBlazor.Pages.Bases
{
    public class PerformingCircularRotationArrayBase : ComponentBase
    {
        protected string str;
        protected string output;

        protected string success;
        protected string error;

        public async void CircularLeftRotation()
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
                char[] strCArray = str.ToCharArray();
                string tempString = new string(strCArray);
                output = tempString;
                int arrayLength = str.Length - 1;
                char t;

                for (int i = arrayLength; i > 0; i--)
                {
                    await Task.Delay(100);
                    t = strCArray[arrayLength];
                    strCArray[arrayLength] = strCArray[i - 1];
                    strCArray[i - 1] = t;
                    tempString = new string(strCArray);
                    output = tempString;
                    StateHasChanged();
                }
                await Task.Delay(100);
                success = "Success!";
                StateHasChanged();
            }
        }

        public async void CircularRightRotation()
        {

            //Reset error message
            error = "";
            //Reset sucess message
            success = " ";

            if (str == null)
            {
                error = "Please enter a string";
            }
            else
            {
                char[] strCArray = str.ToCharArray();
                string tempString = new string(strCArray);
                output = tempString;
                int arrayLength = str.Length - 1;
                char t;

                for (int i = 0; i < arrayLength; i++)
                {
                    await Task.Delay(1000);
                    t = strCArray[0];
                    strCArray[0] = strCArray[i + 1];
                    strCArray[i + 1] = t;
                    tempString = new string(strCArray);
                    output = tempString;
                    StateHasChanged();
                }
                await Task.Delay(500);
                success = "Success!";
                StateHasChanged();
            }
        }
    }
}
