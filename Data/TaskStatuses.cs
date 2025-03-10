using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Task_Manager_Backend.Data
{
    public class TaskStatuses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  // Primary Key
        public string Status_Name { get; set; }

        // 🔹 Foreign Key for One-to-One Relationship
       

    }
}
