using ConsoleApp3.Models;

loginDetails data = new loginDetails();

DirectoryList obj = new DirectoryList();
string output = obj.GetDirectoryList(data.host, data.name, data.password);
Console.WriteLine(output);

DownloadFile obj2 = new DownloadFile();
string download = obj2.fileDownload(data.host, data.name, data.password);
Console.WriteLine(download);

UploadFile obj3 = new UploadFile();
obj3.FileUpload(data.host, data.name, data.password);

AggregateFunctions obj4 = new AggregateFunctions();
obj4.PerformDataAggregation(output);