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
    public class UserDetailsEntity
    {
        [DataMember]
        public int intUserId { get; set; }

        [DataMember]
        public string KeyForUserSettings { get; set; }

        [DataMember]
        public string txtName { get; set; }

        [DataMember]
        public Int64 BigIntPhoneNumber { get; set; }

        [DataMember]
        public string txtState { get; set; }

        [DataMember]
        public string txtDistrict { get; set; }

        [DataMember]
        public string txtMandal { get; set; }

        [DataMember]
        public string txtvillage { get; set; }

        [DataMember]
        public string txtMailId { get; set; }

        [DataMember]
        public string txtPassword { get; set; }

        [DataMember]
        public string OTP { get; set; }

        [DataMember]
        public int bitVerifiedPhoneNumber { get; set; }

        [DataMember]
        public int FlgAccountDeleted { get; set; }

        [DataMember]
        public string UserType { get; set; }

        public string Role { get; set; }


    }
}
