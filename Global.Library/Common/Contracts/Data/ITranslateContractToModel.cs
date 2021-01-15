using System.Collections.Generic;

namespace Global.Library.Common.Contracts.Data
{
    public interface ITranslateContractToModel<C, M>
    {
        public M Translate(C contract);
        public IEnumerable<M> Translate(IEnumerable<C> contracts);
    }
}