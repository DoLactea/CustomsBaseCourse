using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomsBase.Models
{
    public class Customs_agents
    {
        [Key]
        [Display(Name = "Agent ID")]
        public int Customs_agentID { get; set; }
        [Required(ErrorMessage = "Field must be set")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Field must be set")]
        [Display(Name = "Second Name")]
        public string SecondName { get; set; }
        [Required(ErrorMessage = "Field must be set")]
        [Display(Name = "Which warehouse serves")]
        public string Serves { get; set; }
        public ICollection<Duti> Duties { get; set; }
    }
}
