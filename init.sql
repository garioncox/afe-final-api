-- DROP SCHEMA "afe-final";

CREATE SCHEMA "afe-final";

-- DROP SEQUENCE "afe-final".budget_id_seq;

CREATE SEQUENCE "afe-final".budget_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE "afe-final".budget_transaction_event_id_seq;

CREATE SEQUENCE "afe-final".budget_transaction_event_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE "afe-final".customer_id_seq;

CREATE SEQUENCE "afe-final".customer_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE "afe-final".transaction_event_id_seq;

CREATE SEQUENCE "afe-final".transaction_event_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;-- "afe-final".customer definition

-- Drop table

-- DROP TABLE "afe-final".customer;

CREATE TABLE "afe-final".customer (
	id serial4 NOT NULL,
	surname text NULL,
	email text NOT NULL,
	CONSTRAINT customer_email_key UNIQUE (email),
	CONSTRAINT customer_pkey PRIMARY KEY (id)
);


-- "afe-final".budget definition

-- Drop table

-- DROP TABLE "afe-final".budget;

CREATE TABLE "afe-final".budget (
	id serial4 NOT NULL,
	budget_name text NOT NULL,
	subcategory_of int4 NULL,
	customer_id int4 NOT NULL,
	CONSTRAINT budget_pkey PRIMARY KEY (id),
	CONSTRAINT budget_customer_id_fkey FOREIGN KEY (customer_id) REFERENCES "afe-final".customer(id),
	CONSTRAINT budget_subcategory_of_fkey FOREIGN KEY (subcategory_of) REFERENCES "afe-final".budget(id)
);


-- "afe-final".transaction_event definition

-- Drop table

-- DROP TABLE "afe-final".transaction_event;

CREATE TABLE "afe-final".transaction_event (
	id serial4 NOT NULL,
	amt numeric(10, 2) NULL,
	transaction_date date NOT NULL,
	transaction_name text NULL,
	customer_id int4 NULL,
	CONSTRAINT transaction_event_pkey PRIMARY KEY (id),
	CONSTRAINT transaction_event_customer_id_fkey FOREIGN KEY (customer_id) REFERENCES "afe-final".customer(id)
);


-- "afe-final".budget_transaction_event definition

-- Drop table

-- DROP TABLE "afe-final".budget_transaction_event;

CREATE TABLE "afe-final".budget_transaction_event (
	id serial4 NOT NULL,
	transaction_event_id int4 NOT NULL,
	budget_id int4 NOT NULL,
	CONSTRAINT budget_transaction_event_pkey PRIMARY KEY (id),
	CONSTRAINT budget_transaction_event_budget_id_fkey FOREIGN KEY (budget_id) REFERENCES "afe-final".budget(id),
	CONSTRAINT budget_transaction_event_transaction_event_id_fkey FOREIGN KEY (transaction_event_id) REFERENCES "afe-final".transaction_event(id)
);