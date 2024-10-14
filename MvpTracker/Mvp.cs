using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MvpTracker
{
    public class Mvp
    {
        public Mvp(int mvpId, string mvpName, string mvpRespawnTime, string mvpKilledTime, Control formButtonControl)
        {
            Id = mvpId;
            Name = mvpName;
            KilledTime = mvpKilledTime;
            RespawnDate = mvpRespawnTime;
            buttonControl = formButtonControl;
        }

        public Mvp() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string KilledTime { get; set; }
        public string RespawnDate { get; set; }
        public Control buttonControl { get; set; }
    }
}
