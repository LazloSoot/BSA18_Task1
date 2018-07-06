using Core.Entities;
namespace Core.Helpers
{
    public struct UserInfo
    {
        public User User { get; set; }

        public Post LastPost { get; set; }

        public int LastPostCommentsCount { get; set; }

        public int UnfinishedTasksCount { get; set; }

        public Post MostPopComment { get; set; }

        public Post BestPost { get; set; }

    }
}
