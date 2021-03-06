using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using Services;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Collections;

namespace Joole_MVC_Team1.Models
{
    public class ProductViewModel
    {

        public ProductViewModel(int id)
        {
            Service s = new Service();
            tblProduct product = s.getProductService(id);
            /*
            pvList = s.GetTblPropertyValueByProductID(id);

            
            techSpecList = init_TechSpecList();

    */
            
            productID = Int32.Parse(product.Product_ID.ToString());
            techSpecList = init_TechSpecList();
            Manufacture = s.GetManufNameByID(Int32.Parse( product.Manufacturer_ID.ToString()));
            Series = product.Series.ToString();
            Model = product.Model.ToString();
            UseType = "Commercial";
            Application = "Indoor";
            MountingLoaction = "";
            Accessories = "With Lignt";
            ModelYear = product.Model_Year.Year.ToString();
            Img = product.Product_Image.ToString();
        }

        [Key]
        public string Img { get; set; }

        public int productID { get; set; }

        public string Manufacture { get; set; }
        public string Series { get; set; }
        public string Model { get; set; }

        public string UseType { get; set; }

        public string Application { get; set; }
        public string MountingLoaction { get; set; }
        public string Accessories { get; set; }

        public string ModelYear { get; set; }

        public List<tblPropertyValue> pvList { get; set; }

        public List<TechSpecViewModel> techSpecList { get; set; }

        private List<TechSpecViewModel> init_TechSpecList()
        {
            List < TechSpecViewModel > res = new List<TechSpecViewModel>();
            GetProductsService test = new GetProductsService();

            List<DataRow> test1 = test.ProductIDToAllPropertyID(this.productID);
            List<DataRow> test2 = test.SubCategoryIDToAllPropertyID(this.productID);
            foreach (DataRow dr in test1)
            {
                TechSpecViewModel Tsvm = new TechSpecViewModel();
                Tsvm.propID = Convert.ToInt32(dr["Property_ID"]);
                Tsvm.propertyName = Convert.ToString(dr["Property_Name"]);
                Tsvm.isTypeSpec = false;
                Tsvm.singleValue = Convert.ToString(dr["Value"]);
                Tsvm.min = 0;
                Tsvm.max = 0;
                res.Add(Tsvm);
            }

            foreach (DataRow dr in test2)
            {
                TechSpecViewModel Tsvm = new TechSpecViewModel();
                Tsvm.propID = Convert.ToInt32(dr["Property_ID"]);
                Tsvm.propertyName = Convert.ToString(dr["Property_Name"]);
                Tsvm.isTypeSpec = true;
                Tsvm.singleValue = "";
                Tsvm.min = Convert.ToDouble(dr["Min_Value"]);
                Tsvm.max = Convert.ToDouble(dr["Max_Value"]);
                res.Add(Tsvm);
            }
            return res;
        }

    }
}