using Lesson2_MWC.Entities;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson2_MWC.TagHelpers
{
    [HtmlTargetElement("employee-list")]
    public class EmployeeListTagHelper : TagHelper
    {
        public List<Employee> _employees { get; set; }
        public EmployeeListTagHelper()
        {
            _employees = new List<Employee>()
            {
                new Employee
                {
                Id = 1,
                Cityİd=1,
                Lastname="Qasimov",
                Firstname="Vaqif"
                },
              new Employee
              {
                Id = 2,
                Cityİd=2,
                Lastname="Huseynli",
                Firstname="Ahmad"
                },
              new Employee
              {
                Id = 3,
                Cityİd=3,
                Lastname="Amirli",
                Firstname="Mirtalib"
                }
           };
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "section";
            var query = ListCount != 0 ? _employees.Take(ListCount).ToList() : _employees;
            StringBuilder sb = new StringBuilder();
            foreach (var item in query)
                sb.AppendFormat("<h2><a href='employee/detail/{0}'>{1}</a><h2>", item.Id, item.Firstname);
            output.Content.SetHtmlContent(sb.ToString());
        }

        private const string ListCountAttribute = "count";
        [HtmlAttributeName(ListCountAttribute)]
        public int ListCount { get; set; }
    }
}