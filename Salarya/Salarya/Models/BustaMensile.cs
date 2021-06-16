using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace Salarya.Services
{
   public class BustaMensile
   {
      [JsonProperty("IdPDFSalary")]
      public Int32 IdPDFSalary{ get; set; }
      [JsonProperty("Year")]
      public Int32 Year{ get; set; }
      [JsonProperty("Month")]
      public String Month{ get; set; }
      [JsonProperty("FirstName")]
      public String FirstName{ get; set; }
      [JsonProperty("LastName")]
      public String LastName{ get; set; }
      [JsonProperty("Qualification")]
      public String Qualification{ get; set; }
      [JsonProperty("CodTax")]
      public String CodTax{ get; set; }
      [JsonProperty("HolidayDue")]
      public Decimal HolidayDue{ get; set; }
      [JsonProperty("HolidayEnjoyed")]
      public Decimal HolidayEnjoyed{ get; set; }
      [JsonProperty("HolidayResidual")]
      public Decimal HolidayResidual{ get; set; }
      [JsonProperty("PermitsDue")]
      public Decimal PermitsDue{ get; set; }
      [JsonProperty("PermitsEnjoyed")]
      public Decimal PermitsEnjoyed{ get; set; }
      [JsonProperty("PermitsResidual")]
      public Decimal PermitsResidual{ get; set; }
      [JsonProperty("NetSalary")]
      public Decimal NetSalary{ get; set; }
      [JsonProperty("GrossSalary")]
      public Decimal GrossSalary{ get; set; }
      //[JsonProperty("Nome")]
      //public string Nome { get; set; }

      //[JsonProperty("Mese")]
      //public string Mese { get; set; }

      //[JsonProperty("Netto")]
      //public double Netto { get; set; }

      //[JsonProperty("Lordo")]
      //public double Lordo { get; set; }

      //[JsonProperty("FerieDovute")]
      //public int FerieDovute { get; set; }

      //[JsonProperty("FerieGodute")]
      //public int FerieGodute { get; set; }

      //[JsonProperty("OreMaturate")]
      //public int OreMaturate { get; set; }

      //[JsonProperty("OreGodute")]
      //public int OreGodute { get; set; }
   }
}
