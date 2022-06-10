using Guia_Tramites_Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guia_Tramites_Api.Services
{
    public class FontAwesomeService : IFontAwesomeService
    {
        public List<FONT_AWESOME> read()
        {
            try
            {
                return Entities.FONT_AWESOME.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
