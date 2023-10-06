using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentoTrack.Common.Entities
{
    public class Batch
    {
        [Key]
        public int Id { get; set; }
        public string? BatchName { get; set; }
        public int CourseId { get; set; }
        public string? Reference {  get; set; }

        [ForeignKey("CourseId")]  
        public virtual Course? Course { get; set; }



       
        

    }
}
