namespace Zone.UmbracoTemplateEngine.Website.ContentTypes.Media
{
    using System.Collections.Generic;

    public class ImageWithCrops : Image
    {
        public IDictionary<string, string> Crops { get; set; }
    }
}
