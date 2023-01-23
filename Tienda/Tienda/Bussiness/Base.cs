using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Data;

namespace Tienda.Bussiness
{
    public class Base
    {
        protected ExamenContext examenContext;

        public Base(ExamenContext context)
        {
            examenContext = context;
        }
    }
}
