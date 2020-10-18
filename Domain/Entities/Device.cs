using System;
using System.Collections.Generic;

namespace DeviceManagementPortal.Domain.Entities
{
    public partial class Device
    {
        public Device()
        {
            DeviceBackend = new HashSet<DeviceBackend>();
        }

        public int Id { get; set; }
        public string Imei { get; set; }
        public decimal SimCardNumber { get; set; }
        public bool Enabled { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }

        public virtual ICollection<DeviceBackend> DeviceBackend { get; set; }
    }
}
