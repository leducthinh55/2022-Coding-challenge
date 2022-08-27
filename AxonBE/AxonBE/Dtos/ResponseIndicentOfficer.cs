using Microsoft.AspNetCore.Mvc;

namespace AxonBE.Dtos
{
    public class ResponseIndicentOfficer
    {
        public IList<Indicent> indicents { get; set; }
        public IList<Officer> officers { get; set; } = OfficerOnline.Officers;
    }
}
