using System.Collections.Generic;
using System.Linq;
using MamaSuper.Common.ExtensionMethods;
using MamaSuper.Common.Models;
using MamaSuper.Logic.Interfaces;

namespace MamaSuper.Logic.Services
{
    /// <summary>
    /// <inheritdoc cref="ILineService{T}"/>
    /// </summary>
    public class CostumersLineService : ILineService<Costumer>
    {
        private readonly Line<Costumer> _costumersLine;

        public CostumersLineService(Line<Costumer> costumersLine)
        {
            _costumersLine = costumersLine;
        }

        public bool TryAddItemToLine(Costumer costumer, out string failingMessage)
        {
            if (!costumer.IsPermittedToEnter(out failingMessage))
            {
                return false;
            }

            _costumersLine.AddItemToLine(costumer);
            return true;
        }

        public IList<Costumer> GetLineItems()
        {
            return _costumersLine.GetLineItems().ToList();
        }

        public IEnumerable<Costumer> MoveItemsFromLine(int count)
        {
            for (int i = 0; i < _costumersLine.CountLine(); i++)
            {
                Costumer costumer = _costumersLine.RemoveItemFromLine();
                yield return costumer;
            }
        }
    }
}
