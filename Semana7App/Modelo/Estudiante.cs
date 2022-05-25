﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Semana7App.Modelo
{
    public class Estudiante
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [MaxLength(100)]
        public string nombre { get; set; }


        [MaxLength(50)]
        public string usuario { get; set; }

        [MaxLength(50)]
        public string contrasenia { get; set; }

    }
}
