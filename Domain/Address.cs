using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain;

namespace Domain;

public class Address : BaseEntity
{
    public string Street { get; set; }
    public string AddressDescription { get; set; }
    [ForeignKey("City")]
    public int? CityId { get; set; }
    public virtual City City { get; set; }
}