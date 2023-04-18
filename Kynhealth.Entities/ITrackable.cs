using System;
using System.Collections.Generic;
using System.Text;

namespace Kynhealth.Entities
{
    public interface ITrackable
    {
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}
