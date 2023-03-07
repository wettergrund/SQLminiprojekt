namespace SQLminiprojekt.Models
{
    internal class ReportModel
    {
        public int Id { get; set; }
        public int Project_Id { get; set; }
        public int Person_Id { get; set; }
        public string person_name { get; set; }
        public string project_name { get; set; }
        public int hours { get; set;}
    }
}
