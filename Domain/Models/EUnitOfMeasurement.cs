using System.ComponentModel;

namespace SuperMarket.Domain.Models
{
    public enum EUnitOfMeasurement : byte
    {
        //Description attribute applied over 
        //every enumeration possibility. An attribute is a way to define metadata over classes, interfaces, properties 

        [Description("UN")]
        Unity = 1,

        [Description("MG")]
        Milligram = 2,

        [Description("G")]
        Gram = 3,

        [Description("KG")]
        Kilogram = 4,

        [Description("L")]
        Liter = 5
    }
}