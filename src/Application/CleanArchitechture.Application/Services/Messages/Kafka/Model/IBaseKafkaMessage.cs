using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitechture.Application.Messages.Kafka.Model
{
    public interface IBaseKafkaMessage
    {
        DateTime SendDate { get; set; }
    }
}
