using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebTestVersta.Models;

public partial class Recipient
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Не указан город")]
    public string RecCity { get; set; } = null!;

    [Required(ErrorMessage = "Не указан адрес")]
    public string RecAddress { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
