using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebTestVersta.Models;

public partial class Sender
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Не указан город")]
    public string SenderCity { get; set; } = null!;

    [Required(ErrorMessage = "Не указан адрес")]
    public string SenderAddress { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
