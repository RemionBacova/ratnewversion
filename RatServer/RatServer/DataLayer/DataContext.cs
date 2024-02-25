using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using RatServer.Models.Domain;
using System;
using System.Net;
using System.Security.Authentication;

namespace RatServer.DataLayer
{
    public class DataContext
    {
        public IMongoClient Client { get; }

        public IMongoDatabase Database { get; }

        public IConfiguration Config { get; }
        public DataContext(IOptions<Setting> options, IWebHostEnvironment env, IConfiguration config)
        {
            try
            {
                Config = config;
                MongoClientSettings mongoSettings = MongoClientSettings.FromUrl(
                    new MongoUrl(options.Value.ConnectionString));

                mongoSettings.SslSettings = new SslSettings()
                {
                    EnabledSslProtocols = SslProtocols.Tls12
                };


                Client = new MongoClient(mongoSettings);
                Database = Client.GetDatabase(options.Value.Database);

                ConventionPack pack = new()
                {
                    new CamelCaseElementNameConvention()
                };
                ConventionRegistry.Register("camel case", pack, t => true);

            }
            catch (Exception ex)
            {
                throw new Exception("DB server cannot be accessed. " + ex?.Message + ((int)HttpStatusCode.InternalServerError).ToString());
            }
        }
    }





}