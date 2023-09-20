
LinqQueries queries = new LinqQueries();

//toda la coleccion
//ImprimirValores(queries.TodaLaColeccion());

//libros despues del 2000
//ImprimirValores(queries.LibrosDespuesDe2000());

//libros que tienen mas de 250 paginas y tienen en el titulo la palabra in action
//ImprimirValores(queries.LibrosConMasDe250PagConPalabrasInAction());

//Todos los libros tienen status
//Console.WriteLine($" Todos los libros tienen status? - {queries.TodosLosLibrosTienenStatus()}");

//Algun libro publicado en 2005
//Console.WriteLine($" Algun libro publicado en 2005? - {queries.AlgunLibroPublicadoEn2005()}");

//Libros que sean de categoria python
ImprimirValores(queries.LibrosDePython());

void ImprimirValores(IEnumerable<Book> listadelibros)
{
    Console.WriteLine("{0,-60} {1,15} {2,15}\n", "Titulo", "N. paginas", "Fecha publicacion");
    foreach(var item in listadelibros)
    {
        Console.WriteLine("{0,-60} {1,15} {2,15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}