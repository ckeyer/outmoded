create table tb_class
(
	int_class_id int not null primary key,
	chr_class_name varchar(20) 	CHARACTER SET utf8 COLLATE utf8_bin,
	int_academy_id int,
	chr_academy_name varchar(20) CHARACTER SET utf8 COLLATE utf8_bin
)
