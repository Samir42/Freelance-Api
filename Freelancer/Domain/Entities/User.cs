﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Domain.Entities {
    public class User  : IdentityUser<int> {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string AdditionalInfo { get; set; }
        public string ImageUrl { get; set; }
        public DateTime RegisteredAt { get; set; }

        public virtual Freelancer Freelancer { get; set; }
        public virtual Client Client { get; set; }
    }
}
