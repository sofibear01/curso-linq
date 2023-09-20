public class LinqQueries
{

    private List<Book> librosCollection = new List<Book>();
    
    public LinqQueries()
    {
        using(StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
        }
    }

    public IEnumerable<Book> TodaLaColeccion()
    {
        return librosCollection;
    }

    public IEnumerable<Book> LibrosDespuesDe2000()
    {
        return librosCollection.Where(p=> p.PublishedDate.Year > 2000);
    }

    public IEnumerable<Book> LibrosConMasDe250PagConPalabrasInAction()
    {
        //estension methods
        //return librosCollection.Where(p=> p.PageCount > 250 && p.Title.Contains("in Action"));

        //query expression
        return from l in librosCollection where l.PageCount > 250 && l.Title.Contains("in Action") select l;
    }

    public bool TodosLosLibrosTienenStatus()
    {
        return librosCollection.All(p=> p.Status!= string.Empty);
    }

    public bool AlgunLibroPublicadoEn2005(){
        return librosCollection.Any(p=> p.PublishedDate.Year == 2005);
    }

    public IEnumerable<Book> LibrosDePython(){
        return librosCollection.Where(p=> p.Categories.Contains("Python"));
    }
}