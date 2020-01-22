using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace HotelVision_CoreMvc.Models.Dtos
{
    public class EmailPost
    {
        public string Subject { get; set; }

        public string Body { get; set; }

        [DataType(DataType.EmailAddress)]
        public string FromAddress { get; set; }

        [DataType(DataType.EmailAddress)]
        public string ToAddress { get; set; }
    }
}
