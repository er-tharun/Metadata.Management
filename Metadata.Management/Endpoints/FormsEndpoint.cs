using Microsoft.EntityFrameworkCore;
public class FormsEndpoint
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/forms", GetForms)
            .WithName("GetForms")
            .WithOpenApi();

        app.MapGet("/forms/{id}", GetFormById)
            .WithName("GetFormById")
            .WithOpenApi();
    }

    private IResult GetForms(MetadataDbContext dbContext)
    {
        // Logic to retrieve forms
        dbContext.Database.EnsureCreated();
        var forms = dbContext.Forms.ToList();
        return Results.Ok(forms);
    }

    private IResult GetFormById(int id, MetadataDbContext dbContext)
    {
        // Logic to retrieve a specific form by ID
        var form = dbContext.Forms.FirstOrDefault(f => f.Id == id);
        if (form == null)
        {
            return Results.NotFound();
        }
        return Results.Ok(form);
    }
}