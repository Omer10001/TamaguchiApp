using System;
using System.Collections.Generic;
using System.Text;

namespace TamaguchiApp.DataTransferObjects
{
    class PlayerDTO
    {
        public PlayerDTO()
        {

        }
        public string Email { get; set; }

        public string PlayerID { get; set; }
        public string Password { get; set; }
    }
}
