using System;
namespace csharp_lista_indirizzi
{
	public class Indirizzo
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Street { get; set; }
		public string City { get; set; }
		public string Province { get; set; }
		public int ZIP { get; set; }

		public Indirizzo(string name, string surname, string street, string city, string province, int zip)
		{
			Name = name;
			Surname = surname;
			Street = street;
			City = city;
			Province = province;
			ZIP = zip;
		}

        private string CheckField(string field, string fieldName)
        {
            if (string.IsNullOrEmpty(field))
            {
                return $"{fieldName.ToUpper()} NON DISPONIBILE";
            }
            return field;
        }

        public override string ToString()
        {
			string name = CheckField(Name, "Name");
			string surname = CheckField(Surname, "Surname");
			string street = CheckField(Street, "Street");
			string city = CheckField(City, "City");
			string province = CheckField(Province, "Province");

			return $"{name}, {surname}, {street}, {city}, {province}, ({ZIP})";
        }
    }
}

