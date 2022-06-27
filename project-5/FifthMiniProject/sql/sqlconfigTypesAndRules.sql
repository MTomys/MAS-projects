-- Phone number custom rule
CREATE RULE phone_number_rule
AS
@value LIKE '[0-9][0-9][0-9]-[0-9][0-9][0-9]-[0-9][0-9][0-9]';

-- Pesel custom rule
CREATE RULE pesel_rule
AS
@value LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]';

-- Email custom rule
CREATE RULE email_rule
AS
@value LIKE '%_@_%_.__%';

CREATE RULE creditcardnumber_rule
AS
@value LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'

CREATE RULE cvc_number_rule
AS
@value LIKE '[0-9][0-9][0-9]';

CREATE RULE quantity_rule
AS
@range >= $1;


-- Phone Number custom data type
CREATE TYPE PHONENUMBER
FROM NVARCHAR(12) NOT NULL; 

-- Pesel custom data type
CREATE TYPE PESEL 
FROM VARCHAR(11) NOT NULL;

CREATE TYPE EMAIL
FROM NVARCHAR(100) NOT NULL;

CREATE TYPE CREDIT_CARD_NUMBER
FROM NVARCHAR(16) NOT NULL;

CREATE TYPE CVC_CARD_NUMBER
FROM NVARCHAR(3) NOT NULL;

CREATE TYPE QUANTITY
FROM BIGINT;

sp_bindrule pesel_rule, 'PESEL';
sp_bindrule phone_number_rule, 'PHONENUMBER';
sp_bindrule email_rule, 'EMAIL';
sp_bindrule creditcardnumber_rule, 'CREDIT_CARD_NUMBER';
sp_bindrule cvc_number_rule, 'CVC_CARD_NUMBER';
sp_bindrule quantity_rule, 'QUANTITY';
