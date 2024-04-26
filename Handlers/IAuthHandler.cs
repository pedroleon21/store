using Store.Commands;

namespace Store.Handlers
{
    public interface IAuthHandler
    {
        public int? handler(AuthAction action);
    }
}
