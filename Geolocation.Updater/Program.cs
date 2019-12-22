using Geolocation.DAL;
using Geolocation.Main.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;

namespace Geolocation.Updater
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program started!");

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            var services = new ServiceCollection();
            services.AddServices();

            string connection = config.GetConnectionString("Default");
            services.AddDbContext<GeoContext>(options => options.UseNpgsql(connection));
            var serviceProvider = services.BuildServiceProvider();

            var downloadUrl = config.GetValue<string>("Paths:GeoLiteDownload");
            var MD5Url = config.GetValue<string>("Paths:GeoLiteMD5");
            var extacts = config.GetValue<string>("Paths:Extacts");

            var csvCountry = config.GetValue<string>("Paths:csvCountry");
            var csvIPv4 = config.GetValue<string>("Paths:csvIPv4");
            var csvIPv6 = config.GetValue<string>("Paths:csvIPv6");

            var md5Folder = config.GetValue<string>("Paths:MD5");
            var oldMD5Path = config.GetValue<string>("Paths:OldMD5");

            var _dataLoader = serviceProvider.GetService<IDataLoader>();

            while (true)
            {
                Console.WriteLine("Press 'u' if you want to update database.");
                var pressedKey = Console.ReadLine();
                if (pressedKey == "u")
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Update started . . . ");

                        var fileUri = new Uri(downloadUrl);
                        var fileName = Path.GetFileName(fileUri.GetLeftPart(UriPartial.Path));

                        var MD5Uri = new Uri(MD5Url);
                        var MD5Name = Path.Combine(md5Folder, Path.GetFileName(MD5Uri.GetLeftPart(UriPartial.Path)));

                        using (var webClient = new WebClient())
                        {
                            webClient.DownloadFile(fileUri, fileName);
                            ZipFile.ExtractToDirectory(fileName, extacts);
                            File.Delete(fileName);

                            webClient.DownloadFile(MD5Uri, MD5Name);
                        }

                        var folder = new DirectoryInfo(extacts)
                                .GetDirectories()
                                .OrderByDescending(f => f.CreationTime).FirstOrDefault();

                        try
                        {
                            var oldMD5 = "";
                            var newMD5 = "";
                            var check = false;
                            if (!File.Exists(Path.Combine(Directory.GetCurrentDirectory(), md5Folder, oldMD5Path)))
                                check = true;
                            else
                            {
                                oldMD5 = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), md5Folder, oldMD5Path));
                                newMD5 = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), MD5Name));

                                check = oldMD5 != newMD5;
                            }
                            if (check)
                            {
                                var countryPath = Path.Combine(Directory.GetCurrentDirectory(), extacts, folder.Name, csvCountry);
                                var IPv4Path = Path.Combine(Directory.GetCurrentDirectory(), extacts, folder.Name, csvIPv4);
                                var IPv6Path = Path.Combine(Directory.GetCurrentDirectory(), extacts, folder.Name, csvIPv6);

                                _dataLoader.LoadCountries(countryPath);
                                _dataLoader.LoadBlocks(IPv4Path, IPv6Path);

                                Directory.Delete(Path.Combine(Directory.GetCurrentDirectory(), extacts, folder.Name), true);
                                File.Move(Path.Combine(Directory.GetCurrentDirectory(), MD5Name), Path.Combine(Directory.GetCurrentDirectory(), md5Folder, oldMD5Path));
                            }
                            else
                            {
                                Directory.Delete(Path.Combine(Directory.GetCurrentDirectory(), extacts, folder.Name), true);
                                File.Delete(Path.Combine(Directory.GetCurrentDirectory(), MD5Name));

                                Console.WriteLine("Provider does not chang database!");
                            }
                        }
                        catch (Exception ex)
                        {
                            Directory.Delete(Path.Combine(Directory.GetCurrentDirectory(), extacts, folder.Name), true);
                            File.Delete(Path.Combine(Directory.GetCurrentDirectory(), MD5Name));
                            throw ex;
                        }

                        Console.WriteLine("Update completed!");
                        Console.ResetColor();
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Update interrupted!");
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorrect input!");
                    Console.ResetColor();
                }


            }
        }
    }
}
