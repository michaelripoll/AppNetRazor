using AppNetRazor.Datos;
using AppNetRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppNetRazor.Pages.Cursos;

public class Crear : PageModel
{
    private readonly ApplicationDbContext _contexto;

    public Crear(ApplicationDbContext contexto)
    {
        _contexto = contexto;
    }
    
    [BindProperty] 
    public Curso Curso { get; set; }
    
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        
        Curso.FechaCreacion = DateTime.UtcNow;

        _contexto.Add(Curso);
        await _contexto.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}