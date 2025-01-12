-- DROP SCHEMA "C#DB";

CREATE SCHEMA "C#DB" AUTHORIZATION admin123;

-- DROP SEQUENCE "C#DB"."Task_task_id_seq";

CREATE SEQUENCE "C#DB"."Task_task_id_seq"
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE "C#DB".password_task_password_task_id_seq;

CREATE SEQUENCE "C#DB".password_task_password_task_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE "C#DB".password_task_password_task_id_seq1;

CREATE SEQUENCE "C#DB".password_task_password_task_id_seq1
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE "C#DB".stock_data_fetch_task_stock_task_id_seq;

CREATE SEQUENCE "C#DB".stock_data_fetch_task_stock_task_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE "C#DB".user_password_user_password_id_seq;

CREATE SEQUENCE "C#DB".user_password_user_password_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE "C#DB".user_password_user_password_id_seq1;

CREATE SEQUENCE "C#DB".user_password_user_password_id_seq1
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE "C#DB".user_stock_user_stock_id_seq;

CREATE SEQUENCE "C#DB".user_stock_user_stock_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE "C#DB".user_stock_user_stock_id_seq1;

CREATE SEQUENCE "C#DB".user_stock_user_stock_id_seq1
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE "C#DB".users_userid_seq;

CREATE SEQUENCE "C#DB".users_userid_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE "C#DB".users_userid_seq1;

CREATE SEQUENCE "C#DB".users_userid_seq1
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;-- "C#DB"."Job" definition

-- Drop table

-- DROP TABLE "C#DB"."Job";

CREATE TABLE "C#DB"."Job" (
	"Job_id" int4 DEFAULT nextval('"C#DB"."Task_task_id_seq"'::regclass) NOT NULL,
	"name" varchar(255) NOT NULL,
	description text NULL,
	schedule_interval interval NULL,
	CONSTRAINT "Task_pkey" PRIMARY KEY ("Job_id")
);


-- "C#DB".users definition

-- Drop table

-- DROP TABLE "C#DB".users;

CREATE TABLE "C#DB".users (
	userid serial4 NOT NULL,
	"name" varchar(100) NOT NULL,
	email varchar(100) NOT NULL,
	"password" varchar(255) NOT NULL,
	"role" varchar(20) NOT NULL,
	created_at timestamp DEFAULT CURRENT_TIMESTAMP NULL,
	updated_at timestamp DEFAULT CURRENT_TIMESTAMP NULL,
	CONSTRAINT users_email_key UNIQUE (email),
	CONSTRAINT users_pkey PRIMARY KEY (userid)
);


-- "C#DB"."Stock_Data" definition

-- Drop table

-- DROP TABLE "C#DB"."Stock_Data";

CREATE TABLE "C#DB"."Stock_Data" (
	stock_id int4 DEFAULT nextval('"C#DB".stock_data_fetch_task_stock_task_id_seq'::regclass) NOT NULL,
	"Job_id" int4 NOT NULL,
	stock_symbol varchar(20) NOT NULL,
	data_type varchar(50) NOT NULL,
	fetch_interval interval NOT NULL,
	last_fetched timestamp NULL,
	"RegularMarketPrice" numeric(18, 2) NULL,
	"FiftyTwoWeekHigh" numeric(18, 2) NULL,
	"FiftyTwoWeekLow" numeric(18, 2) NULL,
	CONSTRAINT stock_data_fetch_task_pkey PRIMARY KEY (stock_id),
	CONSTRAINT stock_data_job_fk FOREIGN KEY ("Job_id") REFERENCES "C#DB"."Job"("Job_id")
);


-- "C#DB".password_task definition

-- Drop table

-- DROP TABLE "C#DB".password_task;

CREATE TABLE "C#DB".password_task (
	password_task_id serial4 NOT NULL,
	"Job_id" int4 NOT NULL,
	reminder_interval interval NOT NULL,
	default_message text NULL,
	created_at timestamp DEFAULT now() NULL,
	CONSTRAINT password_task_pkey PRIMARY KEY (password_task_id),
	CONSTRAINT password_task_job_fk FOREIGN KEY ("Job_id") REFERENCES "C#DB"."Job"("Job_id")
);


-- "C#DB".user_password definition

-- Drop table

-- DROP TABLE "C#DB".user_password;

CREATE TABLE "C#DB".user_password (
	user_password_id serial4 NOT NULL,
	user_id int4 NOT NULL,
	password_id int4 NOT NULL,
	CONSTRAINT user_password_pkey PRIMARY KEY (user_password_id),
	CONSTRAINT user_password_password_id_fkey FOREIGN KEY (password_id) REFERENCES "C#DB".password_task(password_task_id),
	CONSTRAINT user_password_user_id_fkey FOREIGN KEY (user_id) REFERENCES "C#DB".users(userid)
);


-- "C#DB".user_stock definition

-- Drop table

-- DROP TABLE "C#DB".user_stock;

CREATE TABLE "C#DB".user_stock (
	user_stock_id serial4 NOT NULL,
	user_id int4 NOT NULL,
	stock_id int4 NOT NULL,
	CONSTRAINT user_stock_pkey PRIMARY KEY (user_stock_id),
	CONSTRAINT user_stock_stock_id_fkey FOREIGN KEY (stock_id) REFERENCES "C#DB"."Stock_Data"(stock_id),
	CONSTRAINT user_stock_user_id_fkey FOREIGN KEY (user_id) REFERENCES "C#DB".users(userid)
);