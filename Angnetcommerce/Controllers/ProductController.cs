using Angnetcommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Angnetcommerce.Controllers
{
    public class ProductController : ApiController
    {
        Product[] products = new Product[]
       {
            new Product { Stock_No = 1, Model = "Honda City",Currency ="USD", Price = 250000, Year=2014, Month="Jan", CC= 1500, Color="White", Maker="Honda", Fuel="Petrol", KM_ran=27000, Gear_m_at="A/T", Grade="SE Saloon", ProductType="Sedan" },
            new Product {Stock_No =2 , Model = "Renault Scala", Currency ="USD",Price = 250000 , Year=2013, Month="Dec"},
            new Product {Stock_No = 3, Model = "Mercedes Benz", Currency ="USD",Price = 250000 , Year=2015, Month="Feb"}
       };

        [HttpGet]
        public Product[] GetProducts()
        {
            return products;
        }
        // Product Filters

        //Get products Apply Filters

        [HttpPost]
        public async Task<string> UploadFiles()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                return "";
            }
            #region Commented
            //var files = System.Web.HttpContext.Current.Request.Files;
            //var f = files[0];
            //System.IO.StreamReader reader = new System.IO.StreamReader(f.InputStream);
            //string line;
            //while ((line = reader.ReadLine()) != null)
            //{
            //    Console.WriteLine(line); // Write to console.
            //}
            #endregion
            string root = System.Web.HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);
            var result = await Request.Content.ReadAsMultipartAsync(provider);
            
            
            // This illustrates how to get the file names.
            foreach (MultipartFileData file in provider.FileData)
            {
                var producsTobeImported = ImportProducts(file.LocalFileName);
                SaveProducs(producsTobeImported);
            }
            return "";
        }
        private static void AddFeature(AaauctionEntities db, string featureName,int stock_no)
        {
            var feaureId = db.vehicle_features.Where(x => x.feature_name == featureName).Select(y => y.featureid).FirstOrDefault();
            if (feaureId == 0)
            {
                var feature = db.vehicle_features.Add(new vehicle_features() { feature_name = featureName });
                db.SaveChanges();
                feaureId = feature.featureid;
            }
            var vehicleFeature = db.features_on_vehicles_for_sale.Where(x => x.featureid == feaureId && x.stock_no == stock_no).Select(y => y).FirstOrDefault();
            if (vehicleFeature == null)
            {
                db.features_on_vehicles_for_sale.Add(new features_on_vehicles_for_sale() { featureid = feaureId, stock_no = stock_no });
                db.SaveChanges();
            }

        }
        private static void SaveProducs(List<Product> productsTobeImported)
        {
            try
            {
                AaauctionEntities db = new AaauctionEntities();
                foreach (var product in productsTobeImported)
                {
                    var stock_no = db.vehicle_for_sale.Where(x => x.stock_no == product.Stock_No).Select(y => y.stock_no).FirstOrDefault();
                    if(stock_no > 0)
                    {
                        continue;
                    }
                    var makerId = db.makes.Where(x => x.make_name == product.Maker).Select(y => y.makeid).FirstOrDefault();
                    //break;
                    if (makerId == 0)
                    {
                        var make = db.makes.Add(new make() { make_name = product.Maker });
                        db.SaveChanges();
                        makerId = make.makeid;
                    }
                    var modelId = db.models.Where(x => x.make_id == makerId && x.model_name == product.Model).Select(y => y.id).FirstOrDefault();
                    if(modelId == 0 )
                    {
                        var model = db.models.Add(new model() { model_name = product.Model, make_id = makerId });
                        db.SaveChanges();
                        modelId = model.id;
                    }
                    var categoryId = db.vehicle_category.Where(x => x.category == product.ProductType).Select(y => y.categoryid).FirstOrDefault();
                    if(categoryId == 0)
                    {
                        var category = db.vehicle_category.Add(new vehicle_category() { category = product.ProductType });
                        db.SaveChanges();
                        categoryId = category.categoryid;
                    }
                    
                    if(stock_no == 0)
                    {
                        var addProduct = new vehicle_for_sale();
                        addProduct.model_id = modelId;
                        addProduct.vehicle_category_id = categoryId;
                        addProduct.CC = product.CC;
                        addProduct.chassis_no_1 = product.chassis_no_1;
                        addProduct.chassis_no_2 = product.chassis_no_2;
                        addProduct.color = product.Color;
                        addProduct.ETD = product.ETD;
                        addProduct.gear_at = product.Gear_m_at == "A/T" ? true : false;
                        addProduct.grade = product.Grade;
                        addProduct.KM_ran = product.KM_ran;
                        addProduct.last_modified_date = DateTime.Now;
                        addProduct.month = product.Month;
                        addProduct.year = product.Year;
                        addProduct.no_of_doors = product.NoOfDoors;
                        addProduct.price = product.Price;
                        addProduct.fuel = product.Fuel;
                        addProduct.stock_no = product.Stock_No;
                        var vehicleForSale = db.vehicle_for_sale.Add(addProduct);
                        db.SaveChanges();
                        stock_no = vehicleForSale.stock_no;
                    }
                    if(product.Equipments.AC == true)
                    {
                        AddFeature(db, "AC",stock_no);
                    }
                    if(product.Equipments.FourWheelDrive == true)
                    {
                        AddFeature(db, "FourWheelDrive",stock_no);
                    }
                    if (product.Equipments.PS == true)
                    {
                        AddFeature(db, "PS", stock_no);
                    }
                    if (product.Equipments.PW == true)
                    {
                        AddFeature(db, "PW", stock_no);
                    }
                    if (product.Equipments.WCAB == true)
                    {
                        AddFeature(db, "WCAB", stock_no);
                    }
                    foreach(var image in product.Images)
                    {
                        var imageId = db.images_on_vehicles_for_sale.Where(x => x.stock_no == stock_no && x.imageurl == image).Select(y => y.imageid).FirstOrDefault();
                        if (imageId == 0)
                        {
                            db.images_on_vehicles_for_sale.Add(new images_on_vehicles_for_sale() { imageurl = image, stock_no = stock_no });
                            db.SaveChanges();
                        }
                    }
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private List<Product> ImportProducts(string localFileName)
        {
            var result = new List<Product>();
            try
            {

                var lines = System.IO.File.ReadAllLines(localFileName);
                System.Text.RegularExpressions.Regex csvParser = new System.Text.RegularExpressions.Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                string[] headerColumns = csvParser.Split(lines.FirstOrDefault());
                Dictionary<string, int> columnIndices = GetColumnIndices(headerColumns);
                var imageIndices = columnIndices.Where(x => x.Key.Contains("Image")).Select(x => x.Value);
                foreach (var line in lines.Skip(1))
                {
                    String[] values = csvParser.Split(line);
                    // clean up the fields (remove " and leading spaces)
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = values[i].TrimStart(' ', '"');
                        values[i] = values[i].TrimEnd('"');
                    }
                    var product = new Product();
                    product.Stock_No = Convert.ToInt32(values[columnIndices["STOCK No"]]);
                    product.chassis_no_1 = values[columnIndices["CHASSIS No 1"]];
                    product.chassis_no_2 = values[columnIndices["CHASSIS No 2"]];
                    product.Maker = values[columnIndices["MARCA"]];
                    product.ProductType = values[columnIndices["TYPE"]];
                    product.Model = values[columnIndices["NAME OF CAR"]];
                    product.Grade = values[columnIndices["GRADE"]];
                    product.Year = values[columnIndices["YEAR"]] == ""? (int?)null : Convert.ToInt32(values[columnIndices["YEAR"]]);
                    product.Month = values[columnIndices["MONTH"]];
                    product.ETD = values[columnIndices["ETD"]];
                    product.Color = values[columnIndices["COLOR"]];
                    product.KM_ran = values[columnIndices["KM"]] == "" ? (int?)null : Convert.ToInt32(values[columnIndices["KM"]].Replace(",", ""));
                    product.Fuel = values[columnIndices["FUEL"]];
                    product.Gear_m_at = values[columnIndices["GEAR(A/T)"]];
                    product.CC = values[columnIndices["CC"]] == "" ? (int?)null : Convert.ToInt32(values[columnIndices["CC"]]);
                    product.Price = Convert.ToDecimal(values[columnIndices["SELLING PRICE"]].Replace(",",""));
                    product.Images = (from imageIndex in imageIndices where values[imageIndex] != "" select values[imageIndex]).ToArray();
                    product.Equipments = new Equipment();
                    product.Equipments.AC = values[columnIndices["EQUIPMENT3(A/C)"]] != "" ? true : false;
                    product.Equipments.PS = values[columnIndices["EQUIPMENT2(P/S)"]] != "" ? true : false;
                    product.Equipments.PW = values[columnIndices["EQUIPMENT1(P/W)"]] != "" ? true : false;
                    product.Equipments.WCAB = values[columnIndices["W CAB"]] != "" ? true : false;
                    product.Equipments.FourWheelDrive = values[columnIndices["4 WD"]] != "" ? true : false;
                    var doors = columnIndices.Where(x => x.Key.Contains("DOOR")).Where(y => values[y.Value] != "").Select(x => x.Key.Split(' ')[0]).FirstOrDefault();
                    product.NoOfDoors = doors == "" || doors == null ? (int?)null : Convert.ToInt32(doors);
                    result.Add(product);
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                System.IO.File.Delete(localFileName);
            }
            return result;
        }

        private Dictionary<string, int> GetColumnIndices(string[] headerColumns)
        {
            var result = new Dictionary<string, int>();
            string[] expectedColumns = { "STOCK No", "CHASSIS No 1", "CHASSIS No 2", "MARCA","TYPE", "NAME OF CAR","GRADE", "YEAR","MONTH", "ETD","COLOR", "KM", "FUEL", "GEAR(A / T)", "EQUIPMENT3(A / C)", "EQUIPMENT1(P / W)", "EQUIPMENT2(P / S)", "W CAB", "4 WD", "SELLING PRICE", "2 DOOR", "3 DOOR", "4 DOOR", "5 DOOR", "CC" };
            
            for (int i=0;i<headerColumns.Length;i++)
            {                          
                if(headerColumns[i].Contains("Image"))
                {
                    result.Add(headerColumns[i], i);
                    continue;
                }
                for(int j =0; j < expectedColumns.Length; j++)
                {
                    if(expectedColumns[j].Replace(" ","") == headerColumns[i].Replace(" ", ""))
                    {
                        result.Add(headerColumns[i], i);
                        break;
                    }                    
                }
            }
            
            return result;
        }
    }
}
