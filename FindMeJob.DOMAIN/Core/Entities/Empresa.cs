﻿using System;
using System.Collections.Generic;
using FindMeJob.DOMAIN.Core.Entities;

namespace FindMeJob.DOMAIN.Core.Entities;

public partial class Empresa
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public virtual ICollection<OfertaTrabajo> OfertaTrabajos { get; set; } = new List<OfertaTrabajo>();
}
