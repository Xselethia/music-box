using System;
using System.Threading.Tasks;
using MusicBox.Artists;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace MusicBox;

public class MusicBoxDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly ISongDetailRepository _songDetailRepository;
    private readonly IRepository<Artist, Guid> _artistRepository;
    private readonly IGuidGenerator _generatorGenerator;

    public MusicBoxDataSeedContributor(ISongDetailRepository songDetailRepository,
        IGuidGenerator generatorGenerator,
        IRepository<Artist, Guid> artistRepository)
    {
        _songDetailRepository = songDetailRepository;
        _generatorGenerator = generatorGenerator;
        _artistRepository = artistRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        await CreateSongViewAsync();
        await SeedSampleTarkanDataAsync();
    }

    private async Task SeedSampleTarkanDataAsync()
    {
        if (await _artistRepository.GetCountAsync() > 0)
        {
            return;
        }

        var artist = await _artistRepository.InsertAsync(new Artist(_generatorGenerator.Create(), "Tarkan"));
        var duduAlbum = artist.AddAlbum(_generatorGenerator.Create(), "Dudu", 2003, false);
        duduAlbum.AddSong(_generatorGenerator.Create(), "Dudu",
            "https://music.youtube.com/watch?v=zfkzSJHKdhg",
            SongGenres.Pop, new SongMetaData(277));
        duduAlbum.AddSong(_generatorGenerator.Create(), "Gülümse Kaderine",
            "https://music.youtube.com/watch?v=YCMPgYO_-VA",
            SongGenres.Pop, new SongMetaData(269));
        artist.AddSingleSong(_generatorGenerator.Create(), 2022, "Geççek",
            "https://music.youtube.com/watch?v=EFdhMJby7Ts",
            SongGenres.Pop, new SongMetaData(195));

        await _artistRepository.InsertAsync(artist, true);
    }

    private async Task CreateSongViewAsync()
    {
        await _songDetailRepository.CreateViewAsync();
    }
}