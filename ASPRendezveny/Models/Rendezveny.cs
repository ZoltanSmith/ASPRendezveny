using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASPRendezveny.Models;

//[Table("rendezveny")]
public partial class Rendezveny
{
    //[Column("id")]
    public uint Id { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "A résztvevők száma csak pozitív egész lehet.")]
    [Range(1,uint.MaxValue, ErrorMessage = "A résztvevők száma csak pozitív egész lehet itt sem.")]
    [DisplayName("Résztvevők száma:")]
    public uint ResztvevokSzama { get; set; }

    public string? Elnevezes { get; set; }

    public DateTime Idopont { get; set; }

    public bool Torolt { get; set; }

    public override string ToString()
    {
        return $"{Elnevezes ?? String.Empty} {Idopont}-kor {ResztvevokSzama} fővel.";
    }
}
