namespace LoginService.Models
{
        public class CustomErrorResponse
        {
            public string maximumSeverityCode { get; set; }
            public List<CustomErrorItem> eventItems { get; set; }
        }

        public class CustomErrorItem
        {
            public string severityCode { get; set; }
            public string Description { get; set; }
        }
    
}
