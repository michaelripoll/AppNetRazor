using AppNetRazor.Datos;
using AppNetRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppNetRazor.Pages.Cursos;

public class Editar : PageModel
{
    private readonly ApplicationDbContext _contexto;

    public Editar(ApplicationDbContext contexto)
    {
        _contexto = contexto;
    }
    
    [BindProperty] 
    public Curso Curso { get; set; }
    
    public async Task OnGet(int id)
    {
        Curso = await _contexto.Cursos.FindAsync(id);
    }
    
    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid)
        {
            var cursoDesdeDB = await _contexto.Cursos.FindAsync(Curso.Id);

            cursoDesdeDB.NombreCurso = Curso.NombreCurso;
            cursoDesdeDB.CantidadClases = Curso.CantidadClases;
            cursoDesdeDB.Precio = Curso.Precio;
            
            await _contexto.SaveChangesAsync();
            return RedirectToPage("Index");
        }

        return RedirectToPage();
    }
}