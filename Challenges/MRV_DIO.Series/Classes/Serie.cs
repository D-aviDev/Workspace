using System;

namespace MRV_DIO.Series
{
    public class Serie : BaseEntity
    {
        //Attributes
        private Gender Gender {get; set;}
        private string Title {get; set;}
        private string Description {get; set;}
        private int Year {get; set;}
        private bool Deleted {get; set;}

        // Métodos
		public Serie(int id, Gender gender, string title, string description, int year)
		{
			this.Id = id;
			this.Gender = gender;
			this.Title = title;
			this.Description = description;
			this.Year = year;
            this.Deleted = false;
		}

        public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string report = "";
            report += "Gender: " + this.Gender + Environment.NewLine;
            report += "Title: " + this.Title + Environment.NewLine;
            report += "Description: " + this.Description + Environment.NewLine;
            report += "Year of Release: " + this.Year + Environment.NewLine;
            report += "Deleted: " + this.Deleted;
			return report;
		}
        //Métodos de encapsulamento
        public string ReturnTitle() => this.Title;
        public int ReturnId() => this.Id;
        public bool ReturnDeleted() => this.Deleted;
        public void Delete() => this.Deleted = true;
    }
}