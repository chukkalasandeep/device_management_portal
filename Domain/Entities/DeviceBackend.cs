using System;
using System.Collections.Generic;

namespace DeviceManagementPortal.Domain.Entities
{
    public partial class DeviceBackend
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public int BackendId { get; set; }
        public DateTime MappedDateTime { get; set; }

        public virtual Backend Backend { get; set; }
        public virtual Device Device { get; set; }
    }
}
