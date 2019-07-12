using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using src;
using webapi;
using Xunit;


namespace test
{
    public class RouteParametersTests
    {
        IWebHostBuilder builder = null;
        TestServer testServer = null;

        public RouteParametersTests()
        {
            builder = new WebHostBuilder().UseStartup<Startup>();
            testServer = new TestServer(builder);
        }


        [Fact]
        public async void Test_Route_Parameter_Validation_OK()
        {
            var response = await testServer.CreateRequest("/api/TestValidation/abc/xyz").GetAsync();
            // Assert 
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void Test_Route_Parameter_Validation_Fail()
        {
            var response = await testServer.CreateRequest("/api/TestValidation/abc/xyz123456789").GetAsync();

            var content = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.True(content.Contains(" param2 must be a string with a maximum length of 10"));
        }        
    }
}