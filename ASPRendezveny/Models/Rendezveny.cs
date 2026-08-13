using System.ComponentModel.DataAnnotations;

namespace ASPRendezveny.Models;

//[Table("rendezveny")]
public partial class Rendezveny
{
    //[Column("id")]
    public uint Id { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "")]
    public uint ResztvevokSzama { get; set; }

    public string? Elnevezes { get; set; }

    public DateTime Idopont { get; set; }

    public bool Torolt { get; set; }
}
