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

    public IEnumerable<Book> LibrosDeJavaPorNombreAscendente(){
        return librosCollection.Where(p=> p.Categories.Contains("Java")).OrderBy(p=> p.Title);
    }

    public IEnumerable<Book> LibrosConMasDe450PagOrdenadosPorPagDesc(){
        return librosCollection.Where(p=> p.PageCount > 450).OrderByDescending(p=> p.PageCount);
    }
    
    public IEnumerable<Book> TresPrimerosLibrosOrdenadosPorFecha(){
        return librosCollection
        .Where(p=> p.Categories.Contains("Java"))
        .OrderByDescending(p=> p.PublishedDate)
        .Take(3);
    }

    public IEnumerable<Book> TercerYCuartoLibroConMasDe400Pags(){
        return librosCollection
        .Where(p=> p.PageCount > 400)
        .Take(4)
        .Skip(2); //skippea los dos primeros
    }

    public IEnumerable<Book> TresPrimerosLibrosDeLaColeccion(){
        return librosCollection.Take(3)
        .Select(p=> new Book() { Title = p.Title, PageCount = p.PageCount }); //al libro solamente se le ponen esos datos q le asignamos
    }

    public int NumeroDeLibrosEntre200y500Pags(){
       // return librosCollection.Where(p=> p.PageCount>=200 && p.PageCount<=500).Count();
        //otra forma, el count y LongCount pueden recibir condiciones
        return librosCollection.Count(p=> p.PageCount>=200 && p.PageCount<=500);
    }

    public DateTime MenorFecha(){
        return librosCollection.Min(p=> p.PublishedDate);
    }

    public int NumeroDePagsLibroMayor(){
        return librosCollection.Max(p=> p.PageCount);
    }

    public Book LibroConMenorNumeroDePaginas(){
        return librosCollection.Where(p=> p.PageCount>0).MinBy(p=> p.PageCount);
    }

    public Book LibroConFechaPublicacionMasReciente(){
        return librosCollection.MaxBy(P=> P.PublishedDate);  // si usaramos max nos devolveria la fecha mayor como tal, no el libro
    }

    public int SumaPaginasLibros0y500Pags()
    {
        return librosCollection.Where(p=> p.PageCount >= 0 && p.PageCount <= 500).Sum(p=> p.PageCount);
    }

    public string TitulosDeLibrosDespuesDel2015Concatenados(){
        return librosCollection
            .Where(p=> p.PublishedDate.Year > 2015)
            .Aggregate("", (TitulosDeLibros, next) =>
        {
            if(TitulosDeLibros !=string.Empty)
            {
                TitulosDeLibros += " - " + next.Title;
            }
            else {
                TitulosDeLibros += next.Title;
            }
            return TitulosDeLibros;
        });
    }

    public double PromedioDeCaracteres(){
        return librosCollection.Average(p=> p.Title.Length);
    }

    public IEnumerable<IGrouping<int, Book>> LibrosPublicados2000AgrupadosPorAño(){
        return librosCollection
        .Where(p=> p.PublishedDate.Year >= 2000)
        .GroupBy(p=> p.PublishedDate.Year);
    }

    public ILookup<char, Book> DiccionarioDeLibrosPorLetra(){
        return librosCollection.ToLookup(p=> p.Title[0], p=> p); //podemos usar el [0] porque un string es un vector de caracteres
    }

    public IEnumerable<Book> LibrosDespuesDel2005ConMasDe500Pags(){
        var LibrosDespuesDel2005 = librosCollection.Where(p=> p.PublishedDate.Year > 2005);
        var LibrosConMasDe500Pags = librosCollection.Where(p=> p.PageCount > 500);

        return LibrosDespuesDel2005.Join(LibrosConMasDe500Pags, p=> p.Title, x=> x.Title, (p, x) => p); //comparamos las colecciones con titulo como si fuera unico porque no hay ids
    }
}