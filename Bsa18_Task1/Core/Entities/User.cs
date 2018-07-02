using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User
    {
      //  private List<Post> posts;
      //  private List<Todo> todos;

        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Name { get; set; }

        public string Avatar { get; set; }

        public string Email { get; set; }
    }
}
