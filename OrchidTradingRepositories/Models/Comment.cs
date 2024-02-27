using System;
using System.Collections.Generic;

namespace OrchidTradingRepositories.Models;

public partial class Comment
{
    public Guid CommentId { get; set; }

    public string CommentMessage { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public Guid? UserId { get; set; }

    public Guid? InforId { get; set; }

    public virtual ListInformation? Infor { get; set; }

    public virtual User? User { get; set; }
}
