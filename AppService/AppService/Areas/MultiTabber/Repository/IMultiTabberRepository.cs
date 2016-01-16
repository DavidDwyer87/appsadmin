using AppService.Areas.MultiTabber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppService.Areas.MultiTabber.Repository
{
    public interface IMultiTabberRepository
    {
        IEnumerable<EData> getErrData(string from, string to);
        IEnumerable<MData> getUserData(string from, string to, int activityCount);
    }
}
