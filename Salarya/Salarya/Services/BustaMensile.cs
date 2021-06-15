using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace Salarya.Services
{
   public class BustaMensile
   {
      [JsonProperty("Nome")]
      public string Nome { get; set; }

      [JsonProperty("Mese")]
      public string Mese { get; set; }

      [JsonProperty("Netto")]
      public decimal Netto { get; set; }

      [JsonProperty("Lordo")]
      public decimal Lordo { get; set; }

      [JsonProperty("FerieDovute")]
      public int FerieDovute { get; set; }

      [JsonProperty("FerieGodute")]
      public int FerieGodute { get; set; }

      [JsonProperty("OreMaturate")]
      public int OreMaturate { get; set; }

      [JsonProperty("OreGodute")]
      public int OreGodute { get; set; }
   }
}
