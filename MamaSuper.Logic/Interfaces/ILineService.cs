using System.Collections.Generic;

namespace MamaSuper.Logic.Interfaces
{
    public interface ILineService<T>
    {
        bool TryAddItemToLine(T item, out string failingMessage);
        IList<T> GetLineItems();
        IEnumerable<T> MoveItemsFromLine(int count);
    }
}
