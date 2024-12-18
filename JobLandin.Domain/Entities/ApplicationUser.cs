﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobLandin.Domain.Entities
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public String Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }


        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        
        public int? CandidateId { get; set; }
        public Candidate Candidate { get; set; }

    }
}
