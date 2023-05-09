using System.ComponentModel.DataAnnotations;
using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Domain;

public class City : BaseEntity
{
    public string CityName { get; set; }
}