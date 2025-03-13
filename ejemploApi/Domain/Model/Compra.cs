using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ejemploApi.Domain.Model;

public partial class Compra
{
    [Key]
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaCompra { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Monto { get; set; }

    [ForeignKey("UsuarioId")]
    [InverseProperty("Compras")]
    public virtual Usuario Usuario { get; set; } = null!;
}
