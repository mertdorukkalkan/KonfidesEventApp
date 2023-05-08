using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain;

namespace Domain;

public class Address : BaseEntity
{
    public string Street { get; set; }
    public string Description { get; set; }
    [ForeignKey("City")]
    public int? CityId { get; set; }
    public City City { get; set; }
}