// See https://aka.ms/new-console-template for more information

using ZipArchivationTests.Services;

SevenZipArchivationService sevenZipArchivationService = new();
sevenZipArchivationService.ZipFileCreateSplitArchive();

Console.ReadLine();