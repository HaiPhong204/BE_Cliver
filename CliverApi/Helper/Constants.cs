using static CliverApi.Common.Enum;

namespace CliverApi.Helper
{
    public static class Constants
    {
        public static List<PostStatus> HIDDEN_POST_STATUSES = new() { PostStatus.Draft, PostStatus.Paused, PostStatus.PendingApproval };
    }
}
