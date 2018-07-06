using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Post : IEquatable<Post>
    {
        public List<Comment> Comments { get; set; }

        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public int UserId { get; set; }

        public int Likes { get; set; }

        public override bool Equals(object obj)
        {
            Post other = obj as Post;
            if (other == null)
                return false;
            return this.Id == other.Id && this.UserId == other.UserId;
        }

        public bool Equals(Post other)
        {
            if (other == null)
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return this.Id == other.Id && this.UserId == other.UserId;
        }

        public override int GetHashCode()
        {
            return this.Id * 18 * this.UserId.GetHashCode();
        }

        public override string ToString()
        {
            return  "\t"+ new string('-', 92) +
                $"\n\tid:{Id}| userId:{UserId}| likes:{Likes}|\n\n\t   {Title}\n\t{Body}\n\t  {CreatedAt.ToString()}\n"
                + "\t" + new string('-', 92);
        }
    }
}
