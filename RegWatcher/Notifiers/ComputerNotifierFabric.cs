using RegWatcher.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegWatcher.Notifiers
{
    public class ComputerNotifierFabric : INotifierFabric
    {
        public INotifier CreateEmailConfirmationNotifier()
        {
            return new EmailConfirmationNotifier();
        }
    }
}
