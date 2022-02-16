using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace annuaireEntreprise.DB.Model
{
    class Services
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_service { get; set; }
        public string Name_service { get; set; }
    }
}
