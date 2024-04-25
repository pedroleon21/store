using Store.Commands;

namespace Store.Handlers
{
    public interface IAuthHancler
    {
        public void handler(AuthAction action);
    }
}
