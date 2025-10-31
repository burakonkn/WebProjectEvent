using System.ComponentModel.DataAnnotations;

namespace WebProjectEvent.Models;

public class AdminEventEditModel
{
    public int EventId { get; set; }


    [Display(Name = "Etkinlik Adı *")]
    [Required(ErrorMessage = "Lütfen Etkinlik Adı alanını doldurunuz!")]
    [StringLength(100)]
    public string EventName { get; set; } = null!;

    [Required(ErrorMessage = "Lütfen Açıklama alanını doldurunuz!")]
    [Display(Name = "Açıklama *")]
    [StringLength(2000)]
    public string EventDescription { get; set; } = null!;

    [Required(ErrorMessage = "Lütfen Fİyat alanını doldurunuz!")]
    [Display(Name = "Fiyat (₺) *")]
    public double EventPrice { get; set; }

    [Display(Name = "Etkinlik Görseli *")]
    public IFormFile? EventImage { get; set; }

    public string? EventImageName { get; set; }

    [Required(ErrorMessage = "Lütfen Tarih alanını doldurunuz!")]
    [Display(Name = "Tarih *")]
    [DataType(DataType.Date)]
    public DateOnly EventDate { get; set; }

    [Required(ErrorMessage = "Lütfen Saat Aralığı alanını doldurunuz!")]
    [Display(Name = "Saat Aralığı *")]
    [StringLength(20)]
    public string EventTime { get; set; } = null!;

    [Required(ErrorMessage = "Lütfen Konum alanını doldurunuz!")]
    [Display(Name = "Konum *")]
    [StringLength(150)]
    public string EventLocation { get; set; } = null!;

    [Required(ErrorMessage = "Lütfen Katılımcı Limiti alanını doldurunuz!")]
    [Display(Name = "Katılımcı Limiti *")]
    public int EventSubscriber { get; set; }

    [Display(Name = "Aktif Mi? ")]
    public bool EventIsActive { get; set; }

    [Display(Name = "Anasayfa'da Görünsün Mü? ")]
    public bool EventIsHome { get; set; }


    // Bağlantı -->

    [Required(ErrorMessage = "Lütfen Kategori alanını doldurunuz!")]
    [Display(Name = "Kategori *")]
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "Lütfen Şehir alanını doldurunuz!")]
    [Display(Name = "Şehir *")]
    public int LocationId { get; set; }
}