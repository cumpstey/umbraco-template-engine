namespace Zone.UmbracoTemplateEngine.Website.ContentTypes
{
    public abstract class Node
    {
        #region Properties

        public int Id { get; set; }

        public string Name { get; set; }

        public string DocumentTypeAlias { get; set; }

        public int SortOrder { get; set; }

        public string Url { get; set; }

        #endregion
    }
}
