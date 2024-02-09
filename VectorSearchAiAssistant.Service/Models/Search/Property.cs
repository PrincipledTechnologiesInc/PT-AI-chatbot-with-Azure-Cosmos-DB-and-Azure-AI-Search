using Azure.Search.Documents.Indexes;
using VectorSearchAiAssistant.SemanticKernel.TextEmbedding;

namespace VectorSearchAiAssistant.Service.Models.Search
{

    public class Property : EmbeddedEntity
    {
        [SearchableField(IsKey = true, IsFilterable = true)]
        public string id { get; set; }
        [SimpleField]
        public string name { get; set; }
        [SearchableField(IsFilterable = true, IsFacetable = true)]
        [EmbeddingField(Label = "Property category")]
        public string category { get; set; }
        [SimpleField]
        [EmbeddingField(Label = "Property country")]
        public string country { get; set; }
        [SimpleField]
        [EmbeddingField(Label = "Property zipcode")]
        public string zipcode { get; set; }
        [SimpleField]
        [EmbeddingField(Label = "Property state")]
        public string state { get; set; }
        [SimpleField]
        [EmbeddingField(Label = "Property city")]
        public string city { get; set; }
        [SimpleField]
        [EmbeddingField(Label = "Property neighborhood")]
        public string neighborhood { get; set; }
        [SimpleField]
        [EmbeddingField(Label = "Property description")]
        public string description { get; set; }
        [SimpleField]
        [EmbeddingField(Label = "Property type")]
        public string type { get; set; }
        [SimpleField]
        [EmbeddingField(Label = "Property accomodates")]
        public double accomodates { get; set; }
        [SimpleField]
        [EmbeddingField(Label = "Property daily price")]
        public double dailyprice { get; set; }
        // [SimpleField]
        // [EmbeddingField(Label = "Property amenities")]
        // public List<Amenity> amenities { get; set; }

        // public Property(string id, string name, string category, string country, string zipcode, string state, string city, string neighborhood, string description, string type, double accomodates, double dailyprice, List<Amenity> amenities, float[]? vector = null)
        public Property(string id, string name, string category, string country, string zipcode, string state, string city, string neighborhood, string description, string type, double accomodates, double dailyprice, float[]? vector = null)
        {
            this.id = id;
            this.name = name;
            this.category = category;
            this.country = country;
            this.zipcode = zipcode;
            this.state = state;
            this.city = city;
            this.neighborhood = neighborhood;
            this.description = description;
            this.type = type;
            this.accomodates = accomodates;
            this.dailyprice = dailyprice;
           //  this.amenities = amenities;
            this.vector = vector;
        }

        public Property()
        {
        }
    }

    // public class Amenity
    // {
    //     [SimpleField]
    //     public string id { get; set; }
    //     [SimpleField]
    //     [EmbeddingField(Label = "Property amenity")]
    //     public string amenity { get; set; }

    //     public Amenity(string id, string amenity)
    //     {
    //         this.id = id;
    //         this.amenity = amenity;
    //     }
    // }
}
