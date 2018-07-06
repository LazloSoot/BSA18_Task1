using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class User : IEquatable<User>
    {
        public List<Post> Posts { get;  set; }
        public List<Todo> Todos { get; set; }

        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Name { get; set; }

        public string Avatar { get; set; }

        public string Email { get; set; }

        public bool Equals(User other)
        {
            if (other == null)
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return Id == other.Id && String.Equals(Name, other.Name) && String.Equals(Email, other.Email);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            User other = obj as User;
            if (other == null)
                return false;

            return Id == other.Id && String.Equals(Name, other.Name) && String.Equals(Email, other.Email);
        }

        public override int GetHashCode()
        {
            return this.Id * 21 * Name.GetHashCode();
        }

        public override string ToString()
        {
            return new string('-', 100) +
                $"\nid:{Id}| Name:{Name}| Email:{Email}| createdAt{CreatedAt.ToString()}\n" +
                new string('-', 100);
        }
    }
}
