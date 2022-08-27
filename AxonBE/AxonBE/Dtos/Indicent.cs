using Microsoft.AspNetCore.Mvc;

namespace AxonBE.Dtos
{
    public class Indicent
    {
        public int id { get; set; }
        public string codeName { get; set; }
        public object loc { get; set; }
        public int officerId { get; set; }
    }
}
