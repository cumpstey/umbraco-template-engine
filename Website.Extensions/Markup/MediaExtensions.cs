namespace Zone.UmbracoTemplateEngine.Website.Markup
{
    using System.Web;
    using System.Web.Mvc;
    using System.Xml.Linq;
    using Zone.Library.FrontEnd.Markup;
    using Zone.UmbracoTemplateEngine.Website.ContentTypes.Media;

    public static class MediaExtensions
    {
        #region Images

        public static IHtmlString DisplayImage(this HtmlHelper helper, Image image, int? width = null, int? height = null, string crop = null, string imageClass = null)
        {
            if (image == null)
            {
                return null;
            }

            string source, w, h;
            var imageWithCrops = image as ImageWithCrops;
            if (crop != null && imageWithCrops != null && imageWithCrops.Crops != null && imageWithCrops.Crops.ContainsKey(crop))
            {
                source = imageWithCrops.Crops[crop];
                w = width.HasValue ? width.ToString() : null;
                h = height.HasValue ? height.ToString() : null;
            }
            else
            {
                source = width.HasValue && height.HasValue ? string.Format("/ImageGen.ashx?image={0}&compression=90&width={1}&height={2}", HttpUtility.UrlEncode(image.Url), width, height) : image.Url;
                w = (width.HasValue ? width : image.Width).ToString();
                h = (height.HasValue ? height : image.Height).ToString();
            }

            return new HtmlString(string.Format(@"<img {0} src=""{1}"" alt=""{2}"" {3} {4} />", helper.Attribute("class", imageClass), source, image.AltText, helper.Attribute("width", w), helper.Attribute("height", h)));
        }

        #endregion

        #region Videos

        public static IHtmlString EmbedVideo(this HtmlHelper input, string videoUrl)
        {
            if (!string.IsNullOrEmpty(videoUrl))
            {
                var requestUrl = string.Empty;
                if (videoUrl.Contains("youtube"))
                {
                    requestUrl = string.Format("http://www.youtube.com/oembed?url={0}&format=xml", HttpUtility.UrlEncode(videoUrl));
                }
                else if (videoUrl.Contains("vimeo"))
                {
                    requestUrl = string.Format("http://vimeo.com/api/oembed.xml?url={0}", HttpUtility.UrlEncode(videoUrl));
                }
                else
                {
                    return null;
                }

                try
                {
                    var xml = XDocument.Load(requestUrl);
                    var html = xml.Element("oembed").Element("html").Value;
                    html = html.Insert(html.IndexOf(">"), " wmode=opaque");
                    return new HtmlString(html);
                }
                catch
                {
                    // silent fail just in case destination server is down
                }
            }

            return null;
        }

        #endregion
    }
}
