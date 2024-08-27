using ApiCarros.Enum;

namespace ApiCarros.Models
{
    public class CarroModel
    {
        public int id { get; set; }

        public string nome { get; set; }

        public int ano { get; set; }

        public MarcaEnum marca { get; set; }

    }
}
