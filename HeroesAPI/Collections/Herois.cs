using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HeroesAPI.Collections;

[Table("herois")]
[BsonIgnoreExtraElements]
public class Herois
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("nome")]
    [JsonPropertyName("Nome")]
    public string Nome { get; set; }

    [BsonElement("time")]
    [JsonPropertyName("Time")]
    public string Time { get; set; }

    [BsonElement("idade")]
    public decimal Idade { get; set; }

    [BsonElement("genero")]
    public string Genero { get; set; }

    [BsonElement("habilidades")]
    public List<string> Habilidades { get; set; }

    [BsonElement("caracteristicas")]
    public List<string> Caracteristicas { get; set; }

    [BsonElement("universo")]
    public string Universo { get; set; }
}
