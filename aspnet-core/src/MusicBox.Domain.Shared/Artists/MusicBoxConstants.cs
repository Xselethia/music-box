namespace MusicBox.Artists;

public class MusicBoxConstants
{
    public static class Artist
    {
        public static int NameMaxLength = 128;
        public static int LastNameMaxLength = 128;
        public static int ImageMaxLength = 512;
        public static int BiographyMaxLength = 1024;
    }

    public static class Album
    {
        public static int NameMaxLength = 256;
        public static int CoverImageMaxLength = 512;
    }


    public static class Song
    {
        public static int NameMaxLength = 128;
        public static int SourceLinkMaxLength = 512;
        public static int LyricsMaxLength = int.MaxValue;
        public static int GenreMaxLength = 128;
        public static int MetadataSuffixMaxLength = 8;
    }
}