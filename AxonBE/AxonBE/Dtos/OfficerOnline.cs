using Microsoft.AspNetCore.Mvc;

namespace AxonBE.Dtos
{
    public class OfficerOnline
    {
        public static IList<Officer> Officers { get; set; } = new List<Officer>();

    }
}
