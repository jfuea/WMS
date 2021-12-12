using WMS.Application.Common.Interfaces;
using System;

namespace WMS.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
