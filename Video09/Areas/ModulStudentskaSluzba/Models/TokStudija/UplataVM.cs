﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Models;

namespace MVC.Areas.ModulStudentskaSluzba.Models.TokStudija
{
    public class UplataVM
    {
        public DateTime DatumUplate { get; set; }
        public string Svrha { get; set; }
        public float Iznos { get; set; }
        public string EvidentiranoKorisnik { get; set; }
        public DateTime EvidentiranoDatum { get; set; }
    }
}