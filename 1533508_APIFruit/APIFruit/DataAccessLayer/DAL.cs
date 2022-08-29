using APIFruit.DataAccessLayer.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIFruit.DataAccessLayer
{
    public class DAL
    {
        private FruitFactory _fruitFactory = null;
        private PaysFactory _paysFactory = null;

        public static string ConnectionString { get { return "Server=sql.decinfo-cchic.ca;Port=33306;Database=a22_sda_1533508;Uid=dev-1533508;Pwd=Info2020"; } }


        public FruitFactory FruitFactory
        {
            get
            {
                if (_fruitFactory == null)
                {
                    _fruitFactory = new FruitFactory();
                }

                return _fruitFactory;
            }
        }

        public PaysFactory PaysFactory
        {
            get
            {
                if(_paysFactory == null)
                {
                    _paysFactory = new PaysFactory();
                }

                return _paysFactory;
            }
        }

        public DAL()
        {
        }
    }
}
