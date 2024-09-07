using CleanArchitechture.Application.Messages.Kafka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitechture.Application.Services.Messages.Kafka.Model
{
    public class AddUserMessage : IBaseKafkaMessage
    {
        public DateTime SendDate { get; set; } = DateTime.UtcNow;
        public int UserId { get; set; }
        public string Name { get; set; }
    }
}
