using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeBees.ScanToInvest.Vision.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        [EnableCors]
        [HttpPost(nameof(UploadFile))]
        public async Task<string> UploadFile(IFormFile files)
        {
            string systemFileName = files.FileName;
            string blobstorageconnection = "DefaultEndpointsProtocol=https;AccountName=codestorage001;AccountKey=mcFuwUICoVxdr/PfJc5LnYjjxOqTxyltCjYy/gW7irn/1Uxa9MSbfDMMOPAtI0Bzd+myUvOrXHhw+ASt1Cpgzg==;EndpointSuffix=core.windows.net";
            // Retrieve storage account from connection string.    
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);
            // Create the blob client.    
            CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();
            // Retrieve a reference to a container.    
            CloudBlobContainer container = blobClient.GetContainerReference("codestoragecontainer001");
            // This also does not make a service call; it only creates a local object.    
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(systemFileName);
            await using (var data = files.OpenReadStream())
            {
                await blockBlob.UploadFromStreamAsync(data);
            }

            var blobUrl = blockBlob.Uri.AbsoluteUri;
            return blobUrl;
        }
    }
}
