using Store.Commands;
using Store.Data;

namespace Store.Handlers
{
    public class GetUserHandler : IGetUserHandler
    {
        private DataContext dataContext;
        public GetUserHandler(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public UserResponse Handler(int userID)
        {
            var result = dataContext.Users.Where(u=>u.Id==userID).FirstOrDefault();
            return new UserResponse(result!);
        }
    }
}
