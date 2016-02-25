using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MvcAngular.Models
{
    public class Geo
    {
        [JsonProperty("lat")]
        public string Latitude { get; set; }
        [JsonProperty("lng")]
        public string Longitude { get; set; }
    }

    public class Address
    {
        [JsonProperty("street")]
        public string Street { get; set; }
        [JsonProperty("suite")]
        public string Suite { get; set; }
        [JsonProperty("cit")]
        public string City { get; set; }
        [JsonProperty("zipcode")]
        public string Zipcode { get; set; }
        [JsonProperty("geo")]
        public Geo Geo { get; set; }
    }

    public class Company
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("catchPhrase")]
        public string CatchPhrase { get; set; }
        [JsonProperty("bs")]
        public string Focus { get; set; }
    }

    public class PersonModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("username")]
        public string Username { get; set; }

        [Required]
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("website")]
        public string Website { get; set; }
        [JsonProperty("company")]
        public Company Company { get; set; }


        static readonly string serviceUri = "http://jsonplaceholder.typicode.com/users";

        public static PersonModel GetPerson(int id)
        {
            string uri = string.Format("{0}/{1}", serviceUri, id);
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetStringAsync(uri).Result;
                return JsonConvert.DeserializeObject<PersonModel>(response);
            }
        }
        public static List<PersonModel> GetPersons()
        {
            string uri = serviceUri;
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetStringAsync(uri).Result;
                return JsonConvert.DeserializeObject<List<PersonModel>>(response);
            }
        }
    }

}