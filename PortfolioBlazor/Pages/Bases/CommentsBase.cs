using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PortfolioBlazor.Pages.Bases
{
    public class CommentsBase : ComponentBase
    {
        //Declaring comment object
        /// <summary>
        /// This class will be used to create comment object
        /// </summary>
        public class Comment
        {
            public int Id { get; set; }
            public int Like { get; set; }
            public int Dislike { get; set; }
            public string Name { get; set; }
            public string Message { get; set; }
            public string ImgPath { get; set; }
            public string Posted { get; set; }

            /// <summary>
            /// This class will controll if edit box need to be displayed
            /// </summary>
            public string DisplayEdit { get; set; }

            /// <summary>
            /// When comment is edited it will hide the oryginal one
            /// </summary>
            public string DisplayComment { get; set; }

            /// <summary>
            /// This parameter will bind Ip Address to the coment so only creator of it can edit or delete it
            /// When Implemented it needs to be changed to users Id comming from database
            /// </summary>
            public string CreatorsIP { get; set; }

            public bool BeenEdited { get; set; }

            public List<string> IpLikes { get; set; }
            public List<string> IpDisLikes { get; set; }


            public Comment()
            {
                Like = 0;
                Dislike = 0;
                IpLikes = new List<string>();
                IpDisLikes = new List<string>();
                Posted = DateTime.Now.ToString();
                DisplayComment = "display_block";
                DisplayEdit = "display_none";
            }
        }

        public class ImagePath
        {
            public int Id { get; set; }
            public string ImgPath { get; set; }

            public ImagePath()
            {
            }
        }

        //Declaring variables

        /// <summary>
        /// Dummy list for storing comments data (It is needed to be changed with database when implementing)
        /// </summary>
        protected List<Comment> comments = new List<Comment>();

        /// <summary>
        /// Mock data for image paths. When implementing change with database.
        /// </summary>
        protected List<ImagePath> imagePaths = new List<ImagePath>() { };

        /// <summary>
        /// String for user name (It needs to be changed with user data if it is not a guest)
        /// </summary>
        protected string name = "";
        protected string edit_name = "";

        /// <summary>
        /// This variable is for user comment
        /// </summary>
        protected string message = "";
        protected string edit_message = "";

        /// <summary>
        /// This will display error message if input is incorect
        /// </summary>
        protected string error_message = "";

        /// <summary>
        /// This will link to image path when choosing
        /// </summary>
        protected string img_path = "../CommentsImages/1.png";
        protected string edit_img_path = "";

        /// <summary>
        /// This parameter will store Ip Address of current client
        /// </summary>
        protected string Client_IP = "";

        //Declaring functionality

        /// <summary>
        /// This function will get ip addres when initalized and it will populate mock avatar data
        /// </summary>
        protected override async Task OnInitializedAsync()
        {
            //Get Ip address
            Client_IP = GetIPAddress();

            //Populate mock avatar data
            ImagePath p1 = new ImagePath();
            p1.Id = 0;
            p1.ImgPath = "../CommentsImages/1.png";
            ImagePath p2 = new ImagePath();
            p2.Id = 1;
            p2.ImgPath = "../CommentsImages/2.png";
            ImagePath p3 = new ImagePath();
            p3.Id = 2;
            p3.ImgPath = "../CommentsImages/3.png";

            imagePaths.Add(p1);
            imagePaths.Add(p2);
            imagePaths.Add(p3);

            //Create Mock Comments
            Comment c1 = new Comment();
            c1.CreatorsIP = "11111";
            c1.Dislike = 2;
            c1.Id = 0;
            c1.ImgPath = "../CommentsImages/3.png";
            c1.Like = 15;
            c1.Message = "Wow this place is amazing. I would like to stay longer! <3";
            c1.Name = "Kiara";
            c1.Posted = "2020.03.02 22:30";

            Comment c2 = new Comment();
            c2.CreatorsIP = "11143243211";
            c2.Dislike = 0;
            c2.Id = 1;
            c2.ImgPath = "../CommentsImages/1.png";
            c2.Like = 4;
            c2.Message = "Hi guys, lets know each other.";
            c2.Name = "Daniel";
            c2.Posted = "2020.03.01 11:30";

            comments.Add(c1);
            comments.Add(c2);
        }

        /// <summary>
        /// This function will find IP Address of user
        /// </summary>
        /// <returns>IP Address of Client</returns>
        public string GetIPAddress()
        {
            IPHostEntry Host = default(IPHostEntry);
            string Hostname = null;
            string IPAddress = "";
            Hostname = System.Environment.MachineName;
            Host = Dns.GetHostEntry(Hostname);
            foreach (IPAddress IP in Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    IPAddress = Convert.ToString(IP);
                }
            }
            return IPAddress;
        }

        /// <summary>
        /// This function will change avatar for comment. When implementing change it with user avatar
        /// </summary>
        protected void ChangeAvatar(int id)
        {
            img_path = imagePaths[id].ImgPath;
        }

        /// <summary>
        /// Edit Photopath
        /// </summary>
        protected void ChangeAvatarEdit(int id)
        {
            edit_img_path = imagePaths[id].ImgPath;
        }

        ///<summary>
        ///This function will create comment and add it to memory storage
        /// </summary>
        protected void CreateComment()
        {
            bool no_error = true;

            if(name == "" && message == "")
            {
                error_message = "Please enter your name and write your comment!";
                no_error = false;
            }
            else if(name == "")
            {
                error_message = "Please enter your name!";
                no_error = false;
            }
            else if(message == "")
            {
                error_message = "Please write your comment!";
                no_error = false;
            }

            if (no_error == true)
            {
                //o = object
                Comment o = new Comment();
                if (comments.Count == 0)
                {
                    o.Id = 0;
                    o.Name = name;
                    o.Message = message;
                    o.ImgPath = img_path;
                    o.CreatorsIP = GetIPAddress();
                }
                else
                {
                    o.Id = comments.Count;
                    o.Name = name;
                    o.Message = message;
                    o.ImgPath = img_path;
                    o.CreatorsIP = GetIPAddress();
                }

                comments.Add(o);
                name = "";
                message = "";
            }

        }
        /// <summary>
        /// This function will delete comment from memory storage by its Id
        /// </summary>
        protected void DeleteComment(int id)
        {
            if(comments.Count != 0)
            {
                comments.RemoveAt(id);
                for(int i = 0; i < comments.Count; i++)
                {
                    comments[i].Id = i;
                }
            }
        }
        /// <summary>
        /// This function will add (+1) property and it will store it to database
        /// </summary>
        protected void LikeComment(int id)
        {
            if(comments.Count != 0)
            {
                //This will check if user alredy liked
                //I'm using here Ip address method but it can be exchangeble with user ID
                string UserIpAddress = GetIPAddress();
                bool been_liked = false;
                List<string> c = new List<string>();

                if (comments[id].IpLikes.Count != 0)
                {
                    c = comments[id].IpLikes;
                    for (int i = 0; i < c.Count; i++)
                    {
                        if (c[i] == UserIpAddress)
                        {
                            been_liked = true;
                        }
                    }
                }
                //If user with this ip address has not been liked then like is added
                if(been_liked != true)
                {
                    comments[id].Like = comments[id].Like + 1;
                    c.Add(UserIpAddress);
                    comments[id].IpLikes = c;

                    //If user alredy disliked change if for like
                    if(comments[id].IpDisLikes.Count != 0)
                    {
                        c = comments[id].IpDisLikes;

                        for (int i = 0; i < c.Count; i++)
                        {
                            if (c[i] == UserIpAddress)
                            {
                                c.RemoveAt(i);
                                comments[id].Dislike = comments[id].Dislike - 1;
                                comments[id].IpDisLikes = c;
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// This function will add (+1) property and it will store it to database
        /// </summary>
        protected void DislikeComment(int id)
        {
            if (comments.Count != 0)
            {
                //This will check if user alredy liked
                //I'm using here Ip address method but it can be exchangeble with user ID
                string UserIpAddress = GetIPAddress();
                bool been_disliked = false;
                List<string> c = new List<string>();

                if(comments[id].IpDisLikes.Count != 0)
                {
                    c = comments[id].IpDisLikes;
                    for (int i = 0; i < c.Count; i++)
                    {
                        if (c[i] == UserIpAddress)
                        {
                            been_disliked = true;
                        }
                    }
                }
                //If user with this ip address has not been liked then like is added
                if (been_disliked != true)
                {
                    comments[id].Dislike += 1;
                    c.Add(UserIpAddress);
                    comments[id].IpDisLikes = c;

                    //If user alredy liked change if for dislike
                    c = comments[id].IpLikes;

                    if(comments[id].IpLikes.Count != 0)
                    {
                        for (int i = 0; i < c.Count; i++)
                        {
                            if (c[i] == UserIpAddress)
                            {
                                c.RemoveAt(i);
                                comments[id].Like -= 1;
                                comments[id].IpLikes = c;
                            }
                        }
                    }
                }
            }
        }
        protected void ToggleEditWindow(int id)
        {
            if(Client_IP == comments[id].CreatorsIP)
            {
                if(comments[id].DisplayEdit == "display_none")
                {
                    comments[id].DisplayEdit = "display_block";
                    comments[id].DisplayComment = "display_none";
                }
                else
                {
                    comments[id].DisplayEdit = "display_none";
                    comments[id].DisplayComment = "display_block";
                }
            }
        }
        /// <summary>
        /// This function will edit comment taken from memory
        /// </summary>
        protected void EditComment(int id)
        {
            comments[id].BeenEdited = true;
            comments[id].Message = edit_message;
            comments[id].Name = edit_name;
            comments[id].Posted = DateTime.Now.ToString();
            comments[id].DisplayEdit = "display_none";
            comments[id].DisplayComment = "display_block";

            if(edit_img_path != "" && edit_img_path != null)
            {
                comments[id].ImgPath = edit_img_path;
            }
            else
            {
                comments[id].ImgPath = comments[id].ImgPath;
            }

        }
    }
}