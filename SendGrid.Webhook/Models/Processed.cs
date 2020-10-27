using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SendGrid.Webhook.Models
{
    public class Processed
    {
        public string OriginalJson { get; set; }
        public int CorrespondenceId { get; set; }

    }
}
