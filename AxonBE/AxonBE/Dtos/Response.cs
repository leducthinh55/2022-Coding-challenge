using Microsoft.AspNetCore.Mvc;

namespace AxonBE.Dtos
{
    public class Response 
    {
        public object data { get; set; }
        public object error { get; set; }    
    }
}
