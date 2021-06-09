namespace ApiAutomationTest.Test.DogApi
{
    static class DogUrl
    {
        public static string BaseUrl { get; } = "https://dog.ceo/api";
        public static string ListAllBreeds { get; } = BaseUrl + "/breeds/list/all";
        public static string RandomAnImage { get; } = BaseUrl + "/breeds/image/random";
        public static string RandomImages { get; } = BaseUrl + "/breeds/image/random/{number-of-image}";
        public static string ImagesByBread { get; } = BaseUrl + "/breed/{bread-name}/images";
        public static string RandomImageByBread { get; } = BaseUrl + "/breed/{bread-name}/images/random";
        public static string RandomMultiImagesByBread { get; } = BaseUrl + "/breed/{bread-name}/images/random/{number-of-image}";
        public static string ListAllSubBreeds { get; } = BaseUrl + "/breed/{bread-name}/list";
        public static string ListAllSubBreedsImages { get; } = BaseUrl + "/breed/{bread-name}/{sub-bread-name}/images";
        public static string RandomSingleSubBreedsImage { get; } = BaseUrl + "/breed/{bread-name}/{sub-bread-name}/images/random";
        public static string RandomMultipleSubBreedsImages { get; } = BaseUrl + "/breed/{bread-name}/{sub-bread-name}/images/random/{number-of-image}";
    }
}
