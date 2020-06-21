using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioBlazor.Pages.Bases
{
    public class RemoveDuplicatesFromStringBase : ComponentBase
    {

        protected class Duplicates
        {
            public int Quantity { get; set; }
            public string Character { get; set; }

            public Duplicates(int quantity, string character)
            {
                this.Quantity = quantity;
                this.Character = character;
            }
        }

        protected string str;
        protected string after;
        protected string error;
        protected string success;
        protected List<Duplicates> duplicatesList = new List<Duplicates>();


        public void RemoveDuplicates() {

            if(str == null)
            {
                error = "Please write something";
            }
            else
            {
                string newString = string.Empty;
                List<char> found = new List<char>();
                foreach (char c in str)
                {
                    if (found.Contains(c))
                        continue;

                    newString += c.ToString();
                    found.Add(c);
                }

                after = newString;

                //Statistics by using counting occurence function
                char[] charSentence = str.ToCharArray();
                duplicatesList.Clear();

                for (int i = 0; i < charSentence.Length; i++)
                {
                    if (charSentence[i] != ' ')
                    {
                        char c = charSentence[i];
                        string cS = c.ToString();
                        int counter = 0;

                        for (int j = 0; j < charSentence.Length; j++)
                        {
                            if (c == charSentence[j])
                            {
                                counter++;
                                charSentence[j] = ' ';
                            }
                        }

                        if (counter == 0)
                        {
                            Duplicates oc = new Duplicates(counter, cS);
                            duplicatesList.Add(oc);
                        }
                        else
                        {
                            Duplicates oc = new Duplicates(counter - 1, cS);
                            duplicatesList.Add(oc);
                        }
                    }
                }
            }

        }
    }
}
