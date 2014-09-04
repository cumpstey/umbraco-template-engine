namespace Zone.UmbracoTemplateEngine.Website.Services
{
    using System;
    using Zone.UmbracoMapper;

    public class ServiceCollection
    {
        #region Constructor

        public ServiceCollection(IUmbracoMapper mapper)
        {
            if (mapper == null)
            {
                throw new ArgumentNullException("mapper");
            }
            
            Mapper = mapper;
        }

        #endregion

        #region Properties

        public IUmbracoMapper Mapper { get; private set; }

        #endregion
    }
}
