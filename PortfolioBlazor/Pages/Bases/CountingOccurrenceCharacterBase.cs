using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioBlazor.Pages.Bases
{
    public class CountingOccurrenceCharacterBase : ComponentBase
    {

        protected class occurence
        {
            public int timesOccurence { get; set; }
            public string characterS { get; set; }

            public occurence(int timesOccurence, string characterS)
            {
                this.timesOccurence = timesOccurence;
                this.characterS = characterS;
            }
        }
        protected string str;
        protected List<occurence> occurrenceList = new List<occurence>();
        protected string error;
        protected string success;

        protected int listLenght;

        public void CountOccurance()
        {
            if(str == null)
            {
                error = "Please enter something";
            }
            else
            {
                char[] charSentence = str.ToCharArray();
                occurrenceList.Clear();

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

                        occurence oc = new occurence(counter, cS);

                        occurrenceList.Add(oc);
                    }
                }
            }

        }

    }
}
