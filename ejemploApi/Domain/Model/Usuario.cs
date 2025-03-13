using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ejemploApi.Domain.Model;

[Index("Correo", Name = "UQ__Usuarios__60695A19B20E0C80", IsUnique = true)]
public partial class Usuario
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    public string Correo { get; set; } = null!;

    [StringLength(255)]
    public string Password { get; set; } = null!;

    [StringLength(255)]
    public string Nombre { get; set; } = null!;

    public bool Activo { get; set; }

    [InverseProperty("Usuario")]
    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
}
