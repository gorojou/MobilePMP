using System;
namespace mobilePMP.Models
{
    public class EthToken : Token
    {
        public EthToken()
        {

            this.Name = "PMPlus";
            this.Symbol = "MPP";
            this.NumberOfDecimalPlaces = 18;
            this.ImgUrl = "Icon.png";
        }
    }
}
