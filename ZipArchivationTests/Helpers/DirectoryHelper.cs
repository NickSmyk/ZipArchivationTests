namespace ZipArchivationTests.Helpers;

public static class DirectoryHelper
{
    public static DirectoryInfo CreateNewDirectory(string path)
    {
        string fullPath = Path.GetFullPath(path);
        
        if (Directory.Exists(fullPath))
        {
            Directory.Delete(fullPath, recursive: true);
        }
        
        return Directory.CreateDirectory(fullPath);
    }
}