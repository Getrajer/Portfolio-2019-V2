using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioBlazor.Pages.Bases
{
    public class BuildPizzaBase : ComponentBase
    {
        //Declaring pizza class
        public class Pizza
        {
            //Declaring class sizes price
            public int FirstSizePrice  { get; set; }
            public int SecondSizePrice { get; set; }
            public int ThirdSizePrice { get; set; }
            public int FourthSizePrice { get; set; }
            //Declaring class toppings prices
            public int MashroomPrice { get; set; }
            public int ChickenPrice { get; set; }
            public int PeperoniPrice { get; set; }
            public int OlivesPrice { get; set; }
            public int PepperPrice { get; set; }
            public int OnionPrice { get; set; }
            public int HamPrice { get; set; }
            //Declaring total price
            public int Total { get; set; }

            public Pizza()
            {
                FirstSizePrice = 10;
                SecondSizePrice = 12;
                ThirdSizePrice = 14;
                FourthSizePrice = 18;

                MashroomPrice = 2;
                ChickenPrice = 5;
                PeperoniPrice = 4;
                OlivesPrice = 1;
                PepperPrice = 2;
                OnionPrice = 2;
                HamPrice = 4;
            }
        }

        //Declaring pizza
        protected Pizza pizza = new Pizza();

        //Total price
        protected int totalPrice = 0;

        //Mashroom
        protected string mashroombtn = "";
        protected string mashroomClass = "";

        protected bool collapse_mashroom = true;
        protected string addMenuCss_mashroom => collapse_mashroom ? "toggle" : null;

        public async void Mashroom()
        {
            collapse_mashroom = !collapse_mashroom;

            if (mashroombtn == "X")
            {
                pizza.Total -= pizza.MashroomPrice;
                mashroombtn = "";
            }
            else
            {
                pizza.Total += pizza.MashroomPrice;
                mashroombtn = "X";
            }
        }
        //////////////////////////////////////////////////////////////////

        //Chicken
        protected string chickenbtn = "";
        protected string chickenClass = "";

        protected bool collapse_chicken = true;
        protected string addMenuCss_chicken => collapse_chicken ? "toggle" : null;

        public async void Chicken()
        {
            collapse_chicken = !collapse_chicken;

            if (chickenbtn == "X")
            {
                pizza.Total -= pizza.ChickenPrice;
                chickenbtn = "";
            }
            else
            {
                pizza.Total += pizza.ChickenPrice;
                chickenbtn = "X";
            }
        }
        //////////////////////////////////////////////////////////////////


        //Peperoni
        protected string peperonibtn = "";
        protected string peperoniClass = "";

        protected bool collapse_peperoni = true;
        protected string addMenuCss_peperoni => collapse_peperoni ? "toggle" : null;

        public async void Peperoni()
        {
            collapse_peperoni = !collapse_peperoni;

            if (peperonibtn == "X")
            {
                pizza.Total -= pizza.PeperoniPrice;
                peperonibtn = "";
            }
            else
            {
                pizza.Total += pizza.PeperoniPrice;
                peperonibtn = "X";
            }
        }
        //////////////////////////////////////////////////////////////////

        //Olives
        protected string olivesbtn = "";
        protected string olivesClass = "";

        protected bool collapse_olives = true;
        protected string addMenuCss_olives => collapse_olives ? "toggle" : null;

        public async void Olives()
        {
            collapse_olives = !collapse_olives;

            if (olivesbtn == "X")
            {
                pizza.Total -= pizza.OlivesPrice;
                olivesbtn = "";
            }
            else
            {
                pizza.Total += pizza.OlivesPrice;
                olivesbtn = "X";
            }
        }
        //////////////////////////////////////////////////////////////////

        //Pepper
        protected string pepperbtn = "";
        protected string pepperClass = "";

        protected bool collapse_pepper = true;
        protected string addMenuCss_pepper => collapse_pepper ? "toggle" : null;

        public async void Pepper()
        {
            collapse_pepper = !collapse_pepper;

            if (pepperbtn == "X")
            {
                pizza.Total -= pizza.PepperPrice;
                pepperbtn = "";
            }
            else
            {
                pizza.Total += pizza.PepperPrice;
                pepperbtn = "X";
            }
        }
        //////////////////////////////////////////////////////////////////

        //Onion
        protected string onionbtn = "";
        protected string onionClass = "";

        protected bool collapse_onion = true;
        protected string addMenuCss_onion => collapse_onion ? "toggle" : null;

        public async void Onion()
        {
            collapse_onion = !collapse_onion;

            if (onionbtn == "X")
            {
                pizza.Total -= pizza.OnionPrice;
                onionbtn = "";
            }
            else
            {
                pizza.Total += pizza.OnionPrice;
                onionbtn = "X";
            }
        }
        //////////////////////////////////////////////////////////////////

        //Ham
        protected string hambtn = "";
        protected string hamClass = "";

        protected bool collapse_ham = true;
        protected string addMenuCss_ham => collapse_ham ? "toggle" : null;

        public async void Ham()
        {
            collapse_ham = !collapse_ham;

            if (hambtn == "X")
            {
                pizza.Total -= pizza.HamPrice;
                hambtn = "";
            }
            else
            {
                pizza.Total += pizza.HamPrice;
                hambtn = "X";
            }
        }
        //////////////////////////////////////////////////////////////////

        //Sizes

        //First Size
        protected string firstbtn = "";
        protected string firstClass = "";

        public async void First()
        {
            if (firstbtn == "X")
            {
                pizza.Total -= pizza.FirstSizePrice;
                firstbtn = "";
            }
            else
            {
                if(secondbtn == "X")
                {
                    pizza.Total -= pizza.SecondSizePrice;
                    secondbtn = "";
                    pizza.Total += pizza.FirstSizePrice;
                    firstbtn = "X";
                }
                else if (thirdbtn == "X")
                {
                    pizza.Total -= pizza.ThirdSizePrice;
                    thirdbtn = "";
                    pizza.Total += pizza.FirstSizePrice;
                    firstbtn = "X";
                }
                else if (fourthbtn == "X")
                {
                    pizza.Total -= pizza.FourthSizePrice;
                    fourthbtn = "";
                    pizza.Total += pizza.FirstSizePrice;
                    firstbtn = "X";
                }
                else
                {
                    pizza.Total += pizza.FirstSizePrice;
                    firstbtn = "X";
                }
            }
        }
        //////////////////////////////////////////////////////////////////
        //Second Size
        protected string secondbtn = "";
        protected string secondClass = "";

        public async void Second()
        {

            if (secondbtn == "X")
            {
                pizza.Total -= pizza.SecondSizePrice;
                secondbtn = "";
            }
            else
            {
                if (firstbtn == "X")
                {
                    pizza.Total -= pizza.FirstSizePrice;
                    firstbtn = "";
                    pizza.Total += pizza.SecondSizePrice;
                    secondbtn = "X";
                }
                else if (thirdbtn == "X")
                {
                    pizza.Total -= pizza.ThirdSizePrice;
                    thirdbtn = "";
                    pizza.Total += pizza.SecondSizePrice;
                    secondbtn = "X";
                }
                else if (fourthbtn == "X")
                {
                    pizza.Total -= pizza.FourthSizePrice;
                    fourthbtn = "";
                    pizza.Total += pizza.SecondSizePrice;
                    secondbtn = "X";
                }
                else
                {
                    pizza.Total += pizza.SecondSizePrice;
                    secondbtn = "X";
                }
            }
        }
        //////////////////////////////////////////////////////////////////
        //Third Size
        protected string thirdbtn = "";
        protected string thirdClass = "";


        public async void Third()
        {

            if (thirdbtn == "X")
            {
                pizza.Total -= pizza.ThirdSizePrice;
                thirdbtn = "";
            }
            else
            {
                if (firstbtn == "X")
                {
                    pizza.Total -= pizza.FirstSizePrice;
                    firstbtn = "";
                    pizza.Total += pizza.ThirdSizePrice;
                    thirdbtn = "X";
                }
                else if (secondbtn == "X")
                {
                    pizza.Total -= pizza.SecondSizePrice;
                    secondbtn = "";
                    pizza.Total += pizza.ThirdSizePrice;
                    thirdbtn = "X";
                }
                else if (fourthbtn == "X")
                {
                    pizza.Total -= pizza.FourthSizePrice;
                    fourthbtn = "";
                    pizza.Total += pizza.ThirdSizePrice;
                    thirdbtn = "X";
                }
                else
                {
                    pizza.Total += pizza.ThirdSizePrice;
                    thirdbtn = "X"; ;
                }
            }
        }
        //////////////////////////////////////////////////////////////////
        //Fourth Size
        protected string fourthbtn = "";
        protected string fourthClass = "";

        public async void Fourth()
        {

            if (fourthbtn == "X")
            {
                pizza.Total -= pizza.FourthSizePrice;
                fourthbtn = "";
            }
            else
            {
                if (firstbtn == "X")
                {
                    pizza.Total -= pizza.FirstSizePrice;
                    firstbtn = "";
                    pizza.Total += pizza.FourthSizePrice;
                    fourthbtn = "X";
                }
                else if (secondbtn == "X")
                {
                    pizza.Total -= pizza.SecondSizePrice;
                    secondbtn = "";
                    pizza.Total += pizza.FourthSizePrice;
                    fourthbtn = "X";
                }
                else if (thirdbtn == "X")
                {
                    pizza.Total -= pizza.ThirdSizePrice;
                    thirdbtn = "";
                    pizza.Total += pizza.FourthSizePrice;
                    fourthbtn = "X";
                }
                else
                {
                    pizza.Total += pizza.FourthSizePrice;
                    fourthbtn = "X";
                }
            }
        }
        //////////////////////////////////////////////////////////////////
    }
}
