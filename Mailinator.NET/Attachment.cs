namespace Mailinator
{
    public class Attachment
    {
        public string Filename { get; set; }
        public string FileContentsAsBase64String { get; set; }

        public Attachment(string file, string contents)
        {
            Filename = file;
            FileContentsAsBase64String = contents;
        }
    }
}
