﻿using System;
using Allianz.Domain.Common;

namespace Allianz.Domain.Entities
{
    public class Customer : EntityBase
    {
        public Customer() { }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }

        public string Phone { get; set; }
    }
}