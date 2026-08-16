CREATE TABLE IF NOT EXISTS customers (
    `id` char(36) NOT NULL COMMENT 'Customer identifier',
    `name` varchar(100) NOT NULL COMMENT 'Customer name',
    `lastName` varchar(150) NOT NULL COMMENT 'Customer last name',
    `cpf` varchar(11) NOT NULL COMMENT 'Customer CPF',
    `birthDate` datetime NOT NULL COMMENT 'Customer date of birth',
    `active` bit(1) NOT NULL DEFAULT 0 COMMENT 'Customer active status',
    `createdAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'Record creation date',
    `updatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Record update date',
    PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;