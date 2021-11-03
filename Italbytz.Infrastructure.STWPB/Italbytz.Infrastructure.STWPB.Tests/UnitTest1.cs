using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Italbytz.Infrastructure.STWPB.Tests
{
    public class Tests
    {
        MensaAPI api;
        string secret;

        [SetUp]
        public void Setup()
        {
            secret = Environment.GetEnvironmentVariable("SECRET_STWPB");
            Assert.NotNull(secret);            
        }

        [Test]
        public async Task TestGetMealsDE()
        {
            api = new MensaAPI(secret, "de");
            try
            {                
                var meals = await api.GetMeals();
                Assert.IsTrue(meals.Count > 0);
            }
            catch (System.Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task TestGetTodaysHammMealsDE()
        {
            api = new MensaAPI(secret, "de");
            try
            {                
                var meals = await api.GetTodaysHammMeals();
            }
            catch (System.Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task TestGetMealsEN()
        {
            api = new MensaAPI(secret, "en");
            try
            {
                var meals = await api.GetMeals();
                Assert.IsTrue(meals.Count > 0);
            }
            catch (System.Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task TestGetTodaysHammMealsEN()
        {
            api = new MensaAPI(secret, "en");
            try
            {
                var meals = await api.GetTodaysHammMeals();
            }
            catch (System.Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void TestSerializeToJson()
        {
            var meal = new Meal[] { new Meal()
            {
                Category = Category.Dessert
            }
            };
            var jsonString = meal.ToJson();
        }

        [Test]
        public void TestDeserializeFromJson()
        {
            var json = "[{\"name_de\":null,\"name_en\":null,\"description_de\":null,\"description_en\":null,\"category\":\"dessert\",\"category_de\":\"Beilagen\",\"category_en\":\"Dessert\",\"subcategory_de\":null,\"subcategory_en\":null,\"priceStudents\":0,\"priceWorkers\":0,\"priceGuests\":0,\"order_info\":0,\"image\":null,\"thumbnail\":null}]";
            var meals = json.ToMeals();
            Assert.AreEqual(meals[0].Category, Category.Dessert);
        }

        [Test]
        public void TestDeserializeFromJsonSidedish()
        {
            var json = "[{\"name_de\":null,\"name_en\":null,\"description_de\":null,\"description_en\":null,\"category\":\"sidedish\",\"category_de\":\"Beilagen\",\"category_en\":\"Dessert\",\"subcategory_de\":null,\"subcategory_en\":null,\"priceStudents\":0,\"priceWorkers\":0,\"priceGuests\":0,\"order_info\":0,\"image\":null,\"thumbnail\":null}]";
            var meals = json.ToMeals();
            Assert.AreEqual(meals[0].Category, Category.Sidedish);
        }

        [Test]
        public void TestDeserializeFromJsonNullableEnum()
        {
            var json = "[{\"name_de\":null,\"name_en\":null,\"description_de\":null,\"description_en\":null,\"category\":\"\",\"category_de\":\"Beilagen\",\"category_en\":\"Dessert\",\"subcategory_de\":null,\"subcategory_en\":null,\"priceStudents\":0,\"priceWorkers\":0,\"priceGuests\":0,\"order_info\":0,\"image\":null,\"thumbnail\":null}]";
            var meals = json.ToMeals();
            Assert.AreEqual(meals[0].Category, Category.None);
        }

        [Test]
        public void TestDeserializeFromRealJson()
        {
            var json = @"[ {""date"":""2021-09-16"",""name_de"":""Chili con carne vom Rind mit Baguette"",""name_en"":""Chili con carne of beef with bread"",""description_de"":"""",""description_en"":"""",""category"":""dish"",""category_de"":""Essen"",""category_en"":""Dish"",""subcategory_de"":"""",""subcategory_en"":"""",""priceStudents"":2.9,""priceWorkers"":4.6,""priceGuests"":5.7,""allergens"":[""5"",""9"",""15"",""A1"",""A6"",""A7""],""order_info"":0,""badges"":[],""restaurant"":""cafete"",""pricetype"":""fixed"",""image"":""http:\/\/www.studentenwerk-pb.de\/fileadmin\/imports\/images\/speiseleitsystem\/5010.jpg"",""thumbnail"":""http:\/\/www.studentenwerk-pb.de\/fileadmin\/shareddata\/thumb.php?src=5010.jpg""} ]";
            var meals = json.ToMeals();
            Assert.AreEqual(meals[0].Category, Category.Dish);
        }
    }
}
