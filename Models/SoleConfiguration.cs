using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class SoleConfiguration
{
    public int Id { get; set; }

    [Required]
    public string ConfigurationName { get; set; }

    public string SoleType { get; set; }           // Thermo sole...
    public string Template { get; set; }           // e.g. Full - Men's City - H1
    public string ShoeSizeRange { get; set; }
    public string ClientCode { get; set; }

    public string EngravingText { get; set; }
    public string ContactEmail { get; set; }

    public bool SendLinkToClient { get; set; }
    public bool AllowPrototypeRequest { get; set; }

    public ICollection<SoleLayer> Layers { get; set; }
}