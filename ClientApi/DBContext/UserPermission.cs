using System;
using System.Collections.Generic;

namespace ClientApi.DBContext;

public partial class UserPermission
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public bool CanAddProduct { get; set; }

    public bool CanEditProduct { get; set; }

    public bool CanViewProduct { get; set; }

    public bool CanDeleteProduct { get; set; }

    public bool CanAddOrder { get; set; }

    public bool CanEditOrder { get; set; }

    public bool CanViewOrder { get; set; }

    public bool CanDeleteOrder { get; set; }

    public bool CanAddUser { get; set; }

    public bool CanEditUser { get; set; }

    public bool CanViewUser { get; set; }

    public bool CanDeleteUser { get; set; }

    public bool Deleted { get; set; }

    public DateTimeOffset CreatedDate { get; set; }

    public DateTimeOffset ModifiedDate { get; set; }

    public DateTimeOffset? DeletedDate { get; set; }

    public int? DeletedBy { get; set; }

    public int? CreatedBy { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? DeletedByNavigation { get; set; }

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
