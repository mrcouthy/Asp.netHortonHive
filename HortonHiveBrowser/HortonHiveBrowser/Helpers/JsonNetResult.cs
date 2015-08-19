using System;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HortonHiveBrowser.Helpers
{
    /// <summary>
    ///     Simple Json Result that implements the Json.NET serialiser offering more versatile serialisation
    /// </summary>
    public class JsonNetResult : ActionResult
    {
        #region Constructors and Destructors

        public JsonNetResult()
        {
        }

        public JsonNetResult(object responseBody)
        {
            ResponseBody = responseBody;
            Settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        #endregion

        #region Public Properties

        /// <summary>Gets or sets the encoding of the response</summary>
        public Encoding ContentEncoding { get; set; }

        /// <summary>Gets or sets the content type for the response</summary>
        public string ContentType { get; set; }

        /// <summary>Gets or sets the body of the response</summary>
        public object ResponseBody { get; set; }

        /// <summary>Gets or sets the serialiser settings</summary>
        public JsonSerializerSettings Settings { get; set; }

        #endregion

        #region Properties

        /// <summary>Gets the formatting types depending on whether we are in debug mode</summary>
        private Formatting Formatting
        {
            get
            {
                //return Debugger.IsAttached ? Formatting.Indented : Formatting.None;
                return Formatting.None;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Serialises the response and writes it out to the response object
        /// </summary>
        /// <param name="context">The execution context</param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            HttpResponseBase response = context.HttpContext.Response;

            // set content type 
            response.ContentType = !string.IsNullOrEmpty(ContentType) ? ContentType : "application/json";

            // set content encoding 
            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }

            if (ResponseBody != null)
            {
                response.Write(JsonConvert.SerializeObject(ResponseBody, Formatting, Settings));
            }
        }

        #endregion
    }
}