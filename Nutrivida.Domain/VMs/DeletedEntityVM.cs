﻿using System;
using System.Collections.Generic;
using System.Text;
using Nutrivida.Domain.Entities;

namespace Nutrivida.Domain.VMs
{
    public class DeletedEntityVM : BaseEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }
        public int? DeletedByUserId { get; set; }
        public string DeletedByUser { get; set; }
    }
}
