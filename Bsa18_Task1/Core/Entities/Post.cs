using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Post
    {
      //  private List<Comment> comments;

        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public int UserId { get; set; }

        public int Likes { get; set; }
    }
}
