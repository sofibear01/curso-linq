
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
//ImprimirValores(queries.LibrosDePython());

//libros de java ordenados por nombre
//ImprimirValores(queries.LibrosDeJavaPorNombreAscendente());

//libros con mas de 450 pags ordenados desc
//ImprimirValores(queries.LibrosConMasDe450PagOrdenadosPorPagDesc());

//3 primeros Libros de java ordenados por fecha
//ImprimirValores(queries.TresPrimerosLibrosOrdenadosPorFecha());

//tecrer y cuarto libro con mas de 400 pags
//ImprimirValores(queries.TercerYCuartoLibroConMasDe400Pags());

//primeros libros filtrados con select
//ImprimirValores(queries.TresPrimerosLibrosDeLaColeccion());

//cantidad de libros con paginas entre 200 y 500
//Console.WriteLine("La cantidad es: " + queries.NumeroDeLibrosEntre200y500Pags());

//menor fecha de publicacion
//Console.WriteLine("la menor fecha es: " + queries.MenorFecha());

//libro con mayor pagina
//Console.WriteLine("La mayor cantiad de paginas " + queries.NumeroDePagsLibroMayor());

//libro con mejnor numero de paginas
//var libroMenorPag = queries.LibroConMenorNumeroDePaginas();
//Console.WriteLine("libro con menor numero de paginas: " + libroMenorPag.Title + " - " + libroMenorPag.PageCount);

//libro con fecha de publicacion mas reciente
//var libroFechaMasReciente = queries.LibroConFechaPublicacionMasReciente();
//Console.WriteLine("libro con fecha mas reciente: " + libroFechaMasReciente.Title + " - " + libroFechaMasReciente.PublishedDate);

//Suma de paginas de libros entre 0 y 500 paginas 
//Console.WriteLine("Suma de las paginas: " + queries.SumaPaginasLibros0y500Pags());


//titulos contatenados 
Console.WriteLine(queries.TitulosDeLibrosDespuesDel2015Concatenados());

void ImprimirValores(IEnumerable<Book> listadelibros)
{
    Console.WriteLine("{0,-60} {1,15} {2,15}\n", "Titulo", "N. paginas", "Fecha publicacion");
    foreach(var item in listadelibros)
    {
        Console.WriteLine("{0,-60} {1,15} {2,15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}