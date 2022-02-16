using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace annuaireEntreprise.DB.Model
{
    class Employes
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_employe { get; set; }
        [Required]
        public string FirstName_employe { get; set; }
        [Required]
        public string LastName_employe { get; set; }
        [Required]
        public string PhoneNumber_employe { get; set; }
        public string FixeNumber_employe { get; set; }
        [Required]
        public string Email_employe { get; set; }

        [DefaultValue(false)]
        public Boolean role_employe { get; set; }
        [Required]
        public int Id_service { get; set; }
        public virtual Services Service { get; set; }
        [Required]
        public int Id_site { get; set; }
        public virtual Sites Site { get; set; }
    }
}
