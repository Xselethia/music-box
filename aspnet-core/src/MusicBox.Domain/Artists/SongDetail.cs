using System;
using Volo.Abp.Domain.Entities;

namespace MusicBox.Artists;

// View
public class SongDetail : Entity<Guid>
{
    public string Name { get; set; }
    public string Lyrics { get; set; }
    public string Genre { get; set; }
    public string SourceLink { get; set; }
    public int Length { get; set; }
    public Guid AlbumId { get; set; }
    public string AlbumName { get; set; }
    public int AlbumReleaseYear { get; set; }
    public string AlbumCoverImage { get; set; }
    public bool AlbumIsSingle { get; set; }
    public Guid ArtistId { get; set; }
    public string ArtistName { get; set; }
}