using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wheres_My_Well.Models;
using Wheres_My_Well.Properties;

namespace Wheres_My_Well.Services
{
    public class NorthDakotaWellService
    {
        public async Task<List<Well>> GetWells()
        {
            var key = Resources.AzureStorageKey;
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(key);

            CloudFileClient fileClient = storageAccount.CreateCloudFileClient();

            CloudFileShare share = fileClient.GetShareReference("welldata");
            if (await share.ExistsAsync())
            {
                CloudFileDirectory rootDir = share.GetRootDirectoryReference();
                var fileList = await rootDir.ListFilesAndDirectoriesSegmentedAsync(new FileContinuationToken());
                var wellFile = fileList.Results.Last() as CloudFile;
                var wellString = await wellFile.DownloadTextAsync();
                var wells = JArray.Parse(wellString).ToObject<List<Well>>();
                return wells;
            }
            return new List<Well>();
        }
    }
}
