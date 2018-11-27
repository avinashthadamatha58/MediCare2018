using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;


namespace WebApplication1.Controllers
{
    public class HelloApiController: ApiController
    {
        public HttpResponseMessage Get()
        {
            string yourJson = "{\"coord\":{\"lon\":-122.08,\"lat\":37.42},\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04d\"}],\"base\":\"stations\",\"main\":{\"temp\":19.2,\"pressure\":1013,\"humidity\":60,\"temp_min\":18,\"temp_max\":21},\"visibility\":16093,\"wind\":{\"speed\":2.6,\"deg\":130},\"clouds\":{\"all\":90},\"dt\":1538412960,\"sys\":{\"type\":1,\"id\":428,\"message\":0.0055,\"country\":\"US\",\"sunrise\":1538402672,\"sunset\":1538445012},\"id\":5375480,\"name\":\"Mountain View\",\"cod\":200}";
            var response = HttpRequestMessageCommonExtensions.CreateResponse(this.Request, HttpStatusCode.OK);
            response.Content = new StringContent(yourJson, Encoding.UTF8, "application/json");
            return response;
        }
    }
}