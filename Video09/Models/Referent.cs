﻿using MVC.Helper;

namespace MVC.Models
{
    public class Referent : IEntity
    {
        public int Id { get; set; }
    
        public bool IsDeleted { get; set; }

        public Korisnik Korisnik { get; set; }

        public int FakultetId { get; set; }
        public Fakultet Fakultet { get; set; }
    }
}
