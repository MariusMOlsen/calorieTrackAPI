using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CalorieTrack.Model.Interfaces;

namespace CalorieTrack.Model
{
    public class Diary: INutritionObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]  
        public Guid Guid { get; set; }
        public DateTime Date { get; set; }
        public double Weight { get; set; }
        public Guid NutritionGuid { get; set; }

        public Guid userGuid { get; set; }
        public int Sections { get; set; }
        public Diary() { }
        public Diary( Guid userGuid)
        {
            this.Guid = Guid.NewGuid();
            this.Date = new DateTime();
            this.Weight = 0;
            this.userGuid = userGuid;
            this.Sections = 4;
            
        }
        public Diary(Guid userGuid, DateTime date)
        {
            this.Guid = Guid.NewGuid();
            this.Date = date;
            this.Weight = 0;
            this.userGuid = userGuid;
            this.Sections = 4;

        }
        public int GetCalories()
        {
            throw new NotImplementedException();
        }

        public int GetCarbohydrates()
        {
            throw new NotImplementedException();
        }

        public int GetFat()
        {
            throw new NotImplementedException();
        }

        public int GetProtein()
        {
            throw new NotImplementedException();
        }
    }
}
