using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Modelos.Cadastros
{
    public class Salas
    {
        [Key]
        public long SalaId { get; set; }
        public String Numeracao { get; set; }
        public String Nome { get; set; }
        public long Gateway { get; set; }
        public virtual Dispositivo Dispositivo { get; set; }

        
        
    }
}