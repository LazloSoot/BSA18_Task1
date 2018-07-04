using Core.Entities;
namespace Core.Helpers
{
    public struct PostInfo
    {
        public Post Post { get; set; }

        public Comment LongestComment { get; set; }

        public Comment BestComment { get; set; }

        public int CommentsCount { get; set; }
    }
}
