using System;
using CQRSlite.Commands;

namespace MyCqrsEsRedisDemo.Domain.Commands
{
    public class BaseCommand: ICommand
    {
        public Guid Id { get; set; }
        /// <summary>
        /// the expected version which the aggregate will become
        /// </summary>
        public int ExpectedVersion { get; }
    }
}