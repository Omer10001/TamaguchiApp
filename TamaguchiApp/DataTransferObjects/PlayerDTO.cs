using System;
using System.Collections.Generic;
using System.Text;

namespace TamaguchiApp.DataTransferObjects
{
    public class PlayerDTO
    {
        public PlayerDTO()
        {

        }       
        public int PlayerID { get; set; }
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }  
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }       
        public string UserName { get; set; }      
        public string UserPassword { get; set; }

    }
}
