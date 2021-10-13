using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldJourney.Models;

namespace WorldJourney.Tests.Unit
{
    public class EnvironmentMock : IWebHostEnvironment
    {
        public string WebRootPath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IFileProvider WebRootFileProvider { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IFileProvider ContentRootFileProvider { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ContentRootPath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string EnvironmentName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
    public class DataMock : IData
    {
        public List<City> CityList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public List<City> CityInitializeData()
        {
            throw new NotImplementedException();
        }

        public City GetCityById(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
