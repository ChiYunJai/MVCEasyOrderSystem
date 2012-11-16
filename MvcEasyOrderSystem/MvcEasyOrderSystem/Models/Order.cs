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
            this.StatusId = 1;
        }

        [DisplayName("�q��s��")]
        public int OrderId { get; set; }
        public string UserId { get; set; }

        [DisplayName("�q��ɶ�")]
        [DataType( System.ComponentModel.DataAnnotations.DataType.DateTime)]
        public System.DateTime OrderDateTime { get; set; }

        [DisplayName("�w�w�ɶ�")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]
        public Nullable<System.DateTime> RequireDateTime { get; set; }

        [DisplayName("�����ɶ�")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]
        public Nullable<System.DateTime> ReadyDateTime { get; set; }

        
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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public bool IsCanceled { get; set; }


        [DisplayName("�I�O�覡")]
        public int PaymentMethodId { get; set; }
        [DisplayName("����覡")]
        public int CollectionMethodId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("�q�檬�p")]
        public int StatusId { get; set; }


        //public Address? Address { get; set; }

        [DisplayName("�e�f�ɶ�")]
        public Nullable<System.DateTime> DeliveryStartTime { get; set; }
        [DisplayName("�e��ɶ�")]
        public Nullable<System.DateTime> DeliveryEndTime { get; set; }

        public string Address_AddCity { get; set; }
        public string Address_AddDistrict { get; set; }

        [DisplayName("�a�}")]
        public string Address_AddFull { get; set; }
        public Nullable<int> Address_PostCode { get; set; }


        [DisplayName("���\�ɶ�")]
        public Nullable<System.DateTime> CollectDateTime { get; set; }

        public virtual CollectionMethod CollectionMethod { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<OrderDetial> OrderDetial { get; set; }
    }
}
