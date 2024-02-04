DROP TABLE IF EXISTS ordersRegistry;

CREATE TABLE ordersRegistry (
    id INT PRIMARY KEY AUTO_INCREMENT,
    contractingWorks BOOLEAN,
    executor VARCHAR(50),
    businessClient BOOLEAN,
    countingMethod VARCHAR(100),
    vipClient BOOLEAN,
    CreatedAt TIMESTAMP NOT NULL,
    UpdatedAt TIMESTAMP NULL,
    INDEX (id)
);