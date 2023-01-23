using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebTestVersta.Models;


public partial class Order
{
    public Order() 
    {
        Rec = new Recipient();
        Sender = new Sender();
    }

    [HiddenInput]
    public int Id { get; set; }

    [HiddenInput]
    public int SenderId { get; set; }

    [HiddenInput]
    public int RecId { get; set; }

    [Required(ErrorMessage = "Не указан вес груза")]
    public string CargoWeight { get; set; } = null!;

    [Required(ErrorMessage = "Не указана дата забора груза")]
    public DateTime PickupDate { get; set; }

    [HiddenInput]
    public string? OrderNum { get; set; }

    public virtual Recipient Rec { get; set; } = null!;

    public virtual Sender Sender { get; set; } = null!;

    public string GenerateOrderNum()
    {
        var dt = DateTime.Now.ToString("ddMMyyyy");
        dt += DateTime.Now.ToString("HHmmss");
        return "O-" + dt;
    }

    public string ReturnDateToDisplay
    {
        get
        {
            return this.PickupDate.ToShortDateString();
        }
    }

}
