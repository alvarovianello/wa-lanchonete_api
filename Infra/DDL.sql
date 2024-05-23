CREATE TABLE dbo.Customer (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100),
    email VARCHAR(100) UNIQUE,
    cpf VARCHAR(11) UNIQUE
);


CREATE TABLE dbo.Category (
    id SERIAL PRIMARY KEY,
    name VARCHAR(50) UNIQUE,
    description TEXT
);

CREATE TABLE dbo.Product (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100),
    description TEXT,
    price NUMERIC(10, 2),
    category_id INT REFERENCES dbo.Category(id),
    image VARCHAR(400)
);

CREATE TABLE dbo.Orders (
    id SERIAL PRIMARY KEY,
    customer_id INT REFERENCES dbo.Customer(id),
    order_number VARCHAR(50),
    total_price NUMERIC(10, 2),
    status VARCHAR(50),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE dbo.OrderItem (
    id SERIAL PRIMARY KEY,
    order_id INT REFERENCES dbo.Orders(id),
    product_id INT REFERENCES dbo.Product(id),
    quantity INT,
    price NUMERIC(10, 2)
);

CREATE TABLE dbo.OrderStatus (
    id SERIAL PRIMARY KEY,
    order_id INT REFERENCES dbo.Orders(id),
    status VARCHAR(50),
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE dbo.Payment (
    id SERIAL PRIMARY KEY,
    order_id INT REFERENCES dbo.Orders(id),
    payment_method VARCHAR(50),
    payment_status VARCHAR(50),
    payment_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO dbo.Category (name, description) VALUES
('Lanche', 'Sanduíches e hambúrgueres variados'),
('Acompanhamento', 'Batatas fritas, saladas e outros acompanhamentos'),
('Bebida', 'Refrigerantes, sucos e outras bebidas'),
('Sobremesa', 'Sobremesas diversas');

INSERT INTO dbo.Product (name, description, price, category_id) VALUES
('Cheeseburger', 'Hambúrguer com queijo', 10.00, 1),
('Batata Frita', 'Porção de batatas fritas', 5.00, 2),
('Refrigerante', 'Coca-Cola 350ml', 3.00, 3),
('Sorvete', 'Casquinha de sorvete', 4.00, 4);