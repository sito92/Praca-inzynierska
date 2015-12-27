using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace ClientPanel.Extensions
{
    public class JsonNetResult : JsonResult
    {
        public JsonNetResult()
            : base()
        {

        }

        public JsonNetResult(
            object data,
            JsonRequestBehavior behavior = System.Web.Mvc.JsonRequestBehavior.DenyGet,
            string contentType = "json"
            )
            : base()
        {
            base.Data = data;
            base.ContentType = contentType;
            base.JsonRequestBehavior = behavior;
        }

        public JsonNetResult(
            object data,
            System.Text.Encoding contentEncoding,
            JsonRequestBehavior behavior = System.Web.Mvc.JsonRequestBehavior.DenyGet,
            string contentType = "json"
            )
            : base()
        {
            base.Data = data;
            base.ContentType = contentType;
            base.ContentEncoding = contentEncoding;
            base.JsonRequestBehavior = behavior;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            var response = context.HttpContext.Response;

            response.ContentType = !String.IsNullOrEmpty(ContentType)
                ? ContentType
                : "application/json";

            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;

            var serializedObject = JsonConvert.SerializeObject(Data, Formatting.Indented);
            response.Write(serializedObject);
        }
    }
}