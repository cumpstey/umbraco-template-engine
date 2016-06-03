# Umbraco Template Engine

## Purpose

The purposes of Umbraco Template Engine are:

1. To make it easier to reuse the same content items in different places in a website.
2. To display multiple content types with different templates in a single list.
3. To allow content items to be embedded in rich text areas.

### Example website

The project contains an example website illustrating each usage, as:

- Mixed content in a 'highlights' list on the homepage
- Content of different types embedded in rich text areas

The example website uses Umbraco 7, but the Template Engine is also compatible with Umbraco 6.

CMS credentials for example website: admin / password

### Content reuse

On virtually every website, a single content item will be rendered in multiple places with different templates. An article, for example, could be rendered, differently each time, as:

- a page in its own right
- an item in a section landing page
- an item in search results
- highlighted content in a banner
- referenced by another article

The Template Engine makes this kind of content reuse easy, without having to build different view models and complex logic for each.

### Multiple templates in a single list

Consider a **ListingPage** containing **Article**, **BlogPost**, **PressRelease** content types. Each item contains slightly different information, and is rendered with a different template:

- **Article**: image, title, description
- **BlogPost**: title, description, author, publication date
- **PressRelease**: title, description, publication date

The Template Engine makes it simple to render articles, blog posts and press releases with different templates in a single list.

Using the MVC approach enabled by the [Umbraco Mapper project](https://github.com/AndyButland/UmbracoMapper "Umbraco Mapper project"), one approach would be to have an `IEnumerable<IExcerpt>` property on the `ListingPageModel`, with `ArticleModel`, `BlogModel` and `PressReleaseModel` each implementing `IExcerpt`. This tends to make for complicated controller methods, and also a certain amount of logic in views.

The Template Engine takes the alternative approach of passing an `IEnumerable<int>` to the view, with a template defined for each content type which can be rendered. This makes for far less logic in each controller action method; also it allows caching on a modular basis rather than simply on the page as a whole.

### Embedding content in a rich text editor

The Template Engine enables any content to be referenced, and rendered with a suitable template, in rich text content. The use of this could be:

- Embedding a video or image from a resource library.
- Displaying details of an article.

The project contains a macro partial which can be used in a macro with a single **ContentId** property. Any content item can be selected, and will be rendered with a template tagged "ContentMacro".

It's possible to specify different templates for backoffice and website rendering, by tagging a template "Preview" - particularly useful with an embedded video, which you really don't want playing in a rich text editor!

If debugging is enabled (`system.web/compilation/@debug`) The macro will display an error message if the referenced content no longer exists, or if it doesn't have an appropriate template defined. If debugging is disabled (as on a live website) the content will simply not be displayed.

## Examples

### Declaring a template

Add the `TemplateDescriptorAttribute` to an action method on a content type controller, with a value in the **Tags** property.

```cs
public class ArticleController : SurfaceController
{
    [TemplateDescriptor(Tags = new[] { "ChildListing" })]
    public PartialViewResult ChildListing()
    {
        var model = // build model
        return PartialView(model);
    }
}
```

### Retrieving data

The `CurrentPage` property of the controller still returns the current Umbraco page. The Template Engine adds a `GetCurrentData()` extension method to `Umbraco.Web.Mvc.SurfaceController` which returns the `IPublishedContent` for the item which should be rendered in the template.

The example website content has a base controller with a `CurrentData` property:

```cs
protected IPublishedContent CurrentData
{
    get
    {
        if (!_currentDataDetected)
        {
            _currentData = this.GetCurrentData();
            _currentDataDetected = true;
        }

        return _currentData ?? CurrentPage;
    }
}
```

The recommendation is to add this property to the base controller of a project, and then _always_ use `CurrentData`, _never_ `CurrentPage`, unless there's a specific reason for requiring the current page when it's different from the item being rendered.

### Calling a template from Razor

Include the `Zone.UmbracoTemplateEngine` namespace in your views.

```
@using Zone.UmbracoTemplateEngine
```

or, in the web.config:

```xml
<add namespace="Zone.UmbracoTemplateEngine" />
```

Then call the HtmlHelper extension method, passing in one or more tags to identify the template required; the controller is identified by the content type of the content passed to the method.

```
@Html.Template(1234, "ChildListing")
@Html.Template(1234, new[] { "ChildListing", "Preview" }
```

The template which matches the greatest number of tags (at least one match is required) is rendered. So given the situation below, **Template2** will be rendered.

```cs
[TemplateDescriptor(Tags = new[] { "Tag1" })]
public PartialViewResult Template1() {...}

[TemplateDescriptor(Tags = new[] { "Tag2", "Tag3" })]
public PartialViewResult Template2() {...}

[TemplateDescriptor(Tags = new[] { "Tag1", "Tag3" })]
public PartialViewResult Template3() {...}
```
```
@Html.Template(1234, new[] { "Tag2", "Tag3" }
```

### Templates for rich text

For content referenced in a rich text area, **Template1** will be rendered on the front end, and **Template1Preview** in the backoffice.

```cs
[TemplateDescriptor(Tags = new[] { "ContentMacro" })]
public PartialViewResult Template1() {...}

[TemplateDescriptor(Tags = new[] { "ContentMacro", "Preview" })]
public PartialViewResult Template1Preview() {...}
```

The preview template is optional - in this case, **Template1** would be rendered both on the website and in the backoffice. The same template can be used for both rich text rendering and calling from `@Html.Template`.

```cs
[TemplateDescriptor(Tags = new[] { "ContentMacro", "Tag1" })]
public PartialViewResult Template1() {}
```
