using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patika_BookStore_Proje.Entities
{
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string DogumTarihi { get; set; }
    }
}