using RegWatcher.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegWatcher.Interfaces
{
    interface INotifierFabric
    {
        INotifier CreateEmailConfirmationNotifier();
    }
}
