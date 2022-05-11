using AppNetRazor.Datos;
using AppNetRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
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
    
    [BindProperty] 
    public Curso Curso { get; set; }
    
    [TempData]
    public string Mensaje { get; set; }
    
    public async Task OnGet()
    {
        Cursos = await _contexto.Cursos.ToListAsync();
    }
    
    public async Task<IActionResult> OnPostBorrar(int id)
    {
        var curso = await _contexto.Cursos.FindAsync(id);
        if (curso == null)
        {
            return NotFound();
        }
        _contexto.Cursos.Remove(curso);
        await _contexto.SaveChangesAsync();
        Mensaje = "Curso eliminado correctamente";
        return RedirectToPage("Index");
    }
}