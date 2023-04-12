IF EXISTS (SELECT * FROM sysobjects WHERE name='bankaccount_operation' and xtype='U')
    DROP TABLE bankaccount_operation
GO
IF EXISTS (SELECT * FROM sysobjects WHERE name='bankaccount' and xtype='U')
    DROP TABLE bankaccount
GO
IF EXISTS (SELECT * FROM sysobjects WHERE name='operation' and xtype='U')
    DROP TABLE operation
GO
IF EXISTS (SELECT * FROM sysobjects WHERE name='client' and xtype='U')
    DROP TABLE client
GO

CREATE TABLE client (
	client_id int PRIMARY KEY IDENTITY(1,1),
	firstname varchar(50) NOT NULL,
	lastname varchar(50) NOT NULL,
	phone varchar(10) NOT NULL
);

CREATE TABLE operation (
	operation_id int PRIMARY KEY IDENTITY(1,1),
	montant decimal NOT NULL DEFAULT 0,
	operation_status varchar(20) NOT NULL,
	date_creation datetime NOT NULL
);

CREATE TABLE bankaccount (
	bankaccount_id int PRIMARY KEY IDENTITY(1,1),
	solde decimal NOT NULL DEFAULT 0,
	client_id int NOT NULL,
	CONSTRAINT fk_client_bankaccount_client_id FOREIGN KEY (client_id) REFERENCES client(client_id)
);

CREATE TABLE bankaccount_operation (
	bankaccount_id int,
	operation_id int,
	CONSTRAINT pk_bankaccount_id_operation_id PRIMARY KEY (bankaccount_id, operation_id),
	CONSTRAINT fk_bankaccount_bankaccount_operation_bankaccount_id FOREIGN KEY (bankaccount_id) REFERENCES bankaccount(bankaccount_id),
	CONSTRAINT fk_operation_bankaccount_operation_operation_id FOREIGN KEY (operation_id) REFERENCES operation(operation_id)
);