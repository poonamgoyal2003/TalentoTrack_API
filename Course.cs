using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentoTrack.Common.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string? CourseName { get; set; }
        public float? Fees {  get; set; }
        public string? CourseDuration {  get; set; }   
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public int CreatedById { get; set; }
        public int UpdatedById { get; set; }
    }
}
