using System.ComponentModel.DataAnnotations;

namespace AppNetRazor.Modelos;

public class Curso
{
    [Key]
    public int Id { get; set; }
    [Required]
    [Display(Name = "Nombre Curso")]
    public string NombreCurso { get; set; }
    [Display(Name = "Cantidad Clases")]
    public int CantidadClases { get; set; }
    public int Precio { get; set; }
    [Display(Name = "Fecha Creación")]
    public DateTime FechaCreacion { get; set; }
}