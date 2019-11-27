using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Xml;

namespace HotelVision_CoreMvc.Services.Interfaces
{
    public interface IServiceUpload<T> where T : class
    {
        public void UploadCsv(IFormFile file);
        public void UploadXml(IFormFile file);
        List<T> ParseXmlNodes(XmlNodeList xmlNodes);
    }
}
