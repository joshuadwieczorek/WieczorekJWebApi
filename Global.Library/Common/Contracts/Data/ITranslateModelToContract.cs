using System.Collections.Generic;

namespace Global.Library.Common.Contracts.Data
{
    public interface ITranslateModelToContract<M, C>
    {
        public C Translate(M model);
        public IEnumerable<C> Translate(IEnumerable<M> models);
    }
}