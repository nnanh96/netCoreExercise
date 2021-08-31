using System;
using System.Collections.Generic;
using System.Text;
using Ninject;
using Ninject.Modules;
namespace BookStore
{
    public class Bindings : NinjectModule
    {
        private readonly bool _useJson;

        public Bindings(bool useJson)
        {
            _useJson = useJson;
        }
        public override void Load()
        {
            if (_useJson)
            {
                Bind<IDataAccess>().To<DataAccessJson>();
            }
            else
            {
                Bind<IDataAccess>().To<DataAccessTxt>();
            }
        }
    }
}
