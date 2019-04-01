namespace Dawoe.OEmbedPickerPropertyEditor.Models
{
    using System.Web;

    /// <summary>
    /// Represents a item picked in the editor
    /// </summary>
    public class OEmbedItem
    {
        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets the preview.
        /// </summary>
        public IHtmlString Preview { get; set; }
    }
}
