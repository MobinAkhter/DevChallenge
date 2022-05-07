using Microsoft.EntityFrameworkCore;

namespace Challenge.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            // 5 plants added with id, name, 
            modelBuilder.Entity<Plant>().HasData(
                new Plant { Id = 1, Name = "Aconite", Sku = "AWMGSJ", Status = "Watered" },
                new Plant { Id = 2, Name = "Borage", Sku = "AWMPS", Status = "Rest" },
                new Plant { Id = 3, Name = "Clover", Sku = "AWMSGT", Status = "Watered" },
                new Plant { Id = 4, Name = "Daisy", Sku = "AWMSJ", Status = "Rest" },
                new Plant { Id = 5, Name = "Epimedium", Sku = "AWMTFJ", Status = "Watered" });
        }
    }
}
