using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioBlazor.Pages.Bases
{
    public class ToDoListBase : ComponentBase
    {
        //Declaring to-do item class
        public class ToDoItem
        {
            public static int Id = 0;
            public int ItemId { get; set; }
            public string Title { get; set; }
            public string MainGoal { get; set; }
            public string Posted { get; set; }
            public string Deadline { get; set; }
            public List<ToDoDetails> ToDoDetails = new List<ToDoDetails>();

            public ToDoItem()
            {
                this.Deadline = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
                ItemId = Id;
                Id++;
            }

            public ToDoItem(string title, string mainGoal, DateTime posted, DateTime deadline)
            {
                this.Title = title;
                this.MainGoal = mainGoal;
                this.Posted = posted.ToString("MM/dd/yyyy h:mm tt");
                this.Deadline = deadline.ToString("MM/dd/yyyy h:mm tt"); 
            }

            //Add detail to the to-do
            public void AddDetails(string detailText, DateTime start, DateTime end)
            {
                ToDoDetails toDoDetail = new ToDoDetails();

                toDoDetail.DetailsText = detailText;
                toDoDetail.Start = start.ToString("MM/dd/yyyy h:mm tt");
                toDoDetail.End = end.ToString("MM/dd/yyyy h:mm tt");
                toDoDetail.Id = ToDoDetails.Count;
                ToDoDetails.Add(toDoDetail);


            }

            //Delete detail from to-do
            public void DeleteDetail(int id)
            {
                if(ToDoDetails.Count != 0 || ToDoDetails != null)
                {
                    ToDoDetails.RemoveAt(id);

                    if(ToDoDetails.Count != 0)
                    {
                        for(int i = 0; i < ToDoDetails.Count; i++)
                        {
                            ToDoDetails[i].Id = i;
                        }
                    }
                }
            }
        }

        //Declaring to-do details item class
        public class ToDoDetails
        {
            public int Id { get; set; }
            public string DetailsText { get; set; }
            public string Start { get; set; }
            public string End { get; set; }

            public ToDoDetails()
            {
            }
            public ToDoDetails(string detailsText, DateTime start, DateTime end)
            {
                this.DetailsText = detailsText;
                this.Start = start.ToString("MM/dd/yyyy h:mm tt");
                this.End = end.ToString("MM/dd/yyyy h:mm tt");
            }
        }

        //Declationg list for to do items
        protected List<ToDoItem> toDoItems = new List<ToDoItem>();

        //Declaring variables for main to-do item CREATION
        protected string toDoTitle;
        protected string toDoMainGoal;
        protected DateTime toDoDeadline = DateTime.Now;
        //Declaring variables for EDITING to-do item
        protected string toDoTitleEdit;
        protected string toDoMainGoalEdit;
        protected DateTime toDoDeadlineEdit;
        //Declaring variables for to-do item details CREATION
        protected string detailsText;
        protected DateTime detailsStart = DateTime.Now;
        protected DateTime detailsEnd = DateTime.Now;
        //Declaring variables for EDITING to-do item details
        protected string detailsTextEdit;
        protected DateTime detailsStartEdit = DateTime.Now;
        protected DateTime detailsEndEdit = DateTime.Now;

        //Creating to-do item function
        public async void createToDoItem()
        {
            ToDoItem toDoItem = new ToDoItem();

            toDoItem.ItemId = toDoItems.Count;
            toDoItem.Title = toDoTitle;
            toDoItem.MainGoal = toDoMainGoal;
            toDoItem.Posted = DateTime.Now.ToString("MM/dd/yyyy h:mm tt"); 
            toDoItem.Deadline = toDoDeadline.ToString("MM/dd/yyyy h:mm tt"); 

            toDoItems.Add(toDoItem);

            toDoTitle = "";
            toDoMainGoal = "";
            toDoDeadline = DateTime.Now;
        }

        //Delete to-do item function
        public async void deleteToDoItem(int index)
        {
            toDoItems.RemoveAt(index);
            ToDoItem.Id--;

            if(toDoItems.Count != 0)
            {
                for (int i = 0; i < toDoItems.Count; i++)
                {
                    toDoItems[i].ItemId = i;
                }
            }
        }

        //Edit to-do
        public async void editToDoItem(int id)
        {

        }

        //Toggle for to-do input 
        protected bool collapseAdd = true;
        protected string text_toggle = "Add To-Do";
        protected string addMenuCss => collapseAdd ? "display" : null;
        public void toggleAdd()
        {
            collapseAdd = !collapseAdd;

            if(text_toggle == "Add To-Do")
            {
                text_toggle = "Hide";
            }
            else
            {
                text_toggle = "Add To-Do";
            }
        }

        //Toggle for to-do details input
        protected bool collapseAdd_details = true;
        protected string text_toggle_details = "Add To-Do Details";
        protected string addMenuCss_details => collapseAdd_details ? "display" : null;
        public void toggleAdd_details()
        {
            collapseAdd_details = !collapseAdd_details;

            if (text_toggle_details == "Add To-Do Details")
            {
                text_toggle_details = "Hide";
            }
            else
            {
                text_toggle_details = "Add To-Do Details";
            }
        }
    }
}
