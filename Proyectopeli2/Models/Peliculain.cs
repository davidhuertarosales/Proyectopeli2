using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace Proyectopeli2.Models
{
    public class Peliculain : DropCreateDatabaseAlways<Peliculadb>
    {

        protected override void Seed(Peliculadb context)
        {
            base.Seed(context);

            //Create some photos
            var photos = new List<Pelicula>
            {
                new Pelicula {
                    Title = "Tiburon",
                    Poster = "http://localhost:8080/Imapro/tiburon1.jpg",
                    Poster2 = "https://m.media-amazon.com/images/M/MV5BMmVmODY1MzEtYTMwZC00MzNhLWFkNDMtZjAwM2EwODUxZTA5XkEyXkFqcGdeQXVyNTAyODkwOQ@@._V1_SX651_CR0,0,651,999_AL_.jpg",
                    Video ="https://www.imdb.com/videoembed/vi4242122009",
                    Sinopsis = "It's a hot summer on Amity Island, a small community whose main business is its beaches. When new Sheriff Martin Brody discovers the remains of a shark attack victim, his first inclination is to close the beaches to swimmers. This doesn't sit well with Mayor Larry Vaughn and several of the local businessmen. Brody backs down to his regret as that weekend a young boy is killed by the predator. The dead boy's mother puts out a bounty on the shark and Amity is soon swamped with amateur hunters and fisherman hoping to cash in on the reward. A local fisherman with much experience hunting sharks, Quint, offers to hunt down the creature for a hefty fee. Soon Quint, Brody and Matt Hooper from the Oceanographic Institute are at sea hunting the Great White shark. As Brody succinctly surmises after their first encounter with the creature, they're going to need a bigger boat.",
                    Director = "Steven Spielberg",
                    Fecha_estreno = DateTime.Parse("20/07/1975"),
                    Duracion = DateTime.Parse("2:04"),
                    Generos = "Terror",
                    Idiomas = "English"
                },
                new Pelicula {
                    Title = "Scarface",
                    Sinopsis = "Tony Montana manages to leave Cuba during the Mariel exodus of 1980. He finds himself in a Florida refugee camp but his friend Manny has a way out for them: undertake a contract killing and arrangements will be made to get a green card. He's soon working for drug dealer Frank Lopez and shows his mettle when a deal with Colombian drug dealers goes bad. He also brings a new level of violence to Miami. " +
                    "Tony is protective of his younger sister but his mother knows what he does for a living and disowns him. Tony is impatient and wants it all however, including Frank's empire and his mistress Elvira Hancock. Once at the top however, Tony's outrageous actions make him a target and everything comes crumbling down.",
                    Director = "Brian De Palma",
                    Poster = "http://localhost:8080/Imapro/scarface.jpg",
                    Poster2 = "https://m.media-amazon.com/images/M/MV5BNjdjNGQ4NDEtNTEwYS00MTgxLTliYzQtYzE2ZDRiZjFhZmNlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_UX182_CR0,0,182,268_AL_.jpg",
                    Video ="https://www.imdb.com/videoembed/vi3154549785",
                    Fecha_estreno = DateTime.Parse("12/03/1984"),
                    Duracion = DateTime.Parse("2:50"),
                    Generos = "Crimen/Drama",
                    Idiomas = "Ingles | Español"
                },
                new Pelicula {
                    Title = "Volver al Futuro",
                    Sinopsis = "Marty McFly, a typical American teenager of the Eighties, is accidentally sent back to 1955 in a plutonium-powered DeLorean (time machine) invented by a slightly mad scientist. During his often hysterical, always amazing trip back in time, Marty must make certain his teenage parents-to-be meet and fall in love - so he can get back to the future.",
                    Director = "Robert Zemeckis",
                    Poster = "http://localhost:8080/Imapro/back.gif",
                    Poster2 = "https://m.media-amazon.com/images/M/MV5BZmU0M2Y1OGUtZjIxNi00ZjBkLTg1MjgtOWIyNThiZWIwYjRiXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_UX92_CR0%2C0%2C92%2C137_AL_.jpg",
                    Video ="https://www.imdb.com/videoembed/vi3645551385",
                    Fecha_estreno = DateTime.Parse("02/12/1985"),
                    Duracion = DateTime.Parse("1:56"),
                    Generos = " Aventura | Comedia",
                    Idiomas = "Ingles"
                },
                new Pelicula {
                    Title = "Pulp Fiction",
                    Sinopsis = "Los dos criminales son polos opuestos que deberán trabajar juntos para cumplir su cometido. De forma paralela, Vincent tendrá que hacerse cargo de Mia Wallace (Uma Thurman, Kill Bill), la peculiar novia de su jefe, a petición del mismo, mientras él pasa unos días fuera de la ciudad. Su compañero Jules le recomienda que vaya con cautela, pues la atractiva mujer le puede meter en problemas. Mientras, el boxeador Butch Coolidge (Bruce Willis, El sexto sentido) debe perder una importante pelea, pues ha sido sobornado por Wallace para participar en este combate amañado, y la pareja formada por Pumpkin/Ringo (Tim Roth, Reservoir Dogs) y Honey Bunny/Yolanda (Amanda Plummer, Mi vida sin mí) decidirá atracar un establecimiento debido a su lamentable situación laboral. ",
                    Director = "Quentin Tarantino",
                    Poster = "http://localhost:8080/Imapro/pulp-fiction.jpg",
                    Poster2 = "https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UY137_CR1%2C0%2C92%2C137_AL_.jpg",
                    Video ="https://www.imdb.com/videoembed/vi2620371481",
                    Fecha_estreno = DateTime.Parse("09/11/1988"),
                    Duracion = DateTime.Parse("2:30"),
                    Generos = "Terror",
                    Idiomas = "Ingles"
                },
                new Pelicula {
                    Title = "El padrino",
                    Sinopsis = "En el verano de 1945, se celebra la boda de Connie (Talia Shire) y Carlo Rizzi (Gianni Russo). Connie es la única hija de Don Vito Corleone (Marlon Brando), jefe de una de las familias que ejercen el mando de la Cosa Nostra en la ciudad de Nueva York. Don Vito además tiene otros tres hijos: su primogénito Sonny (James Caan), el endeble Fredo (John Cazale) y el más joven se todos, Michael (Al Pacino), un marine condecorado por su lucha en la Segunda Guerra Mundial que acaba de regresar a su hogar en Nueva York. Por designios de la fortuna, Michael terminará llevando la vida que no deseaba, tomando las riendas del negocio familiar, cambiando su moral y sus valores, para defender a toda costa a su familia. ",
                    Director = "Francis Ford Coppola",
                    Poster = "http://localhost:8080/Imapro/elpadrino.jpg",
                    Poster2 = "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,704,1000_AL_.jpg",
                    Video ="https://www.imdb.com/videoembed/vi1348706585",
                    Fecha_estreno = DateTime.Parse("09/11/1988"),
                    Duracion = DateTime.Parse("02:00"),
                    Generos = "Terror",
                    Idiomas = "Ingles"
                }
            };
            photos.ForEach(s => context.Pelicula.Add(s));
            context.SaveChanges();

            //Create some comments

            //Create some comments
            var comments = new List<Comentario>
            {
                new Comentario {
                    PeliID = 1,
                    UserName = "Luis Sousa",
                    Imaus="http://localhost:8080/Imapro/users/us1.gif",
                    Asunto = "Camera Settings",
                    Cuerpo = "Nice depth-of-field. What aperture did you use?"
                },
                new Comentario {
                    PeliID = 1,
                    UserName = "Brad Sutton",
                    Imaus="http://localhost:8080/Imapro/users/us2.gif",
                    Asunto = "Camera Settings",
                    Cuerpo = "Must have been f11 or something like that?"
                },
                new Comentario {
                    PeliID = 2,
                    UserName = "Brad Sutton",
                    Imaus="http://localhost:8080/Imapro/users/us3.png",
                    Asunto = "Great Shot!",
                    Cuerpo = "I know these things are easy to shoot, but I still think they're great."
                },
                new Comentario {
                    PeliID = 3,
                    UserName = "Masato Kawai",
                    Imaus="http://localhost:8080/Imapro/users/us4.png",
                    Asunto = "Imperfections",
                    Cuerpo = "Looks like there's a hair in the lower right. Was that in the shot?"
                }
            };
            comments.ForEach(s => context.Comentario.Add(s));
            context.SaveChanges();
        }
       
      
    }
}