namespace Zone.UmbracoTemplateEngine.Website.Mapping
{
    using System.Collections.Generic;
    using Umbraco.Core.Models;
    using Umbraco.Web;
    using Zone.UmbracoMapper;
    using Zone.UmbracoTemplateEngine.Website.ContentTypes.Media;
    using MediaFile = Zone.UmbracoTemplateEngine.Website.ContentTypes.Media.MediaFile;

    public static class MediaMapper
    {
        #region Custom mappings

        public static object GetMediaFile(IUmbracoMapper mapper, IPublishedContent contentToMapFrom, string propertyName, bool recursive)
        {
            var umbracoHelper = new UmbracoHelper(UmbracoContext.Current);
            var mediaModel = umbracoHelper.TypedMedia(contentToMapFrom.GetPropertyValue<int>(propertyName));
            if (mediaModel == null)
            {
                return null;
            }

            var mediaFile = new MediaFile();
            MapMediaFileProperties(mediaFile, mediaModel, mapper.AssetsRootUrl);

            return mediaFile;
        }

        public static object GetImage(IUmbracoMapper mapper, IPublishedContent contentToMapFrom, string propertyName, bool recursive)
        {
            var umbracoHelper = new UmbracoHelper(UmbracoContext.Current);
            var mediaModel = umbracoHelper.TypedMedia(contentToMapFrom.GetPropertyValue<int>(propertyName));
            if (mediaModel == null)
            {
                return null;
            }

            var image = new Image();
            MapMediaFileProperties(image, mediaModel, mapper.AssetsRootUrl);
            MapImageProperties(image, mediaModel);

            return image;
        }

        public static object GetImageWithCrops(IUmbracoMapper mapper, IPublishedContent contentToMapFrom, string propertyName, bool recursive)
        {
            var umbracoHelper = new UmbracoHelper(UmbracoContext.Current);
            //var mediaModel = umbracoHelper.TypedMedia(contentToMapFrom.GetPropertyValue<int>(propertyName));
            var mediaModel = contentToMapFrom.GetPropertyValue<IPublishedContent>(propertyName);
            if (mediaModel == null)
            {
                return null;
            }

            var image = new ImageWithCrops();
            MapMediaFileProperties(image, mediaModel, mapper.AssetsRootUrl);
            MapImageProperties(image, mediaModel);
            MapImageWithCropsProperties(image, mediaModel);

            return image;
        }

        #endregion

        #region Mapping helpers

        private static void MapMediaFileProperties(MediaFile mediaFile, IPublishedContent mediaModel, string rootUrl)
        {
            mediaFile.Id = mediaModel.Id;
            mediaFile.Name = mediaModel.Name;
            mediaFile.Url = mediaModel.Url;
            mediaFile.DocumentTypeAlias = mediaModel.DocumentTypeAlias;
            mediaFile.DomainWithUrl = rootUrl + mediaModel.Url;

            mediaFile.Size = mediaModel.GetPropertyValue<int>("umbracoBytes");
            mediaFile.FileExtension = mediaModel.GetPropertyValue<string>("umbracoExtension");
        }

        private static void MapImageProperties(Image image, IPublishedContent mediaModel)
        {
            image.Width = mediaModel.GetPropertyValue<int>("umbracoWidth");
            image.Height = mediaModel.GetPropertyValue<int>("umbracoHeight");
            image.AltText = mediaModel.GetPropertyValue<string>("altText") ?? mediaModel.Name;
        }

        private static void MapImageWithCropsProperties(ImageWithCrops image, IPublishedContent mediaModel)
        {
            try
            {
                image.Crops = new Dictionary<string, string>();
                foreach (var crop in mediaModel.GetPropertyValue<dynamic>("umbracoFile").crops)
                {
                    string alias = crop.alias;
                    image.Crops.Add(alias, mediaModel.GetCropUrl(alias));
                }
            }
            catch
            {
                image.Crops = null;
            }
        }

        #endregion
    }
}
