using System;
using System.IO;
using System.Linq;

namespace QuickTemplate.ConApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Import csv-Daten!");

            using var artistCtrl = new Logic.Controllers.ArtistsController();
            using var albumCtrl = new Logic.Controllers.AlbumsController(artistCtrl);
            var csvAlbums = File.ReadAllLines("Data/Album.csv")
                                .Skip(1)
                                .Select(l => l.Split(";"))
                                .Select(d => new { id = d[0], artistId = d[2], Entity = new Logic.Entities.Album { Title = d[1] } });

            var csvArtists = File.ReadAllLines("Data/Artist.csv")
                                 .Skip(1)
                                 .Select(l => l.Split(";"))
                                 .Select(d => new
                                 {
                                     id = d[0],
                                     Entity = new Logic.Entities.Artist
                                     {
                                         Name = d[1],
                                         Albums = csvAlbums.Where(e => e.artistId == d[0]).Select(e => e.Entity).ToList(),
                                     }
                                 });

            await artistCtrl.InsertAsync(csvArtists.Select(e => e.Entity));
            await artistCtrl.SaveChangesAsync();
        }
    }
}