using Microsoft.AspNetCore.Mvc;

namespace AxonBE.Dtos
{
    public class Officer
    {
        public int id { get; set; }
        public string badgeName { get; set; }
        public object loc { get; set; }

    }
}
