using Store.Models;

namespace Store.Handlers
{
    public interface ICatalogEventHandler
    {
        public void Handler(Produto produto,IEnumerable<string> emails);
    }
}
