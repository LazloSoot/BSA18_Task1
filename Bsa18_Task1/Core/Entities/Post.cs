using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Post
    {
        public List<Comment> Comments { get; set; }

        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public int UserId { get; set; }

        public int Likes { get; set; }
    }
}
