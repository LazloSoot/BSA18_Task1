using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class User
    {
        public List<Post> Posts { get;  set; }
        public List<Todo> Todos { get; set; }

        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Name { get; set; }

        public string Avatar { get; set; }

        public string Email { get; set; }
    }
}
