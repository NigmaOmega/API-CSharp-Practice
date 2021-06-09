using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAutomationTest.Test.DogApi
{
    public static class ApiCallingCenter
    {
        public static IRestResponse GetAllImagesByBreed(string breadName)
        {
            Dictionary<string, object> pathParameter = new Dictionary<string, object>();
            pathParameter.Add("bread-name", breadName);

            return ApiRest.Call(RestSharp.Method.GET, DogUrl.ImagesByBread, null, null, null, pathParameter);
        }

        public static IRestResponse RandomImageFromABreedCollection(string breadName)
        {
            Dictionary<string, object> pathParameter = new Dictionary<string, object>();
            pathParameter.Add("bread-name", breadName);

            return ApiRest.Call(RestSharp.Method.GET, DogUrl.RandomImageByBread, null, null, null, pathParameter);
        }

        public static IRestResponse RandomMultiImagesFromABreedCollection(string breadName,string numberOfImages)
        {
            Dictionary<string, object> pathParameter = new Dictionary<string, object>();
            pathParameter.Add("bread-name", breadName);
            pathParameter.Add("number-of-image", numberOfImages);

            return ApiRest.Call(RestSharp.Method.GET, DogUrl.RandomMultiImagesByBread, null, null, null, pathParameter);
        }

        public static IRestResponse GetListAllSubBreads(string breadName)
        {
            Dictionary<string, object> pathParameter = new Dictionary<string, object>();
            pathParameter.Add("bread-name", breadName);

            return ApiRest.Call(RestSharp.Method.GET, DogUrl.ListAllSubBreeds, null, null, null, pathParameter);
        }

        public static IRestResponse GetListAllSubBreadsImages(string breadName, string subBreadName)
        {
            Dictionary<string, object> pathParameter = new Dictionary<string, object>();
            pathParameter.Add("bread-name", breadName);
            pathParameter.Add("sub-bread-name", subBreadName);

            return ApiRest.Call(RestSharp.Method.GET, DogUrl.ListAllSubBreedsImages, null, null, null, pathParameter);
        }

        public static IRestResponse GetSingleRandomImageFromASubBreadCollection(string breadName, string subBreadName)
        {
            Dictionary<string, object> pathParameter = new Dictionary<string, object>();
            pathParameter.Add("bread-name", breadName);
            pathParameter.Add("sub-bread-name", subBreadName);

            return ApiRest.Call(RestSharp.Method.GET, DogUrl.RandomSingleSubBreedsImage, null, null, null, pathParameter);
        }
    }
}
