# Umbraco Template Engine

## Background

Umbraco Template Engine has been developed to make it easier to reuse the same content items in different places in a website; and to display different content types with different templates in a list containing multiple content types.

Consider a **ListingPage** containing **Article**, **Blog**, **PressRelease** content types. Each item contains slightly different information:

- **Article**: title, description
- **Blog**: title, description, author, publication date
- **PressRelease**: title, description, publication date

Using the MVC approach enabled by the [Umbraco Mapper project](https://github.com/AndyButland/UmbracoMapper "Umbraco Mapper project"), one approach would be to have an `IEnumerable<IExcerpt>` property on the `ListingPageModel`, with `ArticleModel`, `BlogModel` and `PressReleaseModel` each implementing `IExcerpt`. This tends to make for complicated controller methods, and also a certain amount of logic in views.

The Template Engine takes the alternative approach of passing an `IEnumerable<int>` to the view, with a template defined for each content type which can be rendered. This makes for far less logic in each controller action method; also it allows caching on a modular basis rather than simply on the page as a whole.

## Examples

### Declaring a template

Add the `TemplateDescriptorAttribute` to an action method on a content type controller, with a value in the **Tags** property.

    public class ArticleController : SurfaceController
    {
        [TemplateDescriptor(Tags = new[] { "ChildListing" })]
        public PartialViewResult ChildListing()
        {
            var model = // build model
            return PartialView(model);
        }
	}

## Calling a template

Include the `Zone.UmbracoTemplateEngine` namespace in your views.

	@using Zone.UmbracoTemplateEngine

or, in the web.config:

    <add namespace="Zone.UmbracoTemplateEngine" />

Then call the HtmlHelper extension method, passing in one or more tags to identify the template required; the controller is identified by the content type of the content passed to the method.

	@Html.Template(1234, "ChildListing")
	@Html.Template(1234, new[] { "ChildListing", "Preview" }

The template which matches the greatest number of tags (at least one match is required) is rendered. So given the situation below, **Template2** will be rendered.

    [TemplateDescriptor(Tags = new[] { "Tag1" })]
    public PartialViewResult Template1() {}
    [TemplateDescriptor(Tags = new[] { "Tag2, Tag3" })]
    public PartialViewResult Template2() {}
    [TemplateDescriptor(Tags = new[] { "Tag1", "Tag3" })]
    public PartialViewResult Template3() {}

	@Html.Template(1234, new[] { "Tag2", "Tag3" }

## Including content in a rich text editor

The project also contains a macro partial which can be used in a macro with a single **ContentId** property, to include content with suitable templates in a rich text editor.


