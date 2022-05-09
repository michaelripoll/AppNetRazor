using AppNetRazor.Datos;
using AppNetRazor.Modelos;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AppNetRazor.Pages.Cursos;

public class Index : PageModel
{
    private readonly ApplicationDbContext _contexto;

    public Index(ApplicationDbContext contexto)
    {
        _contexto = contexto;
    }
    
    public IEnumerable<Curso> Cursos { get; set; }
    
    public async Task OnGet()
    {
        Cursos = await _contexto.Cursos.ToListAsync();
    }
}