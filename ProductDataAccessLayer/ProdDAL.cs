using ProductDataTransfer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProductDataAccessLayer
{
    public class ProdDAL
    {
        SqlConnection sqlConObj;
        SqlCommand sqlCmdObj;

        public ProdDAL()
        {
            sqlConObj = new SqlConnection();
            sqlCmdObj = new SqlCommand();

        }

        public List<ProdDTO> FetchAllProduct()
        {
            try
            {
                sqlConObj.ConnectionString = ConfigurationManager.ConnectionStrings["AdworkConnStr"].ConnectionString;
                sqlCmdObj.CommandText = @"SELECT TOP 1000 [ProductID]
                                    ,[Name]
                                    ,[ProductNumber]
                                    ,[Color]
                                    ,[ListPrice]
                                    ,[DaysToManufacture]
                                    ,[ModifiedDate]
                                FROM [AdventureWorks2012].[Production].[Product] where ListPrice>0";
                sqlCmdObj.Connection = sqlConObj;

                SqlDataAdapter SqldaObj = new SqlDataAdapter();
                SqldaObj.SelectCommand = sqlCmdObj;

                DataTable ProductDTObj = new DataTable();

                SqldaObj.Fill(ProductDTObj);

                List<ProdDTO> lstProduct = new List<ProdDTO>();

                foreach (DataRow product in ProductDTObj.Rows)
                {

                    ProdDTO productDTOObj = new ProdDTO();

                    productDTOObj.ProductID = Convert.ToInt32(product["ProductID"]);
                    productDTOObj.ProductName = product["Name"].ToString();
                    productDTOObj.ProductNumber = product["ProductNumber"].ToString();
                    productDTOObj.ProductColor = product["Color"].ToString();
                    productDTOObj.ProductListPrice = Convert.ToDecimal(product["ListPrice"]);
                    productDTOObj.ProductDaysToManufacture = Convert.ToInt32(product["DaysToManufacture"]);
                    lstProduct.Add(productDTOObj);

                }
                return lstProduct;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
