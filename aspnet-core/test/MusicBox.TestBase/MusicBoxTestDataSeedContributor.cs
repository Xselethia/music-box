using System;
using System.Threading.Tasks;
using MusicBox.Artists;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace MusicBox;

public class MusicBoxTestDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly TestData _testData;
    private readonly IRepository<Artist, Guid> _repository;
    private readonly ISongDetailRepository _songDetailRepository;
    private readonly IUnitOfWorkManager _unitOfWorkManager;

    public MusicBoxTestDataSeedContributor(IRepository<Artist, Guid> repository, TestData testData,
        ISongDetailRepository songDetailRepository, IUnitOfWorkManager unitOfWorkManager)
    {
        _repository = repository;
        _testData = testData;
        _songDetailRepository = songDetailRepository;
        _unitOfWorkManager = unitOfWorkManager;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        // await SeedDataAsync(context);
    }

    private async Task SeedDataAsync(DataSeedContext context)
    {
        var artist = await _repository.InsertAsync(new Artist(_testData.TarkanId, _testData.TarkanName));
        var duduAlbum = artist.AddAlbum(_testData.TarkanDuduAlbumId, _testData.TarkanDuduAlbumName, 2003, false,
            "no cover");
        duduAlbum.AddSong(_testData.TarkanDuduSongId, _testData.TarkanDuduSongName,
            "https://music.youtube.com/watch?v=zfkzSJHKdhg",
            SongGenres.Pop, new SongMetaData( 277));
        duduAlbum.AddSong(_testData.TarkanSong2Id, _testData.TarkanSong2Name,
            "https://music.youtube.com/watch?v=YCMPgYO_-VA",
            SongGenres.Pop, new SongMetaData( 269));
        artist.AddSingleSong(_testData.TarkanSingleAlbumId, 2022, _testData.TarkanSingleSongName,
            "https://music.youtube.com/watch?v=EFdhMJby7Ts",
            SongGenres.Pop, new SongMetaData(195));

        await _repository.InsertAsync(artist, true);
            
    }
}