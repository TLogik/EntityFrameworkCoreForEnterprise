using System;
using Store.Core.EntityLayer.Production;

namespace Store.Core.EntityLayer.Sales
{
    public class OrderDetail : IAuditableEntity
    {
        public OrderDetail()
        {
        }

        public OrderDetail(Int32? orderDetailID)
        {
            OrderDetailID = orderDetailID;
        }

        public Int64? OrderDetailID { get; set; }

        public Int64? OrderID { get; set; }

        public Int32? ProductID { get; set; }

        public String ProductName { get; set; }

        public Decimal? UnitPrice { get; set; }

        public Int32? Quantity { get; set; }

        public Decimal? Total { get; set; }

        public String CreationUser { get; set; }

        public DateTime? CreationDateTime { get; set; }

        public String LastUpdateUser { get; set; }

        public DateTime? LastUpdateDateTime { get; set; }

        public Byte[] Timestamp { get; set; }

        public virtual Order OrderFk { get; set; }

        public virtual Product ProductFk { get; set; }
    }
}
