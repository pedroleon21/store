using Store.Commands;
using Store.Data;

namespace Store.Handlers
{
    public class AuthHancler : IAuthHancler
    {
        private DataContext dataContext;
        public AuthHancler(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public void handler(AuthAction action)
        {
            // essa função não vale de nada
            var result = dataContext.Users.Any(u => u.Username == action.Username && u.Password == action.Password);
            if (!result)
            {
                throw new UnauthorizedAccessException("Usuário não encontrado ou senha errada.");
            }
        }
    }
}
