namespace Application.Common.Adapters
{
    public interface ICurrentUserService
    {
        public string UserId { get; }

        public bool IsAuthenticated { get; }
    }
}
