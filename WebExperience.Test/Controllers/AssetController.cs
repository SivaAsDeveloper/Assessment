using Newtonsoft.Json;
using SharedDTO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebExperience.Test.Models;

namespace WebExperience.Test.Controllers
{
  
    public class AssetController : ApiController
    {
        // TODO
        // Create an API controller via REST to perform all CRUD operations on the asset objects created as part of the CSV processing test
        // Visualize the assets in a paged overview showing the title and created on field
        // Clicking an asset should navigate the user to a detail page showing all properties
        // Any data repository is permitted
        // Use a client MVVM framework

        private readonly AssetContext assetContext;
        public AssetController()
        {
            assetContext = new AssetContext();
        }
        [HttpGet]
        public HttpResponseMessage GetAssets()
        {
            return Request.CreateResponse<List<Asset>>(HttpStatusCode.OK, assetContext.Assets.ToList());
        }
        [HttpGet]
        public HttpResponseMessage GetAsset(string assetid)
        {
            return Request.CreateResponse<Asset>(HttpStatusCode.OK, assetContext.Assets.ToList().Where(x => x.AssetId == new System.Guid(assetid)).FirstOrDefault());
        }
        [HttpPost]
        public HttpResponseMessage ManageAsset([FromBody]Asset asset)
        {
            if (asset.AssetId != null && asset.AssetId.ToString()!= "00000000-0000-0000-0000-000000000000")
            {
                var assetsource = assetContext.Assets.Where(x => x.AssetId == asset.AssetId).FirstOrDefault();
                if (assetsource == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    assetsource.Country = asset.Country;
                    assetsource.CreatedBy = asset.CreatedBy;
                    assetsource.Description = asset.Description;
                    assetsource.Email = asset.Email;
                    assetsource.FileName = asset.FileName;
                    assetsource.MIMEType = asset.MIMEType;
                }
            }
            else
            {
                asset.AssetId = System.Guid.NewGuid();
                assetContext.Assets.Add(asset);
            }
            assetContext.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpDelete]
        [Route("RemoveAsset")]
        public HttpResponseMessage RemoveAsset(Asset asset)
        {
            assetContext.Assets.Remove(asset);
            var recordsremoved = assetContext.SaveChanges();
            if (recordsremoved == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
