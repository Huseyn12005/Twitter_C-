namespace Twittter_C_
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User(string username,string email,string password )
        {
            Id = Guid.NewGuid();
            Username = username;
            Email = email;
            Password = password;
        }
    }

    public class Admin : User
    {
        public List<Post> Posts { get; set; } = new List<Post>();
        public List<Notification> Notifications { get; set; } = new List<Notification>();

        public Admin(string username, string email, string password) : base(username, email, password)
        {
            Posts = new List<Post>();
            Notifications = new List<Notification>();
        }
    }

    public class Post
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string Text { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int LikeCount { get; set; }
        public int ViewCount { get; set; }

        public Post(string content, string text)
        {
            Id = Guid.NewGuid();
            CreationDateTime = DateTime.Now;
            Content = content;
            LikeCount = 0;
            ViewCount = 0;
            Text = text;

        }
    }


    public class Notification
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime date_time { get; set; }
        public User FromUser { get; set; }

        public Notification(string text,User from)
        {
            Text = text;
            date_time = DateTime.Now;
            FromUser = from;
        }
    }

}
