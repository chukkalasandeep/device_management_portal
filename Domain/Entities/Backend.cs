using System;
using System.Collections.Generic;

namespace DeviceManagementPortal.Domain.Entities
{
    public partial class Backend
    {
        public Backend()
        {
            DeviceBackend = new HashSet<DeviceBackend>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<DeviceBackend> DeviceBackend { get; set; }
    }
}
