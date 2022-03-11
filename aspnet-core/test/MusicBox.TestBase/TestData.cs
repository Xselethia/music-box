using System;
using Volo.Abp.DependencyInjection;

namespace MusicBox;

public class TestData : ISingletonDependency
{
    public Guid TarkanId { get; set; } = Guid.NewGuid();
    public string TarkanName { get; set; } = "Tarkan";
    public Guid TarkanDuduAlbumId { get; set; } = Guid.NewGuid();
    public string TarkanDuduAlbumName { get; set; } = "Dudu";
    public Guid TarkanDuduSongId { get; set; } = Guid.NewGuid();
    public string TarkanDuduSongName { get; set; } = "Dudu";
    public Guid TarkanSong2Id { get; set; } = Guid.NewGuid();
    public string TarkanSong2Name { get; set; } = "Gülümse Kaderine";
    public Guid TarkanSingleAlbumId { get; set; } = Guid.NewGuid();
    public string TarkanSingleSongName { get; set; } = "Geççek";
}