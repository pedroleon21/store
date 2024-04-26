using Store.Commands;
using Store.Data;

namespace Store.Handlers
{
    public class AuthHandler : IAuthHandler
    {
        private DataContext dataContext;
        public AuthHandler(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public int? handler(AuthAction action)
        {
            // essa função não vale de nada
            var result = dataContext.Users.Where(u => u.Username == action.Username && u.Password == action.Password).FirstOrDefault();
            if (result == null)
            {
                throw new UnauthorizedAccessException("Usuário não encontrado ou senha errada.");
            }
            return result.Id;
        }
    }
}
