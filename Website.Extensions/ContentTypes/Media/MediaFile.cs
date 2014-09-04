namespace Zone.UmbracoTemplateEngine.Website.ContentTypes.Media
{
    public class MediaFile : Node
    {
        public int Size { get; set; }

        public string FileExtension { get; set; }

        public string DomainWithUrl { get; set; }
    }
}
