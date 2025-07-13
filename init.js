// Sample orders data
var sampleOrders = [
    {
        "id": "550e8400-e29b-41d4-a716-446655440001",
        "UserId": "123e4567-e89b-12d3-a456-426614174001",
        "OrderDate": new Date("2024-01-15T10:30:00Z"),
        "TotalBill": 299.97,
        "Items": [
            {
                "_id": 1,
                "ProductId": "789e0123-e89b-12d3-a456-426614174001",
                "UnitPrice": 99.99,
                "Quantity": 2,
                "TotalPrice": 199.98
            },
            {
                "_id": 2,
                "ProductId": "456e7890-e89b-12d3-a456-426614174002",
                "UnitPrice": 99.99,
                "Quantity": 1,
                "TotalPrice": 99.99
            }
        ]
    },
    {
        "id": "550e8400-e29b-41d4-a716-446655440002",
        "UserId": "123e4567-e89b-12d3-a456-426614174002",
        "OrderDate": new Date("2024-01-16T14:45:00Z"),
        "TotalBill": 149.95,
        "Items": [
            {
                "_id": 1,
                "ProductId": "789e0123-e89b-12d3-a456-426614174003",
                "UnitPrice": 29.99,
                "Quantity": 5,
                "TotalPrice": 149.95
            }
        ]
    },
    {
        "id": "550e8400-e29b-41d4-a716-446655440003",
        "UserId": "123e4567-e89b-12d3-a456-426614174003",
        "OrderDate": new Date("2024-01-17T09:15:00Z"),
        "TotalBill": 599.96,
        "Items": [
            {
                "_id": 1,
                "ProductId": "789e0123-e89b-12d3-a456-426614174004",
                "UnitPrice": 199.99,
                "Quantity": 2,
                "TotalPrice": 399.98
            },
            {
                "_id": 2,
                "ProductId": "456e7890-e89b-12d3-a456-426614174005",
                "UnitPrice": 99.99,
                "Quantity": 2,
                "TotalPrice": 199.98
            }
        ]
    },
    {
        "id": "550e8400-e29b-41d4-a716-446655440004",
        "UserId": "123e4567-e89b-12d3-a456-426614174001",
        "OrderDate": new Date("2024-01-18T16:20:00Z"),
        "TotalBill": 79.98,
        "Items": [
            {
                "_id": 1,
                "ProductId": "789e0123-e89b-12d3-a456-426614174006",
                "UnitPrice": 39.99,
                "Quantity": 2,
                "TotalPrice": 79.98
            }
        ]
    },
    {
        "id": "550e8400-e29b-41d4-a716-446655440005",
        "UserId": "123e4567-e89b-12d3-a456-426614174004",
        "OrderDate": new Date("2024-01-19T11:30:00Z"),
        "TotalBill": 449.94,
        "Items": [
            {
                "_id": 1,
                "ProductId": "789e0123-e89b-12d3-a456-426614174007",
                "UnitPrice": 149.98,
                "Quantity": 3,
                "TotalPrice": 449.94
            }
        ]
    }
];

// Insert sample orders
db.getSiblingDB("OrdersDatabase").orders.insertMany(sampleOrders);