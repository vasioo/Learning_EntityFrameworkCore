namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
            string res = ExportAlbumsInfo(context, 9);
            Console.WriteLine(res);
            string res1 = ExportSongsAboveDuration(context, 4);
            Console.WriteLine(res);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var allAlbums =
                 context.Albums
                 .Where(p => p.ProducerId == producerId)
                 .Include(al => al.Producer)
                 .Include(al => al.Songs)
                 .ThenInclude(sn => sn.Writer)
                 .ToArray()
                 .Select(alb => new
                 {
                     AlbumName = alb.Name,
                     ReleaseDate = alb.ReleaseDate,
                     ProducerName = alb.Producer.Name,
                     Songs = alb.Songs.Select(song => new
                     {
                         SongName = song.Name,
                         Price = song.Price,
                         Writer = song.Writer.Name
                     })
                        .OrderByDescending(song => song.SongName)
                        .ThenBy(song => song.Writer)
                        .ToArray(),
                     TotalPrice = alb.Price
                 })
                 .OrderByDescending(alb => alb.TotalPrice)
                 .ToArray();
            foreach (var album in allAlbums)
            {
                stringBuilder
                    .AppendLine($"-AlbumName: {album.AlbumName}")
                    .AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy")}")
                    .AppendLine($"-ProducerName: {album.ProducerName}")
                    .AppendLine($"-Songs: ");

                int counter = 1;
                foreach (var song in album.Songs)
                {
                    stringBuilder
                        .AppendLine($"--#{counter++}")
                        .AppendLine($"---SongName: {song.SongName}")
                        .AppendLine($"---Price: {song.Price:f2}")
                        .AppendLine($"---Writer: {song.Writer}");
                }
                stringBuilder.AppendLine($"--Album price {album.TotalPrice}");
            }
            return stringBuilder.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var songsAboveGivenTime =
                context.Songs
                .Include(song=>song.SongPerformers)
                .ThenInclude(songper=> songper.Performer)
                .Include(song=>song.Writer)
                .Include(song=>song.Album)
                .ThenInclude(alb=>alb.Producer)
                .ToArray()
                .Where(sng => sng.Duration.TotalSeconds > duration)
                .Select(song => new
                {
                    Name = song.Name,
                    PerformerName =//if there is not a performer it will return ___
                    $"{song.SongPerformers.FirstOrDefault().Performer.FirstName}" +
                    $" {song.SongPerformers.FirstOrDefault().Performer.LastName}",
                    WriterName = song.Writer.Name,
                    AlbumProducer = song.Album.Producer.Name,
                    Duration = song.Duration
                })
                .OrderBy(song => song.Name)
                .ThenBy(song => song.WriterName)
                .ThenBy(song => song.PerformerName)
                .ToArray();

            int counter = 1;
            foreach (var song in songsAboveGivenTime)
            {
                stringBuilder
                    .AppendLine($"-Song #{counter++}")
                    .AppendLine($"---SongName: {song.Name}")
                    .AppendLine($"---Writer: {song.WriterName}")
                    .AppendLine($"---Performer: {song.PerformerName}")
                    .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                    .AppendLine($"---Duration: {song.Duration.ToString("c")}");
            }
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
