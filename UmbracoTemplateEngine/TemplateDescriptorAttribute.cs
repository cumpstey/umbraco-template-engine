namespace Zone.UmbracoTemplateEngine
{
    using System;

    public class TemplateDescriptorAttribute : Attribute
    {
        public string[] Tags { get; set; }
    }
}
