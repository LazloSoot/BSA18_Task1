using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Comment : IEquatable<Comment>
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Body { get; set; }

        public int UserId { get; set; }

        public int PostId { get; set; }

        public int Likes { get; set; }

        public bool Equals(Comment other)
        {
            if (other is null)
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return Id == other.Id && UserId == other.UserId
                && PostId == other.PostId && String.Equals(Body, other.Body) && DateTime.Equals(CreatedAt, other.CreatedAt);
        }

        public override string ToString()
        {
            return $"id:{Id}| postId:{PostId}| userId:{UserId}| likes:{Likes}|\n  {Body}\n\t createdAt{CreatedAt.ToString()}"; 
        }
    }
}
