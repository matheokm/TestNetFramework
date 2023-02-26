namespace TestNetFramework.Clases.Modelos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuarios()
        {
            Mascotas = new HashSet<Mascotas>();
        }

        [Key]
        public int idUsuario { get; set; }

        [Required]
        [StringLength(50)]
        public string username { get; set; }

        public int password { get; set; }

        [Required]
        [StringLength(50)]
        public string nombreCompleto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mascotas> Mascotas { get; set; }
    }
}
