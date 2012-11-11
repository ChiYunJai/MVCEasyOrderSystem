using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcEasyOrderSystem.Models
{
    
    public partial class Order
    {
        public Order()
        {
            this.OrderDetial = new HashSet<OrderDetial>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderId { get; set; }
        public int UserId { get; set; }

        [DisplayName("�q��ɶ�")]
        public System.DateTime OrderDateTime { get; set; }

        [DisplayName("�w�w�ɶ�")]
        public System.DateTime RequireDateTime { get; set; }

        [DisplayName("�����ɶ�")]
        public System.DateTime ReadyDateTime { get; set; }

        
        [DisplayName("���B")]
        [DataType(DataType.Currency)]
        public decimal TotalPrice { get; set; }


        [DisplayName("�Ƶ�")]
        public string Comment { get; set; }

        [DisplayName("�����ɶ�")]
        public Nullable<System.DateTime> CancelDateTime { get; set; }
        [DisplayName("������]")]
        public string Reason { get; set; }



        [DisplayName("�O�_����")]
        public bool IsCanceled { get; set; }


        public int PaymentMethodId { get; set; }
        public int CollectionMethodId { get; set; }
        public int Status { get; set; }

        public virtual CollectionMethod CollectionMethod { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual Status Status1 { get; set; }
        public virtual ICollection<OrderDetial> OrderDetial { get; set; }
    }
}
