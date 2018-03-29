using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.Actions
{
    public class DatetimePickerAction : Action
    {
        public string data { get; set; }

        public DateTimePickerMode mode { get; set; }

        public string initial { get; set; }

        public string max { get; set; }

        public string min { get; set; }

        public DatetimePickerAction() {
            this.type = ActionType.Datetimepicker;
        }
    }
}
