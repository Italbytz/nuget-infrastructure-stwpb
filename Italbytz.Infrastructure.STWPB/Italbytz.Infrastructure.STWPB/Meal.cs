using System;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Italbytz.Infrastructure.STWPB
{
    public partial class Meal
    {
        [JsonPropertyName("date")]
        public DateTimeOffset Date { get; set; }

        [JsonPropertyName("name_de")]
        public string NameDe { get; set; }

        [JsonPropertyName("name_en")]
        public string NameEn { get; set; }

        [JsonPropertyName("description_de")]
        public string DescriptionDe { get; set; }

        [JsonPropertyName("description_en")]
        public string DescriptionEn { get; set; }

        [JsonPropertyName("category")]
        public Category Category { get; set; }

        [JsonPropertyName("category_de")]
        public CategoryDe CategoryDe { get; set; }

        [JsonPropertyName("category_en")]
        public CategoryEn CategoryEn { get; set; }

        [JsonPropertyName("subcategory_de")]
        public string SubcategoryDe { get; set; }

        [JsonPropertyName("subcategory_en")]
        public string SubcategoryEn { get; set; }

        [JsonPropertyName("priceStudents")]
        public double PriceStudents { get; set; }

        [JsonPropertyName("priceWorkers")]
        public double PriceWorkers { get; set; }

        [JsonPropertyName("priceGuests")]
        public double PriceGuests { get; set; }

        [JsonPropertyName("allergens")]
        public AllergenEnum[] Allergens { get; set; }

        [JsonPropertyName("order_info")]
        public long OrderInfo { get; set; }

        [JsonPropertyName("badges")]
        public Badge[] Badges { get; set; }

        [JsonPropertyName("restaurant")]
        public Restaurant Restaurant { get; set; }

        [JsonPropertyName("pricetype")]
        public Pricetype Pricetype { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; set; }
    }

    public enum AllergenEnum {
        [EnumMember(Value = "1")]
        Z1,
        [EnumMember(Value = "2")]
        Z2,
        [EnumMember(Value = "3")]
        Z3,
        [EnumMember(Value = "4")]
        Z4,
        [EnumMember(Value = "5")]
        Z5,
        [EnumMember(Value = "6")]
        Z6,
        [EnumMember(Value = "7")]
        Z7,
        [EnumMember(Value = "8")]
        Z8,
        [EnumMember(Value = "9")]
        Z9,
        [EnumMember(Value = "10")]
        Z10,
        [EnumMember(Value = "11")]
        Z11,
        [EnumMember(Value = "12")]
        Z12,
        [EnumMember(Value = "13")]
        Z13,
        [EnumMember(Value = "14")]
        Z14,
        [EnumMember(Value = "15")]
        Z15,
        A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14 };

    public enum Badge {
        Nonfat,
        Vegan,
        Vegetarian,
        [EnumMember(Value = "low-calorie")]
        LowCalorie,
        [EnumMember(Value = "lactose-free")]
        LactoseFree,
        [EnumMember(Value = "gluten-free")]
        GlutenFree
    };

    public enum Category {
        [EnumMember(Value = "")]
        None,
        Dessert,
        Dish,
        Empty,
        Sidedish,
        Soups,
        [EnumMember(Value = "dish-default")]
        DishDefault,
        [EnumMember(Value = "dessert-counter")]
        DessertCounter,
        [EnumMember(Value = "dish-grill")]
        DishGrill
    };

    public enum CategoryDe {
        [EnumMember(Value = "")]
        Keine,
        Beilagen,
        Dessert,
        Empty,
        Essen,
        Suppen };

    public enum CategoryEn {
        [EnumMember(Value = "")]
        None,
        Dessert,
        Dish,
        Empty,
        [EnumMember(Value = "Side Dish")]
        SideDish };

    public enum Pricetype { Fixed, Weighted };

    public enum Restaurant {
        Cafete,
        [EnumMember(Value = "mensa-hamm")]
        MensaHamm,
        [EnumMember(Value = "mensa-lippstadt")]
        MensaLippstadt,
        [EnumMember(Value = "mensa-academica-paderborn")]
        MensaAcademicaPaderborn,
        [EnumMember(Value = "mensa-forum-paderborn")]
        MensaForumPaderborn,
        [EnumMember(Value = "one-way-snack")]
        OneWaySnack,
        [EnumMember(Value = "zm2")]
        ZM2
    };

    public static class Serialize
    {
        public static string ToJson(this Meal[] self) => JsonSerializer.Serialize(self, Converter.Options);
    }

    public static class Deserialize
    {
        public static Meal[] ToMeals(this string self) => JsonSerializer.Deserialize<Meal[]>(self, Converter.Options);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            Converters ={
        new JsonStringEnumMemberConverter()
    }
        };
    }

}
