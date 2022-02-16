using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace annuaireEntreprise.DB.Model
{
    class Sites
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_site { get; set; }

        public string Name_site { get; set; }


    }
}
