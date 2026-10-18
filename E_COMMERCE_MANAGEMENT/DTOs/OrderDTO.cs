using E_COMMERCE_MANAGEMENT.Enums;
using E_COMMERCE_MANAGEMENT.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_COMMERCE_MANAGEMENT.DTOs
{
    public class OrderDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public StatusEnum Status { get; set; } = StatusEnum.Pending;
        [Required]
        public decimal TotalAmount { get; set; }
        public int UserId { get; set; }
        public ICollection<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();
    }

    public class OrderItemDTO
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

    }

    public class CreateOrderDTO
    {
        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public StatusEnum Status { get; set; } = StatusEnum.Pending;

        [Required]
        [Range(0.01, 1000000)]
        public decimal TotalAmount { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public ICollection<OrderItemDTOForCreate> OrderItems { get; set; } = new List<OrderItemDTOForCreate>();
    }

    public class OrderItemDTOForCreate
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Quantity must be between 1 and 1000.")]
        public int Quantity { get; set; }

        [Required]
        [Range(0.01, 1000000)]
        public decimal UnitPrice { get; set; }
    }
    public class TotalAmountDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public StatusEnum Status { get; set; } = StatusEnum.Pending;
        [Required]
        public decimal TotalPrice { get; set; }
    }
    public class UpdateStatusDTO
    {
        [Required]
        public StatusEnum Status { get; set; } = StatusEnum.Pending;
    }
    public class OrderDTOWithTotalRevenue
    {
        [Key]
        public int Id { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
