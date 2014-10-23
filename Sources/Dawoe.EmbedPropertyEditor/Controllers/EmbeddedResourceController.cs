namespace Dawoe.OEmbedPickerPropertyEditor.Controllers
{
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;

    /// <summary>
    /// The embedded resource controller.
    /// </summary>   
    public class EmbeddedResourceController : Controller
    {
        /// <summary>
        /// Gets the content of a embedded resource
        /// </summary>
        /// <param name="filename">
        /// The filename of the resource.
        /// </param>
        /// <returns>
        /// The <see cref="FileStreamResult"/>.
        /// </returns>
        public FileStreamResult Resource(string filename)
        {
            var resourceName = Assembly.GetExecutingAssembly().GetManifestResourceNames().ToList().FirstOrDefault(f => f.EndsWith(filename));

            var assembly = this.GetType().Assembly;

            return new FileStreamResult(assembly.GetManifestResourceStream(resourceName), this.GetMimeType(filename));
        }

        /// <summary>
        /// Gets the mimetype based on the filename
        /// </summary>
        /// <param name="filename">
        /// The file name.
        /// </param>
        /// <returns>
        /// The mimetype.
        /// </returns>
        private string GetMimeType(string filename)
        {
            if (filename.EndsWith(".js"))
            {
                return "text/javascript";
            }

            if (filename.EndsWith(".html"))
            {
                return "text/html";
            }

            if (filename.EndsWith(".css"))
            {
                return "text/css";
            }

            return "text";
        }
    }
}
