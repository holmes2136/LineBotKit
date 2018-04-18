using System;
using System.Collections.Generic;
using System.Text;

namespace LinetBotKit.Common.Model.Actions
{
    public class DatetimePickerAction : Action
    {
        public string data { get; set; }

        public DateTimePickerMode mode { get; set; }

        public string initial { get; set; }

        public string max { get; set; }

        public string min { get; set; }

        public DatetimePickerAction()
        {
            this.type = ActionType.Datetimepicker;
        }
    }
}
