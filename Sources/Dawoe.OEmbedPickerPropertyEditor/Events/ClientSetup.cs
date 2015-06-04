namespace Dawoe.OEmbedPickerPropertyEditor.Events
{
    using System.IO;
    using System.Web.Hosting;

    using Dawoe.OEmbedPickerPropertyEditor;

    /// <summary>
    /// The client side files setup.
    /// </summary>
    internal class ClientSetup
    {
        /// <summary>
        /// Configure client files
        /// </summary>
        internal void Configure()
        {
            this.SetupDirectoryStructure();
            this.SetupFiles();
        }

        /// <summary>
        /// Sets up the client side file
        /// </summary>
        private void SetupFiles()
        {
            this.SetupScriptFiles();
            this.SetupViewFiles();
            this.SetupCssFiles();
        }

        /// <summary>
        /// Sets up the css files
        /// </summary>
        private void SetupCssFiles()
        {
            var cssResourceName = string.Concat(Constants.ClientStylesNameSpace, ".styles.css");

            this.ExtractEmbeddedResource(Constants.CssPath, cssResourceName);
        }

        /// <summary>
        /// Sets up the script files
        /// </summary>
        private void SetupScriptFiles()
        {
            var controllerResourceName = string.Concat(Constants.ClientScriptsNameSpace, ".editor.controller.js");

            this.ExtractEmbeddedResource(Constants.ControllerPath, controllerResourceName);
        }

        /// <summary>
        /// Sets up the view files
        /// </summary>
        private void SetupViewFiles()
        {
            var viewResourceName = string.Concat(Constants.ClientViewsNameSpace, ".editor.html");

            this.ExtractEmbeddedResource(Constants.ViewPath, viewResourceName);           
        }

        /// <summary>
        /// Extracts a embedded resource to disk
        /// </summary>
        /// <param name="fileName">
        /// The phyischal file name
        /// </param>
        /// <param name="resourceName">
        /// The embedded resource identifier
        /// </param>
        private void ExtractEmbeddedResource(string fileName, string resourceName)
        {
            if (!File.Exists(HostingEnvironment.MapPath(fileName)))
            {
                using (var file = new FileStream(HostingEnvironment.MapPath(fileName), FileMode.Create))
                {
                    using (var contents = this.GetFileContents(resourceName))
                    {
                        contents.CopyTo(file);
                        contents.Close();
                    }

                    file.Close();
                }
            }
        }

        /// <summary>
        /// Gets the file contents of a embedded resource
        /// </summary>
        /// <param name="resourceName">
        /// The resource name.
        /// </param>
        /// <returns>
        /// The <see cref="Stream"/>.
        /// </returns>
        private Stream GetFileContents(string resourceName)
        {
            var assembly = this.GetType().Assembly;

            return assembly.GetManifestResourceStream(resourceName);
        }

        /// <summary>
        /// Setup directory structure for client side files
        /// </summary>
        private void SetupDirectoryStructure()
        {
            this.CreateDirectory(Constants.PluginPath);           
           
            this.CreateDirectory(Constants.VersionPath);           
        }

        /// <summary>
        /// Checks if a directory exists, and creates it if it doesn't
        /// </summary>
        /// <param name="path">
        /// The relative path
        /// </param>
        private void CreateDirectory(string path)
        {
            var absolutePath = HostingEnvironment.MapPath(path);

            if (!Directory.Exists(absolutePath))
            {
                Directory.CreateDirectory(absolutePath);
            }
        }
    }
}
