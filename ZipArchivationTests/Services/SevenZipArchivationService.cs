using System.Text;
using ZipArchivationTests.Helpers;
using ZipFile = Ionic.Zip.ZipFile;

namespace ZipArchivationTests.Services;

public class SevenZipArchivationService
{
    public string ZipFileCreateSplitArchive()
    {
        //withoud this russian laguage won't work
        using (ZipFile zip = new(Encoding.UTF8))
        {
            DirectoryInfo directory = new(PathHelper.PathToTheFiles);
            string tempFolderPath = directory.FullName;
            zip.AddDirectory(tempFolderPath);
            zip.Comment = "This zip was created at " + System.DateTime.Now.ToString("G") ;
            zip.MaxOutputSegmentSize = 100*1024 ; // 100k segments
            string fileName = Guid.NewGuid() + ".zip";
            string resultFilePath = Path.Combine(PathHelper.ResultPathFolder, fileName);
            
            zip.Save(resultFilePath);

            int segmentsCreated = zip.NumberOfSegmentsForMostRecentSave ;
            return resultFilePath;
        }
    }
}