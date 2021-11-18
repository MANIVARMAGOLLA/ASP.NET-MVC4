using ProductDataAccessLayer;
using ProductDataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBusinessLayer
{
    public class ProdBL
    {
        ProdDAL DALObj;

        public ProdBL()
        {
            DALObj = new ProdDAL();
        }
        public List<ProdDTO> GetAllProduct()
        {

            try
            {
                List<ProdDTO> finLst = DALObj.FetchAllProduct();
                return finLst;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

    }
}
