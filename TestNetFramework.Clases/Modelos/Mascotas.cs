namespace TestNetFramework.Clases.Modelos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Mascotas
    {
        [Key]
        public int idMascota { get; set; }

        public int idUsuario { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        public int edad { get; set; }

        [Required]
        public string descripcion { get; set; }

        public virtual Usuarios Usuarios { get; set; }
    }
}
