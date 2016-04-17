create table make
(
makeid int auto_increment primary key,
make_name varchar(30),
description varchar(30) NULL
)

create table model
(
id int AUTO_INCREMENT PRIMARY KEY,
model_name varchar(30) NOT NULL,
make_id int NOT NULL,
FOREIGN KEY (make_id) REFERENCES make(makeid)
)

create table vehicle_category
(
categoryid int auto_increment primary key,
category varchar(30) NOT NULL
)

create table vehicle_for_sale
(
stock_no int PRIMARY KEY,
model_id int not null,
vehicle_category_id int NOT NULL,
price decimal (10,2) NULL,
year int null,
month varchar(15) NULL,
chassis_no_1 varchar(25) NULL,
chassis_no_2 varchar(25) NULL,
grade varchar(25) NULL,
ETD varchar(25) NULL,
color varchar(10) NULL,
KM_ran int NULL,
uel varchar(15) NULL,
gear_at tinyint(1) DEFAULT 0,
CC int null,
no_of_doors int null,
last_modified_date datetime null,
FOREIGN KEY (model_id) REFERENCES model(id),
FOREIGN KEY (vehicle_category_id) REFERENCES vehicle_category(categoryid)
)

create table vehicle_features
(
featureid int auto_increment primary key,
feature_name varchar(30) NOT NULL
)

create table features_on_vehicles_for_sale
(
stock_no int not null,
featureid int not null,
FOREIGN KEY (stock_no) REFERENCES vehicle_for_sale(stock_no),
FOREIGN KEY (featureid) REFERENCES vehicle_features(featureid),
CONSTRAINT pk_feature PRIMARY KEY(stock_no,featureid)
)

create table customers
(
customerid int auto_increment primary key,
email varchar(50) NOT NULL,
password varchar(50) NOT NULL,
mobile int null,
phone int null
)

create table addresses
(
addressid int auto_increment primary key,
customerid int not null,
FOREIGN KEY(customerid) REFERENCES customer(customerid),
address_line_1 varchar(50) NULL,
address_line_2 varchar(50) NULL,
city varchar(30) NULL,
state varchar(30) NULL,
country varchar(50) NULL,
zip_code int null,
description varchar(30) NULL
)

create table vehicle_order
(
orderid int auto_increment primary key,
stock_no int NOT NULL,
FOREIGN KEY (stock_no) REFERENCES vehicle_for_sale(stock_no),
customerid int not null,
FOREIGN KEY(customerid) REFERENCES customer(customerid),
order_date datetime null,
price decimal (10,2) NULL,
ispaid tinyint(1) default 0,
payment_details varchar(50) NULL
)
