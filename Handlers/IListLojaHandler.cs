using Store.Commands;

namespace Store.Handlers
{
    public interface IListLojaHandler
    {
        public PageResult<LojaResponse> Handler(int? userId, int? PageIndex, int? PageSize);
    }
}
