//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AsTiKa.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rokotuslista
    {
        public string Asiakkaan_nimi { get; set; }
        public string Rokotteen_nimi { get; set; }
        public System.DateTime Anto_päivämäärä { get; set; }
        public Nullable<System.DateTime> Tehosterokotuksen_antopäivä { get; set; }
        public string Mahdolliset_sivuoireet_rokotuksista { get; set; }
    }
}
