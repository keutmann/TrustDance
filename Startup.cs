using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Microsoft.Owin.StaticFiles.ContentTypes;
using Owin;

namespace TrustDance
{
    public class Startup
    {
        public class CustomContentTypeProvider : FileExtensionContentTypeProvider
        {
            public CustomContentTypeProvider()
            {
            }
        }

        public void Configuration(IAppBuilder app)
        {
#if DEBUG
            app.UseErrorPage();
            var physicalFileSystem = new PhysicalFileSystem(@".\..\..\www");
#else
            var physicalFileSystem = new PhysicalFileSystem(@".\www");
#endif
            var options = new FileServerOptions()
            {
                RequestPath = PathString.Empty,
                FileSystem = physicalFileSystem,
            };

            options.StaticFileOptions.FileSystem = physicalFileSystem;
            options.StaticFileOptions.ContentTypeProvider = new CustomContentTypeProvider();

            app.UseFileServer(options);
        }
    }
}
