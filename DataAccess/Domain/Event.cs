using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain;
using Domain;

namespace DataAccess.Domain;

public class Event : BaseEntity
{
    public string Name { get; set; }
    
    public DateTime DateTime { get; set; }
    public int Quota { get; set; }
    public string Description { get; set; }
    
    [ForeignKey("Address")]
    public int? AddressId { get; set; }
    public Address Address { get; set; }
    
    [ForeignKey("City")]
    public int? CityId { get; set; }
    public City City { get; set; }
    
    [ForeignKey("Category")]
    public int? CategoryId { get; set; }
    public Category Category { get; set; }
    
    [ForeignKey("ApplicationUser")]
    public int? UserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    
    [ForeignKey("Status")]
    public int? StatusId { get; set; }
    public Status Status { get; set; }
}