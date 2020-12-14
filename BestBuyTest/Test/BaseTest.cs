using BestBuyApp.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BestBuyTest.Test
{
    [TestClass]
    public class BaseTest
    {
        public RequestFactory requestFactory;


        public string productResource;
        public string endpointUrl;
        public string currentSolutionDirectory;
        public string currentProjectDirectory;

        [ClassInitialize]
        public void PreSetup()
        {
            


        }

        [TestInitialize]
        public void Setup()
        {
            requestFactory = new RequestFactory();

            endpointUrl = "http://ec2-3-129-89-35.us-east-2.compute.amazonaws.com/:3030";
            productResource = "products";

            string currentWorkingDirectory = Environment.CurrentDirectory;

            currentProjectDirectory = Directory.GetParent(currentWorkingDirectory).Parent.Parent.FullName;

            currentSolutionDirectory = Directory.GetParent(currentWorkingDirectory).Parent.Parent.Parent.FullName;

            Console.WriteLine("Setup");
        }

        [TestCleanup]
        public void Cleanup()
        {
            Console.WriteLine("Cleanup");
        }

        [ClassCleanup]
        public void PostCleanup()
        {
            Console.WriteLine("Post-Cleanup");
        }
    }
}
