using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.TemplateActions
{
    public class DatetimePickerTemplateAction : TemplateAction
    {
        public string data { get; set; }

        public DateTimePickerMode mode { get; set; }

        public string initial { get; set; }

        public string max { get; set; }

        public string min { get; set; }

        public DatetimePickerTemplateAction() {
            this.type = TemplateActionType.Datetimepicker;
        }
    }
}
