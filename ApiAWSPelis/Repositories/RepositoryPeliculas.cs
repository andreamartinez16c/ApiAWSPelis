using ApiAWSPelis.Data;
using ApiAWSPelis.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAWSPelis.Repositories
{
    public class RepositoryPeliculas
    {
        public PeliculasContext context;
        public RepositoryPeliculas(PeliculasContext context)
        {
            this.context = context;
        }

        public async Task<List<Pelicula>> GetPeliculasAsync()
        {
            return await this.context.Peliculas.ToListAsync();
        }

        public async Task<List<Pelicula>> FindPeliculaByActorAsync(string actor)
        {
            var consulta = from datos in this.context.Peliculas
                           where datos.Actores.Contains(actor)
                           select datos;
            return await consulta.ToListAsync();
        }

    }
}
