using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace annuaireEntreprise.DB.ReturnModel
{
    class EmployeReturn
    {
        public EmployeReturn(int Id_employe, string FirstName_employe, string LastName_employe, string PhoneNumber_employe, string Email_employe, int Id_service , string Service_name, int Id_site , string Sites_name, string? FixeNumber_employe)
        {
            Id = Id_employe;
            FirstName = FirstName_employe;
            LastName = LastName_employe;
            PhoneNumber = PhoneNumber_employe;
            FixeNumber = FixeNumber_employe;
            Email = Email_employe;
            this.Id_service = Id_service;
            Service = Service_name;
            this.Id_site = Id_site;
            Site = Sites_name;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string FixeNumber { get; set; }
        public string Email { get; set; }
        public int Id_service { get; set; }
        public string Service { get; set; }
        public int Id_site { get; set; }
        public string Site { get; set; }
    }
}
