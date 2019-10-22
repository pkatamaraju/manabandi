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
    public class DetailsEntity
    {
        [DataMember]
        public UserDetailsEntity UserDetails { get; set; }
        [DataMember]
        public List<AdDetailsEntity> AdDetails { get; set; }
    }
}
