using System.Data.SqlTypes;
using System.Globalization;
using System.Runtime.Serialization;

namespace WebApplication2.Models
{
    public class AddFacture
    {
       
        public string? Name { get; set; }
        public long?  Numfac { get; set; }
        public long? Numclient { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Adresse { get; set; }
        public string? CodePostal { get; set; }
        public string? Pays { get; set; }
        public string? Rue { get; set; }
		public string? Typ { get; set; }
		public long? Total { get; set; }

	}
}
