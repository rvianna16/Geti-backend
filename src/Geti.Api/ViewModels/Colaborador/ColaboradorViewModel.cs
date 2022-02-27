using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Geti.Api.ViewModels
{
    public class ColaboradorViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }
       
    }
}
