namespace BitsOrchestra_Test.Models.ViewModels
{
    public record FileUploadProgress(string FileName, long Size)
    {
        public long UploadedBytes { get; set; }
        public double UploadedPercentage =>
            (double)UploadedBytes / (double)Size * 100d;
    }
}
