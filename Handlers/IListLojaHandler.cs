using Store.Commands;

namespace Store.Handlers
{
    public interface IListLojaHandler
    {
        public List<LojaResponse> Handler(int? userId);
    }
}
