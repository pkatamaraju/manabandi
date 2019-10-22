using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace RaiteRaju.Entities
{
    [DataContract]
    public class AdDetailsEntity
    {

        [DataMember]
        public int AdID { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public Int32 intCategoryId { get; set; }
        [DataMember]
        public string txtSubCategoryName { get; set; }
        [DataMember]
        public string AdDescription { get; set; }
        [DataMember]
        public Int32 Price { get; set; }
        [DataMember]
        public Int32 Quantity { get; set; }
        [DataMember]
        public Int32 UserID { get; set; }
        [DataMember]
        public string SellingUnit { get; set; }
        [DataMember]
        public Int64 MobileNumber { get; set; }
         [DataMember]
        public byte[] Image { get; set; }
        [DataMember]
         public string Location { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string PostedDate { get; set; }
    }

}
