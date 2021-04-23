using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebJobNews.Models
{
    [Table("ELMUNDONEWS")]
    public class NewsBdd
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("TITLE")]
        public String Title { get; set; }

        [Column("DESCRIPTION")]
        public String Description { get; set; }

        [Column("LINK")]
        public String Link { get; set; }

        [Column("DATE")]
        public DateTime Date { get; set; }
    }
}
