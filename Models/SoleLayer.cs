using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class SoleLayer
{
    public int Id { get; set; }

    [Required]
    public string LayerType { get; set; }            // Base, Cover, Inclusion...

    public string ElementName { get; set; }
    public string ElementCode { get; set; }

    public string MaterialName { get; set; }
    public string MaterialCode { get; set; }

    public string Density { get; set; }
    public string Thickness { get; set; }
    public string FinishType { get; set; }

    public string Comment { get; set; }

    public int SoleConfigurationId { get; set; }
    public SoleConfiguration SoleConfiguration { get; set; }
}