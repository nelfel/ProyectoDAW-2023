using System;
using System.Collections.Generic;
using FindMeJob.DOMAIN.Core.Entities;

namespace FindMeJob.DOMAIN.Core.Entities;

public partial class OfertaTrabajo
{
    public int Id { get; set; }

    public string? Titulo { get; set; }

    public string? Descripcion { get; set; }

    public int? EmpresaId { get; set; }

    public DateTime? FechaPublicacion { get; set; }

    public virtual Empresa? Empresa { get; set; }

    public virtual ICollection<Postulacion> Postulacions { get; set; } = new List<Postulacion>();
}
