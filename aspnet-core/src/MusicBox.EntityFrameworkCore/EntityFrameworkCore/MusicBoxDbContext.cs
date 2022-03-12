using Microsoft.EntityFrameworkCore;
using MusicBox.Artists;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace MusicBox.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class MusicBoxDbContext :
    AbpDbContext<MusicBoxDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public virtual DbSet<Artist> Artists { get; set; }
    // public virtual DbSet<Album> Albums { get; set; }
    // public virtual DbSet<Song> Songs { get; set; }
    public virtual DbSet<SongDetail> SongDetails { get; set; }

    public MusicBoxDbContext(DbContextOptions<MusicBoxDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureIdentityServer();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        builder.Entity<Artist>(b =>
        {
            b.ToTable(MusicBoxConsts.DbTablePrefix + "Artists", MusicBoxConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(q => q.Name).HasMaxLength(MusicBoxConstants.Artist.NameMaxLength).IsRequired();
            b.Property(q => q.LastName).HasMaxLength(MusicBoxConstants.Artist.LastNameMaxLength);
            b.Property(q => q.Image).HasMaxLength(MusicBoxConstants.Artist.ImageMaxLength);
            b.Property(q => q.Biography).HasMaxLength(MusicBoxConstants.Artist.BiographyMaxLength);

            b.Metadata.FindNavigation(nameof(Artist.Albums))?.SetPropertyAccessMode(PropertyAccessMode.Field);

            b.HasIndex(q => q.Name);
            b.HasIndex(q => q.LastName);
        });
        
        builder.Entity<Album>(b =>
        {
            b.ToTable(MusicBoxConsts.DbTablePrefix + "Albums", MusicBoxConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(q => q.Name).HasMaxLength(MusicBoxConstants.Album.NameMaxLength).IsRequired();
            b.Property(q => q.ReleaseYear).IsRequired();
            b.Property(q => q.IsSingle).IsRequired();
            b.Property(q => q.CoverImage).HasMaxLength(MusicBoxConstants.Album.CoverImageMaxLength);

            b.Metadata.FindNavigation(nameof(Album.Songs))?.SetPropertyAccessMode(PropertyAccessMode.Field);

            b.HasIndex(q => q.Name);
            b.HasIndex(q => q.ReleaseYear);
        });
        
        builder.Entity<Song>(b =>
        {
            b.ToTable(MusicBoxConsts.DbTablePrefix + "Songs", MusicBoxConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(q => q.Name).HasMaxLength(MusicBoxConstants.Song.NameMaxLength).IsRequired();
            b.Property(q => q.SourceLink).HasMaxLength(MusicBoxConstants.Song.SourceLinkMaxLength).IsRequired();
            b.Property(q => q.Genre).HasMaxLength(MusicBoxConstants.Song.GenreMaxLength).IsRequired();
            b.Property(q => q.Lyrics).HasMaxLength(MusicBoxConstants.Song.LyricsMaxLength);

            b.OwnsOne(q => q.MetaData)
                .Property(q => q.Suffix).HasMaxLength(MusicBoxConstants.Song.MetadataSuffixMaxLength)
                .HasColumnName("SongSuffix");
            b.OwnsOne(q => q.MetaData)
                .Property(q => q.LengthInSeconds)
                .HasColumnName("Length");
            
            b.HasIndex(q => q.Name);
            b.HasIndex(q => q.Genre);
        });

        builder.Entity<SongDetail>(b =>
        {
            b.HasNoKey().ToView("View_SongDetails");
        });
    }
}