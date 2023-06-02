﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Domain.Entities.CartEntities
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public AppUser User { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}